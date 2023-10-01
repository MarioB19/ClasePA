using Xunit.Sdk;

namespace UnitTestingArchivos;


public class UnitTest1
{
  [Fact]
  //Prueba para verificar que si se manda un archivo inexistente, no explote el programa
  public void FileDontExist() //prueba1
  {
  
    Archivos archive = new();//instanciar la clase Archivos

    Assert.Throws<FileNotFoundException>(() => 
    archive.funcionArchive("prueba1.txt"));//verificar que se mando un archivo que no existe


  }
  //cuando mandes el archivo como es , que realmente te retorno lo que es


  //verificar si una cadena es palindromo, sin importar mayusculas y minusculas y caracteres especiales
  [Fact]
  public void VerifyStringIsPalondromic() //prueba2
  {

    Archivos archive = new(); //instanciar la clase Archivos

    Assert.True(archive.IsPalindromo("*mIS0s0.0S0SIm*")); //verificar que la cadena es palindromo
  }
  [Fact]

  //verificar que si se manda un archivo que existe, se obtenga el retorno correcto
  public void FileExist() //prueba3
  {
    Archivos archive = new(); //instanciar la clase Archivos
    Assert.Equal("ok", archive.funcionArchive("prueba3.txt")); //verificar que se mando un archivo que existe y que se obtenga el retorno adecuado

  }
  [Fact]

  //verificar que si se manda un archivo que exista, pero este vacio, se obtenga la excepcion adecuada
  public void EmptyFile() //prueba4
  {
    Archivos archive = new();//instanciar la clase Archivos
    Assert.Throws<EndOfStreamException>(() => archive.funcionArchive("prueba4.txt"));//mandar un archivo vacio y verificar que se obtenga la excepcion adecuada


  }
  [Fact]


  //contar las vocales en una string, y comparar con las que realmente hay en el archivo de texto
  public void CountVocalsInString() //prueba5
  {
    int[] contVocals = new int[5]; //array para contar las vocales
    string Archivos = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Archivos");//especificacion de la ubicacion de un directorio(Carpeta) llamado Archivos
    string TextFile = Combine(Archivos, "prueba5.txt"); //especificacion de la direccion del archivo de entrada

    StreamReader textReader = File.OpenText(TextFile); //lectura del archivo de entrada
    string text = textReader.ReadToEnd(); //captacion en la variable text
    textReader.Close(); //cierre del archivo de entrada

    Archivos archive = new(); //instanciar la clase Archivos
    contVocals = archive.ContarVocales(text, contVocals); //llamado a la funcion para contar las vocales en la string text de entrada

    if (contVocals[0] == 21 && contVocals[1] == 7 && contVocals[2] == 8 && contVocals[3] == 9 && contVocals[4] == 6)//verificar que se contaron las vocales correctamente
    {
      Assert.True(true); //si se contaron bien, la prueba es correcta
    }
    else
    {
      Assert.True(false); //si no se contaron bien, la prueba es incorrecta
    }



  }
  [Fact]

  //Verificar que realmente se obtenga el palindromo mas largo de un archivo texto, del cual se obtiene el string text
  public void LongestPalindromoInString() //prueba6
  {

    string Archivos = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Archivos"); //especificacion de la ubicacion de un directorio(Carpeta) llamado Archivos
    string TextFile = Combine(Archivos, "prueba6.txt"); //especificacion de la direccion del archivo de entrada

    StreamReader textReader = File.OpenText(TextFile); //lectura del archivo de entrada
    string text = textReader.ReadToEnd();//captacion en la variable text
    textReader.Close();//cierre del archivo de entrada

    Archivos archive = new();//instanciar la clase Archivos
    Assert.Equal(".91.wjsjsn11nsjsjw.19.", archive.LongestPalindromo(text)); //verificar que se obtuvo el palindromo mas largo de la string text de entrada
  }

  [Fact]

  
  //Verificar que realmente se reemplaza x cantidad de veces que aparece cada vocal en la string text y en la ultima aparicion de estas mismas
  public void VerifyChangesNumbersInTheLastAparittionForEachVocal() //prueba 7
  {

    int[] contVocals = new int[5];//array para contar las vocales
    string Archivos = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Archivos");//especificacion de la ubicacion de un directorio(Carpeta) llamado Archivos
    string TextFile = Combine(Archivos, "prueba7.txt"); //especificacion de la direccion del archivo de entrada
    string OutputFile = Combine(Archivos, "OutputExpected.txt"); //especificacion de la direccion del archivo de salida esperado

    StreamReader textReader = File.OpenText(TextFile); //lectura del archivo de entrada
    string text = textReader.ReadToEnd(); //captacion en la variable text
    textReader.Close(); //cierre del archivo de entrada

    textReader = File.OpenText(OutputFile); //lectura del archivo de salida esperado
    string output = textReader.ReadToEnd(); //captacion en la variable output
    textReader.Close(); //cierre del archivo de salida esperado

    Archivos archive = new(); //instanciar la clase Archivos

//definacion de los valores esperados para cada vocal
    contVocals [0]  = 154;
    contVocals [1]  = 99;
    contVocals [2]  = 84;
    contVocals [3]  = 108;
    contVocals [4]  = 40;

    Assert.Equal(output,archive.ReemplazarVocales(text, contVocals)); //verificar que se reemplazaron las vocales correctamente
  }

  [Fact]

  //Mandar archivo de entrada , y que la salida , sea realmente la salida esperada
  public void OutputExpected() //prueba 8
  {
     
    string Archivos = Combine(GetFolderPath(SpecialFolder.MyDocuments), "Archivos"); //especificacion de la ubicacion de un directorio(Carpeta) llamado Archivos
    string OutputFile = Combine(Archivos, "Output.txt"); //especificacion de la direccion del archivo de salida
    string OutputExpected = Combine(Archivos, "OutputExpected2.txt"); //especificacion de la direccion del archivo de salida esperado


    Archivos archive = new(); //instanciar la clase Archivos

    archive.funcionArchive("prueba8.txt"); // llamado a la funcion para generar la salida, con el archivo de entrada prueba8.txt
    
    StreamReader textReader = File.OpenText(OutputFile); //lectura del archivo de salida
    string output = textReader.ReadToEnd();// captacion en la variable output
    textReader.Close();//cierre del archivo de salida

     textReader = File.OpenText(OutputExpected); //lectura del archivo de salida esperado, definido con anterioridad
    string outputExpected = textReader.ReadToEnd(); //captacion en la variable outputExpected
    textReader.Close();//cierre del archivo de salida esperado

    Assert.Equal(outputExpected,output); //comparacion de la salida esperada con la salida obtenida
  }

  [Fact]

  //Si se mandan cadenas vacias a la funcion para sabaer si un numero es palindromo, que la funcion de palindromo lanze una excepcion
  public void StringNullCannotDo() //prueba9
  {

    Archivos archive = new(); //instanciar la clase Archivos
    Assert.Throws<ArgumentException>(() => archive.IsPalindromo("")); //verificar que se mando una cadena vacia y que se obtenga la excepcion adecuada
  }


  [Fact]

  //Que se lance una excepcion si el archivo de entrada tiene mas de 1_000_000 caracteres, por cuestion personalizada
  public void ArchiveLessThan1_000_000characters() //prueba10
  {
    Archivos archive = new(); //instanciar la clase Archivos
    Assert.Throws<ArgumentOutOfRangeException>(() => archive.funcionArchive("prueba10.txt")); //verificar que se mando un archivo con mas de 1_000_000 caracteres, que se obtenga la excepcion adecuada
  }
}