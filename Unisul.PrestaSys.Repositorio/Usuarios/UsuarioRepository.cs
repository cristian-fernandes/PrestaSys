using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Repositorio.Usuarios
{
    public interface IUsuarioRepository
    {
        int Create(Usuario usuario);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Usuario, Usuario> GetAll();
        Usuario GetById(int id);
        int Update(Usuario usuario);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IPrestaSysDbContext _context;

        public UsuarioRepository(IPrestaSysDbContext context)
        {
            _context = context;
        }

        public int Create(Usuario usuario)
        {
            _context.Add(usuario);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var usuario = _context.Usuario.Find(id);
            _context.Usuario.Remove(usuario);
            return _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }

        public IIncludableQueryable<Usuario, Usuario> GetAll()
        {
            return _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro);
        }

        public Usuario GetById(int id)
        {
            return _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .FirstOrDefault(m => m.Id == id);
        }

        public int Update(Usuario usuario)
        {
            _context.Update(usuario);
            return _context.SaveChanges();
        }
    }
}
