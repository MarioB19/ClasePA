
//Si no te importan los decimalaes : Usar Flotantes
//Usar precision : Decimal


using static System.Console; //Imprimir cosas




#region Datos

//datos nativos
int number =1;
float number1 =1.2F;
double number2 = 5.23;

decimal number3 = 1.24M;
bool isTrue = false;

char character = 'A';


//complex type
string name = "Mario";
DateTime dateOfBirth = DateTime.Now;

#endregion


//Via paramatro (posiciom)
WriteLine("The first number is : {0}",arg0:number); //declaracion implimita de parametros


//Interpolacion

WriteLine($"The second number is : {number1}");




WriteLine($"The int is  {sizeof(int)} bytes {number+1.0} ,The minium size of int is  : {int.MinValue} and max is : {int.MaxValue}");  //sizeof() : Operador

WriteLine($"The float is  {sizeof(float)} bytes {number1+1.0} ,The minium size of float is  : {float.MinValue} and max is : {float.MaxValue}");  //sizeof() : Operador


WriteLine($"The double is  {sizeof(double)} bytes  {number2+1.0} ,The minium size of double is  : {double.MinValue} and max is : {double.MaxValue}");  //sizeof() : Operador




WriteLine($"The char is  {sizeof(char)} bytes  ,The minium size of int is  : {char.MinValue} and max is : {char.MaxValue}");  //sizeof() : Operador




WriteLine($"The decimal is  {sizeof(decimal)} bytes  {number3+1.0M} ,The minium size of int is  : {decimal.MinValue} and max is : {decimal.MaxValue}");  //sizeof() : Operador





