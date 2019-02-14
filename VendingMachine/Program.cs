using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // static void moneyList()
            //{
            //    for (int i = 1; i < moneyArray.length + 1; i++)
            //    {
            //        System.out.println("\n " + i + " - " + moneyArray[i - 1] + ": SEK");
            //    }

            //}

            // static void setMoney()
            //{
            //    int[] coins = { 10, 30, 50, 100, 300, 500, 1000 };
            //    moneyArray = coins;
            //}


            List<Produkt> produkts = new List<Produkt>();


            produkts.Add(new Juice("Mountain Dew", 10, 0.33));
            produkts.Add(new Juice("Coca Cola", 10, 2));
            produkts.Add(new Juice("Red Bull", 20, 25));
            produkts.Add(new Juice("Merinda", 10, 0.33));
            produkts.Add(new Juice("Sprite", 10, 2));
            produkts.Add(new Juice("Looka", 10, 2));
            produkts.Add(new Juice("Fanta", 10, 0.33));
            produkts.Add(new Juice("Bravo", 25, 2));
            produkts.Add(new Juice("Pepsi", 10, 0.33));
            produkts.Add(new Juice("7Up", 10, 1.5));

            produkts.Add(new Snack("Snickers", 5, "Bar"));
            produkts.Add(new Snack("Skittles", 7, "Kollor"));
            produkts.Add(new Snack("MilkyWay", 5, "Bar"));
            produkts.Add(new Snack("Bounty", 5, "Bar"));
            produkts.Add(new Snack("Extra", 14, "tuggummi"));
            produkts.Add(new Snack("Orbit", 14, "tuggummi"));
            produkts.Add(new Snack("Oreo", 10, "Kex"));
            produkts.Add(new Snack("Twix", 5, "Bar"));
            produkts.Add(new Snack("Mars", 5, "Bar"));
            produkts.Add(new Snack("Kex", 5, "Bar"));

            produkts.Add(new Frukt("Granatäpple", 20, "ja"));
            produkts.Add(new Frukt("Apelsin", 10, "Ja"));
            produkts.Add(new Frukt("Kvitten", 10, "Nej"));
            produkts.Add(new Frukt("Citron", 10, "Ja"));
            produkts.Add(new Frukt("Ananas", 20, "ja"));
            produkts.Add(new Frukt("Äpple", 10, "Ibland"));
            produkts.Add(new Frukt("Mango", 15, "Nej"));
            produkts.Add(new Frukt("Päron", 10, "Nej"));
            produkts.Add(new Frukt("Banan", 10, "Nej"));
            produkts.Add(new Frukt("Kiwai", 10, "Ja"));






            bool go = true;
            while (go)
            {
                
                Console.Clear();
                Console.WriteLine("Select product to browse");
                Console.Write("1: Juice\n" +
                              "2: Snack\n" +
                              "3: Frukt\n" +
                              "4: Show list\n" +
                              "\nSelect = ");

                var userInput = Console.ReadKey();
                Console.WriteLine();
                var userSelectedProduct = new List<Produkt>();
                switch (userInput.Key)
                {

                    case ConsoleKey.D1:
                        //Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You selected Juice");
                        Console.ResetColor();
                        userSelectedProduct = new List<Produkt>();
                        foreach (var item in produkts)
                        {
                            if (item is Juice)
                            {
                                item.Info();
                                userSelectedProduct.Add(item);
                            }
                        }
                        AddList(userSelectedProduct);
                        break;
                    case ConsoleKey.D2:
                        //Console.Clear();
                        userSelectedProduct = new List<Produkt>();
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
                        AddList(userSelectedProduct);
                        break;
                    case ConsoleKey.D3:
                        //Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You selected Frukt");
                        Console.ResetColor();
                        userSelectedProduct = new List<Produkt>();
                        foreach (var item in produkts)
                        {
                            if (item is Frukt)
                            {
                                item.Info();
                                userSelectedProduct.Add(item);
                            }
                        }
                        AddList(userSelectedProduct);
                        break;
                    case ConsoleKey.D4:
                        PrintList(produkts);
                        break;
                    case ConsoleKey.D0:
                        go = false;
                        break;
                    default:
                        break;
                }

                
                

                Console.WriteLine("---------------");

                Console.ReadKey();
            }

        }
        static void AddList(List<Produkt> produkts)//ydalit
        {
            bool notFound = true;

            Console.WriteLine("--- Add to Cart ---");

            int selected = AskUserForNumberX("number of Product: ");//sdelat vibor!
            foreach (Produkt item in produkts)
            {
                if (item.Id == selected)
                {

                    Console.WriteLine(item);
                    notFound = false;
                    break;
                }
            }

        }
        static void PrintList(List<Produkt> produkts)//vizozivaet List<Person>
        {
            Console.Clear();
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


    }
}