using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    abstract class Produkt
    {
        static int countId = 0;
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string FullName { get { return Name + " Och " + Price + ":-"; } }

        public Produkt(int Id, string Name)
        {
            this.Id = Id;
            this.Price = Price;
            this.Name = Name;

        }
        public Produkt(string Name, int Price)
        {
            Id = ++countId;
            this.Price = Price;
            this.Name = Name;
        }


        public virtual void Info()
        {
            Console.Write("   Select: ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Id);
            Console.ResetColor();

            Console.WriteLine(" Name: " + Name + " Price: " + Price + ":-");//pokazivaet imya obeih klassov potomychto odno imya na dvoih
        }
        override public string ToString()//Det är visas in i (show list)
        {
            return Id + ": " + FullName;

        }
    }
}
