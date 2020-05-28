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
using FastReport;

namespace Klient_Autoschool
{
    public partial class Ouchenik : Form
    {
        public Ouchenik()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT FIO FROM Uchenik";
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
                    }
                    comboBox1.Enabled = true;
                }
            }
            comboBox1.SelectedIndex++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            string group, category;
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT u.ID, k.Name, g.NameGroup FROM Uchenik u, Kategory k, [BD].[dbo].[Group] g WHERE FIO = '"+ comboBox1.Text + "' AND u.Categori = k.KategoryID AND u.Groop = g.GroupID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader.GetValue(0).ToString());
                group = reader.GetValue(2).ToString();
                category = reader.GetValue(1).ToString();
                reader.Close();
            }
            Report report = new Report();
            report.Load("Ученики.frx");
            report.SetParameterValue("UchenikID", id);
            report.SetParameterValue("Group", group);
            report.SetParameterValue("Category", category);
            report.Show();

        }

        private void Ouchenik_Load(object sender, EventArgs e)
        {
            
        }
    }
}
