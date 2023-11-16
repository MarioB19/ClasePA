using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.AutoGens;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWeb.Pages
{
    public class CategoriesModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        private Northwind db;

        //Injeccion del contexto de la base de datos
        public CategoriesModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        //Metodo get para listar todas las categories
        public void OnGet()
        {
            
            Categories = db.Categories.ToList();
        }

        //Metodo post para eliminar una categoria
        public IActionResult OnPostDelete(long id)
        {
            var categoryToDelete = db.Categories.Find(id);

            if (categoryToDelete != null)
            {
                //Remover la categoria de la base de datos y guardar cambios
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
            }
            

            return RedirectToPage("/index");
        }
    }
}
