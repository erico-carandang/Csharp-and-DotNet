using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            QueryingProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related products
                IQueryable<Categories> cats = db.Categories;
                foreach (Categories c in cats)
                {
                    WriteLine($"{c.CategoryName} products.");
                }
            }
        }

        static void QueryingProducts() 
        { 
            using (var db = new Northwind()) 
            {
                WriteLine("Products that cost more than a price, highest at top."); 
                string input; 
                decimal price; 
                do 
                { 
                    Write("Enter a product price: "); 
                    input = ReadLine(); 
                } while (!decimal.TryParse(input, out price)); 
                IOrderedEnumerable<Products> prods = db.Products
                    .AsEnumerable()
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost); 
                foreach (Products item in prods) 
                { 
                    WriteLine(
                        "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.", 
                        item.ProductID, item.ProductName, item.Cost, item.Stock); 
                } 
            } 
        }

    }
}
