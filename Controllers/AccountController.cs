using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9_VAZQUEZ.Models;

namespace TP9_VAZQUEZ.Controllers;

public class AccountController : Controller
{
    public IActionResult login(string username, string contraseña)
    {
        usuario user = bd.login(username, contraseña);
        if (user == null){
            ViewBag.mensajeError = "Usuario o contraseña incorrecta";
            return View("index");
        }
        else
        {
            ViewBag.usuario = user;
            return View("bienvenido");
        }
    }
    public IActionResult registrarse(){
        return View();
    }
    public IActionResult crearUsuario(usuario usu){
        ViewBag.error = "";
        if (contraseña1!= contraseña2){
            ViewBag.error = "Verifique que las dos contraseñas sean iguales";
        }
        bool existe = bd.existe(username);
        if (existe) {
            ViewBag.error = "El nombre de usuario ya existe. Ingrese uno nuevo."
        }
        else {
            bd.crearUsuario(usu);
            ViewBag.username = username;
            ViewBag.nombre = nombre;
            ViewBag.email = emial;
            ViewBag.telefono = telefono;
            return View("bienvenido");
        }
        return View("registrarse", usu);
    }
    public IActionResult olvideContra(){
        return View();
    }
    public IActionResult traerPregunta(string email){
        ViewBag.pregunta = bd.traerPregunta(email);
        return View();
    }
    public IActionResult traerContra(string email, string respuesta){
        string contraseña = bd.traerContra(email, respuesta);
        ViewBag.contraseña = contraseña;
        return View();
    }
    //hacer uno de traer la contra que lleve el mail y la rta TERMINAR TRAER PREG Y CONTRA EN LA VIEW OLVIDE CONTRA
}