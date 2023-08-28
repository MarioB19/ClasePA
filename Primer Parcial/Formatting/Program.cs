
using static System.Console;

//Margins (Horizontales)

//{index [,aligment] [":formatString]}



string pearText = "Pear";

int pearCount = 12345;  

string pricklyPearText = "Prickly Pear";


int pricklyPearCount = 450000;


//HEADERS

WriteLine(
format: "{0,-12}{1,7}" ,
arg0 : "Name",
arg1 : "Count");

//1st Row

WriteLine(

    format: "{0,-13}{1,7:N0}" ,
    arg0 : pearText,
    arg1 : pearCount
);

//2nd Row

WriteLine(

    format: "{0,-13}{1,8:N0}" ,
    arg0 : pricklyPearText,
    arg1 : pricklyPearCount
);



Write("Type your first name and press ENTER : ");

string firstname = ReadLine();

Write("Type your age name and press ENTER : ");

string age = ReadLine();


WriteLine($"Helo {firstname} with {age}");






