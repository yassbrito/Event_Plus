using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar (ComentarioEvento comentarioEvento);
        void Deletar (int idComentario);
        List<ComentarioEvento> Listar(Guid Id);
        ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
    }
}
