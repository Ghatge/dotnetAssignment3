using System;

namespace A2AkshayGhatge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                menu = Menu();
            }
        }
        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Get all Products");
            Console.WriteLine("2 - Get all Categories ");
            Console.WriteLine("3 - Get all Suppliers");
            Console.WriteLine("4 - Get Products by Category ID");
            Console.WriteLine("5 - Get Products by Supplier ID");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter your choice");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    NorthWind.GetProduct();
                    return true;
                case "2":
                    Console.Clear();
                    NorthWind.GetCategory();
                    return true;
                case "3":
                    Console.Clear();
                    NorthWind.GetSuppliers();
                    return true;
                case "4":
                    Console.Clear();
                   NorthWind. GetProdByCatID();
                    return true;
                case "5":
                    Console.Clear();
                    NorthWind.GetProdBySupID();
                    return true;
                case "6":
                    Environment.Exit(-1);
                    return false;
                default:

                    return true;
            }
        }
    }
}
