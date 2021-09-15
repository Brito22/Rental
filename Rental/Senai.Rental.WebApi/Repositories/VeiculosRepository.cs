using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizaridCorpo(VeiculosDomain veiculoAtt)
        {
            if (veiculoAtt.idModelo > 0 || veiculoAtt.Placa != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE VEICULOS SET idModelo = @idModelo, Placa = @Placa WHERE idVeiculos = @idVeiculo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtt.idVeiculos);
                        cmd.Parameters.AddWithValue("@idModelo", veiculoAtt.idModelo);
                        cmd.Parameters.AddWithValue("@Placa", veiculoAtt.Placa);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizaridUrl(int idVeiculo, VeiculosDomain veiculoAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE VEICULOS SET idModelo = @idModelo, Placa = @Placa WHERE idVeiculos = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtt.idModelo);
                    cmd.Parameters.AddWithValue("@Placa", veiculoAtt.Placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculos,idModelo, Placa FROM VEICULOS WHERE idVeiculos = @idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculosDomain VeiculoBusca = new VeiculosDomain
                        {
                            idVeiculos = Convert.ToInt32(rdr[0]),
                            idModelo = Convert.ToInt32(rdr[1]),
                            Placa = rdr[2].ToString()
                        };

                        return VeiculoBusca;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculosDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULOS (idModelo, Placa) VALUES (@idModelo ,@Placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@Placa", novoVeiculo.Placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULOS WHERE idVeiculos = @idVeiculos";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculos", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculosDomain> ListarTodos()
        {
            List<VeiculosDomain> listaVeiculos = new List<VeiculosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculos, idModelo, Placa FROM VEICULOS ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VeiculosDomain veiculos = new VeiculosDomain()
                        {
                            idVeiculos = Convert.ToInt32(rdr[0]),
                            idModelo = Convert.ToInt32(rdr[1]),
                            Placa = rdr[2].ToString()

                        };
                        listaVeiculos.Add(veiculos);
                    }
                }
            }

            return listaVeiculos;
        }
    }
    
}
