﻿

using System.Data;
using static System.Convert;

//2 types of conversion

///Implicit
///

//Explicit

#region Implicit conversion

int a = 10;


double b = a;
WriteLine($"b is double and is {b}");


#endregion



#region Explicit conversion

double c = 9.8;


int d= (int)c;

WriteLine($"d is int and is {d}");


long e = 10;
int f = (int)e;

WriteLine($"e is {e:N0} and f is {f:N0}");
e = long.MaxValue;
f = (int)e;

WriteLine($"e is {e:N0} and f is {f:N0}");

e = 5_000_000_000;
f = (int)e;

WriteLine($"e is {e:N0} and f is {f:N0}");



#endregion



#region using Convert Class

double g = 9.8;
int h =  ToInt32(g);
WriteLine($"g is {g} and h is {h}");



#endregion



#region toString

WriteLine("----------------------------------");
int number = 12;


WriteLine(number.ToString());


bool boolean = true;
WriteLine(boolean.ToString());
DateTime now = DateTime.Now;
WriteLine(now.ToString());
string name = "Mario";
WriteLine(name.ToString());
object something = new();
WriteLine(something.ToString());


#endregion



int count = int.Parse("13"); 

//Tryparse

//int count = int.Parse("abc"); //SystemFormatException


WriteLine("How many students are?");
string? input = ReadLine();

if(int.TryParse(input, out int cuenta)){
    WriteLine($"There are {cuenta} students");
}
else{
    WriteLine("could't convert");
}