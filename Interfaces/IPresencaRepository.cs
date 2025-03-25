using Event_Plus.Domains;

namespace Event_Plus.Interfaces
{
    public interface IPresencaRepository
    {
        void Deletar(Guid Id);
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid Id);
        void atualizar (Guid id, Presenca presenca);
        List<Presenca> ListarMinhas(Guid Id);
        void Inscrever(Presenca inscricao);
    }
}
