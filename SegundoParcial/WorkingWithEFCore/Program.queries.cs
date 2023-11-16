using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore;

partial class Program{


    static void QueryingCategories(){


        using(Northwind db  = new()){
            Sectiontitle($"Categories and how many products they have");


            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

            if(categories is null || !categories.Any()){
                  Fail("No categories found");
                return;
               
            }
            else{
                 foreach(Category c in categories){
                    Info($"{c.CategoryName} has {c.Products.Count} products.");
                }
              
            }





        
        
            





        }

    }


    static void QueryingProducts(){

        using(Northwind db = new()){

            Sectiontitle("Products that cost more than a price, sorted by price descending");

            string ?input;
            decimal price;
            
            do{
                Console.WriteLine("Enter a product price:");
                input = ReadLine();
            }while(!decimal.TryParse(input, out price));

            IQueryable<Product>? prods = db.Products?.Where(p => p.Cost >= price)?.OrderByDescending(p => p.Cost);

            Sectiontitle($"ToQueryString : {prods?.ToQueryString()}");

            if(prods is null || !prods.Any()){
                Fail("No products found");
                return;
            }
            else{
                foreach(Product p in prods){
                    Info($"{p.ProductId}: {p.ProductName} costs {p.Cost:$#,##0.00} and has {p.Stock} in stock.");
                }
            }

        }
    }


    static void QueryngWithLike(){

         using(Northwind db = new()){

        Sectiontitle("Pattern Matching with LIKE");

        string ?input = ReadLine();


        if(string.IsNullOrWhiteSpace(input)){
            Fail("Nothing to search");
            return;
        }

        IQueryable<Product>? prods = db.Products?.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

        

          Sectiontitle($"ToQueryString : {prods?.ToQueryString()}");

            if(prods is null || !prods.Any()){
                Fail("No products found");
                return;
            }
            else{
                foreach(Product p in prods){
                    Info($"{p.ProductName} has {p.Stock} units in stock. Discontinued? {p.Discontinued}");
                }
            }

         }
    }

    static void GetRandomProduct(){
        using( Northwind db = new()){
            Sectiontitle("Random Product");
            int ? rowCount = db.Products?.Count();


            if(rowCount is null || rowCount == 0){
                Fail("No products found");
                return;
            }
            Product? p = db.Products?.
            FirstOrDefault(p => p.ProductId == (int) (EF.Functions.Random() *rowCount));

            if(p is null){
                Fail("No products found");
                return;
            }
            else{
                Info("Random product:");
                Info($" ID : {p.ProductId} his name {p.ProductName} has {p.Stock} units in stock. Discontinued? {p.Discontinued}");
            }

        }
        
    }

}