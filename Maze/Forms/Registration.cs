using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Maze
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string login = RInputLogin.Text;
            string password = RInputPassword.Text;
            string confirmPassword = RConfirmPassword.Text;

            if (!IsEnglish(login) || !IsEnglish(password))
            {
                MessageBox.Show("Логин и пароль должны содержать только английские буквы.", "Ошибка регистрации");
                return;
            }

            // Проверка валидности логина и пароля
            if (login.Length < 6 || login.Length > 16)
            {
                MessageBox.Show("Логин должен быть от 6 до 16 символов.", "Ошибка регистрации");
                return;
            }
            if (password.Length < 6 || password.Length > 20)
            {
                MessageBox.Show("Пароль должен быть от 6 до 20 символов.", "Ошибка регистрации");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка регистрации");
                return;
            }

            string filePath = $@"{Environment.CurrentDirectory}\users.txt";

            // Проверка наличия пользователя с таким логином
            if (CheckUserExists(login, filePath))
            {
                MessageBox.Show("Пользователь с таким логином уже существует. Выберите другой логин.", "Ошибка регистрации");
                return;
            }

            // Попытка записать данные нового пользователя
            string userData = $"{login}:{password}";
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(userData);
                }
                MessageBox.Show("Регистрация успешно завершена.", "Регистрация");

                // Закрыть текущую форму регистрации и открыть форму авторизации
                this.Close();
                Authorization authorizationForm = new Authorization();
                authorizationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при записи файла: {ex.Message}", "Ошибка регистрации");
            }
        }

        private bool IsEnglish(string input)
        {
            foreach (char c in input)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    continue; // Если символ - буква английского алфавита, продолжаем цикл
                }
                else if (char.IsLetter(c))
                {
                    return false; // Если символ - буква, но не английская, возвращаем false
                }
            }
            return true; // Если во вводе отсутствуют буквы или присутствуют только английские, возвращаем true
        }

        private bool CheckUserExists(string login, string filePath)
        {
            // Проверяем, существует ли файл. Если нет, значит, пользователей нет, и можно регистрировать нового.
            if (!File.Exists(filePath))
            {
                return false;
            }

            // Чтение данных из файла и поиск совпадающего логина
            string[] userLines = File.ReadAllLines(filePath);
            foreach (string userLine in userLines)
            {
                if (userLine.StartsWith(login + ":"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

