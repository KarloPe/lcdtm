﻿using System;
using System.Security.AccessControl;
using System.Collections.Generic;  //librería de LIST
using libreriaClase;

namespace libreria
{

    class Principal{
    
        static void Main(){

            List<Persona> listaPersona = new List<Persona>();

            string opcion = mostrarMenu();

            while (true) {

                switch(opcion) 
                            {
                            case "1":
                                listaPersona.Add(crearPersona());
                                break;
                            case "2":
                                mostrarPersona(listaPersona);
                                break;
                            case "3":
                                buscarPersona(listaPersona);
                                break;
                            case "4":
                                insertarPersona(listaPersona);
                                break;
                            case "5":
                                contarNomPer();
                                break;
                            case "6":
                                muestraTodo();
                                break;
                            case "7":
                                borraalu();
                                break;
                            case "99":
                                bai();
                                return;

                            default:
                                Console.WriteLine("Opción Incorrecta...");
                                Console.ReadKey();
                                break;
                            }

            opcion = mostrarMenu();

            }

        }

        public static void bai() {

        Console.WriteLine("Vuelva prontos...");

        for (int i = 0; i < 44444; i++) 
         {
        Console.Write ("\r/");
        Console.Write ("\r-\r");
        Console.Write (@"\");
        Console.Write ("\r|");}    
        }

         public static Persona crearPersona(){

            Console.Clear();
            Persona p1 = new Persona();

            Console.WriteLine("Ingreso de Personas");
            Console.WriteLine("-------------------");
            Console.WriteLine("");

            Console.Write("Ingrese Apellido: ");
            p1.Apellido = Console.ReadLine();

            Console.Write("Ingrese Nombre: ");
            p1.Nombre = Console.ReadLine();

            Console.Write("Ingrese DNI: ");
            p1.DNI = Convert.ToInt32(Console.ReadLine());            
            

            Console.Write("Ingrese Fecha Nacimiento: ");
            p1.FechaNacimiento = Console.ReadLine();

            return p1;

        }

        public static void mostrarPersona(List<Persona> personas){
                Console.Clear();
                foreach(var elem in personas){
                    
                    Console.Write("Apellido: ");
                    Console.WriteLine(elem.Apellido);
                    Console.Write("Nombre: ");
                    Console.WriteLine(elem.Nombre);
                        Console.Write("DNI:");
                        Console.WriteLine(elem.DNI);
                        Console.Write("Fecha Nacimiento:");
                        Console.WriteLine(elem.FechaNacimiento);
                        
                    //Console.WriteLine("");
                    Console.WriteLine("-------*-*-------");
                    //Console.WriteLine(("").PadRight(24, '-'));

                    
                }
                Console.ReadKey();
        }

        public static void buscarPersona(List<Persona> personas){
                int dni;
                int flag=0;
                Console.Clear();
                Console.Write("Ingrese DNI Persona a buscar: ");
                dni = Convert.ToInt32(Console.ReadLine());

                foreach(var elem in personas){

                    if ( elem.DNI == dni ){

                        Console.Write("Apellido: ");
                        Console.WriteLine(elem.Apellido);
                        Console.Write("Nombre: ");
                        Console.WriteLine(elem.Nombre);
                        Console.Write("DNI:");
                        Console.WriteLine(elem.DNI);
                        Console.Write("Fecha Nacimiento:");
                        Console.WriteLine(elem.FechaNacimiento);
                        Console.WriteLine("----------------");

                        Console.ReadKey();
                        flag = 1;

                    }

                }
                if (flag == 0){
                    Console.WriteLine("Registro No Encontrado");
                    Console.ReadKey();
                }
    }

//              BD   SQL
        public static void insertarPersona(List<Persona> rlistaPersona) {
        
            conexionBD con = new conexionBD();

            con.conectar();

            foreach (var p in rlistaPersona) {

                con.insertarBD(p);

            }

            Console.WriteLine (" Registros insertados...");
            Console.WriteLine ("Presione una tecla para continuar <3");
            Console.ReadKey();
            
        }

        public static void contarNomPer () {

            conexionBD con = new conexionBD();
            con.conectar();
            
            string nombre;

            Console.Clear();            
            
            Console.Write ("Ingrese nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine ("");
            Console.WriteLine ("El nombre ingresado existe {0} veces", con.countPersonNameBD(nombre) );
            Console.WriteLine ("Presione una tecla para continuar <3");
            Console.ReadKey();

        }


        public static void muestraTodo() {

            conexionBD con = new conexionBD();
            con.conectar();

            Console.Clear();
            con.mostrarAlumnos();

            
            Console.WriteLine ("");
            Console.WriteLine ("Presione una tecla para continuar <3");
            Console.ReadKey();
            
        }

        public static void borraalu() {

            conexionBD con = new conexionBD();
            con.conectar();

            con.borrarAlumnoBD();
        
            Console.WriteLine ("Presione una tecla para continuar <3");
            Console.ReadKey();
        }

/// ////////////////////////////////////////////////////////////////////
        public static string mostrarMenu(){

            string opcion;

            Console.Clear();
           
            Console.WriteLine("- Menú -");
            Console.WriteLine("--------");
            Console.WriteLine("1.- Crear Alumno");
            Console.WriteLine("2.- Mostrar Alumnos");
            Console.WriteLine("3.- Buscar Alumno");
            Console.WriteLine("4.- Exportar alumnos a BD");
            Console.WriteLine("5.- Contar la cantidad de nombres ");
            Console.WriteLine("6.- Mostrar Alumnos BD");
            Console.WriteLine("7.- Borrar alumno x dni");
            Console.WriteLine("99.- Salir \r\n\r\n");
            Console.BackgroundColor = ConsoleColor.Blue; 
            Console.Write("Elija una opción: ");
            Console.BackgroundColor = ConsoleColor.Black;

            opcion = Console.ReadLine();

            return opcion;

        }
    }
    
}