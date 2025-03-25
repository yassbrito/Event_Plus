using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;

namespace Event_Plus.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventContext _context;

        public ComentarioRepository(EventContext context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            EventoName = c.Evento!.EventoName,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == UsuarioId && c.IdEvento == EventoId)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioEventoId = Guid.NewGuid();

                _context.ComentarioEvento.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            EventoName = c.Evento!.EventoName,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            EventoName = c.Evento!.EventoName,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        List<ComentarioEvento> IComentarioRepository.Listar(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
