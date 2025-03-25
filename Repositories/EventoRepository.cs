using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _context;

        public EventoRepository(EventContext contexto)
        {
            _context = contexto;
        }


        //Atualizar
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.EventoName = evento.EventoName;
                    eventoBuscado.DescricaoEvento = evento.DescricaoEvento;
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }

                _context.Evento.Update(eventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        EventoName = e.EventoName,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.IdEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BUscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (evento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                evento.EventoId = Guid.NewGuid();

                _context.Evento.Add(evento);

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
                Evento eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        EventoName = e.EventoName,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoId = e.TipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicaoId = e.InstituicaoId,
                        Instituicao = new Instituicao
                        {
                            InstituicaoId = e.InstituicaoId,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> listar()
        {
            throw new NotImplementedException();
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                return _context.Evento.Include(e => e.Presenca).Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        EventoName = e.EventoName,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            TipoEventoId = e.IdTipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },

                        InstituicaoId = e.InstituicaoId,
                        Instituicao = new Instituicao
                        {
                            InstituicaoId = e.InstituicaoId,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },

                        Presenca = new Presenca
                        {
                            Usuario = e.Presenca!.Usuario,
                            Situacao = e.Presenca!.Situacao
                        }
                    }).Where(e => e.PresencasEventos!.Situacao == true && e.PresencasEventos.IdUsuario == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> listarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> ProximosEventos()
        {
            try
            {
                return _context.Evento
                   .Select(e => new Evento
                   {
                       EventoId = e.EventoId,
                       EventoName = e.EventoName,
                       DescricaoEvento = e.DescricaoEvento,
                       DataEvento = e.DataEvento,
                       IdTipoEvento = e.IdTipoEvento,
                       TipoEvento = new TipoEvento
                       {
                          TipoEventoId = e.TipoEvento,
                           TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                       },
                       InstituicaoId = e.InstituicaoId,
                       Instituicao = new Instituicao
                       {
                           InstituicaoId = e.InstituicaoId,
                           NomeFantasia = e.Instituicao!.NomeFantasia
                       }

                   })
                   .Where(e => e.DataEvento >= DateTime.Now)
                   .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ProximosEventos(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

