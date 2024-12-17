using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Sportolo //Sportoló class a versenyzök adatainak tárolása
    {
        public int Helyezes { get; set; } //Versenyző helyezése a versenyen
        public double Eredmeny { get; set; } //Versenyző eredménye (dobott távolság)
        public string Nev { get; set; } //Versenyző Neve
        public string OrszagKod { get; set; } //Versenyző Ország Kódja
        public string Helyszin { get; set; } //Verseny helyszine
        public DateTime Datum { get; set; } //Verseny dátuma

        public Sportolo(int helyezes, double eredmeny, string nev, string orszagKod, string helyszin, DateTime datum)
        {
            Helyezes = helyezes; //Beállitja a versenyzők helyezését
            Eredmeny = eredmeny;//Beállitja a versenyzők eredményét
            Nev = nev;//Beállitja a versenyző nevét
            OrszagKod = orszagKod;//Beállitja az Országkódot
            Helyszin = helyszin;//Beállitja a Verseny Helyszinét
            Datum = datum;//Beállitja a Verseny Dátumát
        }

        public override string ToString() 
        {
            //Kiirat mindent egy sorban
            return $"{Helyezes}; {Eredmeny}m; {Nev}; {OrszagKod}; {Helyszin}; {Datum.ToShortDateString()}";
        }



    }

}
