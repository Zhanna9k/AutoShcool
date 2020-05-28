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
    public partial class Users : Form
    {
        public int index;
        public string cell="";
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private DataGridView dataGridView1;

        public Users()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UserAdd newfrm = new UserAdd(index,cell);
            newfrm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            UserAdd newfrm = new UserAdd(index,cell);
            newfrm.Show();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(355, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(355, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Server_autoscрool.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "Добавить";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Server_autoscрool.Properties.Resources.documentedit;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "Редактировать";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Server_autoscрool.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "Удалить";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Server_autoscрool.Properties.Resources.cancel;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton4.Text = "Закрыть";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click_1);
            // 
            // Users
            // 
            this.ClientSize = new System.Drawing.Size(355, 310);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Activated += new System.EventHandler(this.Users_Activated);
            this.Load += new System.EventHandler(this.Users_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Users_Load_1(object sender, EventArgs e)
        {
            string[] table_headers = new string[0];
            table_headers = new[] { "ID", "Пользователь", "Пароль" };
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT * FROM[BD].[dbo].[User]";
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

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "DELETE[BD].[dbo].[User] WHERE ID = '"+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            string[] table_headers = new string[0];
            table_headers = new[] { "ID", "Пользователь", "Пароль" };
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT * FROM[BD].[dbo].[User]";
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

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            index = 0;
            UserAdd newfrm = new UserAdd(index,cell);
            newfrm.Show();
            
        }

        private void Users_Activated(object sender, EventArgs e)
        {
            string[] table_headers = new string[0];
            table_headers = new[] { "ID", "Пользователь", "Пароль", "Роль" };
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                var CommandText = "SELECT * FROM[BD].[dbo].[User]";
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

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cell = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            index = 1;
            UserAdd newfrm = new UserAdd(index,cell);
            newfrm.Show();
        }
    }
}
