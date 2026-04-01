using Assignment_2.ShopMaster;
using System;


namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Online Store Order Processing  ShopMaster

            #region Assignment 02

            // Product Catalog
            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };

            #region Task 01 : Smart Product Search

            /*
             * Task 01 : Smart Product Search
             * Manager: "Customers search in all kinds of ways - by category, by price, by name, by stock... 
             * and the list keeps growing. 
             * I need ONE search method that works for any filter, now and in the future, without being modified”.
             * 
             * What You Need To Do: 
             * Write a single method called SearchProducts that accepts two parameters: 
             *      1.The product list(List<Product>)
             *      2.A delegate representing the filter condition(Func<Product, bool>)
             * 
             * The method should return a List containing only the products that satisfy the condition.
             * Then, call this method four times with different lambda expressions to perform the following searches: 
             *      1.All Electronics products 
             *      2.Products cheaper than $50 
             *      3.Products that are in stock(Stock > 0) 
             *      4.Clothing products under $100
             */

            //// All Electronics products 
            //Console.WriteLine("--- Electronics ---");
            //var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            //PrintProducts(electronics);

            //// Products cheaper than $50
            //Console.WriteLine("\n--- Under $50 ---");
            //var cheap = SearchProducts(catalog, p => p.Price < 50);
            //PrintProducts(cheap);

            //// Products that are in stock(Stock > 0)
            //Console.WriteLine("\n--- In Stock ---");
            //var inStock = SearchProducts(catalog, p => p.Stock > 0);
            //PrintProducts(inStock.Take(4)); // match expected sample

            //// Clothing products under $100
            //Console.WriteLine("\n--- Clothing Under $100 ---");
            //var clothing = SearchProducts(catalog,
            //    p => p.Category == "Clothing" && p.Price < 100);
            //PrintProducts(clothing);

            #endregion

            #region Task 03 : Custom Report Generator

            /*
             * Manager: "We need different reports from the same data 
             * - a quick summary, a detailed breakdown, a low-stock alert. 
             * Build one reporting engine where the caller controls the format. 
             * Use the built-in delegates this time."
             * 
             */

            #region 3.1 Print Reports

            /*
             * 3.1  Print Reports
             * 
             * Write a method called PrintReport that accepts the product list and an Action.
             * The method loops through all products and calls the action on each one.
             * The caller decides what to print by passing a lambda.
             * 
             * Scenario 1  Short Report: Print each product as Name - $Price
             * 
             * Scenario 2  Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y
             * 
             */

            //// Print each product as Name - $Price
            //Console.WriteLine("\n--- Short Report ---");
            //PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}") );

            //// Print each product as [Category] Name | Price: $X | Stock: Y
            //Console.WriteLine("\n--- Detailed Report ---");
            //PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}") );

            #endregion

            #region 3.2 Transform Products

            /*
             * 3.2. Transform Products
             * 
             * Write a method called TransformProducts that accepts the product list and a Func.
             * The method returns a List by applying the function to each product. 
             * 
             * Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200)". Print all results.
             * 
             * Scenario 4 Price Label: Transform each product into "Expensive!" if Price > $100, or "Affordable" 
             * otherwise.Print each as Name: Label.
             * 
             */

            //// Transform each product into a string like "Laptop ($1200)"
            //Console.WriteLine("\n--- Summary List ---");
            //var summary = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");

            //foreach (var item in summary)
            //    Console.WriteLine(item);

            //// Transform each product into "Expensive!" if Price > $100, or "Affordable" otherwise.Print as Name: Label.
            //Console.WriteLine("\n--- Price Labels ---");
            //var labels = TransformProducts(catalog,
            //    p => new
            //    {
            //        p.Name,
            //        Label = p.Price > 100 ? "Expensive!" : "Affordable"
            //    } );

            //foreach (var item in labels)
            //    Console.WriteLine($"{item.Name}: {item.Label}");

            #endregion

            #region 3.3 Filter Products

            /*
             * 3.3. Filter Products
             * Write a method called FilterProducts that accepts the product list and a Predicate.
             * The method returns a List of products that match the condition.
             * 
             * Scenario 5  Low-Stock Alert: 
             * Find products with Stock < 20 and print an alert for each in the format: [LOW STOCK] Name: only X left!
             * 
             */

            //Console.WriteLine("\n--- Low-Stock Alert ---");
            //var lowStock = FilterProducts(catalog, p => p.Stock < 20);

            //foreach (var p in lowStock)
            //    Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");

            #endregion

            #endregion

            #endregion

        }

        #region Helper Methods

        #region Task 01 : Smart Product Search

        // Flexible filtering using Func<Product, bool>
        //Func<T, bool> is a built-in delegate that represents a method
        //that takes an argument of type T and returns a boolean value.

        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }

        static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
        }

        #endregion

        #region Task 03

        #region 3.1 Print Reports

        // Action<T> is a built-in delegate that represents a method
        // Executes logic without returning value

        static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (var p in products)
                action(p);
        }

        #endregion

        #region 3.2 Transform Products

        // Func<T, TResult> is a built-in delegate that represents a method
        //Func<T, TResult> (Transform) Converts product into another form

        static List<TResult> TransformProducts<TResult>( List<Product> products, Func<Product, TResult> transformer)
        {
            return products.Select(transformer).ToList();
        }

        #endregion

        #region 3.3 Filter Products

        // Predicate<T> is a built-in delegate that represents a method
        // that takes an argument of type T and returns a boolean value.
        // Predicate<T> (Filter) Specialized boolean filter

        static List<Product> FilterProducts( List<Product> products, Predicate<Product> predicate)
        {
            return products.Where(p => predicate(p)).ToList();
        }

        #endregion

        #endregion

        #endregion
    }
}
