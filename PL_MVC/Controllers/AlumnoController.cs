using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet] 
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF(); //EF
            ML.Alumno alumno = new ML.Alumno();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else 
            { 
                return View(alumno);
            }
            
        }

        [HttpGet]
        public ActionResult Form(int? idAlumno) //2
        {
            ML.Result resultSemestre = BL.Semestre.GetAll();
            ML.Result resultPlantel = BL.Plantel.GetAll();

            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();

            alumno.Horario = new ML.Horarios();
            alumno.Horario.Grupo = new ML.Grupo();
            alumno.Horario.Grupo.Plantel = new ML.Plantel();


            if (resultSemestre.Correct && resultPlantel.Correct)
            {
                alumno.Horario.Grupo.Plantel.Planteles = resultPlantel.Objects;
                alumno.Semestre.Semestres = resultSemestre.Objects;
            }
            if (idAlumno == null)
            {
                //add //formulario vacio
                return View(alumno);
            }
            else
            {
                //getById
                ML.Result result = BL.Alumno.GetById(idAlumno.Value); //2

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;//unboxing
                    alumno.Semestre.Semestres = resultSemestre.Objects;
                    //update
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información del alumno";
                    return View("Modal");
                }
                
                
            }

            
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.IdAlumno == 0)
            {
                //add 
                result = BL.Alumno.AddEF(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                
                return View("Modal");
            }
            else
            {

                //update
                //result = BL.Alumno.Add(alumno);

                //if (result.Correct)
                //{
                //    ViewBag.Message = "Se actualizo la información satisfactoriamente";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                //}
                return View("Modal");
            }


        }

        [HttpGet]
        public ActionResult Delete(int idAlumno)
        {
            //ML.Result result = BL.Alumno.Delete(idAlumno);
            return View();
        }
        [HttpPost]
        public JsonResult GrupoGetByIdPlantel(int idPlantel)
        {
            ML.Result result = new ML.Result();
            result = BL.Grupo.GetByIdPlantel(idPlantel);

            return Json(result);
        }
    }
}