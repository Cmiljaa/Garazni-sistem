using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Garaza
    {
        private List<Vozilo> garaza = new List<Vozilo>();
        private Dictionary<int, string> parking = new Dictionary<int, string>(30); 
        private bool Kraj = true;

        public void Pokreni()
        {
            while (Kraj)
            {
                Console.WriteLine("\n1. Unesi vozilo");
                Console.WriteLine("2. Pretraga vozila");
                Console.WriteLine("3. Ispis svih vozila");
                Console.WriteLine("4. Izmeni vozilo");
                Console.WriteLine("5. Izbriši vozilo");
                Console.WriteLine("6. Izlaz");
                Console.Write("Izaberite opciju: ");
                int unos = -1;
                try
                {
                     unos = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Morate uneti broj!");
                    continue;
                }
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
                        IzbrisiVozilo();
                        break;
                    case 6:
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
            if (parking.Count == 30)
            {
                Console.WriteLine("Garaža je puna!");
                return;
            }
            Console.WriteLine("\n" + "1. Automobil");
            Console.WriteLine("2. Kamion");
            Console.Write("Izaberite tip vozila: ");
            int vrsta = -1;
            try{
                vrsta = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Morate uneti broj!");
                return;
            }
            switch (vrsta)
            {
                case 1:
                    Automobil automobil = new Automobil();
                    automobil.Citaj();
                    automobil.PostaviMesto(DodeliMesto(automobil.DajRegistraciju()));
                    garaza.Add(automobil);
                    Console.WriteLine("Vozilo uspešno dodato!");
                    break;
                case 2:
                    Kamion kamion = new Kamion();
                    kamion.Citaj();
                    kamion.PostaviMesto(DodeliMesto(kamion.DajRegistraciju()));
                    garaza.Add(kamion);
                    Console.WriteLine("Vozilo uspešno dodato!");
                    break;
                case 3:
                    Kamion kamion = new Kamion();
                    kamion.Citaj();
                    kamion.PostaviMesto(DodeliMesto(kamion.DajRegistraciju()));
                    garaza.Add(kamion);
                    Console.WriteLine("Vozilo uspešno dodato!");
                    break;
                default:
                    Console.WriteLine("Nepostojeći tip vozila!");
                    break;
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
            int pretraga = -1;
            try
            {
                pretraga = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Morate uneti broj!");
                return;
            }
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
                    int vozilo = -1;
                    try
                    {
                        vozilo = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Morate uneti broj!");
                        return;
                    }
                    switch (vozilo)
                    {
                        case 1:
                            foreach (Automobil x in garaza)
                            {
                                x.Info();
                            }
                            break;
                        case 2:
                            foreach (Kamion x in garaza)
                            {
                                x.Info();
                            }
                            break;
                        default:
                            Console.WriteLine("Ne postoji ta vrsta vozila!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Nepostojeći način pretrage!");
                    break;
            }
        }

        private int DodeliMesto(string Registracija)
        {
            for (int i = 1; i <= 30; i++)
            {
                if (!parking.ContainsKey(i))
                {
                    parking.Add(i, Registracija);
                    return i;
                }
            }
            return -1;
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

        private void IzbrisiVozilo()
        {
            Console.Write("\n" + "Unesite registraciju: ");
            string registracija = Console.ReadLine(); 
            int key = 0; int index = -1;

            foreach (Vozilo x in garaza)
            {
                if (x.ZadReg(registracija))
                {
                    index = garaza.IndexOf(x);
                    key = x.DajMesto();
                }
            }
            
            if (key == 0 || index == -1)
            {
                Console.WriteLine("Vozilo ne postoji u garaži!");
                return;
            }
            
            garaza.RemoveAt(index);
            parking.Remove(key);
            Console.WriteLine("Vozilo uspešno obrisano!");
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
                    return;
                }
            }
            Console.WriteLine("Vozilo ne postoji u garaži!"); 
        }
    }
}
