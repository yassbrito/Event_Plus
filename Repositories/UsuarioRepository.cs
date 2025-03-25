using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interfaces;
using Event_Plus.Utils;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorEmaileSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorID(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                _context.Usuario.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuario = _context.Usuario.ToList();
            return listaUsuario;
        }
    }
}

