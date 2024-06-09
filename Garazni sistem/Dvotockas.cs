using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Dvotockas : Vozilo
    {
        private string Vrsta { get; set; }

        public override void Citaj()
        {
            base.Citaj();
            Console.Write("Unesite vrstu vozila: ");
            Vrsta = Console.ReadLine();
        }

        public override string ToString()
        {
            return string.Format($"{Vrsta}, Registracija {Registracija}, Vlasnik {Vlasnik}, Telefon {Telefon}, Broj parking mesta {Parking_mesto}");
        }
    }
}
