using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Products
{
   
    public abstract class Product
    {
        public abstract int Number { get; }
        public abstract string Brand { get;}
        public abstract int Price { get; }
       
       


        public abstract string Examine();

        public abstract string Use();

        public abstract void Remove();

        public abstract int Quantity();
       
    }

    public class Soda: Product 
    {
        public override int Number { get; }
        public override string Brand { get; }
        public override int Price { get; }

       

        public static int Counter;
       
        public Soda()
        {
            Number = 1;
            Brand = "Trocadero";
            Price = 20;
            Counter++;
        }


        public override string Examine()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append($"#{Number}. {Brand}\t{Price} kr\t{Counter} st kvar");

            return sb.ToString();
        }

        public override string Use()
        {
            return $"Customer drinks the {Brand}";
        }

        public override void Remove()
        {
            Counter--;
        }

        public override int Quantity()
        {
            return Counter;
        }
    }


    public class Sandwich: Product
    {
        public override int Number { get; }
        public override string Brand { get; }
        public override int Price { get; }

        public static int Counter;

        public Sandwich()
        {
            Number = 2;
            Brand = "Sandwich";
            Price = 55;
            Counter++;
        }


        public override string Examine()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append($"#{Number}. {Brand}\t{Price} kr\t{Counter} st kvar");

            return sb.ToString();
        }

        public override string Use()
        {
            return $"Customer eats the {Brand}";
        }

        public override void Remove()
        {
            Counter--;
        }

        public override int Quantity()
        {
            return Counter;
        }
    }

    public class Candy: Product
    {
        public override int Number { get; }
        public override string Brand { get; }
        public override int Price { get; }


        public static int Counter;

        public Candy()
        {
            Number = 3;
            Brand = "Choklad";
            Price = 15;
            Counter++;
        }


        public override string Examine()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append($"#{Number}. {Brand}\t{Price} kr\t{Counter} st kvar");

            return sb.ToString();
        }

        public override string Use()
        {
            return $"Customer eats the {Brand}";
        }

        public override void Remove()
        {
            Counter--;
        }

        public override int Quantity()
        {
            return Counter;
        }
    }


    public class Snacks : Product
    {
        public override int Number { get; }
        public override string Brand { get; }
        public override int Price { get; }


        public static int Counter;

        public Snacks()
        {
            Number = 4;
            Brand = "Doodles";
            Price = 30;
            Counter++;
        }


        public override string Examine()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append($"#{Number}. {Brand}\t{Price} kr\t{Counter} st kvar");

            return sb.ToString();
        }

        public override string Use()
        {
            return $"Customer eats the {Brand}";
        }

        public override void Remove()
        {
            Counter--;
        }

        public override int Quantity()
        {
            return Counter;
        }
    }


    public class Beer : Product
    {
        public override int Number { get; }
        public override string Brand { get; }
        public override int Price { get; }


        public static int Counter;

        public Beer()
        {
            Number = 5;
            Brand = "Mariestad";
            Price = 75;
            Counter++;
        }


        public override string Examine()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append($"#{Number}. {Brand}\t{Price} kr\t{Counter} st kvar");

            return sb.ToString();
        }

        public override string Use()
        {
            return $"Customer enjoys a cold {Brand}";
        }

        public override void Remove()
        {
            Counter--;
        }

        public override int Quantity()
        {
            return Counter;
        }
    }
}
