using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetAula01Manha.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAula01Manha.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Context _context;

        public PedidoController(Context context)        
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Pedidos = ListarPedidos();
            ViewBag.DataHora = DateTime.Now;
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            if (_context.pedidos.Any(p => p.Produto == pedido.Produto))
            {
                return RedirectToAction("Erro");
            }
               
           else
            {
                _context.pedidos.Add(pedido);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public List<Pedido> ListarPedidos()
        {
            return _context.pedidos.ToList();
        }
        public IActionResult Erro()
        {
            return View();
        }
    }
}
