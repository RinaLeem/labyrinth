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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            string login = AInputLogin.Text;
            string password = AInputPassword.Text;

            string userFilePath = $@"{Environment.CurrentDirectory}\users.txt";
            string adminFilePath = $@"{Environment.CurrentDirectory}\admin.txt";

            if (File.Exists(userFilePath) && File.Exists(adminFilePath))
            {
                var errorType = CheckCredentials(login, password, userFilePath, adminFilePath);

                if (errorType == CredentialError.None)
                {
                    if (IsAdmin(login, password, adminFilePath))
                    {
                        MessageBox.Show("Вы успешно авторизовались.");
                        Admin adminForm = new Admin();
                        this.Hide();
                        adminForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Вы успешно авторизовались.");
                        Gamer gamerForm = new Gamer();
                        this.Hide();
                        gamerForm.Show();
                    }
                }
                else
                {
                    switch (errorType)
                    {
                        case CredentialError.LoginNotFound:
                            MessageBox.Show("Логин не найден.", "Ошибка авторизации");
                            break;
                        case CredentialError.IncorrectPassword:
                            MessageBox.Show("Неверный пароль.", "Ошибка авторизации");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Файлы с учетными данными не найдены.", "Ошибка");
            }
        }

        private CredentialError CheckCredentials(string login, string password, string userFilePath, string adminFilePath)
        {
            // Проверяем, существует ли логин среди пользователей
            bool loginExistsInUsers = File.Exists(userFilePath) && File.ReadAllLines(userFilePath)
                .Any(line => line.Split(':')[0] == login);

            bool loginExistsInAdmins = File.Exists(adminFilePath) && File.ReadAllLines(adminFilePath)
                .Any(line => line.Split(':')[0] == login);

            if (!loginExistsInUsers && !loginExistsInAdmins)
            {
                return CredentialError.LoginNotFound; // Логин не найден
            }

            // Проверяем корректность пароля
            bool isPasswordCorrectForUser = File.Exists(userFilePath) &&
                File.ReadAllLines(userFilePath)
                .Any(line => line == $"{login}:{password}");

            bool isPasswordCorrectForAdmin = File.Exists(adminFilePath) &&
                File.ReadAllLines(adminFilePath)
                .Any(line => line == $"{login}:{password}");

            if (loginExistsInUsers || loginExistsInAdmins)
            {
                if (isPasswordCorrectForUser || isPasswordCorrectForAdmin)
                {
                    return CredentialError.None; // Все корректно
                }

                return CredentialError.IncorrectPassword; // Пароль неверный
            }

            return CredentialError.LoginNotFound;
        }

        private enum CredentialError
        {
            None,
            LoginNotFound,
            IncorrectPassword
        }
        private bool IsUserCredentialsValid(string login, string password, string userFilePath, string adminFilePath)
        {
            if (File.Exists(adminFilePath))
            {
                string[] adminLines = File.ReadAllLines(adminFilePath);
                string credentials = $"{login}:{password}";
                if (adminLines.Any(line => line == credentials))
                {
                    // Это администратор
                    return true;
                }
            }

            if (File.Exists(userFilePath))
            {
                string[] userLines = File.ReadAllLines(userFilePath);
                string credentials = $"{login}:{password}";
                if (userLines.Any(line => line == credentials))
                {
                    // Это обычный пользователь
                    return true;
                }
            }
            return false;
        }
        private bool IsAdmin(string login, string password, string adminFilePath)
        {
            if (File.Exists(adminFilePath))
            {
                string[] adminLines = File.ReadAllLines(adminFilePath);
                string credentials = $"{login}:{password}";
                if (adminLines.Any(line => line == credentials))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
