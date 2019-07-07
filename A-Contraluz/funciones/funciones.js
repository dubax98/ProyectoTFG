//Aplicamos la funcionalidad del scroll
window.onscroll = function () { scrollTop() };

/* Ocultamos el contenido del menu y el boton de cerrar para que no se pueda acceder hasta que no pulsemos
 * el boton del menu*/
$(document).ready(function () {
    $("#contenidoMenu").css({
        "display": "none"
    });
    $("#botonCerrarMenu").css({
        "display": "none"
    });
})

/* A medida que bajemos el scroll, el contenido de la página principal se irá mostrando o escondiendo*/
function scrollTop() {
    if (document.body.scrollTop > 500 || document.documentElement.scrollTop > 500) {
        $(".btnTop").css({ "display": "block" });
    } else {
        $(".btnTop").css({ "display": "none" });
    }

    if (document.body.scrollTop > 1250 || document.documentElement.scrollTop > 1250) {
        $(".scrollGallery").css({
            "width": "800px",
            "padding": "10px",
            "opacity": "1",
            "transition": "2s"
        });
        $(".galGallery").css({
            "opacity": "1",
            "transition": "5s"
        });
    } else {       
        $(".scrollGallery").css({
            "width": "0",
            "padding": "0px",
            "opacity": "0",
            "transition": "0.5s"
        });
        $(".galGallery").css({
            "opacity": "0",
            "transition": "1s"
        });
    }

    if (document.body.scrollTop > 1800 || document.documentElement.scrollTop > 1800) {
        $(".scrollDigital").css({
            "width": "800px",
            "padding": "10px",
            "opacity": "1",
            "transition": "2s"
        });
        $(".galDigital").css({
            "opacity": "1",
            "transition": "5s"
        });

    } else {
        $(".scrollDigital").css({
            "width": "0",
            "padding": "0px",
            "opacity": "0",
            "transition": "0.5s"
        });
        $(".galDigital").css({
            "opacity": "0",
            "transition": "1s"
        });
    }

    if (document.body.scrollTop > 2200 || document.documentElement.scrollTop > 2200) {
        $(".scrollImpresion").css({
            "width": "800px",
            "padding": "10px",
            "opacity":"1",
            "transition": "2s"
        });
        $(".galImpresion").css({
            "opacity": "1",
            "transition": "5s"
        });
    }else {
        $(".scrollImpresion").css({
            "width": "0",
            "padding": "0px",
            "opacity": "0",
            "transition": "0.5s"
        });
        $(".galImpresion").css({
            "opacity": "0",
            "transition": "1s"
        });
    }  

    if (document.body.scrollTop > 2900 || document.documentElement.scrollTop > 2900) {
        $(".scrollSoporte").css({
            "width": "800px",
            "padding": "10px",
            "opacity": "1",
            "transition": "2s"
        });
        $(".galSoporte").css({
            "opacity": "1",
            "transition": "5s"
        });
    } else {
        $(".scrollSoporte").css({
            "width": "0",
            "padding": "0px",
            "opacity": "0",
            "transition": "0.5s"
        });
        $(".galSoporte").css({
            "opacity": "0",
            "transition": "1s"
        });
    }  
}


// Abrimos el menu y lo mostramos
function openMenu() {
    $("#contenidoMenu").css({
        "display": "block"
    });
    $("#botonCerrarMenu").css({
        "display": "block"
    });

    // Ajustamos el menu a cuando la pantalla sea menor a 400px de ancho
    if (window.matchMedia("(max-width: 400px)").matches) {
        // Ajustamos el menu
        $("#mySidenav").css({ "width": "280px" }); 
        $("#mySidenav").css({ "width": "280px" }); 
        $("#contenidoMenu").css({ "margin-left": "-100px" });
        $("#myCarousel").css({ "display": "none" });
        $(".scrollGallery").css({ "display": "none" });
        $(".scrollDigital").css({ "display": "none" });
        $(".scrollImpresion").css({ "display": "none" });
        $(".scrollSoporte").css({ "display": "none" });
        $(".textGalIndex").css({ "width": "200px" });

    } else {
        $("#mySidenav").css({ "width": "550px" }); 
    }
    
}

// Cerramos el menu y ocultamos su contenido
function closeMenu() {
    $("#contenidoMenu").css({
        "display": "none"
    });
    $("#botonCerrarMenu").css({
        "display": "none"
    });
    $("#mySidenav").css({ "width": "0px" });  
}

// Al pinchar en el desplegable del menu, aparecen todos los enlaces correspondientes al apartado
function mostrarSubMenu(subMenu) {
    $("#" + subMenu).removeClass("glyphicon glyphicon-triangle-top picoArribaFotos"); 
    $("#" + subMenu).addClass("glyphicon glyphicon-triangle-bottom picoAbajoFotos");  
    $("." + subMenu).css("display", "block");
    $("#" + subMenu).removeAttr("onclick");
    $("#" + subMenu).attr("onclick", "ocultarSubMenu('" + subMenu + "')")
}

// Al pinchar en el desplegable del menu, desaparecen todos los enlaces correspondientes al apartado
function ocultarSubMenu(subMenu) {
    $("#" + subMenu).removeClass("glyphicon glyphicon-triangle-bottom picoAbajoFotos");
    $("#" + subMenu).addClass("glyphicon glyphicon-triangle-top picoArribaFotos");   
    $("." + subMenu).css("display", "none");
    $("#" + subMenu).removeAttr("onclick");
    $("#" + subMenu).attr("onclick","mostrarSubMenu('"+subMenu+"')")
}

// Al pinchar en el boton de la flecha apuntando arriba, nos lleva a la parte superior de la aplicacion
function btnTop() {    
    $('html, body').animate({ scrollTop: 0 }, 1250);   
}

function mostrar(tipo) {
    ocultarTodos();
    var seleccionados = document.getElementsByClassName(tipo).checked;
    for (var i = 0; i < seleccionados.length; i++) {
        seleccionados[i].style.opacity = "1";
    }
}

function ocultarTodos() {
    var seleccionados = document.getElementsByClassName("juego");
    for (var i = 0; i < seleccionados.length; i++) {
        seleccionados[i].style.opacity = "0.2";
    }
}

// Validamos el nombre del formulario
function nombre() {
    var nombre = document.getElementById("nombre");
    if (nombre.value == "") {
        document.getElementById("errorNombre").innerHTML = "Falta por rellenar el campo Nombre";
        nombre.style.border = "2px solid red";
    } else if (nombre.value.length < 3) {
        document.getElementById("errorNombre").innerHTML = "El nombre debe tener al menos 3 caracteres";
        nombre.style.border = "2px solid red";
    }
}

// Validamos el apellido del formulario
function apellido1() {
    var apellido1 = document.getElementById("apellido1");
    if (apellido1.value == "") {
        document.getElementById("errorApellido1").innerHTML = "Falta por rellenar el campo Apellido1";
        apellido1.style.border = "2px solid red";
    } else if (apellido1.value.length < 3) {
        document.getElementById("errorApellido1").innerHTML = "El nombre debe tener al menos 3 caracteres";
        apellido1.style.border = "2px solid red";
    }
}

// Validamos el email del formulario
function email() {
    var email = document.getElementById("email");
    if (email.value == "") {
        document.getElementById("errorEmail").innerHTML = "Falta por rellenar el campo Correo electrónico";
        email.style.border = "2px solid red";
    }
}

// Validamos el password del formulario
function password() {
    var password = document.getElementById("password");
    if (password.value == "") {
        document.getElementById("errorPassword").innerHTML = "Falta por rellenar el campo nombre";
        password.style.border = "2px solid red";
    }
}

// Validamos la provincia del formulario
function provincia() {
    var provincia = document.getElementById("provincia");
    if (provincia.value =="") {
        document.getElementById("errorProvincia").innerHTML = "Debes elegir una provincia";
        provincia.style.border = "2px solid red";
    }
}

// Validamos el nombre de la direccion del formulario
function nombreDireccion() {
    var nombreDir = document.getElementById("nombreDireccion");
    if (nombreDir.value == "") {
        document.getElementById("errorNombreDireccion").innerHTML = "Falta por rellenar el campo Dirección";
        nombreDir.style.border = "2px solid red";
    }
}

// Validamos el codigo postal del formulario
function codPostal() {
    var codPostal = document.getElementById("codPostal");
    if (codPostal.value == "") {
        document.getElementById("errorCodPostal").innerHTML = "Falta por rellenar el campo CP";
        codPostal.style.border = "2px solid red";
    } else if (codPostal.length < 5) {
        codPostal.getElementById("errorCodPostal").innerHTML = "El código postal debe tener 5 dígitos";
    }
}

// Validamos el tipo de pago del formulario
function tipoPago() {
    var tipoPago = document.getElementById("tipoPago");
    if (tipoPago.value == "") {
        document.getElementById("errorTipoPago").innerHTML = "Falta elegir un método de pago";
        tipoPago.style.border = "2px solid red";
    }
}

// Validamos el numero de tarjeta del formulario
function validarNumTarjeta() {
    var numTarjeta = document.getElementById("numTarjeta").value;
    var cadena = document.getElementById("numTarjeta").value.toString;
    var longitud = cadena.length;
    var cifra = null;
    var cifra_cad = null;
    var suma = 0;
    for (var i = 0; i < longitud; i += 2) {
        cifra = parseInt(cadena.charAt(i)) * 2;
        if (cifra > 9) {
            cifra_cad = cifra.toString();
            cifra = parseInt(cifra_cad.charAt(0)) +
                parseInt(cifra_cad.charAt(1));
        }
        suma += cifra;
    }
    for (var i = 1; i < longitud; i += 2) {
        suma += parseInt(cadena.charAt(i));
    }

    if (numTarjeta == "") {
        document.getElementById("errorNumTarjeta").innerHTML = "El campo Núm. Tarjeta está vacio";
        document.getElementById("numTarjeta").style.border = "2px solid red";
    }
    if ((suma % 10) != 0) {        
        document.getElementById("errorNumTarjeta").innerHTML = "El número de tarjeta no es válido";
        document.getElementById("numTarjeta").style.border = "2px solid red";
    }
}

// incluimos todas las validaciones en esta funcion
function validarForm() {
    nombre();
    apellido1();
    email();
    password();
    provincia();
    nombreDireccion();
    codPostal();
    tipoPago();
    validarNumTarjeta();
}






