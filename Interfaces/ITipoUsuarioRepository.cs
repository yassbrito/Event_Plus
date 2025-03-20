using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar (TipoUsuario tipoUsuario);
        void Deletar(Guid Id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId (Guid Id);

        void atualizar(Guid Id, TipoUsuario tipoUsuario);               
    }
}
