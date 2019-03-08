using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Repositorio.Usuarios
{
    public interface IUsuarioRepository
    {
        int Create(Usuario usuario);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Usuario, ICollection<Prestacao>> GetAll();
        Usuario GetById(int id);
        void Update(Usuario usuario);
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

        public IIncludableQueryable<Usuario, ICollection<Prestacao>> GetAll()
        {
            return _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .Include(p => p.PrestacaoAprovador)
                .Include(p => p.PrestacaoAprovadorFinanceiro);
        }

        public Usuario GetById(int id)
        {
            return _context.Usuario
                .Include(u => u.Gerente)
                .Include(u => u.GerenteFinanceiro)
                .Include(p => p.PrestacaoAprovador)
                .Include(p => p.PrestacaoAprovadorFinanceiro)
                .FirstOrDefault(m => m.Id == id);
        }

        public void Update(Usuario usuario)
        {
            var prestacoes = _context.Prestacao.Where(p => p.EmitenteId == usuario.Id);

            foreach (var prestacao in prestacoes)
            {
                prestacao.AprovadorId = usuario.GerenteId;
                prestacao.AprovadorFinanceiroId = usuario.GerenteFinanceiroId;
            }

            _context.BulkUpdate(prestacoes.ToList());

            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}
