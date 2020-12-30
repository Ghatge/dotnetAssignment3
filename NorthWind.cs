using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace A2AkshayGhatge
{
    class NorthWind
    {
      
        static string GetConnectionString()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("configuration.json");
            IConfiguration config = configurationBuilder.Build(); 
            return config["ConnectionStrings:NorthWindLocalDB"];
        }


        public static void GetProduct()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query ="select p.ProductID,p.ProductName,c.CategoryName,s.CompanyName  from Products p inner join" +
                " Categories c on c.CategoryID = p.CategoryID inner join Suppliers s on s.SupplierID = p.SupplierID";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Product ID",7} {"Product Name",-35} {"Category Name",-30} {"Company Name",-20}");
            Console.WriteLine("=======================================================================================================");
            while (reader.Read())
            {
                int id = (int)reader["ProductID"];
                string prodName = (string)reader["ProductName"];
                string catName = (string)reader["CategoryName"];
                string compName = (string)reader["CompanyName"];
                
                Console.WriteLine($"{id,10} {prodName,-35} {catName,-30} {compName,-20}");

            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();

        }
        public static void GetCategory()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select CategoryID, CategoryName from Categories";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Category ID",1} {"Category Name",17}");
            Console.WriteLine("========================================================");
            while (reader.Read())
            {
                int catid = (int)reader["CategoryID"];
                string catName = (string)reader["CategoryName"];


                Console.WriteLine($"{catid,-15} {catName,-25}");

            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
          
        }

        public static void GetSuppliers()
        {
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select SupplierID, CompanyName from Suppliers";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Supplier ID",7} {"Supplier Name",-20}");
            Console.WriteLine("========================================================");
            while (reader.Read())
            {
                int supid = (int)reader["SupplierID"];
                string compName = (string)reader["CompanyName"];

                Console.WriteLine($"{supid,10} {compName,-40}");

            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();

        }
        public static void GetProdByCatID()
        {
            Console.WriteLine("Enter Category ID");
            string catID=Console.ReadLine();
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select p.ProductID,p.ProductName,c.CategoryName," +
                "s.CompanyName from Products p inner join Categories c " +
                "on c.CategoryID=p.CategoryID inner join Suppliers s on " +
                "s.SupplierID=p.SupplierID where c.CategoryID=@CategoryID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("CategoryID",catID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Product ID",7} {"Product Name",-30} {"Category Name",24} {"Company Name",20}");
            Console.WriteLine("========================================================================================");
            while (reader.Read())
            {
                int id = (int)reader["ProductID"];
                string prodName = (string)reader["ProductName"];
                string catName = (string)reader["CategoryName"];
                string compName = (string)reader["CompanyName"];
                Console.WriteLine($"{id,10} {prodName,-35} {catName,20} {compName,-25}");


            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();

        }
        public static void GetProdBySupID()
        {

            Console.WriteLine("Enter Supplier ID");
            string supID = Console.ReadLine();
            string cs = GetConnectionString();
            SqlConnection conn = new SqlConnection(cs);
            string query = "select p.ProductID,p.ProductName,c.CategoryName," +
                "s.CompanyName from Products p inner join Categories c " +
                "on c.CategoryID=p.CategoryID inner join Suppliers s on " +
                "s.SupplierID=p.SupplierID where s.SupplierID=@SupplierID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("SupplierID", supID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine($"{"Product ID",7} {"Product Name",-25} {"Category Name",22} {"Company Name",25}");
            Console.WriteLine("=================================================================================================");

            while (reader.Read())
            {
                int id = (int)reader["ProductID"];
                string prodName = (string)reader["ProductName"];
                string catName = (string)reader["CategoryName"];
                string compName = (string)reader["CompanyName"];
                Console.WriteLine($"{id,10} {prodName,-35} {catName,-25} {compName,-35}");


            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();

        }
    }
}
