using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;



partial class Program
{

   
    // READ
    static void ListCategory(int []? ToRemarcar = null)
    {
        using (Northwind db = new())
        {
            if ((db.Categories is null) || (!db.Categories.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-20} | {2,-70} |",
            "Id", "Name", "Description");

            foreach (var item in db.Categories)
            {

              if((ToRemarcar is not null) && ToRemarcar.Contains(item.CategoryId))
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("| {0,-3} | {1,-20} | {2,-70} |",
                    item.CategoryId, item.CategoryName, item.Description);
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    WriteLine("| {0,-3} | {1,-20} | {2,-70} |",
                    item.CategoryId, item.CategoryName, item.Description);
                }
                 
                   
                ForegroundColor = ConsoleColor.White;

            }

        }

    }


    //CREATE
     static (int affected, int CategoryId) AddCategory(string CategoryName, string Description)
    {
        using(Northwind db = new())
        {
            if(db.Categories is null) return (0,0);
            Category p = new()
            {
               
                CategoryName = CategoryName,
                Description = Description
            };
            

            EntityEntry<Category> entity = db.Categories.Add(p);
            WriteLine($"State: {entity.State} CategoryName: {CategoryName}" );
            // SAVE THE CHANGES ON DB
            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State} CategoryName: {p.CategoryName}" );
            return (affected, p.CategoryId);
        };
    }




    static (int affected, int [] ? CategoriesId) UpdateCategory(string CategoryName, string description)
    {
        using(Northwind db = new())
        {
            if(db.Categories is null) return (0,null);
            // Get the first product that start with productNameStartWith
            IQueryable<Category>? Categories =
            db.Categories.Where(
                p => p.CategoryName.StartsWith(CategoryName));

            int affected = Categories.ExecuteUpdate(u => u.SetProperty(
                p => p.Description, // Property Selctor
                p => description // Value to edit
            ));


            int []? CategoriesId = Categories.Select( p => p.CategoryId).ToArray();

            return (affected, CategoriesId);
        }
    }


      static int DeleteCategory(string categoryName)
    {
        using(Northwind db = new())
        {
            int affected = 0;
            IQueryable<Category>? Categories = db.Categories?.Where(
                p => p.CategoryName.StartsWith(categoryName));
            if(Categories is null || !Categories.Any())
            {
                WriteLine("No categories to delete");
                return 0;
            }
            else
            {
                affected = Categories.ExecuteDelete();
            }
            return affected;
            
        }
    }



    
}
