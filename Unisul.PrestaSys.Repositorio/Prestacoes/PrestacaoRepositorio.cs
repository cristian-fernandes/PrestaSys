using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Repositorio.Prestacoes
{
    public interface IPrestacaoRepositorio
    {
        int Create(Prestacao prestacao);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Prestacao, PrestacaoTipo> GetAll();
        Prestacao GetById(int id);
        int Update(Prestacao prestacao);
    }

    public class PrestacaoRepositorio : IPrestacaoRepositorio
    {
        private readonly IPrestaSysDbContext _context;

        public PrestacaoRepositorio(IPrestaSysDbContext context)
        {
            _context = context;
        }

        public int Create(Prestacao prestacao)
        {
            _context.Add(prestacao);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var prestacao = _context.Prestacao.Find(id);
            _context.Prestacao.Remove(prestacao);
            return _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Prestacao.Any(e => e.Id == id);
        }

        public IIncludableQueryable<Prestacao, PrestacaoTipo> GetAll()
        {
            return _context.Prestacao.Include(pr => pr.Aprovador)
                .Include(pr => pr.AprovadorFinanceiro)
                .Include(pr => pr.Emitente)
                .Include(pr => pr.Status)
                .Include(pr => pr.Tipo);
        }

        public Prestacao GetById(int id)
        {
            return _context.Prestacao
                .Include(p => p.Aprovador)
                .Include(p => p.AprovadorFinanceiro)
                .Include(p => p.Emitente)
                .Include(p => p.Status)
                .Include(p => p.Tipo)
                .FirstOrDefault(m => m.Id == id);
        }

        public int Update(Prestacao prestacao)
        {
            _context.Update(prestacao);
            return _context.SaveChanges();
        }
    }
}
