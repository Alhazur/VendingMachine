using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Person
    {

        public double Balance { get; set; }
        public string Name { get; set; }

        List<Produkt> cart = new List<Produkt>();


        //public override string ToString()
        //{
        //    return Balance + " ";
        //}

        public void Perches(Produkt item)
        {
            cart.Add(item);
        }
    }
}
