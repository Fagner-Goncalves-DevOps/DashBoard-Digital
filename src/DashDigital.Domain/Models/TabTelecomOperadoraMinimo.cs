using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class TabTelecomOperadoraMinimo : Entity
    {
        public string Operadora { get; set; }
        public decimal Minimo { get; set; }
        public decimal MetaComMargen { get; set; }

    }
}



/*
OP_CALLFLEX	varchar
Minimo	int
MetaComMargen	int
 */
