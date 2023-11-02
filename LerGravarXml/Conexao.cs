using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerGravarXml
{
    class Conexao
    {
        string conString = "Server=DESKTOP-TDEFNQP\\SQLEXPRESS;Database=CrudCliente;Trusted_Connection=True;";
        SqlConnection sqlCon = new SqlConnection();

        public SqlConnection Conectar()
        {
            try
            {
                sqlCon.ConnectionString = conString;
                sqlCon.Open();
            }
            catch (SqlException erro)
            {
                System.Windows.Forms.MessageBox.Show("ocorreu um erro ao conectar");
            }
            return sqlCon;
        }

        public void Desconectar()
        {
            try
            {
                sqlCon.Close();
            }
            catch (SqlException erro)
            {
                System.Windows.Forms.MessageBox.Show("ocorreu um erro ao encerrar a conexao");
            }
        }
    }
}
