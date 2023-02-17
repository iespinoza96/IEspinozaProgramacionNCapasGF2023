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
        public ActionResult Form(int? IdAlumno) 
        {
            if (IdAlumno == null)
            {
                //add //formulario vacio
                return View();
            }
            else
            {
                //getById
                //update
                return View();
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
                
                return View();
            }
            else
            {
                //getById
                //update
                return View();
            }


        }


    }
}