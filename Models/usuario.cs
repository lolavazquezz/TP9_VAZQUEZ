public class usuario {
    public int idUsuario{get; set;}
    public string username{get; set;}
    public string contraseña{get; set;}
    public string nombre{get; set;}
    public string email{get; set;}
    public int telefono{get; set;}
    public string pregunta{get; set;}
    public string respuesta{get; set;}

    public usuario(int id, string un, string contra, string nom, string mail, int tel, string preg, string resp){
        idUsuario = id;
        username = un;
        contraseña = contra;
        nombre = nom;
        email = mail;
        telefono = tel;
        pregunta = preg;
        respuesta = resp;
    }
}