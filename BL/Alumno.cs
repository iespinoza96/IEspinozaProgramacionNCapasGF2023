using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (var conn = new SqlConnection("Data Source=.;Initial Catalog=IEspinozaProgramacionNCapasGF2023;Persist Security Info=True;User ID=sa;Password=pass@word1"))
                {
                    var cmd = new SqlCommand("INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno]) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno)", conn);
                    cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Alumno insertado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Ocurrio un error al agregar el alumno";
            }


            return result;

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}
