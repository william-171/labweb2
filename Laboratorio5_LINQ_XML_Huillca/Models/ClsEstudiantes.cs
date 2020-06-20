using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Laboratorio5_LINQ_XML_Huillca.Models
{
    [Serializable]
    [XmlRoot("Estudiantes"),XmlType("Estudiantes")]
    public class ClsEstudiantes
    {
        public int dni { get; set; }
        public int codigo { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int celular { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string email { get; set; }

        public List<ClsEstudiantes> listarestudiantes()
        {
            //definir datos
            string xmldata = HttpContext.Current.Server.MapPath("~/App_Data/Estudiantes.xml");
            DataSet ds = new DataSet();

            ds.ReadXml(xmldata);
            var objestudiantes = new List<ClsEstudiantes>();

            objestudiantes = (from col in ds.Tables[0].AsEnumerable()
                              select new ClsEstudiantes
                              {
                                  dni = int.Parse(col[0].ToString()),
                                  codigo = int.Parse(col[1].ToString()),
                                  apellido = col[2].ToString(),
                                  nombre =col[3].ToString(),
                                  email = col[4].ToString(),
                                  celular = int.Parse(col[5].ToString()),
                                  sexo = col[6].ToString(),
                                  edad = int.Parse(col[7].ToString()),

                              }
            ).ToList();

            return objestudiantes;
        }

        public List<ClsEstudiantes> listarestudiantes2()
        {
            //definir datos
            XDocument xmlData = XDocument.Load( HttpContext.Current.Server.MapPath("~/App_Data/Estudiantes.xml"));
            //DataSet ds = new DataSet();

            //ds.ReadXml(xmldata);
            var objestudiantes = new List<ClsEstudiantes>();

            objestudiantes = (from col in xmlData.Descendants("estudiante")
                              orderby col.Element("apellidos").ToString()
                              select new ClsEstudiantes
                              {
                                  dni = int.Parse(col.Element("dni").Value),
                                  codigo = int.Parse(col.Element("codigo").Value),
                                  apellido = col.Element("apellidos").Value,
                                  nombre = col.Element("nombre").Value,
                                  email = col.Element("email").Value,
                                  celular = int.Parse(col.Element("celular").Value),
                                  sexo = col.Element("sexo").Value,
                                  edad = int.Parse(col.Element("edad").Value),

                              }
            ).ToList();

            return objestudiantes;
        }

        public List<ClsEstudiantes> obtenerporcodigo(string codigo)
        {
            //definir datos
            string xmldata = HttpContext.Current.Server.MapPath("~/App_Data/Estudiantes.xml");
            DataSet ds = new DataSet();

            ds.ReadXml(xmldata);
            var objestudiantes = new List<ClsEstudiantes>();

            objestudiantes = (from col in ds.Tables[0].AsEnumerable()
                              where col[1].ToString() == (codigo) || col[2].ToString()==(codigo)
                              select new ClsEstudiantes
                              {
                                  dni = int.Parse(col[0].ToString()),
                                  codigo = int.Parse(col[1].ToString()),
                                  apellido = col[2].ToString(),
                                  nombre = col[3].ToString(),
                                  email = col[4].ToString(),
                                  celular = int.Parse(col[5].ToString()),
                                  sexo = col[6].ToString(),
                                  edad = int.Parse(col[7].ToString()),

                              }
            ).ToList();

            return objestudiantes;
        }

        public List<ClsEstudiantes> obtenerporcodigo2(string codigo)
        {
            //definir datos
            XDocument xmldata = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Estudiantes.xml"));
            //DataSet ds = new DataSet();

            //ds.ReadXml(xmldata);
            var objestudiantes = new List<ClsEstudiantes>();

            objestudiantes = (from col in xmldata.Descendants("estudiante")
                              where col.Element("codigo").Value.ToString() == (codigo) ||
                              col.Element("apellidos").Value.ToString() == (codigo)

                              orderby col.Element("apellidos").ToString()
                              select new ClsEstudiantes
                              {
                                  dni = int.Parse(col.Element("dni").Value),
                                  codigo = int.Parse(col.Element("codigo").Value),
                                  apellido = col.Element("apellidos").Value,
                                  nombre = col.Element("nombre").Value,
                                  email = col.Element("email").Value,
                                  celular = int.Parse(col.Element("celular").Value),
                                  sexo = col.Element("sexo").Value,
                                  edad = int.Parse(col.Element("edad").Value),

                              }
            ).ToList();

            return objestudiantes;
        }

    }
}