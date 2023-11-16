namespace UnitTestingSerialization;

public class UnitTest1
{
    [Fact]
    public void ValidarInicioSesionAlmacenista() 
    {

        //Llamar a la funcion de inicio de sesion almacenista
        Assert.True(Program.ValidarInicioSesionAlmacenista("Anel","1"));

    }

    [Fact]
    public void ValidarCambioContrasenaAlmacenista() 
    {

        //Llamar a la funcion de inicio de sesion almacenista

        Program.CambiarContraseniaAlmacenista("Mario","2");

        //Llamar a la funcion validar inicio de sesion almacenista

        Assert.True(Program.ValidarInicioSesionAlmacenista("Mario","2"));

    }

     [Fact]
    public void ValidarOrganizarMaterias() 
    {

//Arreglo materias

       string[] Materias = { "BDII", "BDI", "Avanzada I", "Web I" };

       //Llamar a la funcion validar organizar materias


        string[] materiasOrdenadas  = Program.ValidarOrganizarMaterias(Materias);

    //Validar si las materias estan ordenadas correctamente

        if(materiasOrdenadas[0] == "Avanzada I" && materiasOrdenadas[1] == "BDI" && materiasOrdenadas[2] == "BDII" && materiasOrdenadas[3] == "Web I"){

            Assert.True(true);
        }
        else{
            Assert.True(false);
        }
    }


     [Fact]
    public void ArchivosEntidadCreadosCorrectamente() 
    {
//Llamar a la funcion validar archivos, para verificar que se crearon correctamente
      Assert.True(Program.ValidarArchivos());
    }


     [Fact]
    public void InicializarAlmacenista() 
    {
        //Llamar a la funcion inicializar almacenista, para que se inicializen los datos
      Program.InicializarAlmacenista();

      Assert.True(Program.ValidarInicioSesionAlmacenista("Admin","default"));

    }

    [Fact]

    public void InicializarSalonesyVerificarCantidad(){

        //Llamar a la funcion inicializar salones, para que se inicializen los datos

        int valor = Program.CrearSalones();

        Assert.Equal(10,valor);

    }


     [Fact]

    public void VerificarNoIngresarNominaRepetida(){

        //Llamar a la funcion verificar nomina repetida, para corroborar que no haya nominas repitidaas
       Assert.True(Program.VerificarNominaNoRepetida("12345")); //si es true significa que no esta repetida

    }


    [Fact]

     public void VerificarCambioContrasenaProfesor(){

        //Llamar a la funcion cambiar contraseña profesor, para cambiar la contraseña del profesor

        Program.CambiarContraseniaProfesor("1234","abc");

        //Verificar que se cambio correctamente la contraseña

        Assert.True(Program.ValidarCambioContrasenaProfesor("1234","abc"));

      
    }


     [Fact]

     public void VerificarBorrarProfesor(){
        //verifica que se borre la instancia profesor , y las aparaciones en la instancia de salo

        Assert.True(Program.validarBorrarProfesor("1"));
      
    }


     [Fact]

     public void VerificarCambiarMateriayOrdenCorrecto(){
        
        string[] Materias = { "BDII", "BDI", "Avanzada I", "Web I" };

//Llamar a la funcion verificar cambiar materias, para cambiar las materias

        string[] materiasNuevas  = Program.VerificarCambiarMaterias(Materias,"BDII","Analisis de Algoritmos");

    
//Verificar que las materias se ordenaron A-Z , y que se cambio la materia
        if(materiasNuevas[0] == "Analisis de Algoritmos" && materiasNuevas[1] == "Avanzada I" && materiasNuevas[2] == "BDI" && materiasNuevas[3] == "Web I"){

            Assert.True(true);
        }
        else{
            Assert.True(false);
        }
    }




  
    



    

    


}