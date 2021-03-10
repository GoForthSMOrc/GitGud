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
    public partial class AddWorker : Form
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NewGroup_TextChanged(object sender, EventArgs e)
        {

        }

        //AddWorker Добавление нового рабочего(ФИО|Телефон|Должность|Группа|) (Добавить button)//
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Snowmans(NameSnowmans,NamePhone,id_Post,id_GroupSnow) values('" + NewFIO.Text + "','" + NewPhone.Text + "','" + NewPost.Text + "','" + NewGroup.Text + "');";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
