using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Экзамен
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dj_Co\source\repos\Экзамен\Экзамен\stock.mdf;Integrated Security = True";
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;
            string q = "SELECT* FROM[order] WHERE date=20.04.2020";
            LoadData(q, dataGridView1);



        }



        private void LoadData(string q, DataGridView dgv)
        // метод загрузки данных в любую таблицу с любым запросом
        // q - запрос на получение данных из БД  
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();    //Открываем соединение
                SqlCommand cmd = new SqlCommand(q, sqlConnection);
                // создание SQL команды с запросом
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // выполнение команды
                DataTable tb = new DataTable(); // создание таблицы
                da.Fill(tb);    // загрузка данных в таблицу
                dgv.DataSource = tb;  // привязка полученной таблицы к компоненту

                this.ActiveControl = dgv;   // активация компонента таблица
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Selected = true;
                }
                sqlConnection.Close(); // разрываем соединение с БД
            }
            catch
            {
                MessageBox.Show("Данные не найдены!");
            }
        }


    }
}
