using DashDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Domain.Intefaces
{
    public interface IParametrosRepository // sem necessidade de herança no momento.
    {
        Task<IEnumerable<Parametros>> ParamSrv(DateTime? DtIni, DateTime? DtFim);
    }
}
