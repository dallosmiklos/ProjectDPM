using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Sportolo
    {
        public int Helyezes { get; set; }
        public double Eredmeny { get; set; }
        public string Nev { get; set; }
        public string OrszagKod { get; set; }
        public string Helyszin { get; set; }
        public DateTime Datum { get; set; }

        public Sportolo(int helyezes, double eredmeny, string nev, string orszagKod, string helyszin, DateTime datum)
        {
            Helyezes = helyezes;
            Eredmeny = eredmeny;
            Nev = nev;
            OrszagKod = orszagKod;
            Helyszin = helyszin;
            Datum = datum;
        }

        public override string ToString()
        {
            return $"{Helyezes}; {Eredmeny}m; {Nev}; {OrszagKod}; {Helyszin}; {Datum.ToShortDateString()}";
        }
    }

}
