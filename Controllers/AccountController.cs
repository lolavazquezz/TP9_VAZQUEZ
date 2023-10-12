using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9_VAZQUEZ.Models;

namespace TP9_VAZQUEZ.Controllers;

public class AccountController : Controller
{
    public IActionResult index(){
        return View();
    }
    public IActionResult login(string username, string contraseña)
    {
        usuario user = bd.login(username, contraseña);
        if (user == null){
            ViewBag.mensajeError = "Usuario o contraseña incorrecta";
            return View("index");
        }
        else
        {
            ViewBag.username = user.username;
            ViewBag.nombre = user.nombre;
            ViewBag.email = user.email;
            ViewBag.telefono = user.telefono;
            return View("bienvenido");
        }
    }
    public IActionResult registrarse(){
        return View();
    }
    public IActionResult crearUsuario(usuario usu){
        ViewBag.error1 = "";
        ViewBag.error2 = "";
        ViewBag.error3 = "";
        if (usu.contraseña != usu.contraseña2){
            ViewBag.error1 = "Verifique que las dos contraseñas sean iguales";
        }
        bool existe = bd.existe(usu.username);
        if (existe) {
            ViewBag.error2 = "El nombre de usuario ya existe, ingrese uno nuevo.";
        }
        bool existem = bd.existeMail(usu.email);
        if (existem) {
            ViewBag.error3 = "El email ya esta registrado en una cuenta, ingrese uno nuevo.";
        }
        else if ((!existe)&&(!existem)&&(ViewBag.error1 == "")) {
            bd.crearUsuario(usu);
            ViewBag.username = usu.username;
            ViewBag.nombre = usu.nombre;
            ViewBag.email = usu.email;
            ViewBag.telefono = usu.telefono;
            return View("bienvenido");
        }
        return View("registrarse", usu);
    }
    public IActionResult olvideContra(){
        return View();
    }
    public IActionResult traerPregunta(string email){
        ViewBag.validar="";
        bool valido = bd.existeMail(email);
        if (!valido){
            ViewBag.validar="El mail ingresado no pertenece a una cuenta";
            return View("olvideContra");
        }
        ViewBag.pregunta = bd.traerPregunta(email);
        ViewBag.email= email;
        return View("traerContra", ViewBag.email);
    }
    public IActionResult traerContra(string email, string respuesta, string pregunta){
        ViewBag.validar ="";
        ViewBag.pregunta = pregunta;
        ViewBag.email = email;
        bool valido = bd.validarRta(respuesta);
        if (!valido){
            ViewBag.validar="Respuesta incorrecta";
            return View("traerContra", ViewBag.email);
        }
        string contraseña = bd.traerContra(email);
        ViewBag.contraseña = contraseña;
        return View("mostrarContra");
    }
}