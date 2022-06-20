using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class TabTelecomOperadorasCallflex : Entity
    {
        public int id_operadora { get; set; }
        public string Rota { get; set; }
        public string Operadora { get; set; }
        public string tipo { get; set; }
        public string pag_sub { get; set; }
        public string tecnologia { get; set; }
        public string operadora_ftr { get; set; }
    }
}
