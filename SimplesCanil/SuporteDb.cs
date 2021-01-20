using System.Data.SqlClient;

namespace SimplesCanil
{
    public class SuporteDb
    {
        private readonly string _stringDeConexao;

        public SuporteDb()
        {
            //_stringDeConexao = "Server=localhost, 1433;Database=CanilDB;Trusted_Connection=True;";
            _stringDeConexao = "Server=localhost, 1433;Database=CanilDB;User Id=sa;Password=!123Senha;";
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
    }
}