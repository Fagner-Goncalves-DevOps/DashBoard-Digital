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


        public async Task<IEnumerable<CustoOpHoraMinimo>> ObterCustoHoraOpMinimo()
        {
            var CustoOpHoraMinimo = await (
                        from s in Db.TabChamadasDia
                        join a in Db.TabTelecomOperadoras on s.Terminator equals a.Rota
                        join b in Db.TabTelecomOperadoraMinimo on a.Operadora equals b.Operadora  
                        where a.pag_sub == "PAGO" && s.Valor > 0
                        group new { a.Operadora, s.Valor, b.MetaComMargen} by new {a.Operadora, b.MetaComMargen } into gp
                        select new CustoOpHoraMinimo { 
                            Operadora = gp.Key.Operadora,
                            Custo = gp.Sum(t => t.Valor)
                        }).AsNoTracking().ToListAsync();
            return CustoOpHoraMinimo;

        }
    }
}