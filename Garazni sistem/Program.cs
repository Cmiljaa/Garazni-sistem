using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Garazni_sistem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garaza garaza1 = new Garaza();
            garaza1.Pokreni();

        }
    }
}