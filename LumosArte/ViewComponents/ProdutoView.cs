using API;
using LumosArte.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.ViewComponents
{
    public class ProdutoView : ViewComponent
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoView(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IViewComponentResult Invoke(int id)
        {
            List<Produto> produto = _produtoRepositorio.ProdutoUsuarioId(id);
            return View("ProdutoPorUsuario", produto);
        }
    }
}
