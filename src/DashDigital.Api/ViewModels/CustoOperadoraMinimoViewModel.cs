using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashDigital.Api.ViewModels
{
    public class CustoOperadoraMinimoViewModel
    {
        public string Dia { get; set; }
        public string Operadora { get; set; }
        public decimal Custo { get; set; } 
        public decimal Projetado { get; set; }
        public decimal MetaComMargen { get; set; }
    }
}
