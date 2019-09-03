using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgzaminWewn.WF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int numer;
        int Answer = 0;
        Random rnd = new Random();
        string losujNumer()
        {
            numer = rnd.Next(1, 5);
            return Convert.ToString(numer);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.ResetText();
            label3.BackColor = System.Drawing.Color.White;
            
            losujNumer();
            string connectionstring;
            SqlConnection cnn;
            connectionstring = @"Data Source=KONRAD;Initial Catalog=PytaniaEW;Integrated Security=true";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String Sql, Ans = "", Output = "", Obraz = "";

            Sql = "Select Tresc,Odpowiedz,sciezkaOB from PytanieAB Where Id_pytaniaAB =" + numer + "";
            command = new SqlCommand(Sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0);
                Ans = Ans + dataReader.GetValue(1);
                Obraz = Obraz + dataReader.GetValue(2);
            }
            pictureBox1.Image = Image.FromFile(@"C:\Users\Konrad\source\repos\EgzaminWewn.WF\EgzaminWewn.WF\obj\obraz\" + Obraz + "");
            label5.Text = Output;
            
            Answer = Convert.ToInt32(Ans);
            cnn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Answer == 1)
                {
                    label3.BackColor = System.Drawing.Color.Green;
                    label3.Text = "Poprawna odpowiedź";
                }
                else
                {
                    label3.BackColor = System.Drawing.Color.Red;
                    label3.Text = "Zła odpowiedź";
                }

            }
            if (radioButton2.Checked)
            {
                if (Answer == 2)
                {
                    label3.BackColor = System.Drawing.Color.Green;
                    label3.Text = "Poprawna odpowiedź";
                }
                else
                {
                    label3.BackColor = System.Drawing.Color.Red;
                    label3.Text = "Zła odpowiedź";
                }
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
