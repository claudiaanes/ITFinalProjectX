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

                Cliente cliente = new Cliente() { Nome = "Marisa", NumeroIdentificacao = "11877092", NumeroCliente = 12345, TipoDocumento = tipodocumento, TipoCliente = tipocliente, DataNascimento = System.DateTime.Now };
                Cliente cliente2 = new Cliente() { Nome = "Claudia", NumeroIdentificacao = "12345653", NumeroCliente = 1325, TipoDocumento = tipodocumento2, TipoCliente = tipocliente2, DataNascimento = System.DateTime.Now };
                Cliente cliente3 = new Cliente() { Nome = "Daniel", NumeroIdentificacao = "4455332211", NumeroCliente = 1325123, TipoDocumento = tipodocumento3, TipoCliente = tipocliente, DataNascimento = System.DateTime.Now };
                Cliente cliente4 = new Cliente() { Nome = "Miguel", NumeroIdentificacao = "41235653", NumeroCliente = 13, TipoDocumento = tipodocumento, TipoCliente = tipocliente2, DataNascimento = System.DateTime.Now };
                Cliente cliente5 = new Cliente() { Nome = "Daniel Gomes", NumeroIdentificacao = "987123546", NumeroCliente = 133, TipoDocumento = tipodocumento2, TipoCliente = tipocliente, DataNascimento = System.DateTime.Now };
                Cliente cliente6 = new Cliente() { Nome = "Joel", NumeroIdentificacao = "67523456", NumeroCliente = 13278, TipoDocumento = tipodocumento3, TipoCliente = tipocliente2, DataNascimento = System.DateTime.Now };

                Conta conta = new Conta() { NumeroConta = 123456789, IBAN = "PT12365478925656", DataCriacao = System.DateTime.Now , ClienteID = cliente};
                Conta conta2 = new Conta() { NumeroConta = 1563784624, IBAN = "PT5098746523145", DataCriacao = System.DateTime.Now, ClienteID = cliente2 };

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
            }
        }
    }
}
