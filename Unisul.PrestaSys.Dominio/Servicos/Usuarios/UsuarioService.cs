using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Repositorio.Usuarios;

namespace Unisul.PrestaSys.Dominio.Servicos.Usuarios
{
    public interface IUsuarioService
    {
        int Create(Usuario usuario);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Usuario, Usuario> GetAll();
        IQueryable<Usuario> GetAllGerentes();
        IQueryable<Usuario> GetAllGerentesFinanceiros();
        Usuario GetById(int id);
        Usuario GetUsuarioByEmail(string email);
        int Update(Usuario usuario);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Create(Usuario usuario)
        {
            return _repositorio.Create(usuario);
        }

        public int Delete(int id)
        {
            return _repositorio.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repositorio.Exists(id);
        }

        public IIncludableQueryable<Usuario, Usuario> GetAll()
        {
            return _repositorio.GetAll();
        }

        public IQueryable<Usuario> GetAllGerentes()
        {
            return _repositorio.GetAll().Where(x => x.FlagGerente);
        }

        public IQueryable<Usuario> GetAllGerentesFinanceiros()
        {
            return _repositorio.GetAll().Where(x => x.FlagGerenteFinanceiro);
        }

        public Usuario GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            var listaUsuarios = _repositorio.GetAll().Where(u => u.Email == email).ToList();

            return listaUsuarios.Count > 0 ? listaUsuarios.First() : null;
        }

        public int Update(Usuario usuario)
        {
            return _repositorio.Update(usuario);
        }
    }
}
