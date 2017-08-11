using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository
    {
        /***
         *  Método para persistir a Nota Fisca na Base de Dados
         *  
         *  ***/
        public void Incluir(NotaFiscal notaFiscal)
        {
            
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", con);
                    cmd.Parameters.AddWithValue("@pId", notaFiscal.Id).Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.AddWithValue("@pNumeroNotaFiscal", notaFiscal.NumeroNotaFiscal);
                    cmd.Parameters.AddWithValue("@pSerie", notaFiscal.Serie);
                    cmd.Parameters.AddWithValue("@pNomeCliente", notaFiscal.NomeCliente);
                    cmd.Parameters.AddWithValue("@pEstadoDestino", notaFiscal.EstadoDestino);
                    cmd.Parameters.AddWithValue("@pEstadoOrigem", notaFiscal.EstadoOrigem);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    int i = cmd.ExecuteNonQuery();
                    notaFiscal.Id = (int)cmd.Parameters["@pId"].Value;

                    foreach (var item in notaFiscal.ItensDaNotaFiscal)
                    {
                        cmd = new SqlCommand("P_NOTA_FISCAL_ITEM", con);
                        cmd.Parameters.AddWithValue("@pId", item.Id).Value = 0;
                        cmd.Parameters.AddWithValue("@pIdNotaFiscal", notaFiscal.Id);
                        cmd.Parameters.AddWithValue("@pCfop", item.Cfop);
                        cmd.Parameters.AddWithValue("@pTipoIcms", item.TipoIcms);
                        cmd.Parameters.AddWithValue("@pBaseIcms", item.BaseIcms);
                        cmd.Parameters.AddWithValue("@pAliquotaIcms", item.AliquotaIcms);
                        cmd.Parameters.AddWithValue("@pValorIcms", item.ValorIcms);
                        // Ipi
                        cmd.Parameters.AddWithValue("@pBaseIpi", item.BaseIpi);
                        cmd.Parameters.AddWithValue("@pAliquotaIpi", item.AliquotaIpi);
                        cmd.Parameters.AddWithValue("@pValorIpi", item.ValorIpi);

                        // Desconto
                        cmd.Parameters.AddWithValue("@pDesconto", item.Desconto);

                        cmd.Parameters.AddWithValue("@pNomeProduto", item.NomeProduto);
                        cmd.Parameters.AddWithValue("@pCodigoProduto", item.CodigoProduto);
                        cmd.CommandType = CommandType.StoredProcedure;

                        i = cmd.ExecuteNonQuery();
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /***
         * 
         *  Método para pesquisa do Cfop
         *  
         *  ***/
        public string Cfop(string estadoOrigem, string estadoDestino)
        {
            string cfop = string.Empty;
            String sql = @"SELECT cfop from cfop where EstadoOrigem = @estadoOrigem and EstadoDestino = @estadoDestino";

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@estadoOrigem", estadoOrigem);
                    cmd.Parameters.AddWithValue("@estadoDestino", estadoDestino);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cfop = dr["cfop"].ToString();
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cfop;
        }
    }
}
