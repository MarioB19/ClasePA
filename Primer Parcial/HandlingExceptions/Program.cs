
using static System.Exception;



WriteLine("Before Parsing");
WriteLine("What is your age");

string? input = ReadLine();

try{
int age = int.Parse(input);
WriteLine($"Your age is {age}");
}

catch(FormatException ){


WriteLine("Could convert");

}
catch(Exception ex){

 WriteLine($"{ex.GetType} says {ex.Message}");  


}

WriteLine("After parsing");

WriteLine("Enter an amount");
string amount = ReadLine();

//Filtros
if(string.IsNullOrEmpty(amount))
return;

try{

    decimal  amountValue = decimal.Parse(amount);
    WriteLine($"Amount formated as currency {amount:C3}");


}
catch(FormatException) when(amount.Contains("$"))

{
 WriteLine($"There are $");
}
catch(FormatException){
    WriteLine($"There is mistake");

}


//enteros : Evitar en runtime (checked)


/*
checked{
    int aux = int.MaxValue;

aux++;

aux++;
aux++;
WriteLine($"{aux}");
}
*/

int max = 500;

for(byte i=0;i<max;i++){
    WriteLine($"{i}");
}







