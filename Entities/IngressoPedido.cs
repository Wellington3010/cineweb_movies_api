using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Entities
{
    [Table("ingresso_pedido")]
    public class IngressoPedido
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("pedido")]
        public Pedido Pedido { get; set; }

        [ForeignKey("filme")]
        public Filme Filme { get; set; }

        [ForeignKey("ingresso")]
        public Ingresso Ingresso { get; set; }
    }
}
