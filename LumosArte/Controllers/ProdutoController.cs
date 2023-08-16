using LumosArte.Helper;
using LumosArte.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ISessao _sessao;
        public ProdutoController(IProdutoRepositorio produtoRepositorio, ISessao sessao)
        {
            _produtoRepositorio = produtoRepositorio;
            _sessao = sessao;
        }

        //Home
        public ActionResult Index()
        {
            List<Produto> produto = _produtoRepositorio.GetProdutos();
            return View(produto);
        }

        //Produto por Categoria
        [Route("Produto/GetProdutosPorCategoria/{id}")]
        public IActionResult GetProdutosPorCategoria(int id)
        {
            var produtosCategoria = _produtoRepositorio.GetProdutosPorCategoria(id);
            return View(produtosCategoria);
        }

        //[Route("Produto/{id}")]
        public IActionResult ProdutoDetails(int id)
        {
            
            var produto = _produtoRepositorio.ProdutoPorId(id);
            return View(produto);
        }

        public IActionResult MeusProdutos()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var produto = _produtoRepositorio.ProdutoUsuarioId(usuarioLogado.Id);
            return View(produto);
        }

        public IActionResult ProdutoPorUsuario(int id)
        {
            var produto = _produtoRepositorio.ProdutoUsuarioId(id);
            return View(produto);
        }

        // GET: ProdutoController/Create
        public ActionResult ProdutoCadastro()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        public ActionResult ProdutoCadastro(Produto produto)
        {
            
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            produto.Usuario_id = usuarioLogado.Id;
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.AdicionarProduto(produto);

                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR O CADASTRO DO PRODUTO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: ProdutoController/Edit/
        public ActionResult ProdutoEdit(int id)
        {
            
            var produto = _produtoRepositorio.ProdutoPorId(id);
            return View(produto);
        }

        // POST: ProdutoController/Edit/
        [HttpPost]
        public ActionResult ProdutoEdit(int id, Produto produtoNovo)
        {
            try
            {
                Produto produto = _produtoRepositorio.EditarProduto(id, produtoNovo);
                Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                var produto1 = _produtoRepositorio.ProdutoUsuarioId(usuarioLogado.Id);
                return View("MeusProdutos", produto1);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A ALTERAÇÃO DO PRODUTO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

       
        // POST: ProdutoController/Delete/5
       
        public ActionResult ProdutoDelete(int id)
        {
            try
            {
                Produto produto = _produtoRepositorio.ProdutoPorId(id);
                
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.ExcluirProduto(produto);

                }
                return RedirectToAction("MeusProdutos", "produto");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A EXCLUSÃO DO PRODUTO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult PesquisarProduto(string searchTerm)
        {
            TempData["searchTerm"] = searchTerm;
            List<Produto> produto = _produtoRepositorio.BuscaProduto(searchTerm);
            return View(produto);
        }
    }
}
