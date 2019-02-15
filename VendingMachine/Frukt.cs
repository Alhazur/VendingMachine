using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class Frukt : Produkt
    {
        public string Sour { get; set; }


        public Frukt(int id, string name, int prise, string sour) : base(id, name)
        {

            Price = prise;
            Sour = sour;

        }
        public Frukt(string name, int price, string sour) : base(name, price)
        {

            Price = price;
            Name = name;
            Sour = sour;
        }
        public override void Info()
        {
            Console.Write("Does it sour? " + Sour);
            base.Info();

        }
        

    }
}
