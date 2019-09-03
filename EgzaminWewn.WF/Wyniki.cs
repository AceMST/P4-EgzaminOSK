using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgzaminWewn.WF
{
    public partial class Wyniki : Form
    {
        int wynik;
        void zakonczenie()
        {
            if (wynik > 4)
            {
                panel4.BackColor = System.Drawing.Color.Green;
                label4.BackColor =System.Drawing.Color.Green;
                label4.Text = "Pozytywny";
            }
            else
            {
                panel4.BackColor = System.Drawing.Color.Red;
                label4.BackColor = System.Drawing.Color.Red;
                label4.Text = "Negatywny";
            }
        }
        
        public Wyniki(int result)
        {
            InitializeComponent();
            label3.Text = result.ToString();
            wynik = result;
            zakonczenie();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
