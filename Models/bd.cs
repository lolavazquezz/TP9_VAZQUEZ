using System.Data.SqlClient;
using Dapper;
namespace TP9_VAZQUEZ.Models;

public static class bd{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=EjemploLogin;Trusted_Connection=True;";
    public static Usuario login(string username, string contraseña)
    {
        Usuario user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pusername AND contraseña= @pcontra";
            user = db.QueryFirstOrDefault<Usuario>(sql, new { pusername = username, pcontra = contraseña });
        }
        return user;
    }
    public static void crearusuario(string username, string contraseña, string nombre, string email, int telefono, string pregunta, string respuesta){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Usuario(username, contraseña, nombre, email, telefono, pregunta, respuesta) VALUES (@pusername, @pcontraseña, @pnombre, @pemail, @ptelefono, @ppregunta, @prespuesta)";
            db.Execute(sql, new {pusername = username, pcontraseña = contraseña, pnombre = nombre, pemail = email, ptelefono = telefono, ppregunta = pregunta, prespuesta = respuesta});
        }
    }
    public static string traerContra(string email, string respuesta){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT contraseña FROM Usuario WHERE email = @puemail AND respuesta= @prespuesta";
            string contra = db.QueryFirstOrDefault<Usuario>(sql, new { puemail = email, prespuesta = respuesta });
        }
        return contra;
    }
}