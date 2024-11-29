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
                if (IsUserCredentialsValid(login, password, userFilePath, adminFilePath))
                {
                    if (IsAdmin(login, password, adminFilePath))
                    {
                        // Пользователь является администратором
                        MessageBox.Show("Вы успешно авторизовались.");
                        Admin adminForm = new Admin();
                        this.Hide();
                        adminForm.Show();
                    }
                    else
                    {
                        // Пользователь является обычным пользователем
                        MessageBox.Show("Вы успешно авторизовались.");
                        Gamer gamerForm = new Gamer();
                        this.Hide();
                        gamerForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Неверные учетные данные или пользователь не найден.", "Ошибка авторизации");
                }
            }
            else
            {
                MessageBox.Show("Файлы с учетными данными не найдены.", "Ошибка");
            }
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
