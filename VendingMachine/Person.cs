using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    abstract class Person
    {

        public double Balance { get; set; }
        public int Id { get; internal set; }
        List<Produkt> cart = new List<Produkt>();


        public override string ToString()
        {
            return Balance + " ";
        }

        public static void Perches(Produkt item)
        {

        }
    }
}
