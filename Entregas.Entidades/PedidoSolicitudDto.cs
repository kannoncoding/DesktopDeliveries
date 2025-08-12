using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public class PedidoSolicitudDto
    {
   
        public int NumeroPedido { get; set; }

    
        public int ClienteId { get; set; }
        public int RepartidorId { get; set; }

  
        public DateTime FechaPedido { get; set; }
        public string Direccion { get; set; } = string.Empty;

   
        public List<ItemPedidoDto> Items { get; set; } = new();

        // ---------- Validaciones ----------

        public void ValidarBasico()
        {
            if (NumeroPedido <= 0) throw new ArgumentException("El número de pedido debe ser mayor a cero.");
            if (ClienteId <= 0) throw new ArgumentException("El Id de cliente debe ser mayor a cero.");
            if (RepartidorId <= 0) throw new ArgumentException("El Id de repartidor debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(Direccion)) throw new ArgumentException("La dirección es obligatoria.");

            
            if (FechaPedido.Date < DateTime.Today)
                throw new ArgumentException("La fecha del pedido no puede ser anterior a hoy.");
        }

        public void ValidarItems()
        {
            if (Items == null || Items.Count == 0)
                throw new ArgumentException("Debe incluir al menos un artículo en el pedido.");

            // Cantidades válidas
            if (Items.Any(i => i.Cantidad <= 0))
                throw new ArgumentException("Todas las cantidades deben ser mayores a cero.");

            // No duplicados por ArticuloId
            var duplicados = Items
                .GroupBy(i => i.ArticuloId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicados.Count > 0)
                throw new ArgumentException($"No se permiten artículos repetidos en el pedido (IDs: {string.Join(", ", duplicados)}).");
        }

        // Validación completa (encabezado + items).
        public void ValidarTodo()
        {
            ValidarBasico();
            ValidarItems();
        }

        // ---------- Helpers para manipular items ----------

        // Agrega o actualiza la cantidad de un artículo.
        public void AgregarOAcumularItem(int articuloId, int cantidad)
        {
            if (articuloId <= 0) throw new ArgumentException("El Id del artículo debe ser mayor a cero.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");

            var existente = Items.FirstOrDefault(x => x.ArticuloId == articuloId);
            if (existente == null)
            {
                Items.Add(new ItemPedidoDto { ArticuloId = articuloId, Cantidad = cantidad });
            }
            else
            {
                
                existente.Cantidad += cantidad;
            }
        }

        public bool QuitarItem(int articuloId)
        {
            var it = Items.FirstOrDefault(x => x.ArticuloId == articuloId);
            if (it == null) return false;
            Items.Remove(it);
            return true;
        }

        public void LimpiarItems() => Items.Clear();

        // ---------- Representación ----------

        public override string ToString()
        {
            var itemsTxt = Items.Count == 0
                ? "sin items"
                : string.Join(", ", Items.Select(i => $"{i.ArticuloId}x{i.Cantidad}"));
            return $"Pedido #{NumeroPedido} - Cliente:{ClienteId} Rep:{RepartidorId} {FechaPedido:yyyy-MM-dd} -> {Direccion} [{itemsTxt}]";
        }
    }

}
