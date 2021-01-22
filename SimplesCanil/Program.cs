using System;

namespace SimplesCanil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            InserirMassaDeDados();

            // var clientes = suporteDb.ListarClientes();
            // foreach (var item in clientes)
            // {
            //     Console.WriteLine($"{item.Id} {item.Nome} - {item.CPF}");
            // }

            var suporteDb = new SuporteDb();
            var resultado = suporteDb.ListarCaes();


        }

        private static void InserirMassaDeDados()
        {
            var suporteDb = new SuporteDb();
            
            var fulano = new Cliente("Fulano de tal", "12345678900", new DateTime(2000, 1, 1));
            var rex = new Cao("Rex", fulano.Id);
            
            var beltrano = new Cliente("Beltrano de alguma coisa", "32165498700", new DateTime(2000, 2, 2));
            var zezinho = new Cao("Zezinho", beltrano.Id);
            
            suporteDb.InserirUsuario(fulano);
            suporteDb.InserirCao(rex);
            
            suporteDb.InserirUsuario(beltrano);
            suporteDb.InserirCao(zezinho);

            var ze = new Cliente("Ze", "78945613200", new DateTime(1977, 1, 1));
            suporteDb.InserirUsuario(ze);
        }
    }
}