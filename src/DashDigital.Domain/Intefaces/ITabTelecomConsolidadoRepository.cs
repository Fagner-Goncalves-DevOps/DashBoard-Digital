using DashDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Domain.Intefaces
{
    public interface ITabTelecomConsolidadoRepository : IRepository<TabTelecomConsolidado>
    {
        Task<IEnumerable<TabTelecomConsolidado>> ObterTelecomConsolidado();
    }
}

 



