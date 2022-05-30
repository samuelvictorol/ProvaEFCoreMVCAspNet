using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaProjeto2.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
