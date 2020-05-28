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
    public partial class Zachet : Form
    {
        int z1,z2,z3,z4,z5,z6,z7,z8,z9,z10;
        string id;
        string name;

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "Зачёт по теме 2 СДАН!";
            z2 = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "Зачёт по теме 2 НЕ СДАН!";
            z2 = 0;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "Зачёт по теме 3 СДАН!";
            z3 = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "Зачёт по теме 3 НЕ СДАН!";
            z3 = 0;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Зачёт по теме 4 СДАН!";
            z4 = 1;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Зачёт по теме 4 НЕ СДАН!";
            z4 = 0;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = "Зачёт по теме 5 СДАН!";
            z5 = 1;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = "Зачёт по теме 5 НЕ СДАН!";
            z5 = 0;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Text = "Зачёт по теме 6 СДАН!";
            z6 = 1;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Text = "Зачёт по теме 6 НЕ СДАН!";
            z6 = 0;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = "Зачёт по теме 7 СДАН!";
            z7 = 1;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = "Зачёт по теме 7 НЕ СДАН!";
            z7 = 0;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Text = "Зачёт по теме 8 СДАН!";
            z8 = 1;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Text = "Зачёт по теме 8 НЕ СДАН!";
            z8 = 0;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Text = "Зачёт по теме 9 СДАН!";
            z9 = 1;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Text = "Зачёт по теме 9 НЕ СДАН!";
            z9 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox6.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox7.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox8.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox9.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox10.Enabled = true;
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Text = "Зачёт по теме 10 СДАН!";
            z10 = 1;
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Text = "Зачёт по теме 10 НЕ СДАН!";
            z10 = 0;
        }

        public Zachet(string ID, string Name)
        {
            InitializeComponent();
            id = ID;
            name = Name;
            textBox1.Text = name;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            var CommandText = "UPDATE [BD].[dbo].[Zachet] SET Z1 = '" + z1 + "', Z2 = '" + z2 + "', Z3 = '" + z3 + "', Z4 = '" + z4 + "', Z5 = '" + z5 + "', Z6 = '" + z6 + "', Z7 = '" + z7 + "', Z8 = '" + z8 + "', Z9 = '" + z9 + "', Z10 = '" + z10 + "' WHERE ID = '" + id + "'";
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

        private void Zachet_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            using (SqlConnection connection = new SqlConnection(Config.configuration))
            {
                connection.Open();
                var CommandText = "SELECT * FROM Zachet WHERE ID = '" + id + "'";
                SqlCommand command = new SqlCommand
                {
                    CommandText = CommandText,
                    Connection = connection
                };
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                    z1 = Convert.ToInt32(reader.GetValue(1).ToString());
                    z2 = Convert.ToInt32(reader.GetValue(2).ToString());
                    z3 = Convert.ToInt32(reader.GetValue(3).ToString());
                    z4 = Convert.ToInt32(reader.GetValue(4).ToString());
                    z5 = Convert.ToInt32(reader.GetValue(5).ToString());
                    z6 = Convert.ToInt32(reader.GetValue(6).ToString());
                    z7 = Convert.ToInt32(reader.GetValue(7).ToString());
                    z8 = Convert.ToInt32(reader.GetValue(8).ToString());
                    z9 = Convert.ToInt32(reader.GetValue(9).ToString());
                    z10 = Convert.ToInt32(reader.GetValue(10).ToString());
                connection.Close();
            }
            if(z1 == 1)
            {
                textBox2.Text = "Зачёт по теме 1 СДАН!";
                groupBox1.Enabled = false;
            }
            else
            {
                textBox2.Text = "Зачёт по теме 1 НЕ СДАН!";
            }


            if (z2 == 1)
            {
                textBox3.Text = "Зачёт по теме 2 СДАН!";
                groupBox3.Enabled = false;
            }
            else
            {
                textBox3.Text = "Зачёт по теме 2 НЕ СДАН!";
            }


            if (z3 == 1)
            {
                textBox4.Text = "Зачёт по теме 3 СДАН!";
                groupBox2.Enabled = false;
            }
            else
            {
                textBox4.Text = "Зачёт по теме 3 НЕ СДАН!";
            }


            if (z4 == 1)
            {
                textBox5.Text = "Зачёт по теме 4 СДАН!";
                groupBox4.Enabled = false;
            }
            else
            {
                textBox5.Text = "Зачёт по теме 4 НЕ СДАН!";
            }


            if (z5 == 1)
            {
                textBox6.Text = "Зачёт по теме 5 СДАН!";
                groupBox5.Enabled = false;
            }
            else
            {
                textBox6.Text = "Зачёт по теме 5 НЕ СДАН!";
            }


            if (z6 == 1)
            {
                textBox7.Text = "Зачёт по теме 6 СДАН!";
                groupBox6.Enabled = false;
            }
            else
            {
                textBox7.Text = "Зачёт по теме 6 НЕ СДАН!";
            }


            if (z7 == 1)
            {
                textBox8.Text = "Зачёт по теме 7 СДАН!";
                groupBox7.Enabled = false;
            }
            else
            {
                textBox8.Text = "Зачёт по теме 7 НЕ СДАН!";
            }


            if (z8 == 1)
            {
                textBox9.Text = "Зачёт по теме 8 СДАН!";
                groupBox8.Enabled = false;
            }
            else
            {
                textBox9.Text = "Зачёт по теме 8 НЕ СДАН!";
            }


            if (z9 == 1)
            {
                textBox10.Text = "Зачёт по теме 9 СДАН!";
                groupBox9.Enabled = false;
            }
            else
            {
                textBox10.Text = "Зачёт по теме 9 НЕ СДАН!";
            }


            if (z10 == 1)
            {
                textBox11.Text = "Зачёт по теме 10 СДАН!";
                groupBox10.Enabled = false;
            }
            else
            {
                textBox11.Text = "Зачёт по теме 10 НЕ СДАН!";
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Зачёт по теме 1 СДАН!";
            z1 = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Зачёт по теме 1 НЕ СДАН!";
            z1 = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
