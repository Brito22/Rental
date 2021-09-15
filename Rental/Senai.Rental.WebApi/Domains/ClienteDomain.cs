using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CNH { get; set; }
    }
}
