using System;
using Entregas.Entidades;
using Entregas.Datos;
using Entregas.Logica;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Prueba: Registrar un Tipo de Artículo
        var msg = TipoArticuloLogica.RegistrarTipoArticulo(1, "Oficina", "Artículos de oficina");
        Console.WriteLine("Registrar TipoArticulo: " + msg);

        // Prueba: Intentar registrar con ID duplicado
        var msg2 = TipoArticuloLogica.RegistrarTipoArticulo(1, "Abarrotes", "Supermercado");
        Console.WriteLine("Duplicado TipoArticulo: " + msg2);

        // Prueba: Registrar un artículo
        var tipo = TipoArticuloDatos.ObtenerTodos()[0];
        var msg3 = ArticuloLogica.RegistrarArticulo(10, "Lapicero", tipo, "120.5", "5", true);
        Console.WriteLine("Registrar Articulo: " + msg3);

        // Prueba: Cliente menor de edad rechazado (debería permitir cualquier fecha, pero vamos a simular un dato futuro)
        var msg4 = ClienteLogica.RegistrarCliente(11, "Juan", "Pérez", "Soto", DateTime.Today.AddDays(1), true);
        Console.WriteLine("Registrar Cliente con fecha futura: " + msg4);

        // Prueba: Registrar un repartidor menor de edad
        var fechaMenorEdad = DateTime.Today.AddYears(-17);
        var msg5 = RepartidorLogica.RegistrarRepartidor(1, "Luis", "Quesada", "Jiménez", fechaMenorEdad, DateTime.Today, true);
        Console.WriteLine("Repartidor menor de edad: " + msg5);

        // Prueba: Registrar un repartidor válido
        var fechaAdulto = DateTime.Today.AddYears(-25);
        var msg6 = RepartidorLogica.RegistrarRepartidor(2, "Pedro", "Jiménez", "Solano", fechaAdulto, DateTime.Today, true);
        Console.WriteLine("Repartidor válido: " + msg6);

        // Prueba: Crear pedido
        var cliente = ClienteDatos.ObtenerTodos().Length > 0 ? ClienteDatos.ObtenerTodos()[0] : null;
        var repartidor = RepartidorDatos.ObtenerTodos().Length > 0 ? RepartidorDatos.ObtenerTodos()[0] : null;
        var msg7 = PedidoLogica.CrearPedido(100, DateTime.Today, cliente, repartidor, "Dirección de entrega");
        Console.WriteLine("Registrar Pedido: " + msg7);

        // Prueba: Agregar detalle al pedido con inventario insuficiente
        var articulo = ArticuloDatos.ObtenerTodos()[0];
        var msg8 = PedidoLogica.AgregarDetalleAPedido(100, articulo, 99);
        Console.WriteLine("Detalle con inventario insuficiente: " + msg8);

        // Prueba: Agregar detalle válido
        var msg9 = PedidoLogica.AgregarDetalleAPedido(100, articulo, 2);
        Console.WriteLine("Detalle válido: " + msg9);

        // Prueba: Intentar agregar el mismo artículo dos veces al mismo pedido
        var msg10 = PedidoLogica.AgregarDetalleAPedido(100, articulo, 1);
        Console.WriteLine("Detalle duplicado: " + msg10);

        Console.WriteLine("PRUEBAS TERMINADAS.");
        Console.ReadKey();
    }
}

