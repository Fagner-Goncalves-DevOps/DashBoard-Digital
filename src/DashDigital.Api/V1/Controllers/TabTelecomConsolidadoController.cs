using AutoMapper;
using DashDigital.Api.Controllers;
using DashDigital.Api.ViewModels;
using DashDigital.Domain.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashTelecom.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/TabTelecomConsolidado")]
    public class TabTelecomConsolidadoController : MainController
    {

        private readonly ITabTelecomConsolidadoRepository _tabTelecomConsolidadoRepository;
        private readonly ICustoGeralRepository _custoDiaRepository;
        private readonly IOperadoraMsgRedirRepository _operadoraMsgRedirRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TabTelecomConsolidadoController(ITabTelecomConsolidadoRepository tabTelecomConsolidadoRepository,
                                                ICustoGeralRepository custoDiaRepository,
                                                IOperadoraMsgRedirRepository operadoraMsgRedirRepository,
                                                INotificador notificador,
                                                IMapper mapper,
                                                IHttpContextAccessor httpContextAccessor,
                                                IUser user) : base(notificador, user)
        {
            _tabTelecomConsolidadoRepository = tabTelecomConsolidadoRepository;
            _custoDiaRepository = custoDiaRepository;
            _operadoraMsgRedirRepository = operadoraMsgRedirRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

       // [AllowAnonymous]
        [HttpGet("CustoPorDia")]
        public async Task<IEnumerable<CustoDiaViewModel>> CustoPorDia(string ParamPagSub)
        {
            var CustoPorDia = _mapper.Map<IEnumerable<CustoDiaViewModel>>(await _custoDiaRepository.ObterCustoServidorDia(ParamPagSub));
            return CustoPorDia;
        }

        [HttpGet("CustoPorServidor")]
        public async Task<IEnumerable<CustoServidorViewModel>> CustoPorServidor(string ParamPagSub)
        {
            var CustoPorServidor = _mapper.Map<IEnumerable<CustoServidorViewModel>>(await _custoDiaRepository.ObterCustoServidorPorServidor(ParamPagSub));
            return CustoPorServidor;
        }

        [HttpGet("CustoPorServidorPivot")]
        public async Task<IEnumerable<CustoServidorPivotViewModel>> CustoPorServidorPivot(string ParamPagSub)
        {
            var CustoPorServidorPivot = _mapper.Map<IEnumerable<CustoServidorPivotViewModel>>(await _custoDiaRepository.ObterCustoServidorPivot(ParamPagSub));
            return CustoPorServidorPivot;
        }

        [HttpGet("CustoOperadoraMetaDiluida")]
        public async Task<IEnumerable<CustoMetaDiluidaViewModel>> CustoMetaDiluida() 
        {
            var CustoMetaDiluida = _mapper.Map<IEnumerable<CustoMetaDiluidaViewModel>>(await _custoDiaRepository.ObterMetaDiluidaCusto());
            return CustoMetaDiluida;
        }

        [HttpGet("CustoOperadoraMinimo")]
        public async Task<IEnumerable<CustoOperadoraMinimoViewModel>> CustoOperadoraMinimo()
        {
            var CustoOperadoraMinimo = _mapper.Map<IEnumerable<CustoOperadoraMinimoViewModel>>(await _custoDiaRepository.ObterCustoOperadoraMinimo());
            return CustoOperadoraMinimo;
        }

        [HttpGet("CustoOperadora")]
        public async Task<IEnumerable<CustoOperadoraViewModel>> CustoOperadora()
        {
            var CustoOperadora = _mapper.Map<IEnumerable<CustoOperadoraViewModel>>(await _custoDiaRepository.ObterCustoOperadora());
            return CustoOperadora;
        }

        [HttpGet("MsgRedirOperadora")]
        public async Task<IEnumerable<OperadoraMsgRedirViewModel>> OperadoraMsgRedir(DateTime? DtIni, DateTime? DtFim, string ParamSrv)
        {
            var OperadoraMsgRedir = _mapper.Map<IEnumerable<OperadoraMsgRedirViewModel>>(await _operadoraMsgRedirRepository.ObterOperadoraMsgRedir(DtIni, DtFim, ParamSrv));
            return OperadoraMsgRedir;
        }

        [HttpGet("MsgRedirServidor")]
        public async Task<IEnumerable<ServidorMsgRedirViewModel>> ServidorMsgRedir(DateTime? DtIni, DateTime? DtFim)
        {
            var ServidorMsgRedir = _mapper.Map<IEnumerable<ServidorMsgRedirViewModel>>(await _operadoraMsgRedirRepository.ObterServidorMsgRedir(DtIni, DtFim));
            return ServidorMsgRedir;
        }

        [HttpGet("MsgRedirDia")]
        public async Task<IEnumerable<DiaMsgRedirViewModel>> DiaMsgRedir() 
        {
            var DiaMsgRedir = _mapper.Map<IEnumerable<DiaMsgRedirViewModel>>(await _operadoraMsgRedirRepository.ObterDiaMsgRedir());
            return DiaMsgRedir;
        }


    }
}



