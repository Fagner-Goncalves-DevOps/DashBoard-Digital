using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
using DashDigital.Domain.Models.Utils;
using DashDigital.Infrastructure.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DashDigital.Infrastructure.Repository
{
    public class CustoGeralHoraRepository : Repository<TabChamadasDia>, ICustoGeralHoraRepository
    {
        public CustoGeralHoraRepository(MeuDbContext context) : base(context) { }
            //implementação aqui
}
