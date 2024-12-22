using Preguntas_Respuestas.BusinessLogic;
using Preguntas_Respuestas.DTO;
using Preguntas_Respuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Preguntas_Respuestas.Controllers
{
    public class HomeController : Controller
    {
        PreguntasLogic data = new PreguntasLogic();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Registro()
        {
            return View();
        }

        public JsonResult RegistrarUsuario(Usuario entity)
        {
            GenericDTO response = new GenericDTO();

            try
            {
                int result = data.UsuarioExiste(entity);
                if (result > 0)
                {
                    response.Status = 0;
                    response.Message = "El Usuario ya existe...";
                    return Json(response);
                }
                else
                {
                    if (entity.Nombre != null && entity.Usuario1 != null && entity.Contraseña != null)
                    {
                        data.RegistrarUsuario(entity);
                        response.Status = 1;
                        response.Message = "Usuario registrado con exito.";
                        return Json(response);
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = "Los datos no pueden ir vacios...";
                        return Json(response);
                    }
                }

            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = "Un error ha ocurrido " + ex;
                return Json(response);
            }
        }

        public JsonResult Login(Usuario entity)
        {
            GenericDTO response = new GenericDTO();

            try
            {
                List<LoginUsuario> Login = data.LoginUsuario(entity);

                if (Login[0].IdUsuario > 0)
                {
                    response.Status = 1;
                    response.Message = "Bienvenido!";

                    Session["Status"] = "true";
                    Session["ID_USUARIO"] = Login[0].IdUsuario;
                    Session["USUARIO"] = Login[0].Usuario1;
                    Session["NOMBRE"] = Login[0].Nombre;

                    return Json(response);
                }
                else
                {
                    response.Status = 0;
                    response.Message = "El usuario o contraseña son invalidos.";

                    Session["Status"] = "true";
                    Session["ID_USUARIO"] = "";
                    Session["USUARIO"] = "";
                    Session["NOMBRE"] = "";

                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = "Error " + ex;
                return Json(response);
            }
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult CrearPregunta(Preguntas entity)
        {
            GenericDTO response = new GenericDTO();
            var sesion = Convert.ToInt32(Session["ID_USUARIO"]);

            try
            {
                if (sesion > 0)
                {
                    if (entity.Pregunta != null)
                    {
                        var Id_usuario = Convert.ToInt32(Session["ID_USUARIO"]);
                        data.CrearPregunta(entity, Id_usuario);
                        response.Status = 1;
                        response.Message = "Pregunta registrada con exito!";
                        return Json(response);
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = "Datos vacios...";
                        return Json(response);
                    }
                }
                else
                {
                    response.Status = 0;
                    response.Message = "Inicia Sesión para realizar una pregunta";
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = "Un error ha ocurrido... " + ex;
                return Json(response);
            }
        }

        public JsonResult ListarPreguntas()
        {
            List<Preguntas> ListarPreguntas = new List<Preguntas> ();

            using (data)
            {
                var ListPreguntas = data.ListarPreguntar();

                foreach (var item in ListPreguntas)
                {
                    Preguntas asignar = new Preguntas()
                    {
                        IdPregunta = item.IdPregunta,
                        Pregunta = item.Pregunta,
                        IdUsuario = item.IdUsuario,
                        Usuario = item.Usuario,
                        Estado = item.Estado
                    };
                    ListarPreguntas.Add(asignar);
                }
            }
            return Json(ListarPreguntas);
        }

        public JsonResult CrearRespuesta(int IdPregunta, string Respuesta)
        {
            GenericDTO response = new GenericDTO();
            var id_user = Convert.ToInt32(Session["ID_USUARIO"]);
            try
            {
                if (id_user > 0)
                {
                    if (Respuesta != null)
                    {
                        data.CrearRespuesta(IdPregunta, Respuesta, id_user);
                        response.Status = 1;
                        response.Message = "Repuesta registrada con exito!";
                        return Json(response);
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = "Datos Vacios....!";
                        return Json(response);
                    }
                }
                else
                {
                    response.Status = 0;
                    response.Message = "Inicia Sesión para responder.";
                    return Json(response);
                }
                
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = "Un problema ha ocurrido " + ex;
                return Json(response);
            }
        }

        public ActionResult VerPregunta()
        {
            return View();
        }

        public JsonResult LisPreRespuesta(int IdPregunta)
        {
            List<Respuestas> ListRespuesta = new List<Respuestas>();

            using (data)
            {
                var Listrespuestas = data.ListRespuestaByPregunta(IdPregunta);
                foreach (var item in Listrespuestas)
                {
                    Respuestas asnw = new Respuestas
                    {
                        Respuesta = item.Respuesta,
                        IdRespuesta = item.IdRespuesta,
                        IdPregunta = item.IdPregunta,
                        Usuario = item.Usuario
                    };
                    ListRespuesta.Add(asnw);
                }
            }
            return Json(ListRespuesta);
        }

        public JsonResult LisPreguntabyID(int IdPregunta)
        {
            List<Preguntas> ListarPreguntabyId = new List<Preguntas>();

            using (data)
            {
                var Listrespuestas = data.ListarPreguntaxId(IdPregunta);
                foreach (var item in Listrespuestas)
                {
                    Preguntas asignar = new Preguntas()
                    {
                        IdPregunta = item.IdPregunta,
                        Pregunta = item.Pregunta,
                        IdUsuario = item.IdUsuario,
                        Usuario = item.Usuario,
                        Estado = item.Estado
                    };
                    ListarPreguntabyId.Add(asignar);
                }
            }
            return Json(ListarPreguntabyId);
        }

        public ActionResult myquestions()
        {
            return View();
        }

        public JsonResult MisPreguntas()
        {
            //List<PREGUNTASBYUSER_Result> PreguntasbyUser = new List<PREGUNTASBYUSER_Result>();
            List<Preguntas> preguntas = new List<Preguntas>();

            var id_user = Convert.ToInt32(Session["ID_USUARIO"]);

            using (data)
            {
                var lkistarPregunbyuser = data.ListPregunstasbyUser(id_user);
                foreach (var item in lkistarPregunbyuser)
                {
                    Preguntas quest = new Preguntas()
                    {
                        IdPregunta = item.IdPregunta,
                        Pregunta = item.Pregunta,
                        Estado = item.Estado
                    };
                    preguntas.Add(quest);
                }
            }
            return Json(preguntas);
        }

        public JsonResult ActDesacPregunta(int IdPregunta, int IdEstado)
        {
            GenericDTO response = new GenericDTO();

            try
            {
                data.ActivarDesactivarPregunta(IdPregunta, IdEstado);
                if (IdEstado == 1)
                {
                    response.Message = "Pregunta Desactivada.";
                    response.Status = 1;
                }
                else
                {
                    response.Message = "Pregunta Activada.";
                    response.Status = 1;
                }
                return Json(response);
            }
            catch
            {
                response.Message = "Un error ha ocurrido.";
                response.Status = 0;
                return Json(response);
            }
        }
    }
}