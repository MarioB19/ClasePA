
using System.Collections.Generic;
using System;
using System.Security.AccessControl;
using System.Xml.Serialization;
using PA17F.Shared;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using static System.Console;
using System.Text;
using Newtonsoft.Json;
using FastJson = System.Text.Json.JsonSerializer;
using System.Dynamic;


public partial class Program{



    public static List<Almacenista> almacenistas = new List<Almacenista>();
    public static List<Profesor> profesores = new List<Profesor>();
    static List<Salon> salones = new List<Salon>();

    public static XmlSerializer xsAlmacenistas = new XmlSerializer(typeof(List<Almacenista>));
    public static string pathAlmacenistas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "almacenistas.xml");

    public static XmlSerializer xsProfesores = new XmlSerializer(typeof(List<Profesor>));
    public static string pathProfesores = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "profesores.xml");

    public static XmlSerializer xsSalones = new XmlSerializer(typeof(List<Salon>));
    public static string pathSalones = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "salones.xml");

    public static string jsonAlmacenistas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "almacenistas.json");
    public static string jsonProfes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "profesores.json");
    public static string jsonSalones = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "salones.json");


    public static void SerializarXMLAlmacenistas(){
        using (FileStream stream = File.Create(pathAlmacenistas))
        {
            xsAlmacenistas.Serialize(stream, almacenistas);
        }
        

    }
    public static void DeserializarXMLAlmacenistas(){

         using (FileStream xmlLoad = File.Open(pathAlmacenistas, FileMode.Open))
        {
            List<Almacenista>? loadedAlmacenista = xsAlmacenistas.Deserialize(xmlLoad) as List<Almacenista>;
            if (loadedAlmacenista is not null)
            {
                foreach (var item in loadedAlmacenista)
                {
                    almacenistas.Add(item);

                }
            }
     
        }
    }

    public static void SerializarJsonAlmacenistas(){

         using (StreamWriter jsonStream = File.CreateText(jsonAlmacenistas))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                //Serializar
                jss.Serialize(jsonStream, almacenistas);
            }

    }

    public static  void SerializarXMLProfesores(){

             using (FileStream stream = File.Create(pathProfesores))
        {
            xsProfesores.Serialize(stream, profesores);
        }
        

    }

    public static void DeserializarXMLProfesores(){

           using (FileStream xmlLoad = File.Open(pathProfesores, FileMode.Open))
        {
            List<Profesor>? loadedprofesor = xsProfesores.Deserialize(xmlLoad) as List<Profesor>;
            if (loadedprofesor is not null)
            {
                foreach (var item in loadedprofesor)
                {
                    profesores.Add(item);


                }
            }
        }
        

    }

    public static void SerializarJsonProfesores(){

         using (StreamWriter jsonStream = File.CreateText(jsonProfes))
        {
            Newtonsoft.Json.JsonSerializer jss = new();
            //Serializar
            jss.Serialize(jsonStream, profesores);
        }


    }

    public static void SerializarXMLSalones(){
        using (FileStream stream = File.Create(pathSalones))
        {
            xsSalones.Serialize(stream, salones);
        }

    }

    public static  void DeserializarXMLSalones(){

         using (FileStream xmlLoad = File.Open(pathSalones, FileMode.Open))
        {
            List<Salon>? loadedSalones = xsSalones.Deserialize(xmlLoad) as List<Salon>;
            if (loadedSalones is not null)
            {
                foreach (var item in loadedSalones)
                {
                    salones.Add(item);
                }
            }
            }

    }

    public static void SerializarJsonSalones(){

          using (StreamWriter jsonStream = File.CreateText(jsonSalones))
        {
            Newtonsoft.Json.JsonSerializer jss = new();
            //Serializar
            jss.Serialize(jsonStream, salones);
        }

    }

    public static void CambiarContraseniaAlmacenista(){

        Write("Ingrese su Nombre Completo: ");
        string ?nombreCompleto = ReadLine();
        
        Almacenista? almacenista = almacenistas.FirstOrDefault(a => a.NombreCompleto == nombreCompleto);

        if (almacenista != null){

        Write("Ingrese la nueva Contrasenia : ");
        string nuevaContrasenia = CalcularHash(ReadLine());

        
            almacenista.Contrasenia = nuevaContrasenia;


            SerializarXMLAlmacenistas();
            SerializarJsonAlmacenistas();


            WriteLine("Contrasenia  cambiada correctamente.");
        }else{
            WriteLine("Usuario no encontrado.");
        }
        

    }

    public static void CambiarContraseniaProfesor(){

          Write("Ingrese su nomina: ");
        string ?nomina = CalcularHash(ReadLine());

           Profesor? profesor = profesores.FirstOrDefault(p => p.Nomina == nomina);

            if (profesor != null)
            {
                   Write("Ingrese la nueva Contrasenia : ");
        string nuevaContrasenia = CalcularHash(ReadLine());


                profesor.Contrasenia = nuevaContrasenia;

                SerializarXMLProfesores();
                SerializarJsonProfesores();

                WriteLine("Contrasenia  cambiada correctamente.");
            }
            else
            {
                WriteLine("Usuario no encontrado.");
            }
        }



    }

  




