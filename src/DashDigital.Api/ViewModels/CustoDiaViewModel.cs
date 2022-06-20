using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashDigital.Api.ViewModels
{
    public class CustoDiaViewModel
    {
        public string Dia { get; set; }
        public decimal Custo { get; set; }
        public int Disparos { get; set; }
    }

}
