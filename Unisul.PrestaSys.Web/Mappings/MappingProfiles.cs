using AutoMapper;
using Unisul.PrestaSys.Entidades.Prestacoes;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Prestacoes;
using Unisul.PrestaSys.Web.Models.Usuarios;

namespace Unisul.PrestaSys.Web.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Prestacao, PrestacaoViewModel>().ForMember(x => x.ImagemComprovante, opt => opt.Ignore());
            CreateMap<PrestacaoViewModel, Prestacao>().ForMember(x => x.ImagemComprovante, opt => opt.Ignore());
        }
    }
}
