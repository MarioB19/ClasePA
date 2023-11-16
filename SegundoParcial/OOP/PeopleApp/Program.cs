

using System.Formats.Asn1;
using PA17F.Shared;
using static PA17F.Shared.Person;

Person wachi = new(300);



WriteLine($"Wachi is : {wachi.ToString()}");

wachi.Name = "Wachi";
wachi.DateOfBirth = new DateTime(2005, 12, 25);

WriteLine(format : "{0} was born on {1:dddd, d MMMM yyyy}", 
arg0 : wachi.Name, arg1 : wachi.DateOfBirth);

//Generic types
//List, Hash, Dictionary, <T> , <TKey , TValue>

Dictionary<int,string> lookUpIntString = new Dictionary<int,string>();

lookUpIntString.Add(1,"Alpha");
lookUpIntString.Add(2,"Beta");
lookUpIntString.Add(3,"Gamma");
lookUpIntString.Add(4,"tetha");

foreach (var key in lookUpIntString.Keys)
{
    WriteLine($"{key} has value of : {lookUpIntString[key]}");
}


//CalMethod()
///public string CalMethod(int id) 
//firma del metodo que va a usar como delegado
//firma : tipo de retorno , parametros que recibe (method signature)
//mandar funciones como tipos de datos
//delegado que haga match con la firma del metodo que voy a mandar a llamar
//tienen que tener el mismo tipo de parametros y el mismo tipo de retorno


#region  manera Convencional de llamar a un metodo
Person Jordi = new(200);
int answer = Jordi.MethodWantToCall("Alfred");

#endregion


/*

#region manera facil para usar delegado
//Usando delegado para llamar a metodo
//Creando una instancia
//nombre del delegado , instancia del delegado = new (nombre del metodo que quiero llamar)



DelegateWithMatchSignature d = new(Jordi.MethodWantToCall);
int answer2 = d("Alfred");

#endregion




    Jordi.Poke();
    Jordi.Poke();
    Jordi.Poke();

    */


