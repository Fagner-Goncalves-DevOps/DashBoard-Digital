using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
using DashDigital.Domain.Models.Utils;
using DashDigital.Domain.Models.Validations;
using DashDigital.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashDigital.Infrastructure.Repository
{
    public class CustoGeralRepository : Repository<TabTelecomConsolidado> , ICustoGeralRepository
    {
        public CustoGeralRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<CustoDia>> ObterCustoServidorDia(string ParamPagSub) //OK
        {
            var Hoje = DateTime.Now.DataHoje();
            var fdpm = DateTime.Now.FirstDayPrevioMonth();
            var ldpm = DateTime.Now.LastDayPrevioMonth();
            var fdm  = DateTime.Now.FirstDayOfMonth();
            var ldm  = DateTime.Now.LastDayOfMonth();

            var CustoDia = await (
                        from s in Db.TabTelecomConsolidado
                        join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                        where Convert.ToDateTime(Hoje).Day == 1 ? (s.DIA >= fdpm && s.DIA <= ldpm) : (s.DIA >= fdm && s.DIA <= ldm) 
                                        && (ParamPagSub == null ? a.pag_sub == a.pag_sub : a.pag_sub == ParamPagSub)
                        group new { s.DIA, s.CUSTO, s.DISPAROS } by s.DIA into gp
                        orderby(gp.Key)
                        select new CustoDia {
                            Dia = gp.Key.ToString("yyyy'-'MM'-'dd"),
                            Custo = gp.Sum(s => s.CUSTO),
                            Disparos = gp.Sum(s => s.DISPAROS)
                    }).AsNoTracking().ToListAsync();
            return CustoDia;
        }

        public async Task<IEnumerable<CustoServidor>> ObterCustoServidorPorServidor(string ParamPagSub) //OK
        {
            var Hoje = DateTime.Now.DataHoje();
            var fdpm = DateTime.Now.FirstDayPrevioMonth();
            var ldpm = DateTime.Now.LastDayPrevioMonth();
            var fdm = DateTime.Now.FirstDayOfMonth();
            var ldm = DateTime.Now.LastDayOfMonth();

            var CustoServidor = await (
                        from s in Db.TabTelecomConsolidado
                        join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                        where
                            Convert.ToDateTime(Hoje).Day == 1 ? (s.DIA >= fdpm && s.DIA <= ldpm) : (s.DIA >= fdm && s.DIA <= ldm)
                                        && (ParamPagSub == null ? a.pag_sub == a.pag_sub : a.pag_sub == ParamPagSub)
                        group new { s.SERVIDOR, s.CUSTO } by s.SERVIDOR into gp
                        orderby gp.Sum(s => s.CUSTO)  //descending || ascending
                        select new CustoServidor
                        {
                            Servidor = gp.Key,
                            Custo = gp.Sum(s => s.CUSTO)
                        }).AsNoTracking().ToListAsync();
            return CustoServidor;
        }

        public async Task<IEnumerable<CustoServidorPivot>> ObterCustoServidorPivot(string ParamPagSub) //OK
        {
            var dtini = DateTime.Now.AddDays(-7).ToString("yyyy'-'MM'-'dd");
            var dtfim = DateTime.Now.AddDays(-1).AddTicks(-1).ToString("yyyy'-'MM'-'dd");

            var CustoServidorPivot = await(
                                from s in Db.TabTelecomConsolidado
                                join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                                where s.CUSTO > 0 && s.DIA >= Convert.ToDateTime(dtini).Date && s.DIA <= Convert.ToDateTime(dtfim).Date
                                                && (ParamPagSub == null ? a.pag_sub == a.pag_sub : a.pag_sub == ParamPagSub)
                                group new { s.DIA, s.SERVIDOR, s.CUSTO } by new { s.DIA, s.SERVIDOR } into gpf
                                orderby (gpf.Key.DIA)
                                select new CustoServidorPivot
                                {
                                    Dia = gpf.Key.DIA.ToString("yyyy'-'MM'-'dd"),
                                    Servidor = gpf.Key.SERVIDOR,
                                    Custo = gpf.Sum(s => s.CUSTO)
                                }).AsNoTracking().ToListAsync();
           return CustoServidorPivot;
        }

        public async Task<IEnumerable<CustoMetaDiluida>> ObterMetaDiluidaCusto() //Ok, beber dessa Api, para acessar metadiluida! 
        {

            var qtddias = CountDiasMes.GetDifDias();
            var qtdSabs = CountDiasMes.GetDifDiasSab();

            var Hoje = DateTime.Now.DataHoje();
            var PrimeiroDiaMes = DateTime.Now.FirstDayOfMonth();
            var DiaDeOntem = DateTime.Now.LastDayOfMonth();

            var CustoMetaDiluida = await (
                    from s in Db.TabTelecomConsolidado
                    join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                    join b in Db.TabTelecomOperadoraMinimo on a.Operadora equals b.Operadora
                    where a.pag_sub == "PAGO" && s.CUSTO > 0
                                && Convert.ToDateTime(Hoje).Day == 1 ? 
                                    (s.DIA >= (PrimeiroDiaMes) && s.DIA <= (PrimeiroDiaMes)): (s.DIA >= (PrimeiroDiaMes) && s.DIA <= (DiaDeOntem))
                    group new { a.Operadora, s.CUSTO, b.MetaComMargen} by new { a.Operadora, b.MetaComMargen} into gp
                    select new CustoMetaDiluida  {
                        Operadora = gp.Key.Operadora,
                        MetaDiluida = (gp.Key.MetaComMargen - gp.Sum(c => c.CUSTO)) / (qtddias)*1,  //ANALISAR BO AQUI DE NOA CONTAR SABADO QUANDO E SABADO
                        MetaDiluidaSab = (gp.Key.MetaComMargen - gp.Sum(c => c.CUSTO)) / (qtddias)/2, 
                        QtdsDiasFimMesFalta = qtddias,
                        QtdsSabadosFalta = qtdSabs,
                    }).AsNoTracking().ToListAsync();

            return CustoMetaDiluida;
        }

        public async Task<IEnumerable<CustoOperadoraMinimo>> ObterCustoOperadoraMinimo() //OK
        {
            var DiasTrabalhados = CountDiasMes.GetDifDiasTrabalhados();
            var qtddias = CountDiasMes.GetDifDias();

            var Hoje = DateTime.Now.DataHoje();
            var fdpm = DateTime.Now.FirstDayPrevioMonth();
            var ldpm = DateTime.Now.LastDayPrevioMonth();
            var  fdm = DateTime.Now.FirstDayOfMonth();
            var  ldm = DateTime.Now.LastDayOfMonth();

            var CustoOperadoraMinimo = await (
                    from s in Db.TabTelecomConsolidado
                    join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                    join b in Db.TabTelecomOperadoraMinimo on a.Operadora equals b.Operadora
                    where a.pag_sub == "PAGO" && s.CUSTO > 0
                        &&  Convert.ToDateTime(Hoje).Day == 1 ? 
                                (s.DIA >= fdpm && s.DIA <= ldpm) : (s.DIA >= fdm && s.DIA <= ldm)
                    group new {a.Operadora, s.CUSTO, b.MetaComMargen} by new { a.Operadora, b.MetaComMargen } into gp
                select new CustoOperadoraMinimo { 
                        Dia = Hoje.ToString("yyyy'-'MM'-'dd"),
                        Operadora = gp.Key.Operadora,
                        Custo = gp.Sum(t => t.CUSTO),
                        Projetado =  gp.Sum( t=> t.CUSTO) / (DiasTrabalhados) * (qtddias) + gp.Sum(t => t.CUSTO),
                        MetaComMargen = Convert.ToDecimal(gp.Key.MetaComMargen)
                }).AsNoTracking().ToListAsync();

            return CustoOperadoraMinimo;
        }

        public async Task<IEnumerable<CustoOperadora>> ObterCustoOperadora() //OK
        {
            var Hoje = DateTime.Now.DataHoje();
            var fdpm = DateTime.Now.FirstDayPrevioMonth();
            var ldpm = DateTime.Now.LastDayPrevioMonth();
            var fdm = DateTime.Now.FirstDayOfMonth();
            var ldm = DateTime.Now.LastDayOfMonth();

            var CustoOperadora = await(
                    from s in Db.TabTelecomConsolidado
                    join a in Db.TabTelecomOperadoras on s.TERMINATOR equals a.Rota
                   // join b in Db.TabTelecomOperadoraMinimo on a.Operadora equals b.OP_CALLFLEX
                    where a.pag_sub == "PAGO" && s.CUSTO > 0
                         &&  Convert.ToDateTime(Hoje).Day == 1 ? 
                                 (s.DIA >= fdpm && s.DIA <= ldpm) : (s.DIA >= fdm && s.DIA <= ldm)
                    group new {a.Operadora, s.CUSTO} by new { a.Operadora } into gp
                    select new CustoOperadora { 
                    Operadora = gp.Key.Operadora,
                    Custo = gp.Sum(t => t.CUSTO)
                    }).AsNoTracking().ToListAsync();

            return CustoOperadora;
        }
    }
}



/*
--------------------------------------------------
PROJETADO = (realizado['CUSTO_TOTAL'] / dias trabalhados) *dias final do mes )+realizado['CUSTO_TOTAL']
--------------------------------------------------
*/



