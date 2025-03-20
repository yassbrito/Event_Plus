using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEvento);

        void Deletar (Guid Id);
        List<TipoEvento> Listar();

        TipoEvento BuscarPorId(Guid id);

        void Atualizar (Guid Id,TipoEvento tipoEvento);
        List<TipoEvento> listarDeTipoEvento(Guid id);
    }
}
