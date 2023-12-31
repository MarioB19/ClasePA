namespace PA17F.Shared;

 public class Salon
    {
        private static int contador = 0;


        //Constructor salon

        public Salon()
        {
            Identificador = ++contador;
        }


        //Atributos salon

        public int Identificador { get; set; }

        public string? Nombre { get; set; }
        public List<string> Grupos { get; set; } = new List<string>();
        public List<string> ProfesoresAsignados { get; set; } = new List<string>();
    }

