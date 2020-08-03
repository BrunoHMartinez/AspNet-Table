using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetAula01Manha.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int Pedidoid { get; set; }    
        public string Produto { get; set; }
        public int Quantidade { get; set; } 
        public double Valor { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Data { get; set; }


    }
}
