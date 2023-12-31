﻿//Directivas necesarias
using System.Collections.Generic;
using System;
using System.Security.AccessControl;
using System.Xml.Serialization;
using PA17F.Shared;
using static System.Environment;
using static System.IO.Path;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

using System.Text;
using Newtonsoft.Json;
using FastJson = System.Text.Json.JsonSerializer;
using System.Dynamic;
using System.Runtime.CompilerServices;

public partial class Program
{

    public static void Main()
    {

        // Carga inicial de almacenistas
        CrearAlmacenistas();
        CrearSalones();

        //Menu de opciones
        while (IniciarSesionAlmacenista())
        {

            bool salir = false;

            while (!salir)
            {
                WriteLine("Menu:");
                WriteLine("1) Agregar profesor");
                WriteLine("2) Editar profesor");
                WriteLine("3) Eliminar profesor");
                WriteLine("4) Cambiar Contrasenia ");
                WriteLine("5) Generar reportes");
                WriteLine("6) Salir");

                int opcion = int.Parse(ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProfesor();
                        break;
                    case 2:
                        EditarProfesor();
                        break;
                    case 3:
                        EliminarProfesor();
                        break;
                    case 4:
                        CambiarContrasenia();
                        break;
                    case 5:
                        GenerarReportes();
                        break;
                    case 6:
                        salir = true; // Establecer la bandera para salir del bucle
                        break;
                    default:
                        WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        WriteLine("Credenciales incorrectas. Saliendo...");

    }

    public static bool validarBorrarProfesor(string Nomina)
    {

        //limpiar listas de profesores y salones

         profesores.Clear();
        salones.Clear();



//cargar en listas lo que hay en los archivos profesores y salones
        DeserializarXMLProfesores();
        DeserializarXMLSalones();

      //Verificar si hay un profesor con esa nomina
        Profesor? profesor = profesores.FirstOrDefault(p => p.Nomina == CalcularHash(Nomina));

        if (profesor != null)
        {

            //Si existe el profesor, borrarlo de la lista de profesores
        //ademas de cualquier relacion con el salon
            profesores.Remove(profesor);
            WriteLine("Profesor eliminado correctamente.");

            foreach (var item in salones)
            {

                if (item.ProfesoresAsignados.Contains(profesor.Nomina))
                {
                    item.ProfesoresAsignados.Remove(profesor.Nomina);
                }

            }


//Guardamos los cambios en salones y profesores
            SerializarXMLProfesores();
            SerializarXMLSalones();

            SerializarJsonSalones();
            SerializarJsonProfesores();



            return true;

            

        }
        else
        {
          return false;
        }
        
    }



//Funcion para verificar que el cambio de materias dada una cadena , y un elemento a cambiar si se hace correctamente
    public static string [] VerificarCambiarMaterias(string [] Materias ,string materiaCambio, string materiaNueva)
    {
           for (int j = 0; j < Materias.Length; j++)
        {
            if (Materias[j] == materiaCambio)
            {
                Materias[j] = materiaNueva;
            }
        }


        List<string> Materia = new List<string>();

        foreach (var item in Materias)
        {
            Materia.Add(item);
        }

     

        Materia.Sort();

        int i = 0;

        foreach (var item in Materia)
        {

            Materias[i] = item;
            i++;
        }

        

        return Materias;

    }
    


//Funcion inicializar almacenista
    public static void InicializarAlmacenista()
    {

        //Obtener almacenistas de los archivos
        DeserializarXMLAlmacenistas();

        //Si no hay ninguna almacenistas, instanciar 3 almacenistas

        if (almacenistas.Count == 0)
        {

            almacenistas.Clear();


            almacenistas.Add(new Almacenista { NombreCompleto = "Admin", Contrasenia = CalcularHash("default") });
            almacenistas.Add(new Almacenista { NombreCompleto = "Anel", Contrasenia = CalcularHash("1") });
            almacenistas.Add(new Almacenista { NombreCompleto = "Mario", Contrasenia = CalcularHash("default") });

            //Guardar cambios serializando



            SerializarXMLAlmacenistas();
            SerializarJsonAlmacenistas();



        }

    }

    public static void InicializarSalones()
    {

        //limpiar lista salones

        salones.Clear();

        //Obtener salones de los archivos
        DeserializarXMLSalones();

        //Si no hay ningun salon, instanciar 10 salones

        if (salones.Count == 0)
        {

            salones.Clear();

            salones.Add(new Salon { Nombre = "F-201" });
            salones.Add(new Salon { Nombre = "F-202" });
            salones.Add(new Salon { Nombre = "F-203" });
            salones.Add(new Salon { Nombre = "F-204" });
            salones.Add(new Salon { Nombre = "ELEC-A" });
            salones.Add(new Salon { Nombre = "ELEC-B" });
            salones.Add(new Salon { Nombre = "ELEC-C" });
            salones.Add(new Salon { Nombre = "LABC-A" });
            salones.Add(new Salon { Nombre = "LABC-B" });
            salones.Add(new Salon { Nombre = "LABC-C" });

            //Guardar cambios serializando


            SerializarXMLSalones();
            SerializarJsonSalones();

        }

    }

    public static bool ValidarInicioSesionAlmacenista(string nombreCompleto, string Contrasenia)
    {
        //limpiar lista almacenistas
        almacenistas.Clear();

        //obtener almacenistas
        DeserializarXMLAlmacenistas();


        Contrasenia = CalcularHash(Contrasenia);

        //si hay un almacenistas con esas credenciales, regresar true, si no false

        Almacenista? almacenista = almacenistas.FirstOrDefault(a => a.NombreCompleto == nombreCompleto && a.Contrasenia == Contrasenia);

        if (almacenista != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static void CambiarContraseniaAlmacenista(string nombreCompleto, string Contrasenia)
    {

//limpiar lista almacenistas
        almacenistas.Clear();

//obtener almacenistas
        DeserializarXMLAlmacenistas();


//Verificar si hay un almacenista con ese nombre, y si lo hay cambiar su contrasena
        Almacenista? almacenista = almacenistas.FirstOrDefault(a => a.NombreCompleto == nombreCompleto);

        if (almacenista != null)
        {
            almacenista.Contrasenia = CalcularHash(Contrasenia);
        }

        //Guardar cambios
        SerializarXMLAlmacenistas();
        SerializarJsonAlmacenistas();


    }

    public static void CambiarContraseniaProfesor(string nomina, string Contrasenia)
    {
//borrar lista profesores
        profesores.Clear();
//obtener los profesores que hay en los archivos
        DeserializarXMLProfesores();

        string nominaHash = CalcularHash(nomina);

    //si existe un profesor con esa nomina, cambiar su contrasena

        Profesor? profesor = profesores.FirstOrDefault(profesor => profesor.Nomina == nominaHash);

        if (profesor != null)
        {
            profesor.Contrasenia = CalcularHash(Contrasenia);
        }

        //guardar cambios

        SerializarXMLProfesores();
        SerializarJsonProfesores();


    }



    public static bool ValidarCambioContrasenaProfesor(string nomina, string Contrasenia)
    {

        //limpiar profesores
        profesores.Clear();

        //obtener profesores de los archivos
        DeserializarXMLProfesores();


//verificar si las nuevas credenciales son correctas , si lo son regresar true, si no false
    

        Profesor? profesor = profesores.FirstOrDefault(profesor => profesor.Nomina == CalcularHash(nomina) && profesor.Contrasenia == CalcularHash(Contrasenia));

        if (profesor != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }



//Funcion validar organizaer materias
    public static string[] ValidarOrganizarMaterias(string[] Materias)
    {



        List<string> Materia = new List<string>();


//Agregar materias a una list
        foreach (var item in Materias)
        {
            Materia.Add(item);
        }

        //organizar las materias

        Materia.Sort();
        int i = 0;

        //guardar los elementos de la lista en el arreglo

        foreach (var item in Materia)
        {

            Materias[i] = item;
            i++;
        }

        return Materias; //retornar las materias organizadas

    }







    public static void CrearAlmacenistas()
    {
        //Funcion inicializar almacenista, para que en caso de que no haya ninguno se creen 3
        InicializarAlmacenista();
    }
    public static int CrearSalones()
    {

        //Funcion inicializar salones en caso de ser necesario
        InicializarSalones();

//Limpiar salones
        salones.Clear();

//Guardar los salones que en los archivos
        DeserializarXMLSalones();
        SerializarXMLSalones();

        //retornar cantidad de solones creados

        return salones.Count;
    }


//Funcion iniciar sesion almacenistas
    public static bool IniciarSesionAlmacenista()
    {
        WriteLine("LOGIN ALMACENISTA");
        Write("Ingrese su Nombre Completo: ");
        string? nombreCompleto = ReadLine();
        Write("Ingrese su Contrasenia : ");
        string Contrasenia = CalcularHash(ReadLine()); // En un entorno real, se debe encriptar la Contrasenia  y compararla con la almacenada.

//Verificar si hay un almacenistas con esas credenciales
        return almacenistas.Any(a => a.NombreCompleto == nombreCompleto && a.Contrasenia == Contrasenia);
    }


//Funcion agregar profesores
    public static void AgregarProfesor()
    {
        int cont = 0;
        //limpiar lista profesores y salones
        profesores.Clear();
        salones.Clear();

        //obtener salones y profes de los archivos
        DeserializarXMLProfesores();
        DeserializarXMLSalones();

        //creacion del objeto Profesor donde se gurdaran todos los datos
        Profesor nuevoProfesor = new Profesor();
        Write("Nomina del Profesor: ");
        string Nomina = ReadLine();


//Verificiar que la nomina ingresa no este repetida
        if (!VerificarNominaNoRepetida(Nomina))
        {

            WriteLine("Nomina ya existe");
            return;
        }


//Captura de los demas datos

        nuevoProfesor.Nomina = CalcularHash(Nomina);



        Write("Nombre Completo del Profesor: ");
        nuevoProfesor.NombreCompleto = ReadLine();


        Write("Contrasenia  del Profesor: ");
        nuevoProfesor.Contrasenia = CalcularHash(ReadLine()); // En un entorno real, se debe encriptar la Contrasenia .
        do
        {
            Write("Cantidad de Materias que Imparte (1-10): ");
            string? input = ReadLine();

            if (int.TryParse(input, out cont))
            {
                if (cont >= 1 && cont <= 10)
                {
                    break; // Salir del bucle si la entrada es válida
                }
                else
                {
                    WriteLine("Por favor, ingrese un número entre 1 y 10.");
                }
            }
            else
            {
                WriteLine("Por favor, ingrese un número válido.");
            }

        } while (true);

        for (int i = 0; i < cont; i++)
        {
            Write($"Materia {i + 1}: ");
            nuevoProfesor.Materias.Add(ReadLine());
        }

        cont = 0;

        do
        {
            Write("Cantidad de Salones que tiene (1-10): ");
            string? input = ReadLine();

            if (int.TryParse(input, out cont))
            {
                if (cont >= 1 && cont <= 10)
                {
                    break; // Salir del bucle si la entrada es válida
                }
                else
                {
                    WriteLine("Por favor, ingrese un número entre 1 y 10.");
                }
            }
            else
            {
                WriteLine("Por favor, ingrese un número válido.");
            }

        } while (true);

        WriteLine("Opciones : ");

        foreach (var item in salones)
        {
            Write($"{item.Identificador}:{item.Nombre}, ");

        }

        WriteLine("Ingreselas...");

        for (int i = 0; i < cont; i++)
        {
            Write($"Salon {i + 1}: ");
            int opcion = int.Parse(ReadLine());
            nuevoProfesor.SalonesAsignados.Add(salones[opcion - 1]);
        }

        // Solicitar y asignar la cantidad de grupos para cada salón
        foreach (var salon in nuevoProfesor.SalonesAsignados)
        {
            Write($"Ingrese la cantidad de grupos para {salon.Nombre} ({1}-{10}): ");
            int gruposSalon;
            do
            {
                string input = ReadLine();
                if (int.TryParse(input, out gruposSalon) && gruposSalon >= 1 && gruposSalon <= 10)
                {
                    break; // Salir del bucle si la entrada es válida
                }
                else
                {
                    WriteLine("Por favor, ingrese un número entre 1 y 10.");
                }

            } while (true);


            for (int i = 1; i <= gruposSalon; i++)
            {
                Write($"Nombre del grupo {i} para {salon.Nombre}: ");
                string? nombreGrupo = ReadLine();
                salon.Grupos.Add(nombreGrupo);




            }
            salon.ProfesoresAsignados.Add(nuevoProfesor.Nomina);
        }

//ordenar de la A-Z las materias ingresadas
        nuevoProfesor.Materias.Sort();


//Agregando profesor a la lista profesores
        profesores.Add(nuevoProfesor);

//Serializando profesores y salones
        SerializarXMLProfesores();
        SerializarXMLSalones();

        SerializarJsonSalones();
        SerializarJsonProfesores();

        WriteLine("Profesor agregado correctamente.");
    }

    public static bool VerificarNominaNoRepetida(string Nomina)
    {

        //encriptar nomina

        Nomina = CalcularHash(Nomina);
//borrar lista de profesores
        profesores.Clear();

//obtener profesores en los archivos
        DeserializarXMLProfesores();

//verificar si hay un profesor con esa nomina, si lo hay regresar false, si no true

        Profesor? profesor = profesores.FirstOrDefault(p => p.Nomina == Nomina);

        if (profesor != null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }



    public static void EditarProfesor()
    {

        int cont = 0;

        //limpiar lista profesores y salones

        profesores.Clear();
        salones.Clear();

        //obtener profesores y salones de los archivos

        DeserializarXMLProfesores();

        DeserializarXMLSalones();




        Write("Ingrese la Nomina del profe a buscar: ");

        string Nomina = CalcularHash(ReadLine()); // En un entorno real, se debe encriptar la Contrasenia  y compararla con la almacenada.

//buscar si hay un profe con esa nomina
        Profesor? profesor = profesores.FirstOrDefault(p => p.Nomina == Nomina);


//Menu de campos a editar
        if (profesor != null)
        {
            WriteLine("Seleccione el atributo a editar:");
            WriteLine("1. Nombre Completo");
            WriteLine("2. Nomina");
            WriteLine("3. Contrasenia ");
            WriteLine("4. Materia");
            WriteLine("5. Division");
            WriteLine("6. Grupo");


            int opcion = int.Parse(ReadLine());

            switch (opcion)
            {
                case 1:
                    Write("Nuevo Nombre Completo: ");
                    profesor.NombreCompleto = ReadLine();
                    break;
                case 2:

                    Write("Nueva nomina del Profesor: ");
                    Nomina = ReadLine();

                    if (!VerificarNominaNoRepetida(Nomina))
                    {

                        WriteLine("Nomina ya existe");
                        return;
                    }
                    profesor.Nomina = Nomina;


                    break;
                case 3:
                    Write("Nueva Contrasenia : ");
                    profesor.Contrasenia = CalcularHash(ReadLine()); // En un entorno real, se debe encriptar la Contrasenia .
                    break;
                case 4:
                    //Materias
                    int opcionMateria;

                    do
                    {
                        WriteLine("1: Agregar Materia");
                        WriteLine("2: Eliminar Materia");
                        WriteLine("3: Editar Materia");
                        WriteLine("4: Salir");

                        string input = ReadLine();

                        if (int.TryParse(input, out opcionMateria) && opcionMateria >= 1 && opcionMateria <= 4)
                        {
                            break; // Salir del bucle si la entrada es válida
                        }
                        else
                        {
                            WriteLine("Opción no válida. Por favor, ingrese un número entre 1 y 3.");
                        }
                    } while (true);

                    foreach (var item in profesor.Materias)
                    {
                        WriteLine($"Materias: {item}");
                    }

                    switch (opcionMateria)
                    {
                        case 1:
                            Write("Nueva Materia que Imparte: ");
                            profesor.Materias.Add(ReadLine());
                            break;
                        case 2:
                            Write("Materia a Eliminar: ");

                            string? materiaAEliminar = ReadLine();

                            if (profesor.Materias.Contains(materiaAEliminar))
                            {
                                profesor.Materias.Remove(materiaAEliminar);
                                WriteLine($"La materia '{materiaAEliminar}' ha sido eliminada correctamente.");
                            }
                            else
                            {
                                WriteLine($"La materia '{materiaAEliminar}' no existe en la lista. No se puede eliminar.");
                            }
                            break;
                        case 3:

                            string? materiaAEditar = ReadLine();


                            if (profesor.Materias.Contains(materiaAEditar))
                            {
                                profesor.Materias.Remove(materiaAEditar);
                                WriteLine("Modificacion materia: ");
                                string? materiaNueva = ReadLine();
                                profesor.Materias.Add(materiaNueva);
                                WriteLine($"La materia {materiaAEditar} ha sido modificada correctamente y cambiada por {materiaNueva}");

                            }
                            else
                            {

                                WriteLine($"La materia '{materiaAEditar}' no existe en la lista. No se puede editar.");
                            }
                            break;
                        case 4:
                            break;
                        default:
                            WriteLine("Opción no válida.");
                            break;
                    }

                    foreach (var item in profesor.Materias)
                    {
                        cont++;
                    }
                    Write("Nueva Materia que Imparte: ");
                    // profesor.Materia = ReadLine();
                    break;
                case 5:
                    Write("Nueva Division: ");
                    profesor.Division = ReadLine();
                    break;

                case 6:

                    int opcionGrupo, opcionSalon;
                    if (profesor.SalonesAsignados.Count == 0)
                    {
                        WriteLine("No hay salones asignados");
                    }
                    else
                    {

                        do
                        {
                            WriteLine("1: Agregar Grupo");
                            WriteLine("2: Eliminar Grupo");
                            WriteLine("3: Editar Grupo");
                            WriteLine("4: Salir");

                            string input = ReadLine();

                            if (int.TryParse(input, out opcionGrupo) && opcionGrupo >= 1 && opcionGrupo <= 4)
                            {
                                break; // Salir del bucle si la entrada es válida
                            }
                            else
                            {
                                WriteLine("Opción no válida. Por favor, ingrese un número entre 1 y 3.");
                            }
                        } while (true);




                        do
                        {
                            foreach (var salon in profesor.SalonesAsignados)
                            {
                                WriteLine($"Salón {salon.Identificador} : {salon.Nombre}");
                            }




                            string? NumSalon = ReadLine();

                            if (int.TryParse(NumSalon, out opcionSalon) && opcionSalon >= 1 && opcionSalon <= 10)
                            {
                                break; // Salir del bucle si la entrada es válida
                            }
                            else
                            {
                                WriteLine($"Opción no válida. Por favor, ingrese un número entre 1 y 10 .");
                            }

                        } while (true);

                        foreach (var salon in profesor.SalonesAsignados)
                        {
                            if (salon.Identificador == opcionSalon)
                            {
                                WriteLine($"Eligiendo... Salon {salon.Identificador} : {salon.Nombre}");

                                foreach (var item in salon.Grupos)
                                {


                                    WriteLine($"Grupo {item}");
                                }


                                switch (opcionGrupo)
                                {
                                    case 1:
                                        Write("Nuevo Grupo que Imparte: ");

                                        string? input = ReadLine();
                                        salon.Grupos.Add(input);

                                        foreach (var item in salones)
                                        {

                                            item.Grupos.Add(input);

                                        }

                                        break;
                                    case 2:
                                        Write("Grupo a Eliminar: ");

                                        string? GrupoAEliminar = ReadLine();

                                        if (salon.Grupos.Contains(GrupoAEliminar))
                                        {
                                            salon.Grupos.Remove(GrupoAEliminar);
                                            foreach (var item in salones)
                                            {
                                                if (item.Grupos.Contains(GrupoAEliminar))
                                                {
                                                    item.Grupos.Remove(GrupoAEliminar);
                                                }
                                            }
                                            WriteLine($"El grupo '{GrupoAEliminar}' ha sido eliminada correctamente.");
                                        }
                                        else
                                        {
                                            WriteLine($"El grupo '{GrupoAEliminar}' no existe en la lista. No se puede eliminar.");
                                        }

                                        break;
                                    case 3:

                                        string? GrupoAEditar = ReadLine();

                                        if (salon.Grupos.Contains(GrupoAEditar))
                                        {

                                            salon.Grupos.Remove(GrupoAEditar);


                                            WriteLine("Modificacion grupo: ");
                                            string? GrupoNuevo = ReadLine();
                                            salon.Grupos.Add(GrupoNuevo);

                                            foreach (var item in salones)
                                            {
                                                if (item.Grupos.Contains(GrupoAEditar))
                                                {
                                                    item.Grupos.Remove(GrupoAEditar);
                                                    item.Grupos.Add(GrupoNuevo);
                                                }
                                            }


                                            WriteLine($"El grupo '{GrupoAEditar}' ha sido cambiado por '{GrupoNuevo}' correctamente.");
                                        }
                                        else
                                        {
                                            WriteLine($"El grupo '{GrupoAEditar}' no existe en la lista. No se puede eliminar.");
                                        }





                                        break;
                                    case 4:
                                        break;
                                    default:
                                        WriteLine("Opción no válida.");
                                        break;






                                }
                            }


                        }


                    }

                    break;

                default:
                    WriteLine("Opción no válida.");
                    break;
            }



//Guardando cambios serializando

            SerializarXMLProfesores();
            SerializarXMLSalones();
            SerializarJsonSalones();
            SerializarJsonProfesores();

        }
        else
        {
            WriteLine("Profesor no encontrado.");
        }

    }

    public static void EliminarProfesor()
    {

        //limpiar listas de profesores y salones

        profesores.Clear();
        salones.Clear();


//obtener profesores y salones de los archivos

        DeserializarXMLProfesores();
        DeserializarXMLSalones();

        Write("Ingrese la Nomina del profe a eliminar: ");

        string Nomina = CalcularHash(ReadLine()); // En un entorno real, se debe encriptar la Contrasenia  y compararla con la almacenada.


//verificar si hay un profesor con esa nomina
        Profesor? profesor = profesores.FirstOrDefault(p => p.Nomina == Nomina);

        if (profesor != null)
        {

        //si hay un profesor con esa nomina, borrarlo de la lista de profesores
            profesores.Remove(profesor);
            WriteLine("Profesor eliminado correctamente.");

            //ademas borrarlo de todas las relaciones con los salones

            foreach (var item in salones)
            {

                if (item.ProfesoresAsignados.Contains(profesor.Nomina))
                {
                    item.ProfesoresAsignados.Remove(profesor.Nomina);
                }

            }


//guardar cambios serializando
            SerializarXMLProfesores();
            SerializarXMLSalones();

            SerializarJsonSalones();
            SerializarJsonProfesores();

        }
        else
        {
            WriteLine("Profesor no encontrado.");
        }
    }

    public static void CambiarContrasenia()
    {

        int opcion;

        //limpiar listas de profesores y salones

        almacenistas.Clear();
        profesores.Clear();

        //obtener profesores y salones de los archivos

        DeserializarXMLAlmacenistas();
        DeserializarXMLProfesores();

        do
        {

            //menu de opciones
            WriteLine("1: Profesor");
            WriteLine("2: Almacenista");
            WriteLine("3: Salir");

            string? input = ReadLine();

            if (int.TryParse(input, out opcion) && opcion >= 1 && opcion <= 3)
            {
                break; // Salir del bucle si la entrada es válida
            }
            else
            {
                WriteLine("Opción no válida. Por favor, ingrese un número entre 1 y 3.");
            }
        } while (true);

        switch (opcion)
        {
            case 1:
                CambiarContraseniaProfesor();
                break;
            case 2:
                CambiarContraseniaAlmacenista();
                break;
            case 3:
                break;
            default:
                WriteLine("Opción no válida.");
                break;
        }

    }


//Generaciones de reportes
    public static void GenerarReportes()
    {

        //campos de opciones
        WriteLine("Campos de organización:");
        WriteLine("1. Nombre Completo");
        WriteLine("2. Nomina");
        WriteLine("3. Password");
        WriteLine("4. Materias");
        WriteLine("5. Division");

        //WriteLine("6. Grupo");
        //WriteLine("7. Salon");

        int opcion = int.Parse(ReadLine());

        switch (opcion)
        {

            //Mandar reporte segun el cambio
            case 1:
                GenerarReporte("NombreCompleto");
                break;
            case 2:
                GenerarReporte("Nomina");
                break;
            case 3:
                GenerarReporte("Password");
                break;
            case 4:
                GenerarReporte("Materias");
                break;
            case 5:
                GenerarReporte("Division");
                break;

            default:
                WriteLine("Opción no válida.");
                break;
        }
    }

    public static void GenerarReporte(string campoOrganizacion)
    {
        profesores.Clear();
        DeserializarXMLProfesores();

        OrdenarProfesores(campoOrganizacion);

        // Obtener la ruta al directorio MyDocuments
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Crear la carpeta Archivos si no existe
        string archivosDirectory = Path.Combine(myDocumentsPath, "Archivos");
        Directory.CreateDirectory(archivosDirectory);

        // Crear la carpeta Reportes dentro de Archivos si no existe
        string reportesDirectory = Path.Combine(archivosDirectory, "Reportes");
        Directory.CreateDirectory(reportesDirectory);

        // Rutas de los archivos dentro de la carpeta Reportes
        string jsonNombreArchivo = Path.Combine(reportesDirectory, $"Reporte_{campoOrganizacion}.json");
        string xmlNombreArchivo = Path.Combine(reportesDirectory, $"Reporte_{campoOrganizacion}.xml");

        var profesoresOrdenados = new List<Profesor>(profesores);

        // Generar reporte JSON
        File.WriteAllText(jsonNombreArchivo, JsonConvert.SerializeObject(profesoresOrdenados, Formatting.Indented));
        WriteLine($"Reporte JSON generado: {jsonNombreArchivo}");

        // Generar reporte XML
        XmlSerializer serializer = new XmlSerializer(typeof(List<Profesor>));
        using (TextWriter writer = new StreamWriter(xmlNombreArchivo))
        {
            serializer.Serialize(writer, profesoresOrdenados);
        }

        WriteLine($"Reporte XML generado: {xmlNombreArchivo}");
    }



    public static void OrdenarProfesores(string campoOrganizacion)
    {

        //ordenar los campos de los profesores segun el campo de organizacion (de la A-Z)
        switch (campoOrganizacion)
        {
            case "NombreCompleto":
                profesores.Sort((p1, p2) => p1.NombreCompleto.CompareTo(p2.NombreCompleto));
                break;
            case "Nomina":
                profesores.Sort((p1, p2) => p1.Nomina.CompareTo(p2.Nomina));
                break;
            case "Password":
                profesores.Sort((p1, p2) => p1.Contrasenia.CompareTo(p2.Contrasenia));
                break;
            case "Materias":
                profesores.Sort((p1, p2) => p1.Materias[0].CompareTo(p2.Materias[0]));
                break;
            case "Division":
                profesores.Sort((p1, p2) => p1.Division.CompareTo(p2.Division));
                break;
        }
    }






    // Función para calcular el hash de una cadena usando SHA256
    public static string CalcularHash(string input)
    {

        //Encriptar de acuerdo al algoritmo SHA256
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public static bool ValidarArchivos()
    {

        // Directorio base
        string directorioBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos");

        // Nombres de archivos
        string archivoXmlAlmacenistas = "almacenistas.xml";
        string archivoJsonAlmacenistas = "almacenistas.json";

        string archivoXmlProfesores = "profesores.xml";
        string archivoJsonProfesores = "profesores.json";

        string archivoXmlSalones = "salones.xml";
        string archivoJsonSalones = "salones.json";

        // Rutas completas de los archivos
        string rutaXmlAlmacenistas = Path.Combine(directorioBase, archivoXmlAlmacenistas);
        string rutaJsonAlmacenistas = Path.Combine(directorioBase, archivoJsonAlmacenistas);

        string rutaXmlProfesores = Path.Combine(directorioBase, archivoXmlProfesores);
        string rutaJsonProfesores = Path.Combine(directorioBase, archivoJsonProfesores);

        string rutaXmlSalones = Path.Combine(directorioBase, archivoXmlSalones);
        string rutaJsonSalones = Path.Combine(directorioBase, archivoJsonSalones);


        // Verificar si existen los archivos XML
        if (File.Exists(rutaXmlAlmacenistas) && File.Exists(rutaXmlProfesores) && File.Exists(rutaXmlSalones)
        && File.Exists(rutaJsonAlmacenistas) && File.Exists(rutaJsonProfesores) && File.Exists(rutaJsonSalones))
        {
            return true;
        }
        else
        {
            return false;
        }


    }



}


