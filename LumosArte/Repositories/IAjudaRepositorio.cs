namespace LumosArte.Repositories
{
    public interface IAjudaRepositorio
    {
        Ajuda AdicionarAjuda(Ajuda ajuda);

        List<Ajuda> GetAjuda();
    }
}
