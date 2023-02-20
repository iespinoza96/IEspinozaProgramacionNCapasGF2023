using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        //EF
        //add
        //update
        ////delete
        //getall
        //getbyId

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGF2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGF2023Entities())
                {
                    var query = context.SemestreGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Semestre semestre = new ML.Semestre();

                            semestre.IdSemestre = obj.IdSemestre;
                            semestre.Nombre = obj.Nombre;


                            result.Objects.Add(semestre);

                        }
                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        //LINQ 

        //add
        //update
        ////delete
        //getall
        //getbyId
    }
}
