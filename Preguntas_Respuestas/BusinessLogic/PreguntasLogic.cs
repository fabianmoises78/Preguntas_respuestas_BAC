using Preguntas_Respuestas.DataAccess;
using Preguntas_Respuestas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;


namespace Preguntas_Respuestas.BusinessLogic
{
    public class PreguntasLogic : DbContext
    {
        public int RegistrarUsuario(Usuario obj)
        {
            var resultado = 0;
            int UsuarioResultado = 0;

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "RegistrarUsuario";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@Nombre", obj.Nombre);
            command.Parameters.AddWithValue("@Usuario", obj.Usuario1);
            command.Parameters.AddWithValue("@Contrasena", obj.Contraseña);

            resultado = command.ExecuteNonQuery();
            UsuarioResultado = Convert.ToInt32(resultado);
            cnn.Close();

            return UsuarioResultado;
        }

        public int UsuarioExiste(Usuario obj)
        {
            int resultado = 0;
            int existe = 0;

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UsuarioExiste";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@Usuario", obj.Usuario1);
            using (SqlDataReader reader = command.ExecuteReader()) {
                if(reader.Read())
                {
                    resultado = reader.GetInt32(0);
                }
            }
            existe = Convert.ToInt32(resultado);
            cnn.Close();

            return existe;
        }

        public  List<LoginUsuario> LoginUsuario(Usuario obj)
        {
            List<LoginUsuario> ListUsuario = new List<LoginUsuario>();

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "IniciarSesion";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@Usuario", obj.Usuario1);
            command.Parameters.AddWithValue("@Contrasena", obj.Contraseña);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LoginUsuario Login = new LoginUsuario()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Usuario1 = reader.GetString(1),
                        Nombre = reader.GetString(2)
                    };
                    ListUsuario.Add(Login);
                }
            }

            return ListUsuario;
        }

        public int CrearPregunta(Preguntas obj, int IdUsuario)
        {
            int resultado = 0;
            int pregunta = 0;

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "CrearPregunta";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            command.Parameters.AddWithValue("@Pregunta", obj.Pregunta);

            resultado = command.ExecuteNonQuery();
            pregunta = Convert.ToInt32(resultado);

            return pregunta;
        }

        public List<Preguntas> ListarPreguntar()
        {
            List<Preguntas> ListPreguntas = new List<Preguntas>();

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ListarProcedure";
            command.CommandTimeout = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Preguntas quest = new Preguntas()
                    {
                        IdPregunta = reader.GetInt32(0),
                        Pregunta = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2),
                        Estado = Convert.ToInt32(reader.GetBoolean(3)),
                        Usuario = reader.GetString(4)
                    };
                    ListPreguntas.Add(quest);
                }
            }

            return ListPreguntas;
        }

        public List<Preguntas> ListarPreguntaxId(int IdPregunta)
        {
            List<Preguntas> ListPreguntas = new List<Preguntas>();

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PreguntaxId";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@IdPregunta", IdPregunta);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Preguntas quest = new Preguntas()
                    {
                        IdPregunta = reader.GetInt32(0),
                        Pregunta = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2),
                        Estado = Convert.ToInt32(reader.GetBoolean(3)),
                        Usuario = reader.GetString(4)
                    };
                    ListPreguntas.Add(quest);
                }
            }

            return ListPreguntas;
        }

        public List<Respuestas> ListRespuestaByPregunta(int IdPregunta)
        {
            List<Respuestas> ListRespuesta = new List<Respuestas>();

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ListarRespuestasbyPregunta";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@IdPregunta", IdPregunta);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Respuestas answ = new Respuestas()
                    {
                        IdRespuesta = reader.GetInt32(0),
                        Respuesta = reader.GetString(1),
                        IdPregunta = reader.GetInt32(2),
                        IdUsuario = reader.GetInt32(3),
                        Usuario = reader.GetString(4),
                    };
                    ListRespuesta.Add(answ);
                }
            }
            return ListRespuesta;
        }

        public int CrearRespuesta(int IdPregunta, string Respuesta, int IdUsuario)
        {
            var resultado = 0;
            int respuesta = 0;

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "CrearRespuesta";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@Respuesta", Respuesta);
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            command.Parameters.AddWithValue("@IdPregunta", IdPregunta);

            resultado = command.ExecuteNonQuery();
            respuesta = Convert.ToInt32(resultado);

            cnn.Close();

            return respuesta;
        }

        public List<Preguntas> ListPregunstasbyUser(int IdUsuario)
        {
            List<Preguntas> listPregunta = new List<Preguntas>();

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PreguntasbyUser";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Preguntas quest = new Preguntas()
                    {
                        IdPregunta = reader.GetInt32(0),
                        Pregunta = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2),
                        Estado = Convert.ToInt32(reader.GetBoolean(3))
                    };
                    listPregunta.Add(quest);
                }
            }
            return listPregunta;
        }

        public int ActivarDesactivarPregunta(int IdPregunta, int IdEstado)
        {
            int resultado = 0;
            int EstadoPregunta = 0;

            SqlConnection cnn = ConectionBD.GetSqlConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = cnn;
            cnn.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ActivarDesactivarPregunta";
            command.CommandTimeout = 0;

            command.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            command.Parameters.AddWithValue("@Estado", IdEstado);

            resultado = command.ExecuteNonQuery();
            EstadoPregunta = Convert.ToInt32(resultado);

            return EstadoPregunta;
        }

    }
}