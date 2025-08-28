using ColeccionesGenericas;
Restaurante restaurante = new Restaurante();
//Agregando platillos a la lista Menu
restaurante.AgregarPlatillosDisponibles(new Menu { Categoria = "Aves", Nombre = "Pollo frito", Precio = 5.99m });
restaurante.AgregarPlatillosDisponibles(new Menu { Categoria = "Mariscos", Nombre = "Camarones empanizados", Precio = 7.50m });
restaurante.AgregarPlatillosDisponibles(new Menu { Categoria = "Carnes", Nombre = "Churrasco", Precio = 8.99m });
restaurante.AgregarPlatillosDisponibles(new Menu { Categoria = "Peces", Nombre = "Tilapia Rellena", Precio = 10.99m });

//Mostrando los platillos disponibles
restaurante.listarPlatillos();

//Eliminando platillos
restaurante.EliminarPlatillos();
restaurante.listarPlatillos();

//agregando clientes a la cola
restaurante.ClientesEnEspera("Carlos");
restaurante.ClientesEnEspera("Miranda");
restaurante.ClientesEnEspera("Maria");
restaurante.ClientesEnEspera("Juan");

//Proximo cliente en turno
restaurante.ProximoCliente();


//Atendiendo pedidos
restaurante.AtendiendoPedidos();
restaurante.ProximoCliente();
restaurante.ClientesEsperando();



//Mostrar el historial
restaurante.MostrarHistorial();
restaurante.listarPlatillos();
Console.ReadLine();