using AspNetAula01Manha.DAL;
using AspNetAula01Manha.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// Bruno Henrique Martinez
namespace AspNetAula01Manha.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoDAO _pedidoDAO;
        public PedidoController(PedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            _pedidoDAO.Cadastrar(pedido);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewBag.pedidos = _pedidoDAO.ListarPedidos();
            ViewBag.DataHora = DateTime.Now;
            return View();
        }
        public IActionResult Remover(int id)
        {
            _pedidoDAO.Remover(id);
            return RedirectToAction("Index");
        }
        public IActionResult Alterar(int id)
        {
            ViewBag.pedidos = _pedidoDAO.BuscarPorId(id);
            return View();
        }
        [HttpPost]
        public IActionResult Alterar(Pedido pedido)
        {
            Pedido p = _pedidoDAO.BuscarPorId(pedido.Pedidoid);
            p.Produto = pedido.Produto;
            p.Quantidade = pedido.Quantidade;
            p.Valor = pedido.Valor;
            p.Fornecedor = pedido.Fornecedor;
            p.Data = pedido.Data;
            _pedidoDAO.Alterar(p);
            return RedirectToAction("Index");
        }
    }
}