using static System.Convert; //importar miembros System.Convert , para poder hacer uso de las funciones:
//ToBase64String

byte[] arr = new byte[128]; //Creacion del arreglo de bytes de 128 espacios


for (int i = 0; i < 128; i++)
{
    int number = Random.Shared.Next(0, 256); //Creacion del numero aleatorio de 0-255 (1 byte =  0-255)
    //el primer parametro de Random.Shared.Next es inclusivo , y el segundo exclusivo

    arr[i] = (byte)number; //casteo de number a byte , para salvaguradar integridad
}

WriteLine("Binary Object as bytes:");
for (int i = 0; i < 128; i++)
{
 Console.Write($"{arr[i]:X2} "); //Impresion del arreglo en formato hexadecimal , sin necesidad de convertirlo explicitamente
}

WriteLine($"\n\nBinary Object as Base64: {ToBase64String(arr)}"); //Impresion del arreglo en formato StringBase64 
//usando un miembro de la Clase System.Convert: ToBase64String(*parametro*)

   
