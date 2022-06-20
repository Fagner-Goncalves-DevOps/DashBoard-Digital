using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class OperadoraMsgRedir : Entity
    {
        public string Operadora { get; set; }
        public decimal Msg { get; set; }
        public decimal Redir { get; set; }

      //  public decimal RedirPercentual { get; set; } //coluna teste para validação dos dados
      //  public decimal MsgPercentual { get; set; } //coluna teste para validação dos dados
      //  public decimal Total { get; set; } //coluna teste para validação dos dados
    }

}
