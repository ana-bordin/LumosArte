using LumosArte.Models;
namespace LumosArte.Repositories
{
    public interface IProdutoRepositorio
    {
        List<Produto> GetProdutos();
        List<Produto> GetProdutosPorCategoria(int categoria_Id);
        Produto ProdutoPorId(int id);
        List<Produto> ProdutoUsuarioId(int usuario_Id);
        Produto AdicionarProduto(Produto produto);
        Produto EditarProduto(int id, Produto produto);
        bool ExcluirProduto(Produto produto);
        List<Produto> BuscaProduto(string busca);
    }
}
    
