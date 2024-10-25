using MySql.Data.MySqlClient;
using System.Data;


namespace libreriaClase{

    class Persona
    {

//        private string nombre;
        public string Apellido {get;set;}
        public string Nombre {get;set;}
        public int DNI {get;set;}
        public string FechaNacimiento {get;set;}
       

        public  Persona(string rApellido,string rNombre, string rFechaNacimiento, int rDni){
            Apellido = rApellido;
            Nombre = rNombre;
            FechaNacimiento = rFechaNacimiento;
            DNI = rDni;
        }

        public Persona(){
            
        }
        /*
        public string caminar(){

            return "Caminando....";

        }*/

        public void mostrarPersona(){
            Console.WriteLine("Apellido: {0}", Apellido);
            Console.WriteLine("Nombre: {0}", Nombre);
            Console.WriteLine("Fecha Nacimiento: {0}", FechaNacimiento);
            Console.WriteLine("DNI: {0}", DNI);
        }

/*        public void devolverEdad(){
            Console.WriteLine("La edad es:.....");
        }*/

    }


    class Alumno : Persona {

        private int legajo;
        private string curso;

        private int[] notas;


/*        public void estudiar(){
            Console.WriteLine("Estudiando....");
        }*/

        public void devolverCurso(){
            Console.WriteLine("El curso es: {0}", this.curso);
        }
    }



    class conexionBD{

        MySqlConnection Conector; //objeto   atributos?

        MySqlCommand Comando;

        public void conectar (){ //metodo

                //Conector = new MySqlConnection(@"server=127.0.0.1;database=5to_escuela;Uid=5to_agbd;pwd=Triggers!");
                Conector=new MySqlConnection(@"server=127.0.0.1;database=5to_escuela;Uid=root;pwd=123456789");

                Comando = Conector.CreateCommand();

        }

        public void insertarBD (Persona rPersona) {

            //Comando.CommandText = "insert into Persona (DNI,Apellido,Nombre,FechaNacimiento) values (1233246,'Sanchez','Miguel',' 21.05.2015') ";
            
            Comando.CommandText = "insert into Persona (DNI,Apellido,Nombre,FechaNacimiento) values ('"+ rPersona.DNI +
            "', '"+ rPersona.Apellido +"', '"+ rPersona.Nombre +"', '"+ rPersona.FechaNacimiento + "')";
            
            Comando.CommandType = CommandType.Text;  //va siempre asi
            Conector.Open();
            Comando.ExecuteNonQuery();
            Conector.Close();
            
        }

        public void mostrarEscalar(){

            string sql ="select Apellido from Persona where DNI = '5464645'";
            Comando.CommandText = sql;
            Comando.CommandType = CommandType.Text;
            Conector.Open();
            object datoDevuelto = Comando.ExecuteScalar();
            Conector.Close();

            Console.WriteLine (datoDevuelto);
            Console.ReadKey();
        }

        public object countPersonNameBD (string rNombre) {

            object cantidadObjeto;

            Comando.CommandText ="select count(*) from persona where Nombre = '" + rNombre + "'";

            Comando.CommandType=CommandType.Text;
            Conector.Open();
            cantidadObjeto= Comando.ExecuteScalar();
            Conector.Close();

            return cantidadObjeto;
        }

        public void mostrarAlumnos() {
            int c=0;

            string sql = "SELECT * FROM 5to_escuela.persona";
            Comando.CommandText = sql;
            Conector.Open();
            MySqlDataReader datos = Comando.ExecuteReader();

            Console.Clear();
            while (datos.Read()) {

                //Console.WriteLine ("-idpe: "+datos[0]+"\t-dni "+datos[1]+"\tApellido: "+datos[2]+ "\tNombre: "+datos[3]+ "\tFecha Nac: "+datos[4]);
                Console.WriteLine("-DNI {1}\r\nApellido: {2}\r\nNombre: {3}\r\nFecha Nac: {4}",datos[0],datos[1],datos[2],datos[3],datos[4]);
                Console.WriteLine("------------");
                c++;
            }
            datos.Close();
            Conector.Close();
            Console.WriteLine ("Se mostraron {0} registros",c);        

        }

        public void  borrarAlumnoBD() {
            string opcion,dni,sql;
           
            Console.WriteLine ("Ingrese DNI a borrar");
            dni = Console.ReadLine();
            if (dni == "") dni = "0"; //evito el error de no poner numero

            // armo el comando sql
            sql = "SELECT * FROM 5to_escuela.persona where dni=" + dni;
            Console.WriteLine ("\t\t\t..........vamos a ejecutar->{0}<-",sql);  //comprobando

            Conector.Open();
            Comando.CommandText = sql;
            MySqlDataReader datos = Comando.ExecuteReader();

//1 mostrar registro a borrar
            Console.WriteLine("La persona a borrar es ");
           if (datos.Read() == false)  Console.WriteLine("----INEXISTENTE-------");
            else { // 2 existe
                Console.Clear();

//                Console.WriteLine ("...........existe");
                do {
                    Console.WriteLine("-DNI {1}\r\nApellido: {2}\r\nNombre: {3}\r\nFecha Nac: {4}",datos[0],datos[1],datos[2],datos[3],datos[4]);
                    Console.WriteLine("------------");
                } while (datos.Read());

                datos.Close();
                Conector.Close();
//1 fin mostrar
                //3 confirma borrar
                Console.WriteLine ("Escriba OK para borrar...");
                opcion= Console.ReadLine();

                if (opcion == "OK") {
                    Conector.Open();
                    Comando.CommandText = "DELETE from Persona WHERE dni=" + dni ;
                    Comando.ExecuteNonQuery();
                    Conector.Close();

                    Console.WriteLine ("\r\nDNI borrado");
                }
                else {
                    Console.WriteLine ("Cancelando...");
                }//3 fin confirma
            }//2 fin else existe

            Console.WriteLine ("Pulse para continuar");
            Console.ReadKey();

        }

    }
    
} 