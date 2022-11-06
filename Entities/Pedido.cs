using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineweb_movies_api.Entities
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public List<IngressoPedido> Ingressos { get; set; }

        public decimal ValorTotal { get; set; }

        [ForeignKey("cliente")]
        public int IdCliente { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }
    }
}
