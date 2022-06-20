using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models
{
    public class TabChamadasDia : Entity
    {
        public int Idf_Servidor_Callflex { get; set; }
        public string Uniqueid { get; set; }
        public DateTime Calldate { get; set; }
        public int hora { get; set; }
        public int Fila { get; set; }
        public string Terminator { get; set; }
        public string Status { get; set; }
        public int Isdncause { get; set; }
        public string Mailing { get; set; }
        public string Classe { get; set; }
        public decimal Valor { get; set; }
    }
}
