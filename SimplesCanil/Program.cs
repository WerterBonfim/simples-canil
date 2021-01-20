using System;

namespace SimplesCanil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var cliente = new Cliente("Fulano de tal", "12345678900", new DateTime(2000, 1,1));
            var cao = new Cao("Rex", cliente.Id);

            var suporteDb = new SuporteDb();
            
            suporteDb.InserirUsuario(cliente);
            suporteDb.InserirCao(cao);
            

        }
    }
}