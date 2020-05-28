using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace Server_autoscрool
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
            Config.configuration = $"Server=DESKTOP-T5PMJEB\\ZHANNA;DataBase=BD;User Id=zhanna;Password=0921";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value.ToString();
            string roole = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[3].Value.ToString();
            if (roole == "0")
            {
                if (textBox2.Text == password)
                {
                    Сервер_Автошколы newfrm = new Сервер_Автошколы();
                    newfrm.Show();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    comboBox1.Enabled = false;
                    textBox2.Enabled = false;
                    Hide();
                }
                else
                {
                    MessageBox.Show(this, "Вы ввели не правильный пароль!\n\nПовторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Пользователь не является администратором!\n\nПовторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "	SELECT * FROM [BD].[dbo].[User] ORDER BY Login ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
                foreach (DataGridViewRow x in dataGridView1.Rows)
                {
                    comboBox1.Items.Add(x.Cells[1].Value);
                }
                comboBox1.SelectedIndex = 0;
            }
        }
    }
}
