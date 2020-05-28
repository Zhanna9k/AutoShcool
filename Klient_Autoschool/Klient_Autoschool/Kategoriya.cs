using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Klient_Autoschool
{
    public partial class Kategoriya : Form
    {
        public int index;
        public string cell = "";
        public Kategoriya()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            index = 0;
            KategoriyaAdd newfrm = new KategoriyaAdd(index,cell);
            newfrm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cell = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            index = 1;
            KategoriyaAdd newfrm = new KategoriyaAdd(index,cell);
            newfrm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Kategoriya_Activated(object sender, EventArgs e)
        {
            string[] table_headers = new string[0];
            table_headers = new[] { "ID", "Категория", "Описание" };
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT * FROM [BD].[dbo].[Kategory]";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                for (var i = 0; i < table_headers.Length; i++)
                {
                    dataGridView1.Columns[i].HeaderText = table_headers[i];
                }
                connection.Close();
            }
        }

        private void Kategoriya_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "DELETE[BD].[dbo].[Kategory] WHERE KategoryID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            string[] table_headers = new string[0];
            table_headers = new[] { "ID", "Категория", "Описание" };
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT * FROM [BD].[dbo].[Kategory]";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                for (var i = 0; i < table_headers.Length; i++)
                {
                    dataGridView1.Columns[i].HeaderText = table_headers[i];
                }
                connection.Close();
            }
        }
    }
}
