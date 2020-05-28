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

namespace Server_autoscрool
{
    public partial class UserAdd : Form
    {
        public int Index;
        public string Cell;
        public int role;
        public UserAdd(int index, string cell)
        {
            Index = index;
            Cell = cell;
            InitializeComponent();
            if (index == 1)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "SELECT * FROM[BD].[dbo].[User] WHERE ID = '"+cell+"'";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    textBox1.Text = reader.GetValue(1).ToString();
                    textBox2.Text = reader.GetValue(2).ToString();
                    if (reader.GetValue(3).ToString() == "0")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
            else
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                role = 0;
            }
            else
            {
                role = 1;
            }
            if (Index == 0)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "INSERT INTO [BD].[dbo].[User] (Login, Parol, Role) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + role + "')";
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
                    var CommandText = "UPDATE [BD].[dbo].[User] SET Login = '" + textBox1.Text + "',Parol = '" + textBox2.Text + "',Role = '" + role + "' WHERE ID = '" + Cell + "'";
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

        private void UserAdd_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
