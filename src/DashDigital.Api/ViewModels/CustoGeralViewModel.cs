using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashDigital.Api.ViewModels
{
    public class CustoGeralViewModel
    {
        public DateTime Dia { get; set; }
        public string Terminator { get; set; }
        public decimal Custo { get; set; }
        public string Pag_sub { get; set; }
        public string Operadora { get; set; }
        public string Tipo { get; set; }
        public string Rota { get; set; }
    }
}
