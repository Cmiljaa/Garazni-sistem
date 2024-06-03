using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Kamion : Vozilo
    {
        private double Visina { get; set; }
        private double Duzina { get; set; }

        public Kamion(int _parking_mesto) : base(_parking_mesto) {}

        public override void Citaj()
        {
            base.Citaj();
            Console.Write("Unesite visinu: ");
            Visina = double.Parse(Console.ReadLine());
            if (Visina > 2.5)
                throw new Exception("Kamion je previsok!");
            Console.Write("Unesite duzinu: ");
            Duzina = double.Parse(Console.ReadLine());
            if (Duzina > 5.3)
                throw new Exception("Kamion je predugacak!");
        }

        public override string ToString()
        {
            return string.Format($"Vrsta vozila: Kamion Registracija vozila {Registracija} Vlasnik vozila {Vlasnik} Telefon {Telefon} Broj parking mesta {Parking_mesto} ");
        }
    }
}
