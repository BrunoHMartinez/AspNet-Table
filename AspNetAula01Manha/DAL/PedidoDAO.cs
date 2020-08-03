using AspNetAula01Manha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetAula01Manha.DAL
{
    public class PedidoDAO
    {
        private readonly Context _context;
        public PedidoDAO(Context context)
        {
            _context = context;
        }
        public void Cadastrar(Pedido pedido)
        {
            if (!_context.pedidos.Any(p => p.Produto == pedido.Produto))
            {
                _context.pedidos.Add(pedido);
                _context.SaveChanges();
            }
  
        }
        public List<Pedido> ListarPedidos()
        {
            return _context.pedidos.ToList();
        }
    }
}
