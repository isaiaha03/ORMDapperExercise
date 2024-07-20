using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.IO;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            /*
            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("A New Department");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
            }
            */
            #endregion

            #region Product Section
            var productRepo = new DapperProductRepository(conn);

            // productRepo.CreateProduct("A New Product", 99.99, 10);

            /*
            var productToUpdate = productRepo.GetProduct(942);
            productToUpdate.Name = "UPDATED!";
            productToUpdate.Price = 10;
            productToUpdate.CategoryID = 1;
            productToUpdate.OnSale = true;
            productToUpdate.StockLevel = 99;
            productRepo.UpdateProduct(productToUpdate);
            */

            productRepo.DeleteProduct(942);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
            }

            #endregion
        }
    }
}
