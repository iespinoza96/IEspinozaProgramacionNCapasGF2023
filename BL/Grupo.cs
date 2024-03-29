﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int idPlantel)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGF2023Entities context = new DL_EF.IEspinozaProgramacionNCapasGF2023Entities())
                {
                    var query = context.GrupoGetByIdPlantel(idPlantel).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Grupo grupo = new ML.Grupo();

                            grupo.IdGrupo = obj.IdGrupo;
                            grupo.Nombre = obj.Nombre;


                            result.Objects.Add(grupo);
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
