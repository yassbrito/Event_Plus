using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _context;

        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }
        public void atualizar(Guid Id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(Id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid Id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(Id)!;
                return tipoUsuarioBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario novotipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(novotipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                TipoUsuario UsuarioBuscado = _context.TipoUsuario.Find(Id)!;

                if (UsuarioBuscado != null)
                {
                    _context.Remove(UsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaDeUsuarios = _context.TipoUsuario.ToList();
                return listaDeUsuarios;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
