using AutoMapper;
using DashDigital.Api.ViewModels;
using DashDigital.Domain.Models;

namespace DashDigital.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<TabTelecomConsolidado, TabTelecomConsolidadoViewModel>().ReverseMap();
            CreateMap<TabTelecomOperadorasCallflex, TabTelecomOperadorasCallflexViewModel>().ReverseMap();

            CreateMap<CustoDia, CustoDiaViewModel>().ReverseMap();
            CreateMap<CustoServidor, CustoServidorViewModel>().ReverseMap();
            CreateMap<CustoOperadora, CustoOperadoraViewModel>().ReverseMap();
            CreateMap<CustoMetaDiluida, CustoMetaDiluidaViewModel>().ReverseMap();
            CreateMap<CustoServidorPivot, CustoServidorPivotViewModel>().ReverseMap();
            CreateMap<CustoOperadoraMinimo, CustoOperadoraMinimoViewModel>().ReverseMap();
            CreateMap<CustoOpHoraMinimo, CustoOpHoraMinimoDto>().ReverseMap();

            CreateMap<OperadoraMsgRedir, OperadoraMsgRedirViewModel>().ReverseMap();
            CreateMap<ServidorMsgRedir, ServidorMsgRedirViewModel>().ReverseMap();
            CreateMap<DiaMsgRedir, DiaMsgRedirViewModel>().ReverseMap();
        }
    }
}