using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClinteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizaridCorpo(ClienteDomain clienteAtt)
        {
            if (clienteAtt.idCliente > 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @Nome, Sobrenome = @Sobrenome, CNH = @CNH WHERE idCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", clienteAtt.Nome);
                        cmd.Parameters.AddWithValue("@Sobrenome", clienteAtt.Sobrenome);
                        cmd.Parameters.AddWithValue("@CNH", clienteAtt.CNH);
                        cmd.Parameters.AddWithValue("@idCliente", clienteAtt.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }

        public void AtualizaridUrl(int idCliente, ClienteDomain clienteAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @Nome, Sobrenome = @Sobrenome, CNH = @CNH WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", clienteAtt.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", clienteAtt.Sobrenome);
                    cmd.Parameters.AddWithValue("@CNH", clienteAtt.CNH);
                    cmd.Parameters.AddWithValue("@idCliente", clienteAtt.idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, Sobrenome, CNH FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain ClienteBusca = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr[0]),

                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            CNH = rdr[3].ToString(),

                        };

                        return ClienteBusca;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente, Sobrenome, CNH) VALUES (@Nome ,@Sobrenome, @CNH)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoCliente.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoCliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@CNH", novoCliente.CNH);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeCliente, Sobrenome, CNH FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            Nome = rdr[0].ToString(),
                            Sobrenome = rdr[1].ToString(),
                            CNH = rdr[2].ToString(),
                        };
                        listaCliente.Add(cliente);
                    }
                }
            }

            return listaCliente;
        }
    }
}
