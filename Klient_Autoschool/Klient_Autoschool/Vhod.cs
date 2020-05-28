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

namespace Klient_Autoschool
{
    public partial class Vhod : Form
    {
        const string ip = "127.0.0.1";
        const int port = 5004;
        public Vhod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value.ToString();
            if (textBox2.Text == password)
            {
                Autoschool newfrm = new Autoschool();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vhod_Load(object sender, EventArgs e)
        {
            byte[] bytes = new byte[1024];

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            Socket send = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            send.Connect(ipEndPoint);

            string message = "Запрос на информацию по БД";

            byte[] msg = Encoding.UTF8.GetBytes(message);

            int bytesSent = send.Send(msg);

            int bytesRec = send.Receive(bytes);

            Config.configuration = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            send.Shutdown(SocketShutdown.Both);
            send.Close();
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
