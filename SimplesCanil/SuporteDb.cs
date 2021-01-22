using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Insight.Database;

namespace SimplesCanil
{
    public class SuporteDb
    {
        private readonly string _stringDeConexao;
        private readonly SqlConnection _conexao;

        public SuporteDb()
        {
            SqlInsightDbProvider.RegisterProvider();

            //_stringDeConexao = "Server=localhost, 1433;Database=CanilDB;Trusted_Connection=True;";
            _stringDeConexao = "Server=localhost, 1433;Database=CanilDB;User Id=sa;Password=!123Senha;";
            _conexao = new SqlConnection(_stringDeConexao);
        }

        public void InserirUsuario(Cliente cliente)
        {
            var query =
                "INSERT INTO TB_Clientes (Id, Nome, DataNascimento, CPF) values (@id, @nome, @dataNascimento, @cpf)";

            using var conexao = new SqlConnection(_stringDeConexao);
            using var command = new SqlCommand(query, conexao);

            conexao.Open();

            command.Parameters.AddWithValue("@id", cliente.Id);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
            command.Parameters.AddWithValue("@cpf", cliente.CPF);

            command.ExecuteNonQuery();
        }

        public void InserirCao(Cao cao)
        {
            var query =
                "INSERT INTO TB_Caes (Id, Nome, clienteId) values (@id, @nome, @clienteId)";

            using var conexao = new SqlConnection(_stringDeConexao);
            using var command = new SqlCommand(query, conexao);

            conexao.Open();

            command.Parameters.AddWithValue("@id", cao.Id);
            command.Parameters.AddWithValue("@nome", cao.Nome);
            command.Parameters.AddWithValue("@clienteId", cao.ClienteId);

            command.ExecuteNonQuery();
        }

        public List<Cliente> ListarClientes()
        {
            return _conexao.QuerySql<Cliente>("SELECT * FROM TB_Clientes")
                .ToList();
        }
        
        public List<Cao> ListarCaes()
        {
            var query = @"
    select * from TB_Caes AS Cao
    select * from TB_Clientes where Id in (select ClienteId from TB_Caes)
";

            var resultado = _conexao.QueryResultsSql<Cao, Cliente>(query);
            foreach (var cao in resultado.Set1)
                cao.Cliente = resultado.Set2.First(x => x.Id == cao.ClienteId);

            return resultado.Set1.ToList();
        }
    }
}