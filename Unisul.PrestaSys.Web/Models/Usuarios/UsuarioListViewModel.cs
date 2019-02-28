using System.Collections.Generic;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Usuarios
{
    public class UsuarioListViewModel : BaseViewModel
    {
        public IEnumerable<UsuarioViewModel> UsuariosList { get; set; }

        public int TotalRecords { get; set; }

        public int PageNumber { get; set; }
    }
}
