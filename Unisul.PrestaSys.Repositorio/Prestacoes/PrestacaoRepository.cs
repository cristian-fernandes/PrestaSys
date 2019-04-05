using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Unisul.PrestaSys.Entidades.Prestacoes;

namespace Unisul.PrestaSys.Repositorio.Prestacoes
{
    public interface IPrestacaoRepository
    {
        int Create(Prestacao prestacao);
        int Delete(int id);
        bool Exists(int id);
        IQueryable<Prestacao> GetAll();
        IQueryable<PrestacaoTipo> GetAllPrestacaoTipos();
        Prestacao GetById(int id);
        int Update(Prestacao prestacao);
    }

    public class PrestacaoRepository : IPrestacaoRepository
    {
        private readonly PrestaSysDbContext _context;

        public PrestacaoRepository(PrestaSysDbContext context)
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

        public IQueryable<Prestacao> GetAll()
        {
            return _context.Prestacao.Include(pr => pr.Aprovador)
                .Include(pr => pr.AprovadorFinanceiro)
                .Include(pr => pr.Emitente)
                .Include(pr => pr.Status)
                .Include(pr => pr.Tipo);
        }

        public IQueryable<PrestacaoTipo> GetAllPrestacaoTipos()
        {
            return _context.PrestacaoTipo;
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
            if (prestacao == null)
                throw new ArgumentNullException(nameof(prestacao));

            try
            {
                _context.Update(prestacao);
            }
            catch (InvalidOperationException)
            {
                var originalEntity = _context.Find(prestacao.GetType(), prestacao.Id);
                _context.Entry(originalEntity).CurrentValues.SetValues(prestacao);
                _context.Update(originalEntity);
            }

            return _context.SaveChanges();
        }
    }
}
