﻿using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;

namespace Event_Plus.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly EventContext _context;
        public PresencaRepository(EventContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaEventoBuscado = _context.PresencaEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.PresencaEventos.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void atualizar(Guid id, Presenca presenca)
        {
            throw new NotImplementedException();
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.PresencaEventos
                    .Select(p => new Presenca
                    {
                        PresencaEventoId = p.PresencaEventoId,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            EventoId = p.EventoId!,
                            DataEvento = p.Evento!.DataEvento,
                            EventoName = p.Evento.EventoName,
                            DescricaoEvento = p.Evento.DescricaoEvento,

                            Instituicao = new Instituicao
                            {
                                InstituicaoId = p.Evento.Instituicao!.InstituicaoId,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
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
                PresencasEventos presencaEventoBuscado = _context.PresencasEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.PresencasEventos.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencasEventos inscricao)
        {
            try
            {
                inscricao.IdPresencaEvento = Guid.NewGuid();

                _context.PresencasEventos.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            throw new NotImplementedException();
        }

        public List<PresencasEventos> Listar()
        {

            try
            {
                return _context.PresencasEventos
                    .Select(p => new PresencasEventos
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Eventos
                        {
                            IdEvento = p.IdEvento,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEventos> ListarMinhas(Guid id)
        {
            return _context.PresencasEventos
                .Select(p => new PresencasEventos
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,

                    Evento = new Eventos
                    {
                        IdEvento = p.IdEvento,
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                        Descricao = p.Evento!.Descricao,

                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = p.Evento!.IdInstituicao,
                        }
                    }
                })
                .Where(p => p.IdUsuario == id)
                .ToList();
        }

        Presenca IPresencaRepository.BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        List<Presenca> IPresencaRepository.Listar()
        {
            throw new NotImplementedException();
        }

        List<Presenca> IPresencaRepository.ListarMinhas(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
}