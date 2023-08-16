using API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LumosArte.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly LumosDbContext _dbContext;
        public UsuarioRepositorio(LumosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public Usuario UsuarioPagina(int id)
        //{
        //    return _dbContext.Usuario.FirstOrDefault(x => x.Id == id);
        //}

        public Usuario BuscarPorUsuario(string nomeUsuario)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.Nome_usuario == nomeUsuario);
        }

        public Usuario ListarPorId(int id)
        {
            return _dbContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public Usuario AdionarUsuario(Usuario usuario)
        {
            usuario.Foto_Perfil = "user.png";
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }

        public Usuario EditarUsuario(int userLogadoId, Usuario usuario)
        {
            Usuario usuariodb = ListarPorId(userLogadoId);
            if (usuariodb == null)
            {
                throw new Exception("NÃO FOI POSSIVEL ATUALIZAR O USUARIO");
            }
            if (usuario.Foto_Perfil != null)
            {
                usuariodb.Foto_Perfil = usuario.Foto_Perfil;
            }

            usuariodb.Primeiro_nome = usuario.Primeiro_nome;
            usuariodb.Ultimo_nome = usuario.Ultimo_nome;
            usuariodb.Email = usuario.Email;
            usuariodb.Descricao = usuario.Descricao;
            usuariodb.Data_nascimento = usuario.Data_nascimento;
            usuariodb.Telefone = usuario.Telefone;

            _dbContext.Usuario.Update(usuariodb);
            _dbContext.SaveChanges();
            return usuariodb;
        }

        public bool ExcluirUsuario(Usuario usuario)
        {

            if (usuario == null)
            {
                throw new Exception("NÃO FOI POSSIVEL APAGAR A CONTA");
            }

            List<Produto> produto = _dbContext.Produto.Where(x => x.Usuario_id == usuario.Id).ToList();

            foreach (Produto produto1 in produto)
            {
                _dbContext.Produto.Remove(produto1);
            }

            _dbContext.Usuario.Remove(usuario);
            _dbContext.SaveChanges();
            return true;
        }
        public List<Usuario> BuscaUsuario(string busca)
        {
            return _dbContext.Usuario.Where(x => x.Nome_usuario.Contains(busca)).ToList();
        }
    }

}