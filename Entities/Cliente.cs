using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineweb_movies_api.Entities
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public string NomeCliente { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
