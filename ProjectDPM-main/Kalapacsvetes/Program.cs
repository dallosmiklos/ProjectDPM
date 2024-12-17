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


        static void Befejez() //Enter lenyomásával bezárja a programot
        {
            Console.WriteLine("Enterre befejez");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            List<Sportolo> sportolok = new List<Sportolo>(); //Létrehoz egy listát a sportolókról

                string[] sorok = File.ReadAllLines("kalapacsvetes.txt"); // Beolvassa a megadott file-t

            // Első sor kihagyása (fejléc)
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(';');

                int helyezes = int.Parse(adatok[0]); //Kiirja az eredményeket számként
                double eredmeny = double.Parse(adatok[1].Replace(',', '.'), CultureInfo.InvariantCulture); //Kiirja az eredményeket számként
                string nev = adatok[2]; //Kiirja a versenyzők nevét
                string orszagKod = adatok[3];//Kiirja hogy az ország kódját ahol a verseny volt tartva
                string helyszin = adatok[4];//Kiirja a verseny helyszinét
                DateTime datum = DateTime.Parse(adatok[5]);//Kiirja a verseny dátumát

                sportolok.Add(new Sportolo(helyezes, eredmeny, nev, orszagKod, helyszin, datum));
            }
            //Sportólók listájának kiirása
                    

            Console.WriteLine("\nStatisztikák");
            Console.WriteLine($"Legjobb eredmény: {sportolok.Max(s => s.Eredmeny)} m");//Kiirja a Legtávolobb dobott eredményt Méterben
            Console.WriteLine($"Legrosszabb eredmény: {sportolok.Min(s => s.Eredmeny)} m");//Kiirja a legrosszabb dobott eredményt méterben
            Console.WriteLine($"Átlagos eredmény: {sportolok.Average(s => s.Eredmeny):F2} m");//Kiirja az átlagolt eredményt
            Console.WriteLine($"Resztvevők száma: {sportolok.Count}"); //Kiirja a résztvevőket összegezve


            //Kiszámitja a mediánt
            List<double> rendezettEredmenyek = new List<double>(); //Eredmények listája rendezéshez
            for (int i = 0; i < sportolok.Count; i++)
            {
                rendezettEredmenyek.Add(sportolok[i].Eredmeny); //Hozzáadja az eredményeket
            }
            rendezettEredmenyek.Sort(); //Eredmények növekvő sorrendbe rendezése

            double median;
            int n = rendezettEredmenyek.Count;
            if (n % 2 == 0) //Páros szám esetén
                median = (rendezettEredmenyek[n / 2 - 1] + rendezettEredmenyek[n / 2]) / 2;
            else //páratlan szám esetén
                median = rendezettEredmenyek[n / 2];

            Console.WriteLine($"Medián eredmény: {median} m");


            //Szürés országkód alapján
            Console.WriteLine("\nAdja meg az országkódot a szűréshez: "); //Bekéri az országkódot a felhasználótól
            string keresetOrszag = Console.ReadLine().ToUpper();

            List<Sportolo> szurtSportolok = new List<Sportolo>(); ==  // Szürt sportolók listája
            for (int i = 0; i < sportolok.Count; i++)
            {
                if (sportolok[i].OrszagKod == keresetOrszag) //Ha az országkód egyezik 
                {
                    szurtSportolok.Add(sportolok[i]); //hozzáadaj a szürt listához
                }
            }

            Console.WriteLine("\nSzűrt eredmények: ");
            for (int i = 0; i < szurtSportolok.Count; i++)
            {
                Console.WriteLine(szurtSportolok[i]); //a kiszürt sportoló adatainak megjelénitése
            }
            //Szürt adatok mentése file-ban 
            string fajl = "szurt_eredmenyek.txt";
            List<string> szurtSportolokStr = new List<string>(); //File-ban mentendő adatok
            for (int i = 0; i < szurtSportolok.Count; i++)
            {
                szurtSportolokStr.Add(szurtSportolok[i].ToString()); // Sportoló adatait átalakitja szöveggé
            }

            File.WriteAllLines(fajl, szurtSportolokStr.ToArray()); //Beleirja a file-ba az adatokat

            Console.WriteLine($"\nSzűrt adatok mentve a(z) {fajl} fájlba."); //Kiirja ha sikeresen adott adatok müködtek és mentve lett a file


            Befejez();

        }
    }
}
