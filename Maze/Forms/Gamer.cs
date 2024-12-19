using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Diagnostics;

namespace Maze
{
    public partial class Gamer : Form
    {
        private protected enum EStepForm : sbyte
        {
            UNLOADMAZE = 1,
            LOADEDMAZE,
            BEGANPASS,
            ENDPASS
        }
        SolidBrush wallBrush = new SolidBrush(Color.Orange);
        private bool[,] FillWallsArray;

        private Point? startPoint = null;
        private Point? endPoint = null;        

        private uint gridWidth;
        private uint gridHeight;

        private bool[,] visitedCells;
        private LinkedList<(int, int)> pathLinkedList;

        private EStepForm _stepForm = EStepForm.UNLOADMAZE;
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
                case EStepForm.UNLOADMAZE:

                    ModePassGroupBox.Visible = false;
                    pictureMaze.Image = null;
                    pictureMaze.Invalidate();
                    pictureBox2.Enabled = false;
                    pictureBox2.Visible = false;
                    FillWallsArray = null;
                    startPoint = null;
                    endPoint = null;
                    gridWidth = default;
                    gridHeight = default;
                    label4.Visible = false;
                    label3.Visible = false;
                    startGame.Visible = false;
                    startGame.Enabled = false;
                    algorithmGroupBox.Visible = false;
                    trackBarSpeed.Visible = false;
                    trackBarSpeed.Enabled = false;
                    radioButtonHands.Checked = true;
                    radioButtonAU.Checked = true;
                    ThemeRadioButtons_CheckedChanged(radioButtonAU, null);
                    ModeRadioButtons_CheckedChanged(radioButtonHands, null);
                    break;
                case EStepForm.LOADEDMAZE:
                    ModePassGroupBox.Visible = true;
                    pictureBox2.Enabled = false;
                    pictureBox2.Visible = false;
                    textBegining.Visible = false;
                    gridWidth = (uint)FillWallsArray.GetLength(1);
                    gridHeight = (uint)FillWallsArray.GetLength(0);
                    visitedCells = new bool[gridHeight, gridWidth];
                    pathLinkedList = new LinkedList<(int, int)>();
                    startGame.Visible = true;
                    startGame.Enabled = true;
                    trackBarSpeed.Enabled = true;
                    radioButtonHands.Checked = true;
                    radioButtonAU.Checked = true;
                    ThemeGBox.Visible = true;
                    labelChoice.Visible = true;
                    ThemeRadioButtons_CheckedChanged(radioButtonAU, null);
                    ModeRadioButtons_CheckedChanged(radioButtonHands, null);
                    break;
                case EStepForm.BEGANPASS:
                    label3.Visible = false;
                    ModePassGroupBox.Visible = false;
                    label4.Visible = false;
                    algorithmGroupBox.Visible = false;
                    startGame.Visible = false;
                    startGame.Enabled = false;
                    trackBarSpeed.Visible = false;
                    trackBarSpeed.Enabled = false;
                    ThemeGBox.Visible = false;
                    labelChoice.Visible = false;
                    pictureMaze.Focus();
                    if (radioButtonAuto.Checked)
                        AutoPassMaze();
                    break;
                case EStepForm.ENDPASS:
                    startGame.Visible = false;
                    startGame.Enabled = false;
                    break;
            }
        }
        public Gamer()
        {
            InitializeComponent();
        }
        private void clearAll()
        {

            StepForm = EStepForm.UNLOADMAZE;
        }
        private void aboutUs_Click(object sender, EventArgs e)
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

        private void aboutSys_Click(object sender, EventArgs e)
        {
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
        private void Gamer_KeyDown(object sender, KeyEventArgs e)
        {
            if (FillWallsArray is null || FillWallsArray?.Length == 0)
                return;
            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;

            int cellRowIndex = Convert.ToInt32(Math.Floor(pictureBox2.Top / cellHeight));
            int cellColumnIndex = Convert.ToInt32(Math.Floor(pictureBox2.Left / cellWidth));

            if (e.KeyCode == Keys.Left && pictureBox2.Location.X > 0 && cellColumnIndex > 0 && FillWallsArray[cellRowIndex, cellColumnIndex - 1] == false)
            {
                MoveCharacter(cellRowIndex, cellColumnIndex - 1);
                return;
            }

            else if (e.KeyCode == Keys.Right && pictureBox2.Right < pictureMaze.Width && cellColumnIndex < FillWallsArray.GetLength(1) && FillWallsArray[cellRowIndex, cellColumnIndex + 1] == false)
            {
                MoveCharacter(cellRowIndex, cellColumnIndex + 1);
                return;
            }

            else if (e.KeyCode == Keys.Up && pictureBox2.Location.Y > 0 && cellRowIndex > 0 && FillWallsArray[cellRowIndex - 1, cellColumnIndex] == false)
            {
                MoveCharacter(cellRowIndex - 1, cellColumnIndex);
                return;
            }

            else if (e.KeyCode == Keys.Down && pictureBox2.Bottom < pictureMaze.Height && cellRowIndex < FillWallsArray.GetLength(0) && FillWallsArray[cellRowIndex + 1, cellColumnIndex] == false)
            {
                MoveCharacter(cellRowIndex + 1, cellColumnIndex);
                return;
            }

            if ((cellRowIndex, cellColumnIndex + 1) == (endPoint?.X, endPoint?.Y))
                MoveCharacter(cellRowIndex, cellColumnIndex + 1);
        }
        private void MoveCharacter(int cellRowIndex, int cellColumnIndex)
        {
            if (FillWallsArray is null || FillWallsArray.Length == 0)
                return;

            // Обновление позиции персонажа
            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;
            pictureBox2.Left = Convert.ToInt32(cellColumnIndex * cellWidth + 0.5f);
            pictureBox2.Top = Convert.ToInt32(cellRowIndex * cellHeight + 0.5f);

            var currentPosition = (cellRowIndex, cellColumnIndex);

            if (pathLinkedList.Count > 0 && pathLinkedList.Last.Value == currentPosition)
            {
                // Если игрок возвращается в клетку, которая уже была добавлена последней, ничего не делаем
                return;
            }

            // Проверяем, был ли игрок уже в этой клетке
            if (pathLinkedList.Contains(currentPosition))
            {
                // Пошаговое удаление следа до текущей позиции
                while (pathLinkedList.Last.Value != currentPosition)
                {
                    var removedCell = pathLinkedList.Last.Value;
                    visitedCells[removedCell.Item1, removedCell.Item2] = false;
                    pathLinkedList.RemoveLast();
                    DrawMaze(); // Перерисовываем лабиринт после каждого шага назад
                }
            }
            else
            {
                // Добавляем новую клетку
                pathLinkedList.AddLast(currentPosition);
                visitedCells[cellRowIndex, cellColumnIndex] = true;
            }

            DrawMaze();

            // Проверяем достижение цели
            if ((cellRowIndex, cellColumnIndex) == (endPoint?.X, endPoint?.Y))
            {
                MessageBox.Show("Лабиринт пройден!");
                clearAll();
            }
        }

        private void DrawMaze()
        {
            if (FillWallsArray is null || FillWallsArray?.Length == 0)
                return;

            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;

            Pen wallPen = new Pen(Color.Black);
            SolidBrush cellBrush = new SolidBrush(Color.White);
            SolidBrush startPointBrush = new SolidBrush(Color.GreenYellow);
            SolidBrush endPointBrush = new SolidBrush(Color.Red);
            SolidBrush pathBrush = new SolidBrush(Color.Brown); // Цвет для пути

            int fontSize = (int)cellWidth - (int)(cellWidth/3); // Размер символов

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
                        // Рисуем посещенные ячейки
                        if (visitedCells[row, col])
                        {
                            g.FillRectangle(pathBrush, x, y, cellWidth, cellHeight);
                        }
                    }
                }
                // Рисуем начальную и конечную точки
                if (startPoint != null)
                {
                    int startX = (int)(startPoint?.Y * cellWidth);
                    int startY = (int)(startPoint?.X * cellHeight);
                    g.FillRectangle(startPointBrush, startX, startY, cellWidth, cellHeight);
                }
                if (endPoint != null)
                {
                    int endX = (int)(endPoint?.Y * cellWidth);
                    int endY = (int)(endPoint?.X * cellHeight);
                    g.FillRectangle(endPointBrush, endX, endY, cellWidth, cellHeight);
                }
            }
            pictureMaze.Invalidate();
        }
        private bool[,] ReadMatrixFromXml(string filePath)
        {
            XmlReader XMLReader = XmlReader.Create(filePath);
            int rows = 0;
            int cols = 0;
            bool[,] matrix;

            while (XMLReader.Read())
            {
                int count = 0;
                if (XMLReader.NodeType == XmlNodeType.Element && XMLReader.Name == "Row")
                {
                    rows++;
                    XMLReader.ReadToDescendant("Cell");

                    do
                    {
                        count++;
                    } while (XMLReader.ReadToNextSibling("Cell"));
                }
                cols = Math.Max(cols, count);
            }

            XMLReader = XmlReader.Create(filePath);

            matrix = new bool[rows, cols];

            int currentRow = 0;
            int currentCol = 0;

            while (XMLReader.Read())
            {
                if (XMLReader.NodeType == XmlNodeType.Element && XMLReader.Name == "Cell")
                {
                    matrix[currentRow, currentCol] = bool.Parse(XMLReader.ReadElementContentAsString());
                    currentCol++;
                }
                else if (XMLReader.NodeType == XmlNodeType.EndElement && XMLReader.Name == "Row")
                {
                    currentRow++;
                    currentCol = 0;
                }
                else if (XMLReader.NodeType == XmlNodeType.Element && XMLReader.Name == "StartPoint")
                {
                    string[] location = XMLReader.ReadElementContentAsString().Split(':');
                    startPoint = new Point(int.Parse(location[0]), int.Parse(location[1]));
                }
                else if (XMLReader.NodeType == XmlNodeType.Element && XMLReader.Name == "EndPoint")
                {
                    string[] location = XMLReader.ReadElementContentAsString().Split(':');
                    endPoint = new Point(int.Parse(location[0]), int.Parse(location[1]));
                }
            }

            return matrix;
        }

        private void outputMazeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML файлы (*.xml)|*.xml";

            string applicationPath = AppDomain.CurrentDomain.BaseDirectory;
            string mazesFolderPath = Path.Combine(applicationPath, "Mazes");

            if (!Directory.Exists(mazesFolderPath))
            {
                Directory.CreateDirectory(mazesFolderPath);
            }

            openFileDialog.InitialDirectory = mazesFolderPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Проверяем структуру файла перед загрузкой
                if (!IsValidXmlStructure(openFileDialog.FileName))
                {
                    MessageBox.Show("Структура файла нарушена.");
                    return;
                }

                FillWallsArray = ReadMatrixFromXml(openFileDialog.FileName);
                StepForm = EStepForm.LOADEDMAZE;
                DrawMaze();
                MessageBox.Show("Лабиринт успешно загружен из файла!");
            }
        }

        // Функция для проверки структуры XML-файла
        private bool IsValidXmlStructure(string filePath)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                // Проверяем наличие элемента Matrix
                XElement matrixElement = doc.Element("Matrix");
                if (matrixElement == null)
                {
                    return false;
                }

                // Проверяем наличие хотя бы одного элемента Row
                IEnumerable<XElement> rows = matrixElement.Elements("Row");
                if (!rows.Any())
                {
                    return false;
                }

                foreach (XElement row in rows)
                {
                    // Проверяем наличие хотя бы одной ячейки Cell
                    IEnumerable<XElement> cells = row.Elements("Cell");
                    if (!cells.Any())
                    {
                        return false;
                    }

                    foreach (XElement cell in cells)
                    {
                        // Проверяем значение каждой ячейки на допустимые значения True или False
                        string value = cell.Value.Trim().ToLowerInvariant();
                        if (value != "true" && value != "false")
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Логируем исключение, если что-то пошло не так
                Console.WriteLine($"Ошибка при проверке структуры XML: {ex.Message}");
                return false;
            }
        }

        private void Gamer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void Gamer_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(Gamer_PreviewKeyDown);
            }
            Control.ControlCollection themes = ThemeGroupBox.Controls;

            foreach (RadioButton rdb in themes)
            {
                rdb.MouseUp += ThemeRadioButtons_CheckedChanged;
            }

            Control.ControlCollection modes = ModePassGroupBox.Controls;

            foreach (RadioButton rdb in modes)
            {
                rdb.MouseUp += ModeRadioButtons_CheckedChanged;
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
        private void ModeRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked == true)
            {
                switch (radioButton.Name)
                {
                    case "radioButtonHands":
                        label3.Visible = false;
                        label4.Visible = false;
                        trackBarSpeed.Visible = false;
                        algorithmGroupBox.Visible = false;
                        break;
                    case "radioButtonAuto":
                        label3.Visible = true;
                        label4.Visible = true;
                        trackBarSpeed.Visible = true;
                        algorithmGroupBox.Visible = true;
                        break;
                }
            }
        }
        private void startGame_Click(object sender, EventArgs e)
        {
            if (FillWallsArray is null || FillWallsArray?.Length == 0)
                return;
            float cellWidth = (float)pictureMaze.Width / gridWidth;
            float cellHeight = (float)pictureMaze.Height / gridHeight;
            Image image = Image.FromFile(@"Resources\mario.png");

            Bitmap bit = new Bitmap(image);
            bit.MakeTransparent();
            pictureBox2.Image = bit;
            pictureBox2.Size = Size.Round(new SizeF(Convert.ToInt32(cellWidth), Convert.ToInt32(cellHeight)));
            pictureMaze.Controls.Add(pictureBox2);
            pictureBox2.BackColor = Color.Transparent;
            int X = Convert.ToInt32(startPoint?.Y * cellWidth + 0.5f);
            int Y = Convert.ToInt32((startPoint?.X) * cellHeight + 0.5f);
            pictureBox2.Location = new Point(X, Y);
            pictureBox2.Enabled = true;
            pictureBox2.Visible = true;

            pictureMaze.Invalidate();
            pictureBox2.Invalidate();
            StepForm = EStepForm.BEGANPASS;
        }
        private async void AutoPassMaze()
        {
            int[,] intArray = new int[gridHeight, gridWidth];

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    intArray[i, j] = FillWallsArray[i, j] ? 1 : 0;
                }
            }
            
            if (radioButtonWave.Checked)
            {
                var searcher = new WaveResolver(WaveResolver.SearchMethod.Path4);
                var start = new WaveResolver.Point((int)startPoint?.X, (int)startPoint?.Y + 1);
                var end = new WaveResolver.Point((int)endPoint?.X, (int)endPoint?.Y - 1);
                var path = searcher.Search(intArray, start, end);
                await Task.Delay(1000 / trackBarSpeed.Value);
                MoveCharacter((int)startPoint?.X, (int)startPoint?.Y + 1);
                for (int i = 0; i < path.Length; i++)
                {

                    await Task.Delay(1000 / trackBarSpeed.Value);
                    MoveCharacter(path[i].X, path[i].Y);

                }
                await Task.Delay(1000 / trackBarSpeed.Value);
                MoveCharacter((int)endPoint?.X, (int)endPoint?.Y);
            }
            else if (radioButton1Hands.Checked)
            {
                var path = HandSolver.SolveMaze(intArray, new int[] { (int)startPoint?.X, (int)startPoint?.Y }, new int[] { (int)endPoint?.X, (int)endPoint?.Y - 1 });

                for (int i = 0; i < path.GetLength(0); i++)
                {
                    await Task.Delay(1000 / trackBarSpeed.Value);
                    MoveCharacter(path[i, 0], path[i, 1]);
                }
                await Task.Delay(1000 / trackBarSpeed.Value);
                MoveCharacter((int)endPoint?.X, (int)endPoint?.Y);
            }
        }

        private void radioButtonAU_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

