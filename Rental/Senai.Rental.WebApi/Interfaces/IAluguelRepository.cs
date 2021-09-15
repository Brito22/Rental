using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();
        AluguelDomain BuscarPorId(int id);
        void Cadastrar(AluguelDomain novoAluguel);
        void AtualizaridCorpo(AluguelDomain aluguelAtt);
        void AtualizaridUrl(int idAluguel, AluguelDomain aluguelAtt);
        void Deletar(int idAluguel);
    }
}
