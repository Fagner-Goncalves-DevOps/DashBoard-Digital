using DashDigital.Domain.Models;
using DashDigital.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DashDigital.Domain.Intefaces
{
    public interface ICustoGeralRepository //: IRepository<CustoDia> //
    {
        Task<IEnumerable<CustoMetaDiluida>> ObterMetaDiluidaCusto();


        Task<IEnumerable<CustoDia>> ObterCustoServidorDia(string ParamPagSub);
        Task<IEnumerable<CustoOperadoraMinimo>> ObterCustoOperadoraMinimo();
        Task<IEnumerable<CustoOperadora>> ObterCustoOperadora();
        Task<IEnumerable<CustoServidor>> ObterCustoServidorPorServidor(string ParamPagSub);
        Task<IEnumerable<CustoServidorPivot>> ObterCustoServidorPivot(string ParamPagSub);

    }
}
