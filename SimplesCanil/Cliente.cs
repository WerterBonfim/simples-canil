using System;

namespace SimplesCanil
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(string nome, string cpf, DateTime data)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataNascimento = data;
        }
    }
}