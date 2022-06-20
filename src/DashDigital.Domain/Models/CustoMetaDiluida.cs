using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class CustoMetaDiluida : Entity
    {
        public string Operadora { get; set; }
        public decimal MetaDiluida { get; set; }
        public decimal MetaDiluidaSab { get; set; } //MetaDiluidaSab MetaComMargen
        public int QtdsDiasFimMesFalta { get; set; }
        public int QtdsSabadosFalta { get; set; }
    }
}
