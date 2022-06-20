using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class TabTelecomConsolidado : Entity
    {
        public int Id { get; set; }
        public DateTime DIA { get; set; }
        public int FILA { get; set; }
        public string TERMINATOR { get; set; }
        public string STATUS_INICIAL { get; set; }
        public string STATUS_FINAL { get; set; }
        public string CLASSE { get; set; }
        public int BILHETADO { get; set; }
        public int DISPAROS { get; set; }
        public decimal CUSTO { get; set; }
        public int MAIOR_30 { get; set; }
        public int MENOR_30 { get; set; }
        public int DISPARO_TARIFADO { get; set; }
        public string SERVIDOR { get; set; }
    }
    /* EF Relation talves trazer aqui servidorcallflex dxpara */
    // public Fornecedor Fornecedor { get; set; }
}

