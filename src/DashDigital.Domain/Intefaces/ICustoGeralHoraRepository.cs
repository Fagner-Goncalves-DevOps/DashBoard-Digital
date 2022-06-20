using DashDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Domain.Intefaces
{
    public interface ICustoGeralHoraRepository 
    {
        Task<IEnumerable<CustoOpHoraMinimo>> ObterCustoHoraOpMinimo();
    }
}
