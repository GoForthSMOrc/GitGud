using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Practic4BIG
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NewLogin_TextChanged(object sender, EventArgs e)
        {

        }


        //AddUser Добавление нового пользователя (Добавить button)//
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO UsersDB(Login,Password) values('"+ NewLogin.Text + "','"+ Password.Text + "');";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //AddUser Функция создания случайного пароля//
        static string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static Random r = new Random();

        static string GetRandom(string type)
        {
            string Result = "";
            if (type == "Password")
            {
                for (int i = 0; i < 5; i++)
                {
                    var index = r.Next(symbols.Length);
                    Result += symbols[index];
                }

            }
            return Result;
        }

        //AddUser Создание случайного пароля (Обновить button)//
        private void button2_Click(object sender, EventArgs e)
        {
            Password.Text = "";
            Password.Text = GetRandom(Password.Name.ToString());
        }
    }
}
