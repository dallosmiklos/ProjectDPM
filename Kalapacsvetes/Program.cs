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


        static void Befejez()
        {
            Console.WriteLine("Enterre befejez");
            Console.ReadLine();
        }

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





            Console.WriteLine("\nStatisztikák");
            Console.WriteLine($"Legjobb eredmény: {sportolok.Max(s => s.Eredmeny)} m");
            Console.WriteLine($"Legrosszabb eredmény: {sportolok.Min(s => s.Eredmeny)} m");
            Console.WriteLine($"Átlagos eredmény: {sportolok.Average(s => s.Eredmeny):F2} m");
            Console.WriteLine($"Resztvevők száma: {sportolok.Count}");



            List<double> rendezettEredmenyek = new List<double>();
            for (int i = 0; i < sportolok.Count; i++)
            {
                rendezettEredmenyek.Add(sportolok[i].Eredmeny);
            }
            rendezettEredmenyek.Sort();

            double median;
            int n = rendezettEredmenyek.Count;
            if (n % 2 == 0)
                median = (rendezettEredmenyek[n / 2 - 1] + rendezettEredmenyek[n / 2]) / 2;
            else
                median = rendezettEredmenyek[n / 2];

            Console.WriteLine($"Medián eredmény: {median} m");



            Console.WriteLine("\nAdja meg az országkódot a szűréshez: ");
            string keresetOrszag = Console.ReadLine().ToUpper();

            List<Sportolo> szurtSportolok = new List<Sportolo>();
            for (int i = 0; i < sportolok.Count; i++)
            {
                if (sportolok[i].OrszagKod == keresetOrszag)
                {
                    szurtSportolok.Add(sportolok[i]);
                }
            }

            Console.WriteLine("\nSzűrt eredmények: ");
            for (int i = 0; i < szurtSportolok.Count; i++)
            {
                Console.WriteLine(szurtSportolok[i]);
            }

            string fajl = "szurt_eredmenyek.txt";
            List<string> szurtSportolokStr = new List<string>();
            for (int i = 0; i < szurtSportolok.Count; i++)
            {
                szurtSportolokStr.Add(szurtSportolok[i].ToString());
            }

            File.WriteAllLines(fajl, szurtSportolokStr.ToArray());

            Console.WriteLine($"\nSzűrt adatok mentve a(z) {fajl} fájlba.");


            Befejez();

        }
    }
}
