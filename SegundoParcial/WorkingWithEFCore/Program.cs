﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using WorkingWithEFCore.AutoGens;


using Northwind db = new();






/*
WriteLine($"Provider : {db.Database.ProviderName}");

// QueryingCategories();
// FilterIncludes();
// QueryingProducts();
// QueryingWithLike();
// GetRandomProduct();


#region CRUD
ListProducts();
    // Use of Create
    var resultAdd = AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    if(resultAdd.affected == 1)
    {
        WriteLine($"Add product succesful with ID: {resultAdd.productId}");
    }
ListProducts(new int[] {resultAdd.productId});

// Use of Update
// var resultUpdate = UpdateProductPrice(productNameStartWith:"La ", amount:40M);
// if(resultUpdate.affected == 1)
// {
//     WriteLine($"Increase price success for ID : {resultUpdate.productId}");
// }
// ListProducts(productsToHiglight: new[] {resultUpdate.productId});

// Use of better Update
var resultUpdateBetter = UpdateProductPriceBetter(productNameStartWith: "La ", amount: 20M);
if(resultUpdateBetter.affected > 0)
{
    WriteLine("Increase product price succesful.");
}
ListProducts(resultUpdateBetter.productsId);

// Use of Delete and Better Delete
WriteLine("About to delete all products that start with La ");
Write("Press Enter to continue : ");
if(ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProductsBetter(productNameStartWith: "La ");
    WriteLine($"{deleted} product(s) were deleted");
}
else
{
    WriteLine("Delete was cancelced");
}

ListProducts();


#endregion

*/

/*

ListCustomer(new string[] {"2"});

 var resultAdd = AddCustomer(CustomerId:"PAPA",CompanyName:"VoluntRED",ContactName:"Mario Muro",Address:"Colomos 2997",PostalCode:"44630");

 if(resultAdd.affected == 1)
    {
        WriteLine($"Add customer succesful with ID: {resultAdd.CustomerId}");
    }

ListCustomer(new string [] {"Colomos 2997"});



var resultUpdateBetter = UpdateCustomer(ContactNameWith: "Maria", PostalCode:"404");

if(resultUpdateBetter.affected > 0)
{
    WriteLine("Modificacion Adresses succesful.");
}

ListCustomer(resultUpdateBetter.Adresses);


int deleted = DeleteCustomer(CompanyName:"VoluntRED");

WriteLine($"{deleted} customers(s) were deleted");


ListCustomer(new string [] {"*"});


*/
/*

ListCategory(new int[] {2});

var resultAdd1 = AddCategory(CategoryName : "Pizzas", Description : "Pizzas de todo tipo");

  if(resultAdd1.affected == 1)
    {
        WriteLine($"Add category succesful with ID: {resultAdd1.CategoryId}");
    }

var resultAdd2 = AddCategory(CategoryName : "Comida", Description : "Comida de todo tipo");

  if(resultAdd2.affected == 1)
    {
        WriteLine($"Add category succesful with ID: {resultAdd2.CategoryId}");
    }

var resultAdd3 = AddCategory(CategoryName : "Sushi", Description : "Sushi de todo tipo");

  if(resultAdd3.affected == 1)
    {
        WriteLine($"Add category succesful with ID: {resultAdd3.CategoryId}");
    }

ListCategory(new int[] {resultAdd1.CategoryId,resultAdd2.CategoryId,resultAdd3.CategoryId});

var resultUpdateBetter = UpdateCategory(CategoryName: "Comida", description:"your food favorite");
if(resultUpdateBetter.affected > 0)
{
    WriteLine("category modified succesfull.");
}

ListCategory(resultUpdateBetter.CategoriesId);

int deleted = DeleteCategory(categoryName:"Comida");

WriteLine($"{deleted} categories were deleted");

ListCategory(new int[] {});

*/

/*
Clear();

#region practica 1
//Llamada a la funcion de paginacion, se le pasa el numero de pagina que se desea mostrar
Paginator(readNumPage());
#endregion


/*
#region practica 2


while (true)
{

    using (Northwind db = new())
    {
        //captacion de campo a analizar media, moda , mediana
        int opcion;
        do
        {
            Info("Escribe el número del campo que deseas buscar: ");
            WriteLine("1) ProductID");
            WriteLine("2) ProductName");
            WriteLine("3) SupplierID");
            WriteLine("4) CategoryID");
            WriteLine("5) QuantityPerUnit");
            WriteLine("6) UnitPrice");
            WriteLine("7) UnitsInStock");
            WriteLine("8) UnitsOnOrder");
            WriteLine("9) ReorderLevel");
            WriteLine("10) Discontinued");

        } while (!int.TryParse(ReadLine(), out opcion) || (opcion < 1 || opcion > 10));


        //si el campo es 10 se hace un if para saber si es true o false, debido a que es un booleano
        if (opcion == 10)
        {
            //Se llamada cada una de las funciones y se adapta al contexto del booleano

            decimal? media = db.Products.CalcularMedia(opcion);

            if (media == 0)
            {
                Sectiontitle("Media : false");
            }
            else
            {
                Sectiontitle("Media : true");
            }


            decimal? mediana = db.Products.CalcularMediana(opcion);

            if (mediana == 0)
            {
                Sectiontitle("Mediana : false");
            }
            else
            {
                Sectiontitle("Mediana : true");
            }


            if (db.Products.CalcularModa(opcion) != null)
            {
                decimal?[]? moda = db.Products.CalcularModa(opcion);

                if (moda[0] == 0)
                {
                    Sectiontitle("Moda : false");
                }
                else
                {
                    Sectiontitle("Moda : true");
                }

            }
            else
            {
                Sectiontitle("No hay moda");

            }




        }
        else
        {

            //Se llamada cada una de las funciones y se adapta al contexto del campo

            Sectiontitle($"Media : {db.Products.CalcularMedia(opcion)}");
            Sectiontitle($"Mediana : {db.Products.CalcularMediana(opcion)}");

            if (db.Products.CalcularModa(opcion) != null)
            {
                decimal?[]? moda = db.Products.CalcularModa(opcion);

                foreach (var item in moda)
                {
                    Sectiontitle($"Moda : {item}");
                }
            }
            else
            {
                Sectiontitle("No hay moda");

            }

        }
    }

  

    #endregion

  
    

}

*/

