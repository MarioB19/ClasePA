//operators

int a = 3;
int b=4;

WriteLine($"is {a} and b is {b}");

int c = 11;

int d = 3;

WriteLine($"c + d = {c+d}");
WriteLine($"c - d = {c-d}");
WriteLine($"c * d = {c*d}");
WriteLine($"c / d = {c/d}");
WriteLine($"c % d = {c%d}");

//Assigment operators

WriteLine($"Assigment operators");

int e =6;

e+=3;
e-=3;
e*=3;
e/=3;

WriteLine($"e += 3 = {e+=3}");
WriteLine($"e -= 3 = {e-=3}");
WriteLine($"e *= 3 = {e*=3}");
WriteLine($"e /= 3 = {e/=3}");

//Boolean operators
bool f = true;
bool g = false;

WriteLine("AND |f      | g");

WriteLine($"  f | {f&f,-5} | {f&g}");
WriteLine($"  g | {g&f,-5} | {g&g}");
WriteLine();

WriteLine("OR  |f      | g");

WriteLine($"  f | {f|f,-5} | {f|g}");
WriteLine($"  g | {g|f,-5} | {g|g}");
WriteLine();


//conditional Operators

static bool DoStuff(){
    WriteLine  ("I am Working");
    return true;

}

WriteLine();

WriteLine($"f & Do Stuff() = {f & DoStuff()}");
WriteLine($"g & Do Stuff() = {g & DoStuff()}");

WriteLine();

WriteLine($"f & Do Stuff() = {f && DoStuff()}");
WriteLine($"g & Do Stuff() = {g && DoStuff()}");








//Miscelaneos

int age = 50;

char firstDigit = age.ToString()[0];

// = is the assigment operator
// . is the member acces operator
// [] is the index operator
// () is the invocation operator

