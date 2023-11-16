using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace WorkingWithEFCore;


public class Category{


    public int CategoryId {get; set;}
    public string ?CategoryName {get; set;}

    [Column(TypeName = "ntext")]
    public string? Description {get; set;}


    //Navigation property (Son aquellas que permiten crear la relacion backend entre dos tablas)
    //Publicas , Virtual

    public virtual ICollection<Product> Products {get; set;}

    public Category(){

        //Incializar Products

        Products = new HashSet<Product>();

    }

}