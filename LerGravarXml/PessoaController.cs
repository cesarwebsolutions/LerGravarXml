using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerGravarXml
{
    class PessoaController
    {
        Conexao conexao = new Conexao();

        public List<Pessoa> Listar()
        {
            List<Pessoa> listarPessoas = new List<Pessoa>();
            try
            {
                string SQL = "select * from Cliente";

                SqlCommand cmdSql = new SqlCommand(SQL, conexao.Conectar());
                SqlDataReader dataReader = cmdSql.ExecuteReader();

                while (dataReader.Read())
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.ID = Convert.ToInt32(dataReader["ID"]);
                    pessoa.NOME = Convert.ToString(dataReader["NOME"]);
                    pessoa.ENDERECO = Convert.ToString(dataReader["ENDERECO"]);
                    pessoa.EMAIL = Convert.ToString(dataReader["EMAIL"]);
                    pessoa.CPF = Convert.ToString(dataReader["CPF"]);

                    listarPessoas.Add(pessoa);

                }
                return listarPessoas;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
