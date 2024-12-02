using MazeGenerator;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Maze
{
    public partial class Admin : Form
    {
        private protected enum EStepForm : sbyte
        {
            NOTCREATETEMPLATE = 1,
            CREATEDTEMPLATE,
            BEGINSETPOINTS,
            SETPOINTENTRY,
            ENDSETPOINTS,
            GENERATEDMAZE,
            EXPORTEDMAZE

        }
        /*        private StepForm stepForm = StepForm.NOTCREATETEMPLATE;*/
        private bool[,] FillWallsArray;
        private Point? startPoint = null;
        private Point? endPoint = null;
        private uint gridWidth;
        private uint gridHeight;
        private bool buttonAutoExit = false;

        private EStepForm _stepForm = EStepForm.NOTCREATETEMPLATE;

        private protected EStepForm StepForm
        {
            get { return _stepForm; }
            set
            {
                _stepForm = value;
                StepFormPropertyChanged();
            }
        }
        private void StepFormPropertyChanged()
        {
            switch (StepForm)
            {
                case EStepForm.NOTCREATETEMPLATE:

                    pictureMaze.Image = null;
                    pictureMaze.BackColor = Color.White;
                    pictureMaze.Invalidate();
                    FillWallsArray = null;
                    startPoint = null;
                    endPoint = null;
                    gridWidth = default;
                    gridHeight = default;

                    widthUpDown.Value = 15;
                    heightUpDown.Value = 15;


                    Generate.Visible = false; 


                    break;
                case EStepForm.CREATEDTEMPLATE:
                    if (buttonAutoExit)
                        Generate.Visible = true;
                    else
                        Generate.Visible = false;
                    startPoint = null;
                    endPoint = null;
                    FillWallsArray = null;
                    gridWidth = (uint)widthUpDown.Value;
                    gridHeight = (uint)heightUpDown.Value;
                    DrawMaze();
                    break;
                case EStepForm.BEGINSETPOINTS:
                    Generate.Visible = false;
                     
                    break;
                case EStepForm.SETPOINTENTRY:
                    Generate.Visible = false; 
                    break;
                case EStepForm.ENDSETPOINTS:
                    Generate.Visible = true; 
                    break;
                case EStepForm.GENERATEDMAZE:
                    if (buttonAutoExit)
                    {
                        (startPoint, endPoint) = RandomStartEndPoints(FillWallsArray);
                        DrawMaze();
                    }


                    break;
                case EStepForm.EXPORTEDMAZE:
                    StepForm = EStepForm.NOTCREATETEMPLATE;
                    break;

            }
        }
        public Admin()
        {
            InitializeComponent();

        }

        private void createPattern_Click(object sender, EventArgs e)
        {
            settingMazePanel.Visible = true;
            DrawMaze();
            StepForm = EStepForm.CREATEDTEMPLATE;
        }
        private bool[,] List2DToArray(List<List<bool>> listBoolean)
        {


            int rows = listBoolean.Count;
            int cols = listBoolean[0].Count;

            bool[,] array2D = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array2D[i, j] = listBoolean[i][j];
                }
            }
            return array2D;
        }
        private void Generate_Click(object sender, EventArgs e)
        {

            if (radioButtonEuler.Checked)
            {
                bool[,] maze = List2DToArray(MazeGeneratorEuler.GenerateMaze(gridWidth / 2, gridHeight / 2));
                DrawMaze(maze);
            }
            else if (radioButtonAldousBroder.Checked)
            {
                bool[,] maze = List2DToArray(new MazeGeneratorAldousBroder().Generate((int)gridWidth, (int)gridHeight));
                DrawMaze(maze);

            }

            StepForm = EStepForm.GENERATEDMAZE;

        }
        private Tuple<Point, Point> RandomStartEndPoints(bool[,] maze)
        {

            int randomRowStart, randomRowEnd;
            Point startPoint, endPoint;
            do
            {
                Random random = new Random();
                randomRowStart = random.Next(0, maze.GetLength(0));
                startPoint = new Point(randomRowStart, 0);

                randomRowEnd = random.Next(0, maze.GetLength(0));
                endPoint = new Point(randomRowEnd, (int)gridWidth - 1);

            } while (randomRowStart <= 0 ||
                    randomRowStart >= gridWidth - 1 ||
                    randomRowEnd <= 0 ||
                    randomRowEnd >= gridWidth - 1 ||
                    maze[randomRowStart, 1] == true ||
                    maze[randomRowEnd, (int)gridWidth - 2] == true);

            return new Tuple<Point, Point>(startPoint, endPoint);
        }
        private void DrawMaze(bool[,] mazeMatrix = null)
        {
            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;

            Pen wallPen = new Pen(Color.Black);
            SolidBrush cellBrush = new SolidBrush(Color.White);
            SolidBrush wallBrush = new SolidBrush(Color.Black);
            SolidBrush startPointBrush = new SolidBrush(Color.GreenYellow);
            SolidBrush endPointBrush = new SolidBrush(Color.Red);

            FillWallsArray = mazeMatrix is null ? FillWallsArray is null ? null : FillWallsArray : mazeMatrix;
            if (pictureMaze.Image == null || pictureMaze.Image.Width != pictureMaze.Width || pictureMaze.Image.Height != pictureMaze.Height)
            {
                if (pictureMaze.Image != null)
                {
                    pictureMaze.Image.Dispose();
                }
                pictureMaze.Image = new Bitmap(pictureMaze.Width, pictureMaze.Height);
            }
            using (Graphics g = Graphics.FromImage(pictureMaze.Image))
            {

                g.Clear(Color.White);
                for (int row = 0; row < gridHeight; row++)
                {
                    for (int col = 0; col < gridWidth; col++)
                    {
                        int x = (int)(col * cellWidth);
                        int y = (int)(row * cellHeight);

                        int nextX = (int)((col + 1) * cellWidth);
                        int nextY = (int)((row + 1) * cellHeight);


                        g.FillRectangle(cellBrush, x, y, cellWidth, cellHeight);
                        g.DrawRectangle(wallPen, x, y, nextX - x, nextY - y);

                        if (FillWallsArray != null && FillWallsArray[row, col] == true)
                            g.FillRectangle(wallBrush, x, y, cellWidth, cellHeight);



                    }
                }

                if (startPoint != null)
                {
                    int x = (int)(startPoint?.Y * cellWidth);
                    int y = (int)(startPoint?.X * cellHeight);
                    g.FillRectangle(startPointBrush, x, y, cellWidth, cellHeight);
                }

                if (endPoint != null)
                {
                    int x = (int)(endPoint?.Y * cellWidth);
                    int y = (int)(endPoint?.X * cellHeight);
                    g.FillRectangle(endPointBrush, x, y, cellWidth, cellHeight);
                }


            }
            pictureMaze.Invalidate();

        }
        private void AdminAboutUs_Click(object sender, EventArgs e)
        {
            Form customMessageBox = new Form();
            customMessageBox.Size = new Size(825, 350);
            customMessageBox.Text = "Справочная информация о разработчиках";

            Label label = new Label();
            label.Text = "Самарский университет\nКафедра программных систем\n\nКурсовой проект по дисциплине 'Программная инженерия'\n\nТема проекта:\n«Автоматизированная система генерирования структуры лабиринта и нахождения выхода из него»\n\nРаботу выполнили обучающиеся группы 6402-020302D:\n Балашова Екатерина\n Гриднева Виктория\n\nНаучный руководитель:\nЗеленко Лариса Сергеевна, доцент кафедры ПС\n\n\nСамара 2024";
            label.AutoSize = true;
            label.Font = new Font("Times New Roman", 11, FontStyle.Bold); // Настройки шрифта
            label.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста по центру
            label.Dock = DockStyle.Fill; // Занимает всю доступную площадь
            customMessageBox.Controls.Add(label);

            customMessageBox.ShowDialog();
        }

        private void AdminAboutSys_Click(object sender, EventArgs e)
        {
            string htmlFilePath = $@"{Environment.CurrentDirectory}\admin.html";

            if (File.Exists(htmlFilePath))
            {
                System.Diagnostics.Process.Start(htmlFilePath);
            }
            else
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveMatrixToXml(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Matrix");

                for (int i = 0; i < FillWallsArray.GetLength(0); i++)
                {
                    writer.WriteStartElement("Row");

                    for (int j = 0; j < FillWallsArray.GetLength(1); j++)
                    {
                        writer.WriteElementString("Cell", FillWallsArray[i, j].ToString());
                    }

                    writer.WriteEndElement();
                }
                if (startPoint != null)
                {
                    writer.WriteElementString("StartPoint", $"{startPoint?.X}:{startPoint?.Y}");
                }
                if (endPoint != null)
                {
                    writer.WriteElementString("EndPoint", $"{endPoint?.X}:{endPoint?.Y}");
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                MessageBox.Show("Лабиринт успешно сохранён в файл!");
            }
            return true;
        }
        private void saveToFile_Click(object sender, EventArgs e)
        {
            switch (StepForm)
            {
                case EStepForm.NOTCREATETEMPLATE:
                    MessageBox.Show("Создайте шаблон!");
                    break;
                case EStepForm.CREATEDTEMPLATE:
                    MessageBox.Show("Расставьте точки входа и выхода!");
                    break;
                case EStepForm.GENERATEDMAZE:
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "XML файлы (*.xml)|*.xml";
                    saveFileDialog.InitialDirectory = KnownFolders.Downloads.Path;
                    if (FillWallsArray is null || FillWallsArray?.Length == 0)
                    {
                        MessageBox.Show("Генерация лабиринта не выполнена!");
                        break;
                    }

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveMatrixToXml(saveFileDialog.FileName);
                        StepForm = EStepForm.EXPORTEDMAZE;
                    }
                    break;
            }



        }

         

        private void pictureMaze_Click(object sender, EventArgs e)
        {
            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;
            MouseEventArgs me = (MouseEventArgs)e;
            int cellRowIndex = Convert.ToInt32(Math.Floor(me.Y / cellHeight));
            int cellColumnIndex = Convert.ToInt32(Math.Floor(me.X / cellWidth));

            switch (StepForm)
            {
                case EStepForm.BEGINSETPOINTS:

                    if (cellRowIndex > 0 && cellRowIndex < gridHeight - 1 && cellColumnIndex == 0)
                    {
                        startPoint = new Point(cellRowIndex, cellColumnIndex);
                        DrawMaze(FillWallsArray);
                        StepForm = EStepForm.SETPOINTENTRY;
                        MessageBox.Show("Входная точка установлена.");
                    }
                    else
                    {
                        MessageBox.Show("Нужна точка по левому боковому периметру без угла.");
                    }

                    break;
                case EStepForm.SETPOINTENTRY:
                    if (cellRowIndex > 0 && cellRowIndex < gridHeight - 1 && cellColumnIndex == gridWidth - 1)
                    {
                        endPoint = new Point(cellRowIndex, cellColumnIndex);
                        DrawMaze(FillWallsArray);
                        StepForm = EStepForm.ENDSETPOINTS;

                        MessageBox.Show("Выходная точка установлена.");
                    }
                    else
                    {
                        MessageBox.Show("Нужна точка по правому боковому периметру без угла.");
                    }

                    break;
                case EStepForm.ENDSETPOINTS:
                    MessageBox.Show("Точки входа и выхода расставлены!");
                    break;

            }


        }


        private void handed_Click(object sender, EventArgs e)
        {
            buttonAutoExit = false;

            if (gridWidth > 0 && gridHeight > 0)
                StepForm = EStepForm.CREATEDTEMPLATE;
            else
                StepForm = EStepForm.NOTCREATETEMPLATE;
            startPoint = null;
            endPoint = null;
            DrawMaze();

            MessageBox.Show("Установите точку входа и выхода по боковому периметру лабиринта.");
            StepForm = EStepForm.BEGINSETPOINTS;
        }

        private void nonhanded_Click(object sender, EventArgs e)
        {
            buttonAutoExit = true;

            if (gridWidth > 0 && gridHeight > 0)
                StepForm = EStepForm.CREATEDTEMPLATE;
            else
                StepForm = EStepForm.NOTCREATETEMPLATE;
            startPoint = null;
            endPoint = null;
            DrawMaze();
        }

        private void ModeRadioButtons_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonTheme1_Click(object sender, EventArgs e)
        {

        }
    }
}
