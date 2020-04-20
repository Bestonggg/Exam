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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dj_Co\source\repos\Экзамен\Экзамен\stock.mdf;Integrated Security = True";

        DateTime dateTime = DateTime.Now; //Дата оформления
                                         
        int id;


        private async void button1_Click(object sender, EventArgs e)
        {
          
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO [client] (name, phone,number_drivers_license,place_of_issue) " +
                "VALUES (@name, @phone,@number_drivers_license,@place_of_issue)", sqlConnection);

            command.Parameters.AddWithValue("name", textBox1.Text);
            command.Parameters.AddWithValue("phone", textBox2.Text);
            command.Parameters.AddWithValue("number_drivers_license", textBox3.Text);
            command.Parameters.AddWithValue("place_of_issue", textBox4.Text);
           

            await sqlConnection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            sqlConnection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
          

        }

          
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
           
           
       
            string date = Convert.ToString(dateTime);

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO [order] (client_id, car_id,date,time_rent_start,time_rent_end) " +
                "VALUES (@client_id, @car_id,@date,@time_rent_start,@time_rent_end)", sqlConnection);

            command.Parameters.AddWithValue("client_id", 1);
            command.Parameters.AddWithValue("car_id", textBox10.Text);
            command.Parameters.AddWithValue("date", date);
            command.Parameters.AddWithValue("time_rent_start", textBox8.Text);
            command.Parameters.AddWithValue("time_rent_end", textBox9.Text);

            await sqlConnection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            sqlConnection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}

        