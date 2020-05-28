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

namespace Klient_Autoschool
{
    public partial class KategoriyaAdd : Form
    {
        public int Index;
        public string Cell;
        public KategoriyaAdd(int index, string cell)
        {
            InitializeComponent();
            Index = index;
            Cell = cell;
            if (index == 1)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "SELECT * FROM[BD].[dbo].[Kategory] WHERE KategoryID = '" + cell + "'";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    textBox5.Text = reader.GetValue(1).ToString();
                    richTextBox1.Text = reader.GetValue(2).ToString();
                }
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Index == 0)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "INSERT INTO [BD].[dbo].[Kategory] (Name, Inf) values('" + textBox5.Text + "', '" + richTextBox1.Text + "')";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "UPDATE [BD].[dbo].[Kategory] SET Name = '" + textBox5.Text + "',Inf = '" + richTextBox1.Text + "' WHERE KategoryID = '" + Cell + "'";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
            }
        }

        private void KategoriyaAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
