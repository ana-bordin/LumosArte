using API;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.ViewComponents
{
    public class AssuntoView : ViewComponent
    {
        private readonly LumosDbContext _dbContext;
        public AssuntoView(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            List<Assunto> assunto = _dbContext.Assunto.ToList();
            return View("Assunto", assunto);
        }
    }
}