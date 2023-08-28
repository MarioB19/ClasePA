/* if(expression)
{

}else if (expression)
{

}


*/


string password = "gasper";

if(password.Length < 6){
    WriteLine("Yor password is too short . Use at least 6");
}
else
{
    WriteLine("Your password is strong");
}


object o =3;

int j = 4;

//is compara los tipos de datos , necesitamos crear una variable de ese tipo de dato

if(o is int i /*out reference*/){

WriteLine($"{i} * {j} = {i*j}");

}
else{
    WriteLine("o is not integger , cannot multily");
}

//Random number

int number = Random.Shared.Next(1, 7);
WriteLine($"Memory randon number is {number}");

switch(number){




    case 1:
    WriteLine("One");
    break;
     case 2:
    WriteLine("Twp");
     goto case 1;
    case 3:
    case 4:
        WriteLine("Three or Four");
        goto case 1;
    case 5:
     goto A_label;
     default:
     WriteLine("Default");
     break;

}

WriteLine("Aftener end of switch");
A_label:
WriteLine("After A_label");

