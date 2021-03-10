using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Practic4BIG
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //MainMenu Вывод списка (ФИО|Должность|Название группы) (Список button)//
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT Snowmans.NameSnowmans as 'ФИО',Post.NamePost as 'Должность', GroupSnow.NameGroup as 'Название группы' FROM Snowmans JOIN Post on Post.Id_Post = Snowmans.id_Post JOIN GroupSnow on GroupSnow.Id_GroupSnow = Snowmans.id_GroupSnow;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            MySqlDataReader rd;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                conn.Close();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                MessageBox.Show("Подключение к БД прошло успешно");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД");
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
       
        //MainMenu Переход в окно добавления нового пользователя (Добавить пользователя button)//
        private void button2_Click(object sender, EventArgs e)
        {
            AddUser Win = new AddUser();
            Win.Show();
          
        }

        //MainMenu Переход в окно добавления нового рабочего (Добавить рабочего button)//
        private void button3_Click(object sender, EventArgs e)
        {
            AddWorker Win = new AddWorker();
            Win.Show();
        }
    }
}
