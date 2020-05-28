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
    public partial class OGroop : Form
    {
        public OGroop()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group]";
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
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT GroupID FROM [BD].[dbo].[Group] WHERE NameGroup = '" + comboBox1.Text + "'";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader.GetValue(0).ToString());
                reader.Close();
            }
            Report report = new Report();
            report.Load("Группы.frx");
            report.SetParameterValue("GroupID", id);
            report.Show();
        }

        private void OGroop_Load(object sender, EventArgs e)
        {

        }
    }
}
