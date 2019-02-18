﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class VendingMachine
    {
        static readonly int[] moneyArray = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };

        public double MoneyPool { get; set; }
        public List<Produkt> produkts { get; set; }

        public VendingMachine(List<Produkt> produkts)
        {
            this.produkts = produkts;
        }

        public void StartMachine()
        {
            Console.WriteLine("Welkom to Vending Machine");

            Person person = new Person() { Name = "Eriksson" };


            bool go = true;
            while (go)
            {

                Console.WriteLine("Select product to browse");
                Console.Write("1: Juice\n" +
                              "2: Snack\n" +
                              "3: Frukt\n" +
                              "0: Exit\n" +
                              "\nSelect = ");

                var userInput = Console.ReadKey();

                List<Produkt> userSelectedProduct = new List<Produkt>();
                Console.Clear();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You selected Juice");
                        Console.ResetColor();

                        foreach (var item in produkts)
                        {
                            if (item is Juice)
                            {
                                item.Info();
                                userSelectedProduct.Add(item);

                            }
                        }
                        AddList(person, userSelectedProduct);
                        break;
                    case ConsoleKey.D2:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You selected Snack");
                        Console.ResetColor();

                        foreach (var item in produkts)
                        {
                            if (item is Snack)
                            {
                                item.Info();
                                userSelectedProduct.Add(item);
                            }
                        }
                        AddList(person, userSelectedProduct);
                        break;
                    case ConsoleKey.D3:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You selected Frukt");
                        Console.ResetColor();

                        foreach (var item in produkts)
                        {
                            if (item is Frukt)
                            {
                                item.Info();
                                userSelectedProduct.Add(item);
                            }
                        }
                        AddList(person, userSelectedProduct);
                        break;
                    case ConsoleKey.D4:

                        break;
                    case ConsoleKey.D0:
                        go = false;
                        break;
                    default:
                        break;
                }
                

                Console.Write("Do you want buy more?\nEnter 1 to continue\nEnter 2 to exit");
                userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        StartMachine();
                        break;
                    case ConsoleKey.D2:

                        Change change = new Change(person.Balance);
                        

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your chenge is: " + person.Balance + ": SEK");
                        Console.ResetColor();

                        Console.WriteLine($"500 Banknote: x {change.FemHundra}: SEK");
                        Console.WriteLine($"200 Banknote: x {change.TvåHundra}: SEK");
                        Console.WriteLine($"100 Banknote: x {change.EttHundra}: SEK");
                        Console.WriteLine($"50 Banknote: x {change.Femtio}: SEK");
                        Console.WriteLine($"20 Banknote: x {change.Tjogo}: SEK");
                        Console.WriteLine($"10 coins: x {change.Tio}: SEK");
                        Console.WriteLine($"5 coins: x {change.Fem}: SEK");
                        Console.WriteLine($"1 coins: x {change.Ett}: SEK");
                        Console.WriteLine("\nThenks for your puchase!");
                        go = false;
                        break;
                }

                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        void moneyList()
        {

            for (int i = 1; i < moneyArray.Length + 1; i++)
            {
                Console.WriteLine(i + " - " + moneyArray[i - 1] + ": SEK");
            }

        }

        void AddList(Person person, List<Produkt> selectedProdukts)
        {
            bool notFound = true;

            int selected = AskUserForNumberX("Number of Product: ");//sdelat vibor!
            foreach (Produkt item in selectedProdukts)
            {
                if (item.Id == selected)
                {

                    Perches(person, item);
                    notFound = false;
                    break;
                }
            }

        }
        static void PrintList(List<Produkt> produkts)//vizozivaet List<Person>
        {

            foreach (Produkt item in produkts)//pokazivaet iz Lista
            {
                Console.WriteLine(item);

            }

        }

        static string AskUserForX(string x)//prosit text imya ili nazvanie
        {
            string Input = "";
            while (Input.Length == 0)
            {
                Console.Write("Please input " + x + ": ");
                Input = Console.ReadLine();
            }
            return Input;// while zavershit svoe dejstvie return vernet k nachala dejstvi
        }
        static int AskUserForNumberX(string x)//prosit nomer ili vozrost pri sozdani chegoto
        {
            int number = 0;
            bool noNumber = true;
            while (noNumber)
            {
                try
                {
                    number = Convert.ToInt32(AskUserForX(x));
                    noNumber = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number, Please try once more.");
                }
            }
            return number; // vozvroshaet k metody a v metode vaible togda nado pisat nazvanie variabla
        }

        public void Perches(Person person, Produkt produkt)
        {

            moneyList();

            bool go = true;
            while (go)
            {
                int moneyIndex = AskUserForNumberX("value");
                person.Balance = moneyArray[moneyIndex - 1];


                if (produkt.Price > person.Balance)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{produkt.Name} for {produkt.Price}: SEK.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Can not buy for: " + person.Balance + ": Sek, you need more money!");
                    Console.ResetColor();

                    go = false;


                }
                else
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{person.Name} Bought: {produkt.Name} for {produkt.Price}: SEK. Item was send to the card");
                    Console.ResetColor();

                    person.Balance -= produkt.Price;
                    person.Perches(produkt);
                    Console.WriteLine("Your remaining money is: " + person.Balance + ": SEK");
                    go = false;

                }

            }

        }

    }
}
