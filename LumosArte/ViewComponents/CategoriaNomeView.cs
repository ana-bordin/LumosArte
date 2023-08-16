using API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LumosArte.ViewComponents
{
    public class CategoriaNomeView : ViewComponent
    {
        private readonly LumosDbContext _dbContext;
        public CategoriaNomeView(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public IViewComponentResult Invoke(int id)
        {
            Categoria categoria = _dbContext.Categoria.FirstOrDefault(x => x.Id == id);

            return View("CategoriaNome", categoria);

        }
    }
}
