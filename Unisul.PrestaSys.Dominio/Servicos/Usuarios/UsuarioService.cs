using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Repositorio.Usuarios;

namespace Unisul.PrestaSys.Dominio.Servicos.Usuarios
{
    public interface IUsuarioService
    {
        int Create(Usuario usuario);
        int Delete(int id);
        bool Exists(int id);
        IIncludableQueryable<Usuario, ICollection<Prestacao>> GetAll();
        IQueryable<Usuario> GetAllGerentes();
        IQueryable<Usuario> GetAllGerentesFinanceiros();
        Usuario GetById(int id);
        Usuario GetUsuarioByEmail(string email);
        Usuario GetUsuarioByEmailAndSenha(string email, string senha);
        void Update(Usuario usuario);
        string GetUsuarioEmailById(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public int Create(Usuario usuario)
        {
            return _repository.Create(usuario);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public IIncludableQueryable<Usuario, ICollection<Prestacao>> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Usuario> GetAllGerentes()
        {
            return _repository.GetAll().Where(x => x.FlagGerente);
        }

        public IQueryable<Usuario> GetAllGerentesFinanceiros()
        {

            return _repository.GetAll().Where(x => x.FlagGerenteFinanceiro);
        }

        public Usuario GetById(int id)
        {
            return _repository.GetById(id);
        }

        public string GetUsuarioEmailById(int id)
        {
            return _repository.GetById(id).Email;
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            var listaUsuarios = _repository.GetAll().Where(u => u.Email == email).ToList();

            return listaUsuarios.Count > 0 ? listaUsuarios.First() : null;
        }

        public Usuario GetUsuarioByEmailAndSenha(string email, string senha)
        {
            var listaUsuarios = _repository.GetAll().Where(u => u.Email == email && u.Senha == senha).ToList();

            return listaUsuarios.Count > 0 ? listaUsuarios.First() : null;
        }

        public void Update(Usuario usuario)
        {
            _repository.Update(usuario);
        }
    }
}
