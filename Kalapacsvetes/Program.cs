using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Sportolo> sportolok = new List<Sportolo>();

                string[] sorok = File.ReadAllLines("kalapacsvetes.txt");

            // Első sor kihagyása (fejléc)
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(';');

                int helyezes = int.Parse(adatok[0]);
                double eredmeny = double.Parse(adatok[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                string nev = adatok[2];
                string orszagKod = adatok[3];
                string helyszin = adatok[4];
                DateTime datum = DateTime.Parse(adatok[5]);

                sportolok.Add(new Sportolo(helyezes, eredmeny, nev, orszagKod, helyszin, datum));
            }

            foreach (var sportolo in sportolok)
            {
                Console.WriteLine(sportolo);
            }
        }
    }
}
