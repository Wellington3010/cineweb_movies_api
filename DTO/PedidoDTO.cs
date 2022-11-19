using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.DTO
{
    public class PedidoDTO
    {
        public List<IngressoPedidoDTO> Ingressos { get; set; }

        public decimal ValorTotal { get; set; }

        public int IdUsuario { get; set; }

        public string NomeCliente { get; set; }
    }
}
