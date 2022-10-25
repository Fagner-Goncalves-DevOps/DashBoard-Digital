using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
using DashDigital.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DashDigital.Infrastructure.Repository
{
    public class ParametrosRepository : Repository<TabTelecomConsolidado> , IParametrosRepository
    {

        public ParametrosRepository(MeuDbContext context) : base(context) { }
        //implementação aqui
    }
}
