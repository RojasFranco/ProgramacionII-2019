﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Ingrese numero:");
            string valorIngresado = Console.ReadLine();
            Console.WriteLine(valorIngresado.CantidadDeDigitos());

            Console.ReadKey();
            
        }
    }
}
