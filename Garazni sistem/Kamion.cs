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

        public override void Citaj()
        {
            base.Citaj();
            try
            {
                Console.Write("Unesite visinu: ");
                double visina = double.Parse(Console.ReadLine());
                if (visina > 2.5)
                {
                    throw new Exception("Kamion je previsok!");
                }

                Console.Write("Unesite duzinu: ");
                double duzina = double.Parse(Console.ReadLine());
                if (duzina > 5.3)
                {
                    throw new Exception("Kamion je predugacak!");
                }

                Visina = visina;
                Duzina = duzina;
            }
            catch (Exception)
            {
                throw new Exception("Neispravan format unosa!");
            }
        }

        public override string ToString()
        {
            return string.Format($"Kamion, Registracija {Registracija}, Vlasnik {Vlasnik}, Telefon {Telefon}, Broj parking mesta {Parking_mesto}");
        }
    }
}
