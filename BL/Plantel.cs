using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGF2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGF2023Entities())
                {
                    var query = context.GetAllPlantel().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Plantel plantel = new ML.Plantel();

                            plantel.IdPlantel = obj.IdPlantel;
                            plantel.Nombre = obj.Nombre;


                            result.Objects.Add(plantel);

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
    }
}
