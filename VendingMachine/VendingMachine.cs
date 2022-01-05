using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using static System.Console;
using System.Reflection;
using Products;
using IVending;

namespace Vending
{
    // Vending Machine class totally independed of changes in the Products class.
    // You can add, remove and change properties in Products without changing the functionality
    // of the program.
    public class VendingMachine : IVendings
    {
       
        public int MoneyPool { get; set; }

        public static int NumberOfDifferentProducts;

        // Valid money values
        readonly int[] MoneyValues = { 1, 5, 10, 20, 50, 100, 500, 1000 };

        // List of products
        public List<Product> products = new List<Product>();

        //Creates VM with standrard values
        public VendingMachine(int NumberOfEachItem) 
        {
            MoneyPool = 0;         
          
           
            for (int i = 0; i < NumberOfEachItem; i++)
            {
                foreach (Type type in Assembly.GetAssembly(typeof(Product)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract
                    && myType.IsSubclassOf(typeof(Product))))
                {
                    products.Add((Product)Activator.CreateInstance(type));
                  
                }
            }

            NumberOfDifferentProducts = products.Count / NumberOfEachItem;
        }

    

        public int EndTransaction()
        {
            if (MoneyPool >= 0)
            {
                return MoneyPool;
            }
            return -1;
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

            if (EnoughMoney(number) && !IsSoldOut(number))
            {               
                MoneyPool -= products.ElementAt(number - 1).Price;
                products.ElementAt(number - 1).Remove();
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ShowAll()
        {
            
            WriteLine("\n\n\t***Vending Machine***");
            WriteLine("------------------------------------");
            for (int i = 1; i <= NumberOfDifferentProducts; i++)
            {
                WriteLine("  "+products.ElementAt(i-1).Examine());
            }
            WriteLine("------------------------------------");
        }


        public bool EnoughMoney(int productID)
        {
            int price = products.ElementAt(productID - 1).Price;


            if (MoneyPool >= price)
                return true;
            else
                return false;
        }


        public int CheapestPrice()
        {
            int number = products.Count;
            int[] prices = new int[number];
            for (int i = 0; i < number; i++)
            {
                prices[i] = products.ElementAt(i).Price;
            }

            return prices.Min();
        }

        public string GetBrand(int produktID)
        {
            return products.ElementAt(produktID - 1).Brand;
        }

        public string UserAdvise(int produktID)
        {
            return products.ElementAt(produktID - 1).Use();
        }

        public bool IsSoldOut(int produktID)
        {
            if (products.ElementAt(produktID - 1).Quantity() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetNumberOfDifferentProducts()
        {
            return NumberOfDifferentProducts;
        }
    }
}
