namespace PA17F.Shared;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Xml.Serialization;



 //[xml atribbute]

public class Person
{

  public Person(decimal initialSalary){
    Salary = initialSalary;
  }

#region Apuntes
    /*
    members
    constat , readonly , events

    Constant : Solo una vez declarada
      no puede cambiar en tiempo de ejecucion

    Read-only
    Similar a constante pero se pueden cambiar los valores con un constructor

    Events
    Es una referencia a un metodo

*/


    /*
    Methods : Igual que funciones pero en contexto de POO
   Contructor : Se ejecuta cuando se crea una instancia de la clase , y ejecutas el NEW

   Property :

   member -> int number = 0;

   property -> string Name{get; set;} getter and setters , esto lo hace una propiedad

   Indexers []
   Operators : + = =>  * / &

   



*/

#endregion

public Person()
{
}
//members
[XmlAttribute("fname")]
public string? Name { get; set; }
[XmlAttribute("lname")]
public string? LastName { get; set; }

[XmlAttribute("cumple")]
public DateTime DateOfBirth;


protected decimal Salary { get; set; }

public HashSet<Person> ? Children{ get; set; }








//Delegates

public int MethodWantToCall(string input)
{
    return input.Length;

}

//public delegate int DelegateWithMatchSignature (string s);


//1st Step , Event Handler
//public delegate void EventHandler(object? sender, EventArgs e);


//delegate field
//private  EventHandler? Shout;

//Date field for delegate


/*
public int AngerLevel;

public void Poke(){
    AngerLevel++;
    if (AngerLevel >= 3)

    {

      if(Shout != null){
        //despues llama el delegado
         Shout(this,EventArgs.Empty);

      }

       
    }
  AngerLevel++;
}

*/





}
