using API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LumosArte.ViewComponents
{
    public class CategoriaView : ViewComponent
    {
        private readonly LumosDbContext _dbContext;
        public CategoriaView(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public IViewComponentResult Invoke(int id)
        {
            List<Categoria> categoria = _dbContext.Categoria.ToList();
            
            if (id == 1)
            {
                return View("Categoria", categoria);
            }
            return View("CategoriaProduto", categoria);

        }
    }
}
