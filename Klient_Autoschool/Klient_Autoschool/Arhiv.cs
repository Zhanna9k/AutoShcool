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
    public partial class Arhiv : Form
    {
        public Arhiv()
        {
            InitializeComponent();
        }

        private void ученикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Вы действительно хотите удалить группу!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    var CommandText = "DELETE [BD].[dbo].[Group] WHERE NameGroup = '" + treeView1.SelectedNode.Text + "'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(CommandText, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                return;
            }
            treeView1.Nodes.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group] WHERE Arhiv = 1";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                for (var i = 0; i < c; i++)
                {
                    treeView1.Nodes.Add(Convert.ToString(ds.Tables[0].Rows[i][0]));

                }
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT g.NameGroup, u.FIO FROM [BD].[dbo].[Group] g,[BD].[dbo].[Uchenik] u WHERE u.Groop = g.GroupID";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                string[,] mass = new string[c, c];
                int a = treeView1.Nodes.Count;
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        mass[i, j] = Convert.ToString(ds.Tables[0].Rows[i][j]);
                    }

                }
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < a; j++)
                    {
                        if (treeView1.Nodes[j].Text == mass[i, 0])
                        {
                            treeView1.Nodes[j].Nodes.Add(mass[i, 1]);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Arhiv_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group] WHERE Arhiv = 1";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                //string[,] mass = new string[c, c];
                for (var i = 0; i < c; i++)
                {
                    treeView1.Nodes.Add(Convert.ToString(ds.Tables[0].Rows[i][0]));

                }
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT g.NameGroup, u.FIO FROM [BD].[dbo].[Group] g,[BD].[dbo].[Uchenik] u WHERE u.Groop = g.GroupID";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                string[,] mass = new string[c, c];
                int a = treeView1.Nodes.Count;
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        mass[i, j] = Convert.ToString(ds.Tables[0].Rows[i][j]);
                    }

                }
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < a; j++)
                    {
                        if (treeView1.Nodes[j].Text == mass[i, 0])
                        {
                            treeView1.Nodes[j].Nodes.Add(mass[i, 1]);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Вы действительно хотите восстановить группу!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
                {
                    var CommandText = "UPDATE [BD].[dbo].[Group] SET Arhiv = 0 WHERE NameGroup = '" + treeView1.SelectedNode.Text + "'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(CommandText, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                return;
            }
            treeView1.Nodes.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group] WHERE Arhiv = 1";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                for (var i = 0; i < c; i++)
                {
                    treeView1.Nodes.Add(Convert.ToString(ds.Tables[0].Rows[i][0]));

                }
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT g.NameGroup, u.FIO FROM [BD].[dbo].[Group] g,[BD].[dbo].[Uchenik] u WHERE u.Groop = g.GroupID";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                string[,] mass = new string[c, c];
                int a = treeView1.Nodes.Count;
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        mass[i, j] = Convert.ToString(ds.Tables[0].Rows[i][j]);
                    }

                }
                for (var i = 0; i < c; i++)
                {
                    for (var j = 0; j < a; j++)
                    {
                        if (treeView1.Nodes[j].Text == mass[i, 0])
                        {
                            treeView1.Nodes[j].Nodes.Add(mass[i, 1]);
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
