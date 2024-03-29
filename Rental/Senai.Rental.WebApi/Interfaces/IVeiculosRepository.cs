﻿using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculosRepository
    {
        List<VeiculosDomain> ListarTodos();
        VeiculosDomain BuscarPorId(int id);
        void Cadastrar(VeiculosDomain novoVeiculo);
        void AtualizaridCorpo(VeiculosDomain veiculoAtt);
        void AtualizaridUrl(int idVeiculo, VeiculosDomain veiculoAtt);
        void Deletar(int idVeiculo);
    }
}
