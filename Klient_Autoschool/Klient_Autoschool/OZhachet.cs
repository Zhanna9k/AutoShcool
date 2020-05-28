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
    public partial class OZhachet : Form
    {
        public OZhachet()
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
            int Z1, Z2, Z3, Z4, Z5, Z6, Z7, Z8, Z9, Z10;
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM Zachet z, Uchenik u WHERE u.FIO = '" + comboBox1.Text + "' AND z.ID = u.ID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Z1 = Convert.ToInt32(reader.GetValue(1).ToString());
                Z2 = Convert.ToInt32(reader.GetValue(2).ToString());
                Z3 = Convert.ToInt32(reader.GetValue(3).ToString());
                Z4 = Convert.ToInt32(reader.GetValue(4).ToString());
                Z5 = Convert.ToInt32(reader.GetValue(5).ToString());
                Z6 = Convert.ToInt32(reader.GetValue(6).ToString());
                Z7 = Convert.ToInt32(reader.GetValue(7).ToString());
                Z8 = Convert.ToInt32(reader.GetValue(8).ToString());
                Z9 = Convert.ToInt32(reader.GetValue(9).ToString());
                Z10 = Convert.ToInt32(reader.GetValue(10).ToString());
                reader.Close();
            }
            Report report = new Report();
            report.Load("Зачёты.frx");
            report.SetParameterValue("Name", comboBox1.Text);
            report.SetParameterValue("Z1", Z1);
            report.SetParameterValue("Z2", Z2);
            report.SetParameterValue("Z3", Z3);
            report.SetParameterValue("Z4", Z4);
            report.SetParameterValue("Z5", Z5);
            report.SetParameterValue("Z6", Z6);
            report.SetParameterValue("Z7", Z7);
            report.SetParameterValue("Z8", Z8);
            report.SetParameterValue("Z9", Z9);
            report.SetParameterValue("Z10", Z10);
            report.Show();
        }

        private void OZhachet_Load(object sender, EventArgs e)
        {

        }
    }
}
