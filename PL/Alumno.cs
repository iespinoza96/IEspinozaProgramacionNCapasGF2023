using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Inserte el nombre del alumno: ");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Inserte el Apellido Paterno del alumno: ");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Inserte el Apellido Materno del alumno: ");
            alumno.ApellidoMaterno = Console.ReadLine();


            //ML.Result result = BL.Alumno.Add(alumno); //Query
            //ML.Result result = BL.Alumno.AddSP(alumno); //SP
            ML.Result result = BL.Alumno.AddEF(alumno); //EF

            if (result.Correct)
            {
                Console.WriteLine("Se inserto el alumno");

            }
            else
            {
                Console.WriteLine("No se inserto el alumno");


            }

            Console.ReadKey();
        }

        public static void GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();

            if (result.Correct)
            {
                //unboxing
                foreach (ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                    Console.WriteLine("Nombre: " + alumno.Nombre);
                    Console.WriteLine("Apellido Paterno: " + alumno.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + alumno.ApellidoMaterno);
                    Console.WriteLine("----------------------------------------------");

                }

            }

            Console.ReadKey();
        }

        public static void GetById()
        {
            //ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingrese el Id del alumno que desea consultar: ");

            int IdAlumno = int.Parse(Console.ReadLine());
            ML.Result result = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                //unboxing

                ML.Alumno alumno = (ML.Alumno)result.Object;
                //foreach (ML.Alumno alumno in result.Objects)
                //{
                Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                Console.WriteLine("Nombre: " + alumno.Nombre);
                Console.WriteLine("Apellido Paterno: " + alumno.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + alumno.ApellidoMaterno);
                Console.WriteLine("----------------------------------------------");

                //}

            }

            Console.ReadKey();
        }

    }
}
