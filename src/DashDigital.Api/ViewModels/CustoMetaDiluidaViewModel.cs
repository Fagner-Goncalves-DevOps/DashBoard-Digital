using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashDigital.Api.ViewModels
{
    public class CustoMetaDiluidaViewModel
    {
        public string Operadora { get; set; }
        public decimal MetaDiluida { get; set; }  
        public decimal MetaDiluidaSab { get; set; } //MetaDiluidaSab MetaComMargen
        public int QtdsDiasFimMesFalta { get; set; }
        public int QtdsSabadosFalta { get; set; }

    }
}
