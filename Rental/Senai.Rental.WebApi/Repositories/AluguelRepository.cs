using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizaridCorpo(AluguelDomain aluguelAtt)
        {
            if (aluguelAtt.idVeiculos > 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE ALUGUEL SET idVeiculos = @idVeiculo WHERE idAluguel = @idAluguel";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtt.idVeiculos);
                        cmd.Parameters.AddWithValue("@idAluguel", aluguelAtt.idAluguel);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizaridUrl(int idAluguel, AluguelDomain aluguelAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET idVeiculos = @idVeiculo WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtt.idVeiculos);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, idVeiculos, idCliente, DataEmissão, DataDevolussao FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain AluguelBusca = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            idVeiculos = Convert.ToInt32(rdr[1]),
                            idCliente = Convert.ToInt32(rdr[2]),
                            DataEmissao = Convert.ToDateTime(rdr[3]),
                            DataDevolucao= Convert.ToDateTime(rdr[4]),
                        };

                        return AluguelBusca;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCliente, idVeiculos, DataEmissão, DataDevolussao) VALUES (@idCliente ,@idVeiculo, @DataEmissao, @DataDevolussao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculos);
                    cmd.Parameters.AddWithValue("@DataEmissao", novoAluguel.DataEmissao);
                    cmd.Parameters.AddWithValue("@DataDevolussao", novoAluguel.DataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Deletar(int idAluguel)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";
                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                        con.Open();
  
                        cmd.ExecuteNonQuery();
                    }
                }
            }
         public List<AluguelDomain> ListarTodos()
            {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, idCliente, IdVeiculos, DataEmissão, DataDevolussao FROM ALUGUEL";
              
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculos = Convert.ToInt32(rdr[2]),

                            DataEmissao = Convert.ToDateTime(rdr[3]),
                            DataDevolucao = Convert.ToDateTime(rdr[4])
                        };
                        listaAluguel.Add(aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }            
}
