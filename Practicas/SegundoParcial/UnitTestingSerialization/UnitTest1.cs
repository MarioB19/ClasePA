namespace UnitTestingSerialization;

public class UnitTest1
{
    [Fact]
    public void ValidarInicioSesionAlmacenista() 
    {
        Assert.True(Program.ValidarInicioSesionAlmacenista("Anel","1"));

    }

    [Fact]
    public void ValidarCambioContrasenaAlmacenista() 
    {

        Program.CambiarContraseniaAlmacenista("Mario","2");

        Assert.True(Program.ValidarInicioSesionAlmacenista("Mario","2"));

    }

     [Fact]
    public void ValidarOrganizarMaterias() 
    {

       string[] Materias = { "BDII", "BDI", "Avanzada I", "Web I" };


        string[] materiasOrdenadas  = Program.ValidarOrganizarMaterias(Materias);

    

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

      Assert.True(Program.ValidarArchivos());
    }


     [Fact]
    public void InicializarAlmacenista() 
    {
      Program.InicializarAlmacenista();

      Assert.True(Program.ValidarInicioSesionAlmacenista("Admin","default"));

    }

    [Fact]

    public void InicializarSalonesyVerificarCantidad(){

        int valor = Program.CrearSalones();

        Assert.Equal(10,valor);

    }


     [Fact]

    public void VerificarNoIngresarNominaRepetida(){

       Assert.True(Program.VerificarNominaNoRepetida("12345")); //si es true significa que no esta repetida

    }


    [Fact]

     public void VerificarCambioContrasenaProfesor(){

        Program.CambiarContraseniaProfesor("1234","abc");

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


        string[] materiasNuevas  = Program.VerificarCambiarMaterias(Materias,"BDII","Analisis de Algoritmos");

    

        if(materiasNuevas[0] == "Analisis de Algoritmos" && materiasNuevas[1] == "Avanzada I" && materiasNuevas[2] == "BDI" && materiasNuevas[3] == "Web I"){

            Assert.True(true);
        }
        else{
            Assert.True(false);
        }
    }




  
    



    

    


}