using AutoMapper;
using DashDigital.Api.Controllers;
using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
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
    [Route("api/v{version:apiVersion}/Parametros")]
    public class ParametrosController : MainController
    {
        private readonly IParametrosRepository _iparametrosRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ParametrosController(IParametrosRepository iparametrosRepository,
                                    INotificador notificador,
                                    IMapper mapper,
                                    IHttpContextAccessor httpContextAccessor,
                                    IUser user) : base(notificador, user)


        {
            _iparametrosRepository = iparametrosRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("DateServidor")]
        public async Task<IEnumerable<Parametros>> DateServidor(DateTime? DtIni, DateTime? DtFim)
        {
            var Parametros =  _mapper.Map<IEnumerable<Parametros>>(await  _iparametrosRepository.ParamSrv(DtIni, DtFim));
            return Parametros;
        }
    }
}
