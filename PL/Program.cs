using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PL.SumaServiceReference;
using PL.ServiceSuma;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PL.Alumno.GetAll();
            //PL.Alumno.GetById();
            //PL.Alumno.Add();

            SumaClient client = new SumaClient();
           
            int a = 5; int b = 6;
            int restult = client.SumarNumeros(a, b);

            Console.WriteLine("El resutlado de la suma es:"+ restult);
            Console.ReadKey();
        }
    }
}
