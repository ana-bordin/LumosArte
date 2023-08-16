using API;
using LumosArte.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LumosArte.ViewComponents
{
    public class MenuView : ViewComponent
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public MenuView(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");



            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return View("MenuDeslogado");
            }
            Usuario usuarioLogado = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
            Usuario usuario = _usuarioRepositorio.ListarPorId(usuarioLogado.Id);
           
            return View("MenuLogado", usuario);
        }
    }
}
