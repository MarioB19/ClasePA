using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.AutoGens;
using System.Linq;

namespace NorthwindWeb.Pages
{
    public class AddCategoryModel : PageModel
    {  

        //Determinacion de los campos Bind para captarse desde la vista
        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        [BindProperty]
        public Category Category { get; set; }
        private Northwind db;

        //Anadir el contexto de la base de datos
        public AddCategoryModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        //Metodo post para agregar una nueva categoria con los campos del formulario enviado

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Agregar cambios y guardar
                db.Categories.Add(Category);
                db.SaveChanges();

                // Redirigir a la página principal
                return RedirectToPage("/index");
            }

            // Si hay errores de validación, vuelve a la página actual
            return Page();
        }
    }
}
