using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using static System.Console;
using Products;
using System.Reflection;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        const int NumberOfProducts = 15;

        const int NumberOfDifferentProducts = 3;

        const int NumberOfEachItem = 5;


        public int MoneyPool { get; set; }
        public int MoneySpent { get; set; }


        readonly int[] MoneyValues = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        List<Product> products = new List<Product>();


        public VendingMachine() //Creates VM with standrard values
        {
            MoneyPool = 0;
            MoneySpent = 0;

            for (int i = 0; i < NumberOfEachItem; i++)
            {
                foreach (Type type in Assembly.GetAssembly(typeof(Product)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract
                    && myType.IsSubclassOf(typeof(Product))))
                {
                    products.Add((Product)Activator.CreateInstance(type));
                }
            }
 
        }

    

        public int EndTransaction()
        {
            if (MoneyPool > 0)
            {
                return MoneyPool;
            }
            else return -1;
        }

        public bool InsertMoney(int money)
        {


            if (MoneyValues.Contains(money))
            {
                switch (money)
                {
                    case (1):
                        MoneyPool += 1;

                        break;
                    case (5):
                        MoneyPool += 5;

                        break;
                    case (10):
                        MoneyPool += 10;

                        break;
                    case (20):
                        MoneyPool += 20;

                        break;
                    case (50):
                        MoneyPool += 50;

                        break;
                    case (100):
                        MoneyPool += 100;

                        break;
                    case (500):
                        MoneyPool += 500;

                        break;
                    case (1000):
                        MoneyPool += 1000;

                        break;
                    default:

                        break;
                }

                return true;
            }
            else
            {
                return false;
            }

        }


        public bool Purchase(int number)
        {

            if (EnoughMoney(number))
            {
                MoneySpent += products.ElementAt(number).Price;
                MoneyPool -= products.ElementAt(number).Price;
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ShowAll()
        {
            for (int i = 0; i < NumberOfDifferentProducts; i++)
            {
                WriteLine($"{products.ElementAt(i).Examine()}");
            }
        }


        public bool EnoughMoney(int number)
        {
            int price = 0;


            price = products.ElementAt(number).Price;


            if (MoneyPool >= price)
                return true;
            else
                return false;
        }


        public int CheapestPrice()
        {
            int[] numbers = new int[]
            { products.ElementAt(0).Price,
                products.ElementAt(1).Price,
                products.ElementAt(2).Price };

            return numbers.Min();
        }
    }
}
