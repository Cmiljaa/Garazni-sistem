using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal abstract class Vozilo
    {
        protected string Registracija { get; set; }
        
        protected string Vlasnik { get; set; }

        private string Marka { get; set; }

        private string Model { get; set; }

        protected int Parking_mesto { get; set; }

        protected string Telefon { get; set; }

        public Vozilo(int _parking_mesto)
        {
            Parking_mesto = _parking_mesto;
        }

        public bool ZadReg(string _Registracija)
        {
            return Registracija == _Registracija;
        }

        public bool ZadVla(string _Vlasnik)
        {
            return Vlasnik == _Vlasnik;
        }

        public bool ZadMarMod(string _Marka, string _Model)
        {
            return (Marka == _Marka) && (Model == _Model);
        }

        public bool ZadParMes(int _Parking_mesto)
        {
            return Parking_mesto == _Parking_mesto;
        }

        public void Info()
        {
            Console.WriteLine($"Broj parking mesta {Parking_mesto} Vlasnik {Vlasnik} Telefon {Telefon}");
        }

        public virtual void Citaj()
        {
            Console.Write("Unesite registraciju: ");
            Registracija = Console.ReadLine();
            Console.Write("Unesite marku: ");
            Marka = Console.ReadLine();
            Console.Write("Unesite model: ");
            Model = Console.ReadLine();
            Console.Write("Unesite vlasnika: ");
            Vlasnik = Console.ReadLine();
            Console.Write("Unesite telefon: ");
            Telefon = Console.ReadLine();
        }

        public abstract override string ToString();

    }
}