function validarContraseña(){
    let contraseña = document.getElementById("contraseña").value;
    let m1 = document.getElementById("m1");
    let m2 = document.getElementById("m2");
    let m3 = document.getElementById("m3");
    const exp = /[^a-zA-Z0-9]/;
    m3.style.color= (contraseña.length > 7 && contraseña.length < 21 ? "green" : "red");
    m2.style.color= (contraseña === contraseña.toUpperCase() ? "green" : "red");
    m1.style.color= (exp.test(contraseña) ? "green" : "red");
    return (m1.style.color == "green" && m2.style.color == "green" && m3.style.color == "green");
}