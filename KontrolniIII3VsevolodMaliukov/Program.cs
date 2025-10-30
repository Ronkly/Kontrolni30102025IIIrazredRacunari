using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ODGOVORI NA PITANJA - Нисам сигуран да је тачно. Последни одговор је сигурно тачан.
 * 1.   b
 * 2.   b
 * 3.   b
 * 4.   c
 * 5.   b
 * 6.   b
 * 7.   a
 */

namespace KontrolniIII3VsevolodMaliukov
{
    abstract class Racunar
    {
        protected string Proizvodjac { get; set; }
        protected string Procesor { get; set; }
        protected double Cena { get; set; }
        public Racunar (string proizvodjac, string procesor, double cena)
        {
            Proizvodjac = proizvodjac;
            Procesor = procesor;
            Cena = cena;
        }
        public void PromeniProcesor(string noviProc)
        {
            Procesor = noviProc;
            Console.WriteLine("Procesor je promenjen");
        }
        public abstract double RacunajPopust();
        public virtual void PrikaziDetalje()
        {
            Console.WriteLine("Proizvodjac: " + Proizvodjac);
            Console.WriteLine("Procesor: " + Procesor);
            Console.WriteLine("Cena: " + Cena);
        }
        public void ProveriCenu()
        {
            Console.WriteLine("Ovaj racunar je " + (Cena <= 25000 ? "budzetski" : (Cena <= 75000 ? "srednje klase" : "premium")));
        }
    }
    class Laptop : Racunar
    {
        private double Tezina { get; set; }
        private double Baterija { get; set; }
        public Laptop(string proizvodjac, string procesor, double cena, double tezina, double baterija)
            : base(proizvodjac, procesor, cena)
        {
            Tezina = tezina;
            Baterija = baterija;
        }
        public override double RacunajPopust()
        {   
            return (Baterija < 5 ? (Cena * 0.95) : (Cena * 0.90)); // Ako je baterija manje od 5h, onda se vraca 95% od popusta
        }
        public override void PrikaziDetalje()
        {
            base.PrikaziDetalje();
            Console.WriteLine("Tezina: " + Tezina + "kg");
            Console.WriteLine("Baterija: " + Baterija + "h");
        }
        public void ProveriPrenoslivost()
        {
            Console.WriteLine("Laptop je " + (Tezina < 1.5 ? "lagan" : (Tezina < 5 ? "prosecne tezine" : "tezak")));
        }
    }
    class Desktop : Racunar
    {
        private string Kuciste { get; set; }
        private bool ImaMonitor { get; set; }
        public Desktop (string proizvodjac, string procesor, double cena, string kuciste, bool imaMonitor) 
            :base (proizvodjac, procesor, cena)
        {
            Kuciste = kuciste;
            ImaMonitor = imaMonitor;
        }
        public override double RacunajPopust()
        {
            return (ImaMonitor ? (Cena * 0.85) : (Cena * 0.92));
        }
        public override void PrikaziDetalje()
        {
            base.PrikaziDetalje();
            Console.WriteLine("Kuciste: " + Kuciste);
            Console.WriteLine("Ima monitor: " + (ImaMonitor ? "da" : "ne"));
        }
        public void ProveriKomplet()
        {
            Console.WriteLine("Ovaj desktop " + (ImaMonitor ? "je" : "nije") + " kompletan.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Racunar> racunari = new Dictionary<int, Racunar>();
                racunari.Add(1, new Laptop("Dell", "Intel", 49999, 1.2, 4));
                racunari.Add(2, new Laptop("Apple", "Apple Silicon", 99999, 2.4, 12));
                racunari.Add(3, new Desktop("Corsair", "AMD", 78999, "Tower", true));
                racunari.Add(4, new Desktop("Mini-Yettel", "Intel", 119999, "Mini", false));
            foreach (Racunar r in racunari.Values)
            {
                r.PrikaziDetalje();
                r.ProveriCenu();
                if (r is Laptop laptop)
                    laptop.ProveriPrenoslivost();
                if (r is Desktop desktop)
                    desktop.ProveriKomplet();

                Console.WriteLine(new string('-', 25));
            }
            racunari[2].PromeniProcesor("Intel");
            Console.WriteLine(new string('-', 25));
            racunari.Remove(3);
            foreach (Racunar r in racunari.Values)
            {
                r.PrikaziDetalje();
                r.ProveriCenu();
                if (r is Laptop laptop)
                    laptop.ProveriPrenoslivost();
                if (r is Desktop desktop)
                    desktop.ProveriKomplet();

                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
