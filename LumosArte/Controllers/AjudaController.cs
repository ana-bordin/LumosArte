using LumosArte.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.Controllers
{
    public class AjudaController : Controller
    {
        private readonly IAjudaRepositorio _ajudaRepositorio;

        public AjudaController(IAjudaRepositorio ajudaRepositorio)
        {
            _ajudaRepositorio = ajudaRepositorio;
        }
        // GET: AjudaController/Create
        public ActionResult CreateAjuda()
        {
            return View();
        }

        // POST: AjudaController/Create
        [HttpPost]
        public IActionResult CreateAjuda(Ajuda ajuda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ajudaRepositorio.AdicionarAjuda(ajuda);
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL ENVIAR O PEDIDO DE AJUDA:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            List<Ajuda> ajuda = _ajudaRepositorio.GetAjuda();
            return View(ajuda);
        }


    }
}