using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ITFinalProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        : base("ITFinalProjectDB")
        { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
        public DbSet<TipoDocumento> TipoDocumentoes { get; set; }





        public class MyDataContextDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                // preencher tabela formatos
                TipoCliente tipocliente = new TipoCliente() { TipoClienteID = 1, Descricao = "Particular" };
                TipoCliente tipocliente2 = new TipoCliente() { TipoClienteID = 2, Descricao = "Empresa" };

                TipoDocumento tipodocumento = new TipoDocumento() { TipoDocumentoID = 1, Descricao = "Cartão do Cidadão" };
                TipoDocumento tipodocumento2 = new TipoDocumento() { TipoDocumentoID = 2, Descricao = "Bilhete de Identidade" };
                TipoDocumento tipodocumento3 = new TipoDocumento() { TipoDocumentoID = 3, Descricao = "Passaporte" };

                Cliente cliente = new Cliente() { Nome = "Marisa", Telemovel = "911111111", NumeroIdentificacao = "11877092", NIF = 666666666, NumeroCliente = 12345, TipoDocumento = tipodocumento, TipoCliente = tipocliente, Morada = "Rua da Marisa", Nacionalidade = "Portuguesa", Email = "emaildamarisa@marisa.pt", Balcao = "Miranda do Douro", Contrato = true, DataNascimento = System.DateTime.Now, ClienteImage = "21.jpg" };
                Cliente cliente2 = new Cliente() { Nome = "Claudia", Telemovel = "912222222", NumeroIdentificacao = "12345653", NIF = 555555555, NumeroCliente = 1325, TipoDocumento = tipodocumento2, TipoCliente = tipocliente2, Morada = "Rua da Claudia", Nacionalidade = "Portuguesa", Email = "emaildaclaudia@claudia.pt", Balcao = "Bragança", Contrato = false, DataNascimento = System.DateTime.Now, ClienteImage = "68.jpg" };
                Cliente cliente3 = new Cliente() { Nome = "Daniel", Telemovel = "933333333", NumeroIdentificacao = "4455332211", NIF = 444444444, NumeroCliente = 1325123, TipoDocumento = tipodocumento3, TipoCliente = tipocliente, Morada = "Rua do Daniel", Nacionalidade = "Portuguesa", Email = "emaildodaniel@daniel.pt", Balcao = "Bragança", Contrato = true, DataNascimento = System.DateTime.Now, ClienteImage = "32.jpg" };
                Cliente cliente4 = new Cliente() { Nome = "Miguel", Telemovel = "944444444", NumeroIdentificacao = "41235653", NIF = 333333333, NumeroCliente = 13, TipoDocumento = tipodocumento, TipoCliente = tipocliente2, Morada = "Rua do Miguel", Nacionalidade = "Portuguesa", Email = "emaildomiguel@miguel.pt", Balcao = "Vila Real", Contrato = false, DataNascimento = System.DateTime.Now, ClienteImage = "43.jpg" };
                Cliente cliente5 = new Cliente() { Nome = "Daniel Gomes", Telemovel = "955555555", NumeroIdentificacao = "987123546", NIF = 222222222, NumeroCliente = 133, TipoDocumento = tipodocumento2, TipoCliente = tipocliente, Morada = "Rua do Gomes", Nacionalidade = "Portuguesa", Email = "emaildogomes@gomes.pt", Balcao = "Bragança", Contrato = false, DataNascimento = System.DateTime.Now, ClienteImage = "gaurav.JPG" };
                Cliente cliente6 = new Cliente() { Nome = "Joel", Telemovel = "966666666", NumeroIdentificacao = "67523456", NIF = 111111111, NumeroCliente = 13278, TipoDocumento = tipodocumento3, TipoCliente = tipocliente2, Morada = "Rua do Joel", Nacionalidade = "Portuguesa", Email = "emaildojoel@joel.pt", Balcao = "Bragança", Contrato = false, DataNascimento = System.DateTime.Now, ClienteImage = "photo-1507003211169-0a1dd7228f2d.jpg" };

                Conta conta = new Conta() { NumeroConta = 123456789, IBAN = "PT12365478925656", Saldo = 120, DataCriacao = System.DateTime.Now, ClienteID = cliente };
                Conta conta2 = new Conta() { NumeroConta = 1563784624, IBAN = "PT5098746523145", Saldo = 1000, DataCriacao = System.DateTime.Now, ClienteID = cliente2 };
                Conta conta3 = new Conta() { NumeroConta = 987654328, IBAN = "PT508521479635", Saldo = 500, DataCriacao = System.DateTime.Now, ClienteID = cliente3 };
                Conta conta4 = new Conta() { NumeroConta = 1852147963, IBAN = "PT50998765432", Saldo = 50000, DataCriacao = System.DateTime.Now, ClienteID = cliente4 };
                Conta conta5 = new Conta() { NumeroConta = 654987321, IBAN = "PT509852136479", Saldo = 100, DataCriacao = System.DateTime.Now, ClienteID = cliente5 };
                Conta conta6 = new Conta() { NumeroConta = 654987322, IBAN = "PT508754796219", Saldo = 10005, DataCriacao = System.DateTime.Now, ClienteID = cliente6 };


                context.TipoClientes.Add(tipocliente);
                context.TipoClientes.Add(tipocliente2);
                context.TipoDocumentoes.Add(tipodocumento);
                context.TipoDocumentoes.Add(tipodocumento2);
                context.TipoDocumentoes.Add(tipodocumento3);
                context.Clientes.Add(cliente);
                context.Clientes.Add(cliente2);
                context.Clientes.Add(cliente3);
                context.Clientes.Add(cliente4);
                context.Clientes.Add(cliente5);
                context.Clientes.Add(cliente6);
                context.Contas.Add(conta);
                context.Contas.Add(conta2);
                context.Contas.Add(conta3);
                context.Contas.Add(conta4);
                context.Contas.Add(conta5);
                context.Contas.Add(conta6);
            }
        }
    }
}
