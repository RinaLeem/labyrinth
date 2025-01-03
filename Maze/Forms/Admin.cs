﻿using MazeGenerator;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        SolidBrush wallBrush = new SolidBrush(Color.Orange);
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
        //private void DrawMaze(bool[,] mazeMatrix = null)
        //{
        //    float cellWidth = (float)Math.Floor((double)pictureMaze.Width / gridWidth);
        //    float cellHeight = (float)Math.Floor((double)pictureMaze.Height / gridHeight);

        //    Pen wallPen = new Pen(Color.Black);
        //    SolidBrush cellBrush = new SolidBrush(Color.White);
        //    //SolidBrush wallBrush = new SolidBrush(Color.Orange);
        //    SolidBrush startPointBrush = new SolidBrush(Color.GreenYellow);
        //    SolidBrush endPointBrush = new SolidBrush(Color.Red);

        //    ////
        //    int fontSize = (int)cellWidth - (int)(cellWidth / 3); // Размер символов

        //    // Создаем кисть и шрифт для снежинки
        //    Font snowflakeFont = new Font("Arial", fontSize);
        //    SolidBrush snowflakeBrush = new SolidBrush(Color.Blue); // Цвет 

        //    // Создаем кисть и шрифт для цветочка
        //    Font springFont = new Font("Arial", fontSize);
        //    SolidBrush springBrush = new SolidBrush(Color.Red); // Цвет 

        //    // Создаем кисть и шрифт для солнца
        //    Font summerFont = new Font("Arial", fontSize);
        //    SolidBrush summerBrush = new SolidBrush(Color.GreenYellow); // Цвет 

        //    // Создаем кисть и шрифт для карандаша
        //    Font auFont = new Font("Arial", fontSize);
        //    SolidBrush auBrush = new SolidBrush(Color.Yellow); // Цвет 
        //    //





        //    FillWallsArray = mazeMatrix is null ? FillWallsArray is null ? null : FillWallsArray : mazeMatrix;
        //    if (pictureMaze.Image == null || pictureMaze.Image.Width != pictureMaze.Width || pictureMaze.Image.Height != pictureMaze.Height)
        //    {
        //        if (pictureMaze.Image != null)
        //        {
        //            pictureMaze.Image.Dispose();
        //        }
        //        pictureMaze.Image = new Bitmap(pictureMaze.Width, pictureMaze.Height);
        //    }
        //    using (Graphics g = Graphics.FromImage(pictureMaze.Image))
        //    {
        //        g.Clear(Color.White);
        //        for (int row = 0; row < gridHeight; row++)
        //        {
        //            for (int col = 0; col < gridWidth; col++)
        //            {
        //                int x = (int)(col * cellWidth);
        //                int y = (int)(row * cellHeight);

        //                int nextX = (int)((col + 1) * cellWidth);
        //                int nextY = (int)((row + 1) * cellHeight);

        //                g.FillRectangle(cellBrush, x, y, cellWidth, cellHeight);
        //                g.DrawRectangle(wallPen, x, y, nextX - x - 1, nextY - y - 1);

        //                // Рисуем стену
        //                if (FillWallsArray != null && FillWallsArray[row, col] == true)
        //                    g.FillRectangle(wallBrush, x, y, cellWidth, cellHeight);
        //            }
        //        }

        //        if (startPoint != null)
        //        {
        //            int x = (int)(startPoint?.Y * cellWidth);
        //            int y = (int)(startPoint?.X * cellHeight);
        //            g.FillRectangle(startPointBrush, x, y, cellWidth, cellHeight);
        //        }

        //        if (endPoint != null)
        //        {
        //            int x = (int)(endPoint?.Y * cellWidth);
        //            int y = (int)(endPoint?.X * cellHeight);
        //            g.FillRectangle(endPointBrush, x, y, cellWidth, cellHeight);
        //        }

        //                    }
        //    pictureMaze.Invalidate();

        //}

        private void DrawMaze(bool[,] mazeMatrix = null)
        {
            float cellWidth = (float)Math.Floor((double)pictureMaze.Width / gridWidth);
            float cellHeight = (float)Math.Floor((double)pictureMaze.Height / gridHeight);

            Pen wallPen = new Pen(Color.Black);
            SolidBrush cellBrush = new SolidBrush(Color.White);
            SolidBrush startPointBrush = new SolidBrush(Color.GreenYellow);
            SolidBrush endPointBrush = new SolidBrush(Color.Red);

            // Убедимся, что cellWidth больше 0 перед вычислением fontSize
            int fontSize = Math.Max(1, (int)cellWidth - (int)(cellWidth / 3)); // Минимальный размер шрифта 1

            // Создаем кисть и шрифт для снежинки
            Font snowflakeFont = new Font("Arial", fontSize);
            SolidBrush snowflakeBrush = new SolidBrush(Color.Blue); // Цвет 

            // Создаем кисть и шрифт для цветочка
            Font springFont = new Font("Arial", fontSize);
            SolidBrush springBrush = new SolidBrush(Color.Red); // Цвет 

            // Создаем кисть и шрифт для солнца
            Font summerFont = new Font("Arial", fontSize);
            SolidBrush summerBrush = new SolidBrush(Color.GreenYellow); // Цвет 

            // Создаем кисть и шрифт для карандаша
            Font auFont = new Font("Arial", fontSize);
            SolidBrush auBrush = new SolidBrush(Color.Yellow); // Цвет 

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
                        g.DrawRectangle(wallPen, x, y, nextX - x - 1, nextY - y - 1);

                        // Рисуем стену
                        if (FillWallsArray != null && FillWallsArray[row, col] == true)
                        {
                            g.FillRectangle(wallBrush, x, y, cellWidth, cellHeight);

                            // Если цвет стены Aqua, добавляем снежинку
                            if (wallBrush.Color == Color.Aqua)
                            {
                                string snowflakeSymbol = "❄";
                                SizeF snowflakeSize = g.MeasureString(snowflakeSymbol, snowflakeFont);
                                float snowflakeX = x + (cellWidth - snowflakeSize.Width) / 2;
                                float snowflakeY = y + (cellHeight - snowflakeSize.Height) / 2;
                                g.DrawString(snowflakeSymbol, snowflakeFont, snowflakeBrush, snowflakeX, snowflakeY);
                            }
                            // Если цвет стены Pink, добавляем цветочек ❀
                            if (wallBrush.Color == Color.Pink)
                            {
                                string springSymbol = "❀"; // Эмодзи цветка
                                SizeF springSize = g.MeasureString(springSymbol, springFont);
                                float springX = x + (cellWidth - springSize.Width) / 2;
                                float springY = y + (cellHeight - springSize.Height) / 2;
                                g.DrawString(springSymbol, springFont, springBrush, springX, springY);
                            }
                            // Если цвет стены Green, добавляем цветочек ❅✰
                            if (wallBrush.Color == Color.Green)
                            {
                                string summerSymbol = "✸"; // Эмодзи цветка
                                SizeF summerSize = g.MeasureString(summerSymbol, summerFont);
                                float summerX = x + (cellWidth - summerSize.Width) / 2;
                                float summerY = y + (cellHeight - summerSize.Height) / 2;
                                g.DrawString(summerSymbol, summerFont, summerBrush, summerX, summerY);
                            }
                            // Если цвет стены Orange, добавляем карандаш 
                            if (wallBrush.Color == Color.Orange)
                            {
                                string auSymbol = "✎"; // Эмодзи цветка
                                SizeF auSize = g.MeasureString(auSymbol, summerFont);
                                float auX = x + (cellWidth - auSize.Width) / 2;
                                float auY = y + (cellHeight - auSize.Height) / 2;
                                g.DrawString(auSymbol, auFont, auBrush, auX, auY);
                            }
                        }
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
            customMessageBox.Size = new Size(850, 400);
            customMessageBox.Text = "Справочная информация о разработчиках";
            customMessageBox.MaximizeBox = false;
            customMessageBox.MinimizeBox = false;
            customMessageBox.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label label = new Label();
            label.Text = "Самарский университет\nКафедра программных систем\n\nКурсовой проект по дисциплине «Программная инженерия»\n\nТема проекта:\n«Автоматизированная система генерирования структуры лабиринта и нахождения выхода из него»\n\nРазработчики\nобучающиеся группы 6402-020302D:\n Балашова Екатерина\n Гриднева Виктория\n\nНаучный руководитель:\nЗеленко Лариса Сергеевна, доцент кафедры ПС\n\n\nСамара 2024";
            label.AutoSize = true;
            label.Font = new Font("Monserrat", 11, FontStyle.Bold); // Настройки шрифта
            label.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста по центру
            label.Dock = DockStyle.Fill; // Занимает всю доступную площадь
            customMessageBox.Controls.Add(label);

            customMessageBox.ShowDialog();
        }
        private void AdminAboutSys_Click(object sender, EventArgs e)
        {
            //string htmlFilePath = $@"{Environment.CurrentDirectory}\admin.html";

            //if (File.Exists(htmlFilePath))
            //{
            //    System.Diagnostics.Process.Start(htmlFilePath);
            //}
            //else
            //{
            //    MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            string htmlFilePath = Path.Combine(Environment.CurrentDirectory, "Resources", "кр.html");

            try
            {
                if (File.Exists(htmlFilePath))
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = htmlFilePath,
                        UseShellExecute = true // Используем оболочку для открытия файла
                    });
                }
                else
                {
                    MessageBox.Show("Файл не найден: " + htmlFilePath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при открытии файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string applicationPath = AppDomain.CurrentDomain.BaseDirectory;
                    string mazesFolderPath = Path.Combine(applicationPath, "Mazes");
                    if (!Directory.Exists(mazesFolderPath))
                    {
                        Directory.CreateDirectory(mazesFolderPath);
                    }

                    if (FillWallsArray is null || FillWallsArray?.Length == 0)
                    {
                        MessageBox.Show("Генерация лабиринта не выполнена!");
                        break;
                    }

                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "XML файлы (*.xml)|*.xml";
                        saveFileDialog.InitialDirectory = mazesFolderPath;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            SaveMatrixToXml(saveFileDialog.FileName);
                            StepForm = EStepForm.EXPORTEDMAZE;
                        }
                    }
                    break;
            }
        }
        private void pictureMaze_Click(object sender, EventArgs e)
        {
            // Получаем ширину и высоту одной ячейки
            float cellWidth = (float)Math.Floor((double)pictureMaze.Width / gridWidth);
            float cellHeight = (float)Math.Floor((double)pictureMaze.Height / gridHeight);


            // Получаем ширину и высоту одной ячейки
            MouseEventArgs me = (MouseEventArgs)e;

            // Рассчитываем индексы строки и столбца, на которые указывает клик
            int cellRowIndex = (int)Math.Floor((me.Y - pictureMaze.ClientRectangle.Top) / cellHeight);
            int cellColumnIndex = (int)Math.Floor((me.X - pictureMaze.ClientRectangle.Left) / cellWidth);

            switch (StepForm)
            {
                case EStepForm.BEGINSETPOINTS:

                    if (cellRowIndex > 0 && cellRowIndex < gridHeight && cellColumnIndex == 0)
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
                    if (cellRowIndex > 0 && cellRowIndex < gridHeight && cellColumnIndex == gridWidth - 1)
                    {
                        endPoint = new Point(cellRowIndex, cellColumnIndex);
                        DrawMaze(FillWallsArray);
                        StepForm = EStepForm.ENDSETPOINTS;

                        MessageBox.Show("Выходная точка установлена.");
                    }
                    else
                    {
                        MessageBox.Show("Нужна точка по правому боковому периметру.");
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
            {
                (startPoint, endPoint) = RandomStartEndPoints(FillWallsArray ?? new bool[gridHeight, gridWidth]);
                DrawMaze(FillWallsArray);
                MessageBox.Show("Вход и выход расставлены автоматически.");
                StepForm = EStepForm.GENERATEDMAZE;
                Generate.Visible = true;
            }
            else
            {
                MessageBox.Show("Создайте шаблон лабиринта перед автоматической расстановкой.");
                StepForm = EStepForm.NOTCREATETEMPLATE;
            }
        }

        private void Gamer_Load(object sender, EventArgs e)
        {
            
            Control.ControlCollection themes = ThemeGroupBox.Controls;

            foreach (RadioButton rdb in themes)
            {
                rdb.MouseUp += ThemeRadioButtons_CheckedChanged;
            }
            

        }

        private void ThemeRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked == true)
            {
                switch (radioButton.Name)
                {
                    case "radioButtonAU":
                        wallBrush = new SolidBrush(Color.Orange);
                        DrawMaze();
                        break;
                    case "radioButtonSU":
                        wallBrush = new SolidBrush(Color.Green);
                        DrawMaze();
                        break;
                    case "radioButtonSP":
                        wallBrush = new SolidBrush(Color.Pink);
                        DrawMaze();
                        break;
                    case "radioButtonWI":
                        wallBrush = new SolidBrush(Color.Aqua);
                        DrawMaze();
                        break;
                }
            }
        }
       
        private void heightUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (heightUpDown.Value % 2 == 0)
            {
                heightUpDown.Value++;  
                //MessageBox.Show("Высота изменена на ближайшее нечётное значение.");
            }
        }

        private void widthUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (widthUpDown.Value % 2 == 0)
            {
                widthUpDown.Value++;  
                //MessageBox.Show("Ширина изменена на ближайшее нечётное значение.");
            }
        }

    }
}
