using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Repositorio
{
    public interface IPrestaSysDbContext : IDisposable
    {
        DbSet<Prestacao> Prestacao { get; set; }
        DbSet<PrestacaoStatus> PrestacaoStatus { get; set; }
        DbSet<PrestacaoTipo> PrestacaoTipo { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        EntityEntry Add(object entity);
        bool Equals(object obj);
        int GetHashCode();
        EntityEntry Remove<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        string ToString();
        EntityEntry Update(object entity);
        void BulkUpdate<T>(IList<T> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where T : class;
    }
}
