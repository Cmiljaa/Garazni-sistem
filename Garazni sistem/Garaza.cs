using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Garaza
    {
        private List<Vozilo> garaza = new List<Vozilo>();
        private int Brojac = 0;
        private bool Kraj = true;

        public void Pokreni()
        {
            while (Kraj)
            {
                Console.WriteLine("\n1. Unesi vozilo");
                Console.WriteLine("2. Pretraga vozila");
                Console.WriteLine("3. Ispis svih vozila");
                Console.WriteLine("4. Izmeni vozilo");
                Console.WriteLine("5. Izlaz");
                Console.Write("Izaberite opciju: ");

                int unos = int.Parse(Console.ReadLine());
                switch (unos)
                {
                    case 1:
                        DodajVozilo();
                        break;
                    case 2:
                        PretraziVozilo();
                        break;
                    case 3:
                        IspisiVozila();
                        break;
                    case 4:
                        IzmeniVozilo();
                        break;
                    case 5:
                        Kraj = false;
                        break;
                    default:
                        Console.WriteLine("Pogrešna komanda!");
                        break;
                }
            }
        }

        private void DodajVozilo()
        {
            if (Brojac == 30)
            {
                Console.WriteLine("Garaža je puna!");
                return;
            }
            Console.WriteLine("\n" + "1. Automobil");
            Console.WriteLine("2. Kamion");
            Console.Write("Izaberite tip vozila: ");
            int vrsta = int.Parse(Console.ReadLine());
            if (vrsta == 1)
            {
                Automobil automobil = new Automobil(garaza.Count + 1);
                automobil.Citaj();
                garaza.Add(automobil);
                Brojac++;
            }
            else if (vrsta == 2)
            {
                Kamion kamion = new Kamion(garaza.Count + 1);
                kamion.Citaj();
                garaza.Add(kamion);
                Brojac++;
            }
            else
            {
                Console.WriteLine("Pogrešna komanda!");
            }
        }

        private void PretraziVozilo()
        {
            Console.WriteLine("\n" + "Pretraga po:");
            Console.WriteLine("1. Registraciji:");
            Console.WriteLine("2. Vlasniku:");
            Console.WriteLine("3. Marki i modelu:");
            Console.WriteLine("4. Parking mestu:");
            Console.WriteLine("5. Vrsti vozila:");
            Console.Write("Izaberite način pretrage: ");
            int pretraga = int.Parse(Console.ReadLine());
            switch (pretraga)
            {
                case 1:
                    Console.Write("Unesite registraciju: ");
                    string registracija1 = Console.ReadLine();
                    foreach (Vozilo x in garaza)
                    {
                        if (x.ZadReg(registracija1))
                            x.Info();
                    }
                    break;
                case 2:
                    Console.Write("Unesite vlasnika: ");
                    string vlasnik = Console.ReadLine();
                    foreach (Vozilo x in garaza)
                    {
                        if (x.ZadVla(vlasnik))
                            x.Info();
                    }
                    break;
                case 3:
                    Console.Write("Unesite marku: ");
                    string marka = Console.ReadLine();
                    Console.Write("Unesite model: ");
                    string model = Console.ReadLine();
                    foreach (Vozilo x in garaza)
                    {
                        if (x.ZadMarMod(marka, model))
                            x.Info();
                    }
                    break;
                case 4:
                    Console.Write("Unesite broj parking mesta: ");
                    int mesto = int.Parse(Console.ReadLine());
                    foreach (Vozilo x in garaza)
                    {
                        if (x.ZadParMes(mesto))
                            x.Info();
                    }
                    break;
                case 5:
                    Console.WriteLine("1. Automobil:");
                    Console.WriteLine("2. Kamion:");
                    Console.Write("Odaberite vrstu vozila: ");
                    int vozilo = int.Parse(Console.ReadLine());
                    if (vozilo == 1)
                    {
                        foreach (Automobil x in garaza)
                        {
                            x.Info();
                        }
                    }
                    else if (vozilo == 2)
                    {
                        foreach (Kamion x in garaza)
                        {
                            x.Info();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ne postoji ta vrsta vozila!");
                    }
                    break;
                default:
                    Console.WriteLine("Nepostojeći način pretrage!");
                    break;
            }
        }
        
        private void IspisiVozila()
        {
            if(garaza.Count() == 0)
            {
                Console.WriteLine("Garaža je prazna!");
            }
            foreach (Vozilo x in garaza)
            {
                Console.WriteLine(x);
            }
        }

        private void IzmeniVozilo()
        {
            Console.Write("\n" + "Unesite registraciju: ");
            string registracija = Console.ReadLine();
            foreach (Vozilo x in garaza)
            {
                if (x.ZadReg(registracija))
                {
                    x.Citaj();
                }
            }
        }
    }
}
