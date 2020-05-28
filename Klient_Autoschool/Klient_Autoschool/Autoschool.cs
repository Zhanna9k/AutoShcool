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
    public partial class Autoschool : Form
    {
        public int index;
        public string name = "";
        public string ID;
        public Autoschool()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            index = 0;
            Groop newfrm = new Groop(index, name);
            newfrm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            index = 1;
            Groop newfrm = new Groop(index, name);
            newfrm.Show();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            index = 0;
            UchenikAdd newfrm = new UchenikAdd(index, name);
            newfrm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            name = textBox5.Text;
            index = 1;
            UchenikAdd newfrm = new UchenikAdd(index, name);
            newfrm.Show();
        }

        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Arhiv newfrm = new Arhiv();
            newfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox5.Text;
            Zachet newfrm = new Zachet(ID,name);
            newfrm.Show();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sotrudniki newfrm = new Sotrudniki();
            newfrm.Show();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kategoriya newfrm = new Kategoriya();
            newfrm.Show();
        }

        private void поГруппеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OGroop newfrm = new OGroop();
            newfrm.Show();
        }

        private void поСтудентамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ouchenik newfrm = new Ouchenik();
            newfrm.Show();
        }

        private void поЗачетамУчениковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OZhachet newfrm = new OZhachet();
            newfrm.Show();
        }

        private void Autoschool_Load(object sender, EventArgs e)
        {
           
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           o_programe newfrm = new o_programe();
            newfrm.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT FIO FROM [BD].[dbo].[Uchenik] WHERE FIO = '" + treeView1.SelectedNode.Text + "'";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (command == null)
                {
                    textBox5.Text = reader.GetValue(0).ToString();
                }

                connection.Close();
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM Uchenik u, BD.dbo.[Group] g, Kategory k, Sotr s WHERE u.FIO = '" + treeView1.SelectedNode.Text + "' and u.Groop = g.GroupID and g.KategoryID = k.KategoryID and g.InstructorID = s.ID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    ID = reader.GetValue(0).ToString(); //IDUchenik
                    textBox1.Text = reader.GetValue(12).ToString(); //Group
                    textBox2.Text = reader.GetValue(13).ToString(); //Dataon
                    textBox3.Text = reader.GetValue(14).ToString(); //Dataoff
                    textBox4.Text = reader.GetValue(20).ToString(); //Kateg
                    textBox5.Text = reader.GetValue(1).ToString(); //FIO
                    textBox6.Text = reader.GetValue(3).ToString(); //DataR
                    textBox7.Text = reader.GetValue(4).ToString(); //Adres
                    textBox8.Text = reader.GetValue(5).ToString(); //Doc
                    textBox9.Text = reader.GetValue(6).ToString(); //NomDoc
                    textBox10.Text = reader.GetValue(7).ToString(); //DataB
                    textBox11.Text = reader.GetValue(8).ToString(); //KemB
                    textBox12.Text = reader.GetValue(23).ToString(); //Instr
                    textBox14.Text = reader.GetValue(20).ToString(); //Kat
                    textBox15.Text = reader.GetValue(12).ToString(); //Group
                    toolStripButton2.Enabled = false;
                    toolStripButton7.Enabled = false;
                    toolStripButton5.Enabled = true;
                    toolStripButton6.Enabled = true;
                    button1.Enabled = true;
                }

                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM Uchenik u, BD.dbo.[Group] g, Kategory k, Sotr s WHERE u.FIO = '" + treeView1.SelectedNode.Text + "' and u.Groop = g.GroupID and g.KategoryID = k.KategoryID and g.PrepodID = s.ID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox13.Text = reader.GetValue(23).ToString(); //Prepod
                    toolStripButton2.Enabled = false;
                    toolStripButton7.Enabled = false;
                    toolStripButton5.Enabled = true;
                    toolStripButton6.Enabled = true;
                }

                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM BD.dbo.[Group] g, Kategory k, Sotr s WHERE g.NameGroup = '" + treeView1.SelectedNode.Text + "' and g.KategoryID = k.KategoryID and g.InstructorID = s.ID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox1.Text = reader.GetValue(1).ToString(); //Group
                    textBox2.Text = reader.GetValue(2).ToString(); //Dataon
                    textBox3.Text = reader.GetValue(3).ToString(); //Dataoff
                    textBox4.Text = reader.GetValue(9).ToString(); //Kateg
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = reader.GetValue(12).ToString(); //Instr
                    textBox14.Text = "";
                    textBox15.Text = "";
                    toolStripButton2.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton5.Enabled = false;
                    toolStripButton6.Enabled = false;
                    button1.Enabled = false;
                }

                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM BD.dbo.[Group] g, Kategory k, Sotr s WHERE g.NameGroup = '" + treeView1.SelectedNode.Text + "' and g.KategoryID = k.KategoryID and g.PrepodID = s.ID";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBox13.Text = reader.GetValue(12).ToString(); //Prepod
                    toolStripButton2.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton5.Enabled = false;
                    toolStripButton6.Enabled = false;
                }

                connection.Close();
            }
        }

        private void Autoschool_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "DELETE [BD].[dbo].[Zachet] WHERE ID = '" + ID + "'; DELETE [BD].[dbo].[Uchenik] WHERE ID = '" + ID + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            treeView1.Nodes.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group]";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
        }

        private void Autoschool_Activated(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group] WHERE Arhiv = 0";
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void архивToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Arhiv newfrm = new Arhiv();
            newfrm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Вы действительно хотите добавить группу в архив!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "UPDATE [BD].[dbo].[Group] SET Arhiv = 1 WHERE NameGroup = '" + textBox1.Text + "'";
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
                var CommandText = "SELECT NameGroup FROM [BD].[dbo].[Group] WHERE Arhiv = 0";
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
