using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Entities
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public string NomeCliente { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
