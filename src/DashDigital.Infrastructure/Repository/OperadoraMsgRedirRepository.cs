using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
using DashDigital.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Infrastructure.Repository
{
    public class OperadoraMsgRedirRepository : Repository<OperadoraMsgRedir>, IOperadoraMsgRedirRepository
    {
        public OperadoraMsgRedirRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<DiaMsgRedir>> ObterDiaMsgRedir() //OK
        {
            var dataini = DateTime.Now.AddDays(-7).ToString("yyyy'-'MM'-'dd");
            var datafim = DateTime.Now.AddDays(-1).AddTicks(-1).ToString("yyyy'-'MM'-'dd");

            var DiaMsgRedir = await (
                    from s in Db.TabTelecomConsolidado
                    join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                    where a.pag_sub == "PAGO" && s.CUSTO > 0 && a.Rota != ""
                        && (s.DIA >= Convert.ToDateTime(dataini).Date && s.DIA <= Convert.ToDateTime(datafim).Date)
                    group new { s.DIA, a.Operadora, s.STATUS_FINAL, s.CUSTO  } by new { s.DIA, a.Operadora } into gpdata
                    select new DiaMsgRedir
                                    {
                                        Dia = gpdata.Key.DIA.ToString("yyyy'-'MM'-'dd"),
                                        Operadora = gpdata.Key.Operadora,
                                        Msg = gpdata.Sum(c => (c.STATUS_FINAL == "MACHINE" ? c.CUSTO : 0)) / gpdata.Sum(t => t.CUSTO) * 100,
                                        Redir = gpdata.Sum(c => (c.STATUS_FINAL == "REDIR" ? c.CUSTO : 0)) / gpdata.Sum(t => t.CUSTO) * 100
                    }).AsNoTracking().ToListAsync();
            return DiaMsgRedir;
        }

        public async Task<IEnumerable<OperadoraMsgRedir>> ObterOperadoraMsgRedir(DateTime? DtIni, DateTime? DtFim, string ParamSrv) //OK
        {
            var dataini = DateTime.Now.AddDays(-2).ToString("yyyy'-'MM'-'dd");
            var datafim = DateTime.Now.AddDays(-1).AddTicks(-1).ToString("yyyy'-'MM'-'dd");

            var OperadoraMsgRedir = await (
                        from s in Db.TabTelecomConsolidado
                        join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                        where a.pag_sub == "PAGO" && s.CUSTO > 0 && a.Rota != ""
                                && (DtIni == null ? s.DIA >= Convert.ToDateTime(dataini).Date : s.DIA >= DtIni) 
                                        && (DtFim == null ? s.DIA <= Convert.ToDateTime(datafim).Date : s.DIA <= DtFim) 
                                                && (ParamSrv == null ? s.SERVIDOR == s.SERVIDOR : s.SERVIDOR == ParamSrv)
                        group new { a.Operadora, s.STATUS_FINAL, s.CUSTO } by a.Operadora into groupedData
                        select new OperadoraMsgRedir{
                            Operadora = groupedData.Key,
                            Msg = groupedData.Sum(c => (c.STATUS_FINAL == "MACHINE" ? c.CUSTO : 0)) / groupedData.Sum(t => t.CUSTO) *100,
                            Redir = groupedData.Sum(c => (c.STATUS_FINAL == "REDIR" ? c.CUSTO : 0)) / groupedData.Sum(t => t.CUSTO) *100
                            }).AsNoTracking().ToListAsync();        
            return OperadoraMsgRedir;
        }

        public async Task<IEnumerable<ServidorMsgRedir>> ObterServidorMsgRedir(DateTime? DtIni, DateTime? DtFim) //OK
        {
            var dataini = DateTime.Now.AddDays(-2).ToString("yyyy'-'MM'-'dd");
            var datafim = DateTime.Now.AddDays(-1).AddTicks(-1).ToString("yyyy'-'MM'-'dd");

            var ServidorMsgRedir = await (
                            from s in Db.TabTelecomConsolidado
                            join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                            where s.CUSTO > 0
                                && (DtIni == null ? s.DIA >= Convert.ToDateTime(dataini).Date : s.DIA >= DtIni) && (DtFim ==null ? s.DIA <= Convert.ToDateTime(datafim).Date : s.DIA <= DtFim)
                            group new { s.SERVIDOR, s.STATUS_FINAL, s.CUSTO } by s.SERVIDOR into groupData
                            select new ServidorMsgRedir {
                                Servidor = groupData.Key,
                                Msg = groupData.Sum(c => (c.STATUS_FINAL == "MACHINE" ? c.CUSTO : 0 )) / groupData.Sum(t => t.CUSTO) *100,
                                Redir = groupData.Sum(c => (c.STATUS_FINAL == "REDIR" ? c.CUSTO : 0 )) / groupData.Sum(t => t.CUSTO) *100    
                            }).AsNoTracking().ToListAsync();

            return ServidorMsgRedir;
        }
    }
}
