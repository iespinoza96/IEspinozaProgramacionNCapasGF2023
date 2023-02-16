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
    }
}