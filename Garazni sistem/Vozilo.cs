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
        protected string Vrsta { get; set; }

        private string Registracija { get; set; }

        private string Vlasnik { get; set; }

        private string Marka { get; set; }

        private string Model { get; set; }

        private int Parking_mesto { get; set; }

        private string Telefon { get; set; }

        public Vozilo(int _parking_mesto)
        {
            Parking_mesto = _parking_mesto;
        }

        public bool ZadRegVla(string vrsta, string parametar)
        {
            if (vrsta.ToLower() == "vlasnik")
                return Vlasnik == parametar;
            else
                return Registracija == parametar;
        }

        public bool ZadMarMod(string _Marka, string _Model)
        {
            return (Marka == _Marka) && (Model == _Model);
        }

        public bool ZadParMes(int _Parking_mesto)
        {
            return Parking_mesto == _Parking_mesto;
        }

        public virtual void Citaj()
        {
            Console.Write("Unesite registraciju:   ");
            Registracija = Console.ReadLine();
            Console.Write("Unesite model:   ");
            Model = Console.ReadLine();
            Console.Write("Unesite marku:   ");
            Marka = Console.ReadLine();
            Console.Write("Unesite vlasnika: ");
            Vlasnik = Console.ReadLine();
            Console.Write("Unesite telefon:  ");
            Telefon = Console.ReadLine();
        }

        public virtual string ToString()
        {
            return $"Registracija vozila {Registracija} Vlasnik vozila {Vlasnik} Telefon {Telefon} Broj parking mesta {Parking_mesto}";
        }
    }
}