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

namespace DashDigital.Api.V1.Controllers
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/TabChamadasDia")]
    public class TabChamadasDiaController : MainController
    {
        private readonly ICustoGeralHoraRepository _icustogeralhorarepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TabChamadasDiaController(ICustoGeralHoraRepository icustoGeralHoraRepository,
                                        IMapper mapper,
                                        IHttpContextAccessor httpContextAccessor,
                                        INotificador notificador,
                                        IUser user) :base(notificador, user)
        {

            _icustogeralhorarepository = icustoGeralHoraRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("CustoOpHoraMinimos")]
        public async Task<IEnumerable<CustoOpHoraMinimoDto>> CustoOpHoraMinimos() {

            var CustoOpHoraMinimos = _mapper.Map<IEnumerable<CustoOpHoraMinimoDto>>(await _icustogeralhorarepository.ObterCustoHoraOpMinimo());
            return CustoOpHoraMinimos;

        }

    }
}
