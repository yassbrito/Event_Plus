using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmaileSenha(string email, string senha);
    }
}
