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
    public IActionResult crearUsuario(usuario usu){
        ViewBag.error = "";
        if (usu.contraseña!= usu.contraseña2){
            ViewBag.error = "Verifique que las dos contraseñas sean iguales";
        }
        bool existe = bd.existe(usu.username);
        if (existe) {
            ViewBag.error = "El nombre de usuario ya existe. Ingrese uno nuevo.";
        }
        bool existem = bd.existeMail(usu.email);
        if (existem) {
            ViewBag.error = "El email ya esta registrado en una cuenta. Ingrese uno nuevo.";
        }
        else {
            bd.crearUsuario(usu);
            ViewBag.username = usu.username;
            ViewBag.nombre = usu.nombre;
            ViewBag.email = usu.email;
            ViewBag.telefono = usu.telefono;
            return View("bienvenido");
        }
        return View("registrarse", usu);
    }
    public IActionResult traerPregunta(string email){
        ViewBag.pregunta = bd.traerPregunta(email);
        return View("traerContra");
    }
    public IActionResult traerContra(string email, string respuesta){
        string contraseña = bd.traerContra(email, respuesta);
        ViewBag.contraseña = contraseña;
        return View("mostrarContra");
    }
}