using API;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.ViewComponents
{
    public class ArtistaView : ViewComponent
    {
        private readonly LumosDbContext _dbContext;
        public ArtistaView(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke(int id)
        {
            Usuario usuario = _dbContext.Usuario.FirstOrDefault(x => x.Id == id);

            return View("Artista", usuario);

        }
    }
}