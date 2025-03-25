using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _context;
        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid Id, TipoEvento tipoEvento)
        {

            try
            {
                TipoEvento tipoBuscados = _context.TipoEvento.Find(Id)!;

                if (tipoBuscados != null)
                {
                    tipoBuscados.TituloTipoEvento = tipoEvento.TituloTipoEvento;

                }

                _context.SaveChanges();

            }

            catch (Exception)
            {

                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {

            try
            {
                TipoEvento tipoEvento = _context.TipoEvento.Find(id)!;

                return tipoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TipoEvento BuscarPorId(Guid Id, TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }



        public List<TipoEvento> Cadastrar()
        {
            try
            {
                _context.TipoEvento.Add();

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid Id)
        {
            try
            {
                TipoEvento eventoBuscado = _context.TipoEvento.Find(Id)!;

                if (eventoBuscado != null)
                {
                    _context.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<TipoEvento> Listar()
        {
            try
            {
                List<TipoEvento> listaDeTipos = _context.TipoEvento.Include(g => g.TituloTipoEvento).ToList();

                return listaDeTipos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> listarDeTipoEvento(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
