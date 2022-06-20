using DashDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Domain.Intefaces
{

    public interface IOperadoraMsgRedirRepository  //não vou herdar de local nem um para não teq implementar interface generica
    {
        Task<IEnumerable<DiaMsgRedir>> ObterDiaMsgRedir();
        Task<IEnumerable<OperadoraMsgRedir>> ObterOperadoraMsgRedir(DateTime? DtIni, DateTime? DtFim, string ParamSrv);
        Task<IEnumerable<ServidorMsgRedir>> ObterServidorMsgRedir(DateTime? DtIni, DateTime? DtFim);
    }
}
