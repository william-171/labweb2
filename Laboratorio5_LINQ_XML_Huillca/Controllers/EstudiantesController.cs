using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio5_LINQ_XML_Huillca.Models;
using System.Data;

namespace Laboratorio5_LINQ_XML_Huillca.Controllers
{
    public class EstudiantesController : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarDS()
        {
            ClsEstudiantes objestudiante = new ClsEstudiantes();
            var data = objestudiante.listarestudiantes();

            return View(data.ToList());
        }

        public ActionResult ListarXdocument(ClsEstudiantes objestudiante)
        {
            //ClsEstudiantes objestudiante = new ClsEstudiantes();
            //var data = objestudiante.listarestudiantes();

            return View(objestudiante.listarestudiantes2());
        }

        public ActionResult obtenercodigoDS(ClsEstudiantes objestudiante, string codigo)
        {
            if(codigo =="" || codigo == null)
            {
                return View(objestudiante.listarestudiantes());
            }
            else
            {
                return View(objestudiante.obtenerporcodigo(codigo));
            }
        }

        public ActionResult obtenercodigoXdocument(ClsEstudiantes objestudiante, string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return View(objestudiante.listarestudiantes2());
            }
            else
            {
                return View(objestudiante.obtenerporcodigo2(codigo));
            }
        }
    }
}