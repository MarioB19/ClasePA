
public class Archivos
{
public string? funcionArchive(string nameArchivo) //funcion para hacer el tratamiento del archivo
{


    int[] contVocals = new int[5]; //array para contar las apariciones de las vocales
    string text = "", auxText = "", longestPalindrome = ""; //variables para el texto, el texto auxiliar, y el palindromo mas largo

    string Archivos = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Archivos"); //especificacion de la ubicacion de un directorio(Carpeta) llamado Archivos
    CreateDirectory(Archivos); //Creacion del directorio


    string TextFile = Combine(Archivos, nameArchivo); //especificacion de la direccion del archivo de entrada
       if(Path.Exists(TextFile)== false) //verificacion de que el archivo exista
    {
        throw new FileNotFoundException("El archivo no existe"); //excepcion si el archivo no existe
    }


    string OutputFile = Combine(Archivos, "Output.txt"); //especificacion de la direccion del archivo de salida


    StreamReader textReader = File.OpenText(TextFile); //lectura del archivo de entrada
    text = textReader.ReadToEnd(); //captacion en la variable text
    textReader.Close(); //cierre del archivo de entrada

    if(text.Length == 0) //verificacion de que el archivo no este vacio
    {
        throw new EndOfStreamException("El archivo esta vacio"); //excepcion si el archivo esta vacio
    }
    if(text.Length >=1_000_000)
    {
       throw new ArgumentOutOfRangeException("El archivo es demasiado grande"); //excepcion si el archivo es demasiado grande
    }
{

}
    ContarVocales(text, contVocals); //llamado a la funcion para contar las vocales en la string text de entrada
    auxText = ReemplazarVocales(text, contVocals); //llamado a la funcion para reemplazar las vocales en la string auxText
    longestPalindrome = LongestPalindromo(auxText); //llamado a la funcion para encontrar el palindromo mas largo en la string auxText
    //despues de esto, ya tenemos el texto auxiliar con las vocales reemplazadas y el palindromo mas largo en la variable longestPalindrome


    StreamWriter textWriter = File.CreateText(OutputFile); //creacion del archivo de salida
    textWriter.WriteLine(auxText);  //escritura en el archivo de salida

    textWriter.WriteLine($"VocalA: {contVocals[0]}");
    textWriter.WriteLine($"VocalE: {contVocals[1]}");
    textWriter.WriteLine($"VocalI: {contVocals[2]}");
    textWriter.WriteLine($"VocalO: {contVocals[3]}");
    textWriter.WriteLine($"VocalU: {contVocals[4]}");

    textWriter.WriteLine($"Longest palindrome: {longestPalindrome}");
    textWriter.Close(); //cierre del archivo de salida



return "ok"; //retorno de la funcion en caso de todo bien

}


public  bool IsPalindromo(string cadena) //funcion para verificar si una string es palindromo
{

    if(cadena.Length == 0) //si la string esta vacia, no es palindromo
    {
       throw new ArgumentException("La cadena no puede estar vacia"); //excepcion si la string esta vacia
    }

    cadena = cadena.ToLower(); //pasar la string a minusculas

    char[] caracteres = cadena.ToCharArray(); //pasar la string a un array de caracteres

    Array.Reverse(caracteres); //invertir el array de caracteres

    string cadenaInvertida = new string(caracteres);//pasar el array de caracteres invertido a una string


    return cadena.Equals(cadenaInvertida); //   comparar la string original con la string invertida, si son iguales, es palindromo, si no, no es palindromo
}
public string LongestPalindromo(string text) //funcion para encontrar el palindromo mas largo en una string
{
    string auxText = text.ToLower(); //pasar la string a minusculas
    string[] wordsWithNumbers = auxText.Split(new[] { ' ', '\n', '\r', }, StringSplitOptions.RemoveEmptyEntries); //pasar la string a un array de strings, separando por espacios, saltos de linea y /r

    string longestPalindrome = ""; //variable para el palindromo mas largo

    foreach (string word in wordsWithNumbers) //recorrer el array de strings
    {
        if (IsPalindromo(word) && word.Length > longestPalindrome.Length) //si la string es palindromo y es mas larga que la string longestPalindrome
        {
            longestPalindrome = word; //la string longestPalindrome se vuelve la string word
        }
    }

    return longestPalindrome;//retorno de la string longestPalindrome

}
public string ReemplazarVocales(string text, int[] contVocals)//funcion para reemplazar las vocales en una string
{
    //declaracion de variables
    string nuevaCadena; 
    int posicion = 0;
    char[] Vocales = { 'a', 'e', 'i', 'o', 'u' };

    string auxText = text;//pasar la string text a la string auxText

    nuevaCadena = auxText; //la string nuevaCadena se vuelve la string auxText

    for (int i = 0; i < 5; i++)
    {

        posicion = auxText.LastIndexOfAny(new char[] { Vocales[i], char.ToUpper(Vocales[i]) });//encontrar la ultima posicion de la vocal en la string auxText


        if (posicion != -1)
        {
            nuevaCadena = auxText.Substring(0, posicion) + contVocals[i].ToString() + auxText.Substring(posicion + 1); //reemplazar la vocal por el numero de apariciones de la vocal en la string auxText, en su ultima aparicion
        }

        auxText = nuevaCadena;//la string auxText se vuelve la string nuevaCadena, para hacerlo de nuevo con la siguiente vocal
    }
    return auxText; //retorno de la string auxText
}
public int [] ContarVocales(string text, int[] contVocals) //funcion para contar las vocales en una string

{

    string[] words = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); //pasar la string text a un array de strings, separando por espacios, saltos de linea y /r

    foreach (string word in words) //recorrer el array de strings
    {

        for (int i = 0; i < word.Length; i++) //recorrer la string word
        {
            if (word[i] == 'a' || word[i] == 'A') //si el caracter en la posicion i de la string word es una vocal, aumentar el contador de vocales en la posicion 0 del array contVocals
            {
                contVocals[0]++;
            }
            else if (word[i] == 'e' || word[i] == 'E')//si el caracter en la posicion i de la string word es una vocal, aumentar el contador de vocales en la posicion 1 del array contVocals
            {
                contVocals[1]++;
            }
            else if (word[i] == 'i' || word[i] == 'I')//si el caracter en la posicion i de la string word es una vocal, aumentar el contador de vocales en la posicion 2 del array contVocals
            {
                contVocals[2]++;
            }
            else if (word[i] == 'o' || word[i] == 'O')//si el caracter en la posicion i de la string word es una vocal, aumentar el contador de vocales en la posicion 3 del array contVocals
            {
                contVocals[3]++;
            }
            else if (word[i] == 'u' || word[i] == 'U')//si el caracter en la posicion i de la string word es una vocal, aumentar el contador de vocales en la posicion 4 del array contVocals
            {
                contVocals[4]++;
            }


        }

    }

    return contVocals; //retorno del array contVocals
}

}


