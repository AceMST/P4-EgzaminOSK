using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminWewn.WF
{
    class Losuj : Form1
    {
        int numer;
        Random rnd = new Random();
        public void losujNumer()
        {
            numer = rnd.Next(10);
            Console.WriteLine(numer);
        }
        
    }
}
