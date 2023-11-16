using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


using WorkingWithEFCore.AutoGens;

partial class Program
{
    // READ
    static void ListCustomer(string [] ToRemarcar)
    {
        using (Northwind db = new())
        {
            if ((db.Customers is null) || (!db.Customers.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-8} | {1,-45} | {2,-30} | {3,-50} | {4,-10}",
            "Id", "Company", "ContactName", "Addres", "Postal code");

            foreach (var item in db.Customers)
            {

              if((ToRemarcar is not null) && ToRemarcar.Any(toRemarcar => item.Address.Contains(toRemarcar)))
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("| {0,-8} | {1,-45} | {2,-30} | {3,-50} | {4,-10}",
                    item.CustomerId, item.CompanyName, item.ContactName, item.Address, item.PostalCode);
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    WriteLine("| {0,-8} | {1,-45} | {2,-30} | {3,-50} | {4,-10}",
                    item.CustomerId, item.CompanyName, item.ContactName, item.Address, item.PostalCode);
                }
                ForegroundColor = ConsoleColor.White;

            }

        }

    }

     static (int affected, string CustomerId) AddCustomer(string CustomerId, string CompanyName, string ContactName, string Address, string PostalCode)
    {
        using(Northwind db = new())
        {
            if(db.Customers is null) return (0,"0");
            Customer p = new()
            {
                CustomerId = CustomerId,
                CompanyName = CompanyName,
                ContactName = ContactName,
                Address = Address,
                PostalCode = PostalCode
            };
            

            EntityEntry<Customer> entity = db.Customers.Add(p);
            WriteLine($"State: {entity.State} CustomerId: {CustomerId}" );
            // SAVE THE CHANGES ON DB
            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State} CustomerId: {p.CustomerId}" );
            return (affected, p.CustomerId);
        };
    }




    static (int affected, string [] ?Adresses) UpdateCustomer(string ContactNameWith, string PostalCode)
    {
        using(Northwind db = new())
        {
            if(db.Customers is null) return (0,null);
            // Get the first product that start with productNameStartWith
            IQueryable<Customer>? customers =
            db.Customers.Where(
                p => p.ContactName.StartsWith(ContactNameWith));

            int affected = customers.ExecuteUpdate(u => u.SetProperty(
                p => p.PostalCode, // Property Selctor
                p => PostalCode // Value to edit
            ));


            string []? CustomersId = customers.Select( p => p.Address).ToArray();

            return (affected, CustomersId);
        }
    }


      static int DeleteCustomer(string CompanyName)
    {
        using(Northwind db = new())
        {
            int affected = 0;
            IQueryable<Customer>? customers = db.Customers?.Where(
                p => p.CompanyName.StartsWith(CompanyName));
            if(customers is null || !customers.Any())
            {
                WriteLine("No products to delete");
                return 0;
            }
            else
            {
                affected = customers.ExecuteDelete();
            }
            return affected;
            
        }
    }



    
}
