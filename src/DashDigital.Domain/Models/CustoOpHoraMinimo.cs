using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class CustoOpHoraMinimo
    {
        public string Operadora { get; set; }
        public decimal Custo { get; set; }
        public decimal PercentualRealizado { get; set; }
    }
}
