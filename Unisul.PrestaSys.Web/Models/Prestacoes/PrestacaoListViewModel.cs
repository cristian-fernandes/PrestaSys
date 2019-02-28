using System.Collections.Generic;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Prestacoes
{
    public class PrestacaoListViewModel : BaseViewModel
    {
        public IEnumerable<PrestacaoViewModel> PrestacoesList { get; set; }

        public int TotalRecords { get; set; }

        public int PageNumber { get; set; }
    }
}
