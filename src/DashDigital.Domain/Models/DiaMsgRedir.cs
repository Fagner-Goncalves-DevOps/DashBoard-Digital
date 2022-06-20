using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class DiaMsgRedir : Entity
    {
        public string Dia { get; set; }
        public string Operadora { get; set; }
        public decimal Msg { get; set; }
        public decimal Redir { get; set; }
    }
}
