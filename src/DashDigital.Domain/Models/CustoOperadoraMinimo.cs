using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class CustoOperadoraMinimo : Entity
    {
        public string Dia { get; set; }
        public string Operadora { get; set; }
        public decimal Custo { get; set; } //MetaDiluidaSab MetaComMargen
        public decimal Projetado { get; set; }
        public decimal MetaComMargen { get; set; }
    }
}
