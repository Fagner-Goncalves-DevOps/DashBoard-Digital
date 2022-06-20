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

        public async Task<IEnumerable<Parametros>> ParamSrv(DateTime? DtIni, DateTime? DtFim)
        {

            var dataini = DateTime.Now.AddDays(-2).ToString("yyyy'-'MM'-'dd");
            var datafim = DateTime.Now.AddDays(-1).AddTicks(-1).ToString("yyyy'-'MM'-'dd");

            var Parametros = await (
                           from s in Db.TabTelecomConsolidado
                           join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                           where a.pag_sub == "PAGO" && s.CUSTO > 0 && a.Rota != "" 
                                && (DtIni == null ? s.DIA >= Convert.ToDateTime(dataini).Date : s.DIA >= DtIni) && (DtFim == null ? s.DIA <= Convert.ToDateTime(datafim).Date : s.DIA <= DtFim)
                              group s by new { s.SERVIDOR} into gp
                              orderby(gp.Key.SERVIDOR)
                           select new Parametros {
                               Idservidor = gp.Key.SERVIDOR,
                               Servidor = gp.Key.SERVIDOR
                           }).AsNoTracking().ToListAsync();

            return Parametros;
        }
    }
}
