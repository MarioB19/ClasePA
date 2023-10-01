namespace PA17F.Shared;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public class Person
{

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


public string? Name;
public DateTime DateOfBirth;


//Delegates

public int MethodWantToCall(string input)
{
    return input.Length;

}

public delegate int DelegateWithMatchSignature (string s);


//1st Step , Event Handler
public delegate void EventHandler(object? sender, EventArgs e);


//delegate field
private  EventHandler? Shout;

//Date field for delegate

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





}
