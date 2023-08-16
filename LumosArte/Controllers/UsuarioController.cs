using LumosArte.Helper;
using LumosArte.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LumosArte.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;


        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;

        }

        // UsuarioController
        public IActionResult UsuarioDetails()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var usuario = _usuarioRepositorio.ListarPorId(usuarioLogado.Id);
            return View(usuario);
        }

        public IActionResult UsuarioVisualizacao(int id)
        {
            var usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult UsuarioCadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UsuarioCadastro(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AdionarUsuario(usuario);

                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR O CADASTRO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: ProdutoController/Edit/
        public ActionResult UsuarioEdit()
        {
                Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                if (usuarioLogado != null)
            {
                var usuario = _usuarioRepositorio.ListarPorId(usuarioLogado.Id);
                return View(usuario);
            }
            
                return RedirectToAction("Index", "Login");
        }

        // POST: ProdutoController/Edit/
        [HttpPost]
        public ActionResult UsuarioEdit(Usuario usuario)
        {
            try
            {
                Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                Usuario usuarioNovo = _usuarioRepositorio.EditarUsuario(usuarioLogado.Id, usuario);


                return View("UsuarioDetails", usuarioNovo);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A ALTERAÇÃO NO USUARIO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: ProdutoController/Delete/5
        //public ActionResult UsuarioDeleteConfirmacao(int id)
        //{
        //    var usuario = _usuarioRepositorio.ListarPorId(id);
        //    return View(usuario);
        //}

        // POST: ProdutoController/Delete/5
        //[Route("/Login/Index")]
        public IActionResult UsuarioDelete()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            try
            {
                _usuarioRepositorio.ExcluirUsuario(usuarioLogado);
                _sessao.RemoverSessaoDoUsuario();


                return RedirectToAction("Index", "Produto");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A EXCLUSÃO:{erro.Message}";
                return View("");
            }
        }

        public IActionResult PesquisarUsuario()
        {
            string searchTerm = TempData["searchTerm"] as string;
            List<Usuario> usuario = _usuarioRepositorio.BuscaUsuario(searchTerm);
            return View(usuario);
        }
    }
}
