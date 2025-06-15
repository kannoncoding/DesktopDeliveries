using System;
using Entregas.Entidades;
using Entregas.Datos;
using Entregas.Logica;


class Program
{
    static void Main(string[] args)
    {
        // Registrar Tipos de Artículo
        Console.WriteLine(TipoArticuloLogica.RegistrarTipoArticulo(1, "Oficina", "Artículos de oficina"));
        Console.WriteLine(TipoArticuloLogica.RegistrarTipoArticulo(2, "Abarrotes", "Artículos de supermercado"));

        // Registrar Artículos
        var tipoOficina = TipoArticuloDatos.ObtenerTodos()[0];
        var tipoAbarrotes = TipoArticuloDatos.ObtenerTodos()[1];

        Console.WriteLine(ArticuloLogica.RegistrarArticulo(10, "Lapicero", tipoOficina, "100", "10", true));
        Console.WriteLine(ArticuloLogica.RegistrarArticulo(11, "Resma Papel", tipoOficina, "3000", "8", true));
        Console.WriteLine(ArticuloLogica.RegistrarArticulo(20, "Arroz", tipoAbarrotes, "1800", "5", true));

        // Registrar Clientes
        Console.WriteLine(ClienteLogica.RegistrarCliente(1, "Carlos", "Gómez", "Solís", DateTime.Today.AddYears(-30), true));
        Console.WriteLine(ClienteLogica.RegistrarCliente(2, "Laura", "Mora", "Sánchez", DateTime.Today.AddYears(-22), true));

        // Registrar Repartidores
        var fechaContrat = DateTime.Today.AddMonths(-2);
        Console.WriteLine(RepartidorLogica.RegistrarRepartidor(1, "Pedro", "Jiménez", "Solano", DateTime.Today.AddYears(-35), fechaContrat, true));
        Console.WriteLine(RepartidorLogica.RegistrarRepartidor(2, "María", "Rodríguez", "Vargas", DateTime.Today.AddYears(-29), fechaContrat, true));

        // Crear Pedidos válidos
        var cliente1 = ClienteDatos.ObtenerTodos()[0];
        var cliente2 = ClienteDatos.ObtenerTodos()[1];
        var repartidor1 = RepartidorDatos.ObtenerTodos()[0];
        var repartidor2 = RepartidorDatos.ObtenerTodos()[1];

        Console.WriteLine(PedidoLogica.CrearPedido(100, DateTime.Today, cliente1, repartidor1, "Calle 1, Ciudad"));
        Console.WriteLine(PedidoLogica.CrearPedido(101, DateTime.Today, cliente2, repartidor2, "Calle 2, Ciudad"));

        // Agregar detalles a pedidos
        var lapicero = ArticuloDatos.ObtenerTodos()[0];
        var papel = ArticuloDatos.ObtenerTodos()[1];
        var arroz = ArticuloDatos.ObtenerTodos()[2];

        Console.WriteLine(PedidoLogica.AgregarDetalleAPedido(100, lapicero, 2)); // Pedido 100, Lapicero
        Console.WriteLine(PedidoLogica.AgregarDetalleAPedido(100, papel, 1));    // Pedido 100, Resma Papel
        Console.WriteLine(PedidoLogica.AgregarDetalleAPedido(101, arroz, 2));    // Pedido 101, Arroz
        Console.WriteLine(PedidoLogica.AgregarDetalleAPedido(101, papel, 3));    // Pedido 101, Resma Papel

        // Mostrar detalles de cada pedido
        var pedidos = PedidoDatos.ObtenerTodosLosPedidos();
        foreach (var pedido in pedidos)
        {
            if (pedido != null)
            {
                Console.WriteLine($"\nDetalles del Pedido #{pedido.NumeroPedido} para {pedido.Cliente.Nombre} (Repartidor: {pedido.Repartidor.Nombre}):");
                var detalles = DetallePedidoDatos.ObtenerDetallesPorPedido(pedido.NumeroPedido);
                foreach (var detalle in detalles)
                {
                    if (detalle != null)
                    {
                        Console.WriteLine($"  Artículo: {detalle.Articulo.Nombre} | Cantidad: {detalle.Cantidad} | Monto: {detalle.Monto:C2}");
                    }
                }
            }
        }

        Console.WriteLine("\nPRUEBAS TERMINADAS.");
        Console.ReadKey();
    }
}
