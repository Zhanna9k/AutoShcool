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
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Server_autoscрool
{


    public partial class Сервер_Автошколы : Form
    {
        const string ip = "127.0.0.1";
        const int port = 5004;
        
        public Сервер_Автошколы()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(Config.configuration))
            {
                connect.Open();
                if (connect.State==ConnectionState.Open)
                {
                    richTextBox1.Text = "Соединение с БД установлено";
                }
                else 
                {
                    richTextBox1.Text = "Ошибка соединения с БД";
                }
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void управлениеПользователямиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void пользователиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Users newfrm = new Users();
            newfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket sListener = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    //Process.Start("D:\\БГУИР\\Курсач\\Klient_Autoschool\\Klient_Autoschool\\bin\\Debug\\Klient_Autoschool.exe");

                    sListener.Bind(ipEndPoint);
                    sListener.Listen(10);
                richTextBox1.Text = "Сервер включен";
                while (true)
                    {
                        Socket handler = sListener.Accept();

                        //string data = null;

                        byte[] bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);

                        //data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                        //richTextBox1.AppendText("Полученный текст: " + data + "\n\n");

                        string reply = Config.configuration;
                        byte[] msg = Encoding.UTF8.GetBytes(reply);

                        handler.Send(msg);

                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
           
        }

        private void Сервер_Автошколы_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}