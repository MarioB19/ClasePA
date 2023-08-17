// See https://aka.ms/new-console-template for more information


// no un try catch del main entero
// string []  args

WriteLine($"There are {args.Length} arguments.");

foreach (var arguments in args)

{

    WriteLine(arguments);


}


#region Infer Types

//Object : Best Type to transfer data

object number = "13";

WriteLine(number.GetType());

string name = "Mario";

//Dynamic : Si hereda metodos , no usa Garbage Collector 
dynamic decimalNumer = 45.8;
WriteLine(decimalNumer.GetType());




//Var esta joyita
// Lo puedes hacer sin saber que es

var array  = new int[1,2,3,4]; //Se aloja en la ram
WriteLine(array.GetType());

#endregion


if(args.Length <3){
    WriteLine("Debe tener 3 argumentos : 2 colores y cursor");
    WriteLine("Example : dotnet run red yellow 50");

    return; //stop running block
}

ForegroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
    value : args [0],
    ignoreCase :true
);

BackgroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
    value : args [1],
    ignoreCase :true
);


try{
CursorSize = int.Parse(args[2]);
}

catch(System.PlatformNotSupportedException){
    WriteLine("Sistema No compatible");
}



