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
    public partial class UchenikAdd : Form
    {
        int[] Kategory_indexs;
        int[] Group_indexs;
        public int Index;
        public string Name;
        string ID;
        public UchenikAdd(int index, string name)
        {
            InitializeComponent();
            Index = index;
            Name = name;
            if (index == 1)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "SELECT * FROM [BD].[dbo].[Uchenik] WHERE FIO = '" + Name + "'";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    textBox5.Text = reader.GetValue(1).ToString();
                    dateTimePicker1.Text = reader.GetValue(3).ToString();
                    textBox7.Text = reader.GetValue(4).ToString();
                    textBox8.Text = reader.GetValue(5).ToString();
                    textBox9.Text = reader.GetValue(6).ToString();
                    dateTimePicker1.Text = reader.GetValue(7).ToString();
                    textBox11.Text = reader.GetValue(8).ToString();
                    ID = reader.GetValue(0).ToString();
                }
            }
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT Name, KategoryID FROM Kategory";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Kategory_indexs = new int[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Kategory_indexs[i] = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        comboBox3.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox3.Enabled = true;
                }
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT NameGroup, GroupID FROM [BD].[dbo].[Group]";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Group_indexs = new int[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Group_indexs[i] = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox1.Enabled = true;
                }
            }
            comboBox1.SelectedIndex++;
            comboBox3.SelectedIndex++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var CommandText = "";
            if (Index == 1)
            {
                DialogResult result = MessageBox.Show(this, "Вы действительно хотите изменить данные об ученике!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    CommandText = "UPDATE [BD].[dbo].[Uchenik] SET" +
                        " FIO = '" + textBox5.Text + "', Data = '" + Convert.ToDateTime(dateTimePicker1.Text) + "', Adress = '" + textBox7.Text + "', Doc = '" + textBox8.Text + "'," +
                        " Nomer = '" + textBox9.Text + "', DataDoc = '" + Convert.ToDateTime(dateTimePicker2.Text) + "', WhoDoc = '" + textBox11.Text + "'," +
                        " Categori = '" + Kategory_indexs[comboBox3.SelectedIndex] + "', Groop = '" + Group_indexs[comboBox1.SelectedIndex] + "' " +
                        " WHERE FIO = '" + Name + "'";
                    using (SqlConnection connection = new SqlConnection(Config.configuration))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand
                        {
                            CommandText = CommandText,
                            Connection = connection
                        };
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                }
                else
                {
                    return;
                }
            }
            else
            {
                CommandText = "INSERT INTO [BD].[dbo].[Uchenik] (FIO, Data, Adress, Doc, Nomer, DataDoc, WhoDoc, Categori, Groop) VALUES " +
                              "('" + textBox5.Text + "', '" + Convert.ToDateTime(dateTimePicker1.Text) + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + Convert.ToDateTime(dateTimePicker2.Text) + "', '" + textBox11.Text + "', " + Kategory_indexs[comboBox3.SelectedIndex] + ", " + Group_indexs[comboBox1.SelectedIndex] + ");";
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    CommandText = "SELECT TOP (1) * FROM Uchenik ORDER BY ID DESC";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    ID = reader.GetValue(0).ToString();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    CommandText = "INSERT INTO [BD].[dbo].[Zachet] (ID,Z1,Z2,Z3,Z4,Z5,Z6,Z7,Z8,Z9,Z10) VALUES ('" + ID + "',0,0,0,0,0,0,0,0,0,0)";
                    connection.Open();
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }


            Close();

        }

        private void UchenikAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
