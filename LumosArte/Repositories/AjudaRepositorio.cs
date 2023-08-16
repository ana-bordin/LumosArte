using API;

namespace LumosArte.Repositories
{
    public class AjudaRepositorio : IAjudaRepositorio
    {
        private readonly LumosDbContext _dbContext;
        public AjudaRepositorio(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ajuda AdicionarAjuda(Ajuda ajuda)
        {
            _dbContext.Ajuda.Add(ajuda);
            _dbContext.SaveChanges();
            return ajuda;
        }

        public List<Ajuda> GetAjuda()
        {
            return _dbContext.Ajuda.ToList();
        }
    }
}
