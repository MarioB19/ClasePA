namespace PA17F.Shared;
public class Profesor
{

//Constructor profesor
    public Profesor(){
        SalonesAsignados = new List<Salon>();  
        Division = "Desarrollo de Software";
        Materias = new List<string>();

    }


//Atributos profesor
public string? NombreCompleto { get; set; }
public string? Nomina { get; set; } // La nómina se almacena en forma de hash.
public string? Contrasenia { get; set; } // La contraseña se almacena en forma de hash.
public string? Division { get; set; }

public List<string> Materias { get; set; }
public List<Salon> SalonesAsignados { get; set; }


}




