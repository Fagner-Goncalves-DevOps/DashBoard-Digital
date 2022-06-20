using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class ServidorMsgRedir :Entity
    {
        public string Servidor { get; set; }
        public decimal Msg { get; set; }
        public decimal Redir { get; set; }
    }
}
