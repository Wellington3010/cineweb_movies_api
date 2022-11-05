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
        public int PedidoId { get; set; }

        [NotMapped]
        public Pedido Pedido { get; set; }

        [ForeignKey("filme")]
        public Guid FilmeId { get; set; }

        [NotMapped]
        public Filme Filme { get; set; }

        [ForeignKey("ingresso")]
        public int IngressoId { get; set; }

        [NotMapped]
        public Ingresso Ingresso { get; set; }
    }
}
