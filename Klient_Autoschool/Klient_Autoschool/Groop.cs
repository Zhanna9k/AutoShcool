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
    public partial class Groop : Form
    {
        int[] Kategory_indexs;
        int[] Instruktor_indexs;
        int[] Prepod_indexs;
        public int Index;
        public string Name;
        public Groop(int index, string name)
        {
            InitializeComponent();
            Index = index;
            Name = name;
            if (index == 1)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    connection.Open();
                    var CommandText = "SELECT * FROM [BD].[dbo].[Group] WHERE NameGroup = '" + Name + "'";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = CommandText,
                        Connection = connection
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    textBox1.Text = reader.GetValue(1).ToString();
                    dateTimePicker1.Text = reader.GetValue(2).ToString();
                    dateTimePicker2.Text = reader.GetValue(3).ToString();
                }
            }

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
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
                        comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox1.Enabled = true;
                }
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT FIO, ID FROM Sotr";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Instruktor_indexs = new int[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Instruktor_indexs[i] = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        comboBox2.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox2.Enabled = true;
                }
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT FIO, ID FROM Sotr";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Prepod_indexs = new int[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Prepod_indexs[i] = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        comboBox3.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox3.Enabled = true;
                }
            }
            comboBox1.SelectedIndex++;
            comboBox2.SelectedIndex++;
            comboBox3.SelectedIndex++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var CommandText = "";
            if (Index == 1)
            {
                DialogResult result = MessageBox.Show(this, "Вы действительно хотите изменить данные о группе!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    CommandText = "UPDATE [BD].[dbo].[Group] SET NameGroup = '" + textBox1.Text + "', DataStart = '" + Convert.ToDateTime(dateTimePicker1.Text) + "', DataFinish = '" + Convert.ToDateTime(dateTimePicker2.Text) + "', KategoryID = '" + Kategory_indexs[comboBox1.SelectedIndex] + "', InstructorID = '" + Instruktor_indexs[comboBox2.SelectedIndex] + "', PrepodID = '" + Prepod_indexs[comboBox3.SelectedIndex] + "' WHERE NameGroup = '" + Name + "'";
                }
                else
                {
                    return;
                }
            }
            else
            {
                CommandText = "INSERT INTO [BD].[dbo].[Group] (NameGroup, DataStart, DataFinish, KategoryID, InstructorID, PrepodID) VALUES " +
                              "('" + textBox1.Text + "', '" + Convert.ToDateTime(dateTimePicker1.Text) + "', '" + Convert.ToDateTime(dateTimePicker2.Text) + "', " + Kategory_indexs[comboBox1.SelectedIndex] + ", " + Instruktor_indexs[comboBox2.SelectedIndex] + ", " + Prepod_indexs[comboBox3.SelectedIndex] + ");";
            }
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
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Groop_Load(object sender, EventArgs e)
        {

        }
    }
}
