using API;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace LumosArte.Repositories
{
    public class ProdutoRepositorio: IProdutoRepositorio
    {
        private readonly LumosDbContext _dbContext;
        public ProdutoRepositorio(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List <Produto> GetProdutos()
        {      
            return _dbContext.Produto.ToList();
        }

        public List<Produto> GetProdutosPorCategoria(int categoria_Id)
        {
            return _dbContext.Produto.Where(x => x.Categoria_id == categoria_Id).ToList();
        }

        public Produto ProdutoPorId(int id) 
        {
            return _dbContext.Produto.FirstOrDefault(x => x.Id == id);
        }

        public List<Produto> ProdutoUsuarioId(int usuario_id)
        {
            var produtosUsuario = _dbContext.Produto.Where(x => x.Usuario_id == usuario_id).ToList();
            return produtosUsuario;
        }

        public Produto AdicionarProduto(Produto produto)
        {
            _dbContext.Produto.Add(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public Produto EditarProduto(int id, Produto produtoNovo)
        {
            Produto produtodb = ProdutoPorId(id);
            if (produtodb == null)
            {
                throw new Exception("NÃO FOI POSSIVEL ATUALIZAR O PRODUTO");
            }
            if (produtoNovo.Imagem != null)
            {
                produtodb.Imagem = produtoNovo.Imagem;
            }
            produtodb.Nome = produtoNovo.Nome;
            produtodb.Descricao = produtoNovo.Descricao;
            produtodb.Categoria_id = produtoNovo.Categoria_id;

            _dbContext.Produto.Update(produtodb);
            _dbContext.SaveChanges();
            return produtodb;
        }

        public bool ExcluirProduto (Produto produto)
        {

            if (produto == null)
            {
                throw new Exception("NÃO FOI POSSIVEL APAGAR A CONTA");
            }

           
            _dbContext.Produto.Remove(produto);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Produto> BuscaProduto(string busca)
        {
            return _dbContext.Produto.Where(x => x.Descricao.Contains(busca) || x.Nome.Contains(busca)).ToList();
        }

    }
}
