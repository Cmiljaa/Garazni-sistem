﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Automobil : Vozilo
    {
        private string Karoserija { get; set; }

        public Automobil(int _parking_mesto) : base(_parking_mesto) { Vrsta = "Automobil"; }

        public bool ZadKar(string _Karoserija)
        {
            return Karoserija == _Karoserija;
        }

        public override void Citaj()
        {
            base.Citaj();
            Console.Write("Unesite karoseriju:   ");
            Karoserija = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Vrsta vozila {Vrsta}, {base.ToString()} Karoserija {Karoserija}";
        }
    }
}