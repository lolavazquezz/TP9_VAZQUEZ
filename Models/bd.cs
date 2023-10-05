using System.Data.SqlClient;
using Dapper;
namespace TP9_VAZQUEZ.Models;

public static class bd{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=EjemploLogin;Trusted_Connection=True;";
    public static usuario login(string username, string contraseña)
    {
        usuario user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pusername AND contraseña= @pcontra";
            user = db.QueryFirstOrDefault<usuario>(sql, new { pusername = username, pcontra = contraseña });
        }
        return user;
    }
    public static void crearUsuario(usuario usu){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Usuario(username, contraseña, nombre, email, telefono, pregunta, respuesta) VALUES (@pusername, @pcontraseña, @pnombre, @pemail, @ptelefono, @ppregunta, @prespuesta)";
            db.Execute(sql, new {pusername = usu.username, pcontraseña = usu.contraseña, pnombre = usu.nombre, pemail = usu.email, ptelefono = usu.telefono, ppregunta = usu.pregunta, prespuesta = usu.respuesta});
        }
    }    
    public static string traerPregunta(string email){
        string pregunta ="";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT pregunta FROM Usuario WHERE email = @puemail";
            pregunta = db.QueryFirstOrDefault<string>(sql, new { puemail = email});
        }
        return pregunta;
    }
    public static string traerContra(string email, string respuesta){
        string contra = "";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT contraseña FROM Usuario WHERE email = @puemail AND respuesta= @prespuesta";
            contra = db.QueryFirstOrDefault<string>(sql, new { puemail = email, prespuesta = respuesta });
        }
        return contra;
    }
    public static bool existe(string username)
    {
        int cant=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string lowerUsername = username.ToLower();
            string sql = "SELECT COUNT(*) FROM Usuario WHERE LOWER(username) = @pusername";
            cant = db.QueryFirstOrDefault<int>(sql, new { pusername = lowerUsername});
        }
        if (cant > 0) return true;
        else return false;
    }
    public static bool existeMail(string email)
    {
        int cant=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string lowerMail = email.ToLower();
            string sql = "SELECT COUNT(*) FROM Usuario WHERE LOWER(email) = @pemail";
            cant = db.QueryFirstOrDefault<int>(sql, new { pemail = lowerMail});
        }
        if (cant > 0) return true;
        else return false;
    }
}