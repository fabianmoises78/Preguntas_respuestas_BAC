using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preguntas_Respuestas.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
    }

    public class Preguntas
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public int IdUsuario { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Usuario { get; set;}
    }

    public class Respuestas
    {
        public int IdRespuesta { get; set; }
        public string Respuesta { get; set; }
        public int IdPregunta { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set;}
    }

    public class LoginUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
    }
}
