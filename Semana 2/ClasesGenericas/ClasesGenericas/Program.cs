using ClasesGenericas;

//Caja de Enteros
var cajaEntero = new Caja<int> { Valor = 123 };

//Caja de Texto
var CajaTexto = new Caja<string> { Valor = "Hola mundpo"};

//Caja de Usuario
var cajaUsuario = new Caja<Usuario> { Valor = new Usuario { Nombre = "Karla"}};

cajaEntero.MostrarContenido();
CajaTexto.MostrarContenido();
cajaUsuario.MostrarContenido();
Console.WriteLine("------------------------------------------------------------------");

var historialDeMensaje = new Historial<String>(3);
historialDeMensaje.Agregar("Primer mensaje");
historialDeMensaje.Agregar("Segundo mensaje");
historialDeMensaje.Agregar("Tercer mensaje");
historialDeMensaje.Agregar("Cuarto mensaje"); // Este no se agregará porque la capacidad es 3
historialDeMensaje.MostrarHistorial();
Console.Read();

