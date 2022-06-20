using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class CustoServidorPivot : Entity
    {
        public string Dia { get; set; }
        public string Servidor { get; set; }
        public decimal Custo { get; set; }
    }
}
