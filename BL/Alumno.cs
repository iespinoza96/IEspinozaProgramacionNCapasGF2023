using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
                //using (var conn = new SqlConnection("Data Source=.;Initial Catalog=IEspinozaProgramacionNCapasGF2023;Persist Security Info=True;User ID=sa;Password=pass@word1"))
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString())) // obtengo la cadena de conexion del DL
                {
                   // var cmd = new SqlCommand("INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno]) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno)", conn);
                   string query = "INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno]) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno)"; //obtengo el query a ejecutar 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //asigno la cadena de conexion al objeto cmd
                        cmd.CommandText = query; //asigno el query al objeto cmd


                        //cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        //cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno);
                        //cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno);

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        //con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al agregar el alumno";
            }


            return result;

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))//conexion
                {
                    string query = "AlumnoGetAll";

                    using(SqlCommand cmd = new SqlCommand()) 
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable alumnoDataTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(alumnoDataTable);

                        if (alumnoDataTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in alumnoDataTable.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.IdAlumno = (int)row[0];
                                alumno.Nombre = (string)row[1];
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                                result.Objects.Add(alumno); //boxing

                            }
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {

                
            }
            return result;
        }


    }
}
