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
    public partial class Form3 : Form
    {
        public int doWynikow;
        public Form3()
        {
            InitializeComponent();
        }
       public int wynik= 0;
        int Answer = 0;
        int liczPytan = 7;
        int[] pytania = new int[7];
        int licznik = 0;
        int tik = 15;
        Dictionary<int, int> wyniki = new Dictionary<int, int>();

        void losujNumer()
        {
            Random rand = new Random();
           
            int[] tab = new int[liczPytan];
            for (int i = 0; i < liczPytan; i++)
                tab[i] = i + 1;
            

            for (int i = 0; i < 7; i++)
            {
               
                int r = rand.Next(liczPytan);
               
                pytania[i] = tab[r];

                tab[r] = tab[liczPytan - 1];
                liczPytan--;
            }
        }
        void Podlicz()
        {
           wynik = wyniki.Sum(x => x.Value);
            
        }

        void Koniec()
        {
            Wyniki karta = new Wyniki(wynik);
            karta.Show();
        }

       public void NastPyt()
        {
            tik = 15;
            if (licznik ==6)
            {
                timer1.Stop();
                Podlicz();
                Koniec();
                Close();
            }
            string connectionstring;
            SqlConnection cnn;
            connectionstring = @"Data Source=KONRAD;Initial Catalog=PytaniaEW;Integrated Security=true";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String Sql, Ans = "", Output = "", Obraz = "";

            Sql = "Select Tresc,Odpowiedz,sciezkaOB from PytanieAB Where Id_pytaniaAB =" + pytania[licznik] + "";
            command = new SqlCommand(Sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0);
                Ans = Ans + dataReader.GetValue(1);
                Obraz = Obraz + dataReader.GetValue(2);
            }
            pictureBox1.Image = Image.FromFile(@"C:\Users\Konrad\source\repos\EgzaminWewn.WF\EgzaminWewn.WF\obj\obraz\" + Obraz + "");
            label4.Text = Output;

            Answer = Convert.ToInt32(Ans);
            cnn.Close();
            
            if (radioButton1.Checked)
            {
                if (Answer == 1)
                    wyniki.Add(pytania[licznik], 1);
                else
                    wyniki.Add(pytania[licznik], 0);
            }
            if (radioButton2.Checked)
            {
                if (Answer == 2)
                    wyniki.Add(pytania[licznik], 1);
                else
                    wyniki.Add(pytania[licznik], 0);
            }
            licznik++;
        }
        private void button1_Click(object sender, EventArgs e) // Start
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
            
            Sql = "Select Tresc,Odpowiedz,sciezkaOB from PytanieAB Where Id_pytaniaAB =" + pytania[licznik] + "";
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
            licznik++;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e) //Następne pytanie
        {
            NastPyt();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tik--;
            label3.Text = tik.ToString();
            if (tik ==0)
            {
                NastPyt();
                
                tik = 15;
               
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    
    
}
