using LumosArte.Helper;
using LumosArte.Models;
using LumosArte.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LumosArte.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Produto");
            }

            return View();
        }
        public IActionResult Sair() 
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index","Login");
        }
        [HttpPost]
        public IActionResult Entrar(Login login) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorUsuario(login.Usuario);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);

                            return RedirectToAction("Index", "Produto");
                        }
                    }
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR O LOGIN:{erro.Message}";
                return RedirectToAction("Index"); 
            }
        }
    }
}
