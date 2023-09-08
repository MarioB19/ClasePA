using System.Runtime.Intrinsics.X86;

namespace CalculatorLib;

public class Calculator
{

public double? Add(double?a, double?b)
{

        if(a+b > int.MaxValue ){
            throw new OverflowException("Se excedio la memoria de int.");
        }

        else if(a == null || b == null)
        {
            throw new ArgumentNullException("Los parametros no pueden ser nulos");

        }
         else if(double.IsNaN(a.Value+b.Value) ||  double.IsInfinity(a.Value+b.Value)){
            throw new NotFiniteNumberException("Resultado no es un número finito.");
        }
         else if(a+b ==23){
            throw new ArithmeticException("Numero bloqueado.");
        }
        

        return a+b;
 

      
}


public double? Div(double ?a, double ?b)
{
  
        if(b == 0){
             throw new DivideByZeroException("No se puede dividir por cero.");
        }
        else if(a/b > double.MaxValue ){
            throw new OverflowException("Se excedio la memoria de double.");
        }
          else if(a == null || b == null)
        {
            throw new ArgumentNullException("Los parametros no pueden ser nulos");


        }
        else if(double.IsNaN(a.Value/b.Value) ||  double.IsInfinity(a.Value/b.Value)){
            throw new NotFiniteNumberException("Resultado no es un número finito.");
        }
       

        return a/b;

        
    }
   


}



    

