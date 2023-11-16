
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using WorkingWithEFCore.AutoGens;





public partial class Program
{

    public static void Paginator(int numPages)

    //Determina la cantidad de productos que se mostraran por pagina
    {
        int pageSize = numPages;
        int currentPage = 1;
        int totalPages;

        while (true)
        {
            //Listar productos por pagina
            totalPages = ListarProducts(pageSize, currentPage);

            //Control de paginacion, teclas y que no se desborde

            var key = ReadKey(intercept: true).Key;

            if (key == ConsoleKey.LeftArrow && currentPage > 1)
            {
                currentPage--;
            }
            else if (key == ConsoleKey.RightArrow && currentPage < totalPages)
            {
                currentPage++;
            }
            else if (key == ConsoleKey.Escape)
            {
                return;
            }

        }


    }

    public static int ObtenerTotalPages(int pageSize){

        //Obtener la cantidad de paginas que se mostraran, de acuerdo los elementos que se quieren mostrar
         using (Northwind db = new Northwind())
        {
            var products = db.Products.ToList();

        return (products.Count + pageSize - 1) / pageSize;

        }
        
    }

    public static int ListarProducts(int pageSize, int currentPage)

    //Lista los productos de acuerdo a la pagina que se le pase
    {
        using (Northwind db = new Northwind())
        {
            var products = db.Products.ToList(); // Obtén los productos desde la base de datos.

            int totalPages = ObtenerTotalPages(pageSize);

            if (products.Count == 0)
            {
                WriteLine("No hay productos");
                return 0;
            }

            Clear();

            int startIndex = (currentPage - 1) * pageSize;

            WriteLine("---------------------------------------------------------------------------------------");

            WriteLine("|{0,-4} | {1,-32} | {2,-10} | {3,-10} | {4,-17}|",
                "PID", "PName", "PStock", "Discount", "Category");
            WriteLine("---------------------------------------------------------------------------------------");

            for (int i = startIndex; i < products.Count && i < startIndex + pageSize; i++)
            {
          

                var product = products[i];

                string categoryName = db.Categories
                    .Where(c => c.CategoryId == product.CategoryId)
                    .Select(c => c.CategoryName)
                    .FirstOrDefault() ?? "No hay";

                string discount = product.Discontinued ? "Yes" : "No";

                WriteLine($"|{product.ProductId,-4} | {product.ProductName,-32} | {product.UnitsInStock,-10} | {discount,-10} | {categoryName,-17}|");
            
            }

            WriteLine("---------------------------------------------------------------------------------------");

            WriteLine($"|{pageSize,-4} {currentPage,+30} / {totalPages,-34}{"T:",+11}{products.Count}|");


            WriteLine("---------------------------------------------------------------------------------------");


            return totalPages;

        }



    }

    public static int readNumPage()

    //Funcion para que el usuario ingrese el numero de elementos que quiere mostrar por pagina
    {
        int numPages;
        do
        {
            WriteLine("Elija la cantidad de productos que quiere ver por pagina?");
            WriteLine("Opciones :");
            WriteLine("1");
            WriteLine("5");
            WriteLine("10");
            WriteLine("25");
            WriteLine("50");

        } while (!int.TryParse(ReadLine(), out numPages) || (numPages != 1 && numPages != 5 && numPages != 10 && numPages != 25 && numPages != 50));
        return numPages;
    }


    // READ
}





