using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idCliente { get; set; }
        public int idVeiculos { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataDevolucao { get; set; }
        //public ClienteDomain cliente { get; set; }
        //public VeiculosDomain veiculos { get; set; }
    }
}
