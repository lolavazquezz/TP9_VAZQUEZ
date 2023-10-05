function validarContraseña(contraseña){
    let mensaje = document.getElementById("mensaje");
    let m = "";
    if ((contraseña.length < 7 || contraseña.length > 21) || (!/[A-Z]/.test(contraseña))|| (!/[\W_]/.test(contraseña)))
     m = "La contraseña no cumple con los requisitos"
    else m = "La contraseña cumple con los requisitos"
    mensaje.innerHTML = m;
}