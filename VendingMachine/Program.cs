using System;
using System.Linq;
using static System.Console;
using Products;
using System.Collections.Generic;
using System.Text;

namespace Vending
{
    class Program
    {
        public static VendingMachine vm;
        public static List<string> chosenProducts = new List<string>();

        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            // Vending machine takes number of each item as parameter
            vm = new VendingMachine(10); 

            vm.ShowAll();

            EnterMoney_Iterate(); // Enter money fase

            Purchase_Iterate(); // Purchase fase

            FinalizeBuy(); ; // End transaction face

            ReadKey();
        }

        private static void FinalizeBuy()
        {
            int change = vm.EndTransaction();
            if (change >= 0)
            {
                ShowTransactions();
                WriteLine($"\nCustomer receives {change} kr in change");
                WriteLine("Have a nice day!");
            }
            else
            {
                WriteLine("Arithmetical error. Contact support.");
            }
        }

        // Shows total number of purchases
        private static void ShowTransactions()
        {
            Clear();
            vm.ShowAll();

            WriteLine("You bought a total of:\n");
            var selectQuery =
            from word in chosenProducts
            group word by word into g
            select new { Word = g.Key, Count = g.Count() };
            foreach (var word in selectQuery)
                Console.WriteLine($"{word.Word}: {word.Count}");
        }

        private static void Purchase_Iterate()
        {
            bool running = true;
            bool first = true;

            while (running)
            {
                if (first)
                {
                    UpdateDisplay(1);
                }

                Write("\nPlease choose product to buy: ");
                bool inputOk = Int32.TryParse(ReadLine(), out int productID);

                if (inputOk)
                {
                    if (productID != 0)
                    {
                        if (productID > 0 && productID <= vm.GetNumberOfDifferentProducts())
                        {
                            bool solvent = vm.Purchase(productID);
                            if (solvent)
                            {
                                first = false;
                                chosenProducts.Add(vm.GetBrand(productID));
                                UpdateDisplay2(productID);

                                if (vm.MoneyPool == 0 || vm.MoneyPool <= vm.CheapestPrice())
                                {
                                    running = false;
                                }
                            }
                            else
                            {
                                if (vm.IsSoldOut(productID))
                                {
                                    UpdateDisplay(1);
                                    WriteLine("\nThis product is sold out.");
                                    first = false;
                                }
                                else
                                {
                                    UpdateDisplay(1);
                                    WriteLine("\nYou don't have enough money to buy that product.");
                                    first = false;
                                }
                            }
                        }
                        else
                        {
                            UpdateDisplay(1);
                            WriteLine("\nInvalid produkt ID.");
                            first = false;
                        }
                    }
                    else
                    {
                        running = false;
                    }
                }
                else
                {
                    UpdateDisplay(1);
                    WriteLine("\nInvalid input.");
                    first = false;
                }
            }
        }

       
        private static void UpdateDisplay2(int productID)
        {
            Clear();
            vm.ShowAll();
            WriteLine($"Money left: {vm.MoneyPool} kr");
            WriteLine("Press 0 to finish.\n");
            WriteLine($"Thanks for buying a {vm.GetBrand(productID)}");
            WriteLine(vm.UserAdvise(productID));
            
        }

        private static void EnterMoney_Iterate()
        {
            bool running = true;
            while (running)
            {

                Write("\nPlease enter money: ");
                bool inputOk = Int32.TryParse(ReadLine(), out int money);
                if (inputOk)
                {
                    if (money != 0)
                    {
                        bool validAmount = vm.InsertMoney(money);
                        if (validAmount)
                        {
                            UpdateDisplay(1);

                        }
                        else
                        {
                            UpdateDisplay(1);
                            WriteLine("\nInvalid money input.");
                        }
                    }
                    else
                    {
                        bool solvent = CheckIfEnoughMoney();
                        if (!solvent)
                        {
                            running = false;
                        }
                        else
                        {
                            if (WantsRefund())
                            {
                                EndEarly();
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    UpdateDisplay(1);
                    WriteLine("\nInvalid input.");
                }

            }
        }

        // When customer aborts without making any purchases....
        private static void EndEarly()
        {
            WriteLine($"\nCustomer receives {vm.EndTransaction()} kr in change");
            WriteLine("Have a nice day!");
            Environment.Exit(0);
        }

        //....then he can request a refund
        private static bool WantsRefund()
        {
            bool running = true;
            bool answer = false;

            Clear();
            vm.ShowAll();

            WriteLine("Money inserted: " + vm.MoneyPool);
           

            WriteLine("\nYou don't have enough money for purchase.");
            WriteLine("Press 0 if you wan't to stop and get a refund,");
            WriteLine("or 1 if you wan't to insert more money.\n");
            Write("Enter input: ");

            while (running)
            {
                bool inputOk = Int32.TryParse(ReadLine(), out int output);

                if (inputOk)
                {
                    if (output == 0)
                    {
                        answer = true;
                        running = false;
                    }
                    else if (output == 1)
                    {
                        answer = false;
                        running = false;
                    }
                    else
                    {
                        WriteLine("Invalid innput number.");
                    }
                   
                }
                else
                {
                    WriteLine("Invalid input.");
                }

            }
            return answer;
        }

        private static bool CheckIfEnoughMoney()
        {
            
            if (vm.MoneyPool < vm.CheapestPrice())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void UpdateDisplay(int module)
        {
            Clear();
            vm.ShowAll();
            if (module == 1)
            {
                WriteLine("Money inserted: " + vm.MoneyPool);
                WriteLine("Press 0 to finish.");
            }
            else
            {
                WriteLine("Money left: " + vm.MoneyPool);
                WriteLine("Press 0 to finish.");
            }

        }
    }
}
