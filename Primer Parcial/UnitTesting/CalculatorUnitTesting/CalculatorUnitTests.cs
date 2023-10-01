
//UnitTset : 3 cosas necesarias
// Arrange : Declara todo lo que necesito para correr mi prueba (objetos , variables , funciones)
// Act : Es el que manda a llamar la funcion que quiero probar
// Assert : Validar que lo que quiero de mi prueba , realmente se obtenga (comparar con lo esperado)


namespace CalculatorUnitTests;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CalculatorLib;


public class UnitTest1
{

    #region Division
    [Fact] //Annotation : Verbos que le puedo poner a mis funcione

    public void DivideByZeroExceptionDiv()
    {

        // Arrange
        double? a = 23;
        double? b = 0.0;

        Calculator calc = new();

        // Act y Assert
        Assert.Throws<DivideByZeroException>(() => calc.Div(a, b));


    }

    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void ArgumentNullExceptionDiv()
    {
        // Arrange
        double? a = 7;
        double? b = null;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<ArgumentNullException>(() => calc.Div(a, b));



    }

    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void NotFiniteNumberExceptionDiv()
    {
        // Arrange
        double? a = double.NaN;
        double? b = double.PositiveInfinity;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<NotFiniteNumberException>(() => calc.Div(a, b));


    }

    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void OverflowExceptionDiv()
    {
        // Arrange
        double? a = double.MaxValue;
        double? b = 0.1;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<OverflowException>(() => calc.Div(a, b));



    }

    #endregion


    #region Suma

    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void ArgumentNullExceptionAdd()
    {
        // Arrange
        double? a = 1.0;
        double? b = null;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<ArgumentNullException>(() => calc.Add(a, b));



    }


    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void OverflowExceptionAdd()
    {
        // Arrange
        double? a = double.MaxValue;
        double? b = 1.0;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<OverflowException>(() => calc.Add(a, b));


    }

    [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    public void NotFiniteNumberExceptionAdd()
    {
        // Arrange
        double? a = double.NegativeInfinity;
        double? b = -1.0;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<NotFiniteNumberException>(() => calc.Add(a, b));


    }
      [Fact] //Annotation : Verbos que le puedo poner a mis funcione
    
      public void AritmethicExceptionAdd()
    {
        // Arrange
        double? a = 11.0;
        double? b = 12.0;
        Calculator calc = new();

        // Act y Assert
        Assert.Throws<ArithmeticException>(() => calc.Add(a, b));



    }




    #endregion




    

    /*
        #region verif



         [Fact] //Annotation : Verbos que le puedo poner a mis funcione
         public  void VerifAdd(){
            // Arrange
            double? a = 10.0;
            double? b = 2.0;
            double? expect = a +b;
            Calculator calc = new();

            Assert.Equal(expect,calc.Add(a,b));



        }

        [Fact] //Annotation : Verbos que le puedo poner a mis funcione
         public  void VerifDiv(){
            // Arrange
            double ?a = 20.5;
            double ?b = 10.4;
            double ?expect = a/b;
            Calculator calc = new();


            Assert.Equal(expect,calc.Div(a,b));





        }



        #endregion


*/
        



}