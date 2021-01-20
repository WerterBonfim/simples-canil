using System;

namespace SimplesCanil
{
    public class Cao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ClienteId { get; set; }

        public Cao()
        {
        }

        public Cao(string nome, Guid clienteId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            ClienteId = clienteId;
        }

        
    }
}