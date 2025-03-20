using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        void Deletar (Guid Id);
        List<Evento> listar();
        List<Evento> listarPorId(Guid Id);
        List<Evento> ProximosEventos(Guid Id);
        Evento BUscarPorId(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
