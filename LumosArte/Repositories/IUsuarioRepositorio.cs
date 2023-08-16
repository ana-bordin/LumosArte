namespace LumosArte.Repositories
{
    public interface IUsuarioRepositorio
    {
        //Usuario UsuarioPagina(int id);
        Usuario BuscarPorUsuario(string nomeUsuario);
        Usuario ListarPorId(int id);
        Usuario AdionarUsuario(Usuario usuario);
        Usuario EditarUsuario(int IdUserLogado, Usuario usuario);
        bool ExcluirUsuario(Usuario usuario);
        List<Usuario> BuscaUsuario(string busca);
    }
}