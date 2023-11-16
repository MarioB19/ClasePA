using System.Collections.Generic;
using System;
using System.Security.AccessControl;
using System.Xml.Serialization;
using PA17F.Shared;
using static System.Environment;
using static System.IO.Path;
using Microsoft.VisualBasic;


using FastJson = System.Text.Json.JsonSerializer;
//segun donde ponga el alias , es a lo que puedo acceder










List<Person> people = new()
{
    new(3000M){
        Name ="Isaac",
        LastName = "Chavez",
        DateOfBirth = new(year:1999,month:10,day:25),
    },
    new(4000M){
        Name = "Carolina",
        LastName = "Prian",
        DateOfBirth = new(year:1999,month:11,day:25),

    },
    new(2000M){
         Name = "Mario",
        LastName = "Muro",
        DateOfBirth = new(year:1999,month:12,day:25),

    
    },
    new(800M){
        Name = "Juan",
        LastName = "Torres",

        DateOfBirth = new(year:2001,month:04,day:12),
        Children = new(){
            new(0M){
                Name = "Juanito",
                LastName = "Torres",
                DateOfBirth = new(year:2023,month:10,day:2)
            },
            new(0M){
                Name = "Juanita",
                LastName = "Torres",
                DateOfBirth = new(year:2023,month:10,day:2)
            }
        }
    }
};


//es necesario especificar el tipo de dato que se va a serializar
XmlSerializer xs = new(type:people.GetType());
string path = Combine(CurrentDirectory,"people.xml");



using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream,people);
}


WriteLine($"Written {new FileInfo(path).Length} bytes of XML to : {path}");
WriteLine();

WriteLine(File.ReadAllText(path));

//Deserializar
WriteLine("Deserializing people.xml");

using (FileStream xmlLoad = File.Open(path,FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if(loadedPeople is not null){
    foreach (var item in loadedPeople)
    {
        WriteLine($"{item.Name} has {item.Children?.Count ?? 0} children.");
    }
    }
    
}


#region Serialize Json
string jsonPath = Combine(CurrentDirectory,"people.json");
using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();
    //Serializar
     jss.Serialize(jsonStream,people);
}




WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to : {jsonPath}");
WriteLine();

WriteLine(File.ReadAllText(jsonPath));



#endregion


#region Deserializar Json

using (FileStream jsonLoad = File.Open(jsonPath,FileMode.Open))
{

    List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad,
    returnType: typeof(List<Person>)) as List<Person>; 


    if(loadedPeople is not null){
        foreach(Person p in loadedPeople){
            WriteLine($"{p.Name} has {p.Children?.Count ?? 0} children.");
        }
    }
    
}




/*
Asincrono

//Deserializar
    //sincrono
    //esperar que siempre se termine el paso anterior, para continuar

    //asincrono
    //hacer varios pasos al mismo tiempo

async Task <int> GetLengthString(string? text){
    if(text is null){
        return 0;
    }
    return await s.Length;
}



al procesador solo le importan 3 cosas : que haya fallado un proceso , que haya terminado un proceso , que haya empezado un proceso


*/
#endregion