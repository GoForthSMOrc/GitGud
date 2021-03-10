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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


        //LoginForm Authorization (Enter button)//
        private void button1_Click(object sender, EventArgs e)
        {
            int Count = 0;
            string query = "Select count(*) from UsersDB where Login = '" + logBox.Text + "' and Password = '" + passBox.Text +"';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                Count = Convert.ToInt32(cmDB.ExecuteScalar());
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка авторизации.Попробуйте еще раз");
                MessageBox.Show(ex.Message);
            }
            if(Count > 0)
            {
                MainMenu win = new MainMenu(); ;
                win.Show();
                this.Hide();
            }
            if (Count == 0)
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
        
        
        //LoginFrom Exit (Exit button)//
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
