using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITFinalProject.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required()]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Data de Nascimento: ")]
        public DateTime DataNascimento { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Documento de Identificação: ")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required()]
        [Display(Name = "Numero de Identificação: ")]
        public string NumeroIdentificacao { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "NIF: ")]
        public int NIF { get; set; }
        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Numero de Cliente: ")]
        public int NumeroCliente { get; set; }

        [Required()]
        [Display(Name = "Tipo de Cliente: ")]
        public virtual TipoCliente TipoCliente { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Morada: ")]
        [DataType(DataType.MultilineText)]
        public string Morada { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Nacionalidade: ")]
        public string Nacionalidade { get; set; }


        [Display(Name = "Telemóvel: ")]
        [DisplayFormat(NullDisplayText = "-")]
        public string Telemovel { get; set; }

        [Display(Name = "Email: ")]
        [DisplayFormat(NullDisplayText = "-")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required()]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Balcão: ")]
        public string Balcao { get; set; }

        [Display(Name = "Contrato?: ")]
        [DisplayFormat(NullDisplayText = "-")]
        public bool Contrato { get; set; }

        [DisplayFormat(NullDisplayText = "default.jpg")]
        public string ClienteImage { get; set; }





    }

    //public class ClienteViewModel
    //{
    //    public int ClienteID { get; set; }

    //    [Required()]
    //    [Display(Name = "Nome: ")]
    //    public string Nome { get; set; }

    //    [Required()]
    //    [Display(Name = "Data de Nascimento: ")]
    //    public DateTime DataNascimento { get; set; }

    //    [Required()]
    //    [Display(Name = "Documento de Identificação: ")]
    //    public virtual List<TipoDocumento> ListaTipoDocumento { get; set; }

    //    [Required()]
    //    [Display(Name = "Numero de Identificação: ")]
    //    public string NumeroIdentificacao { get; set; }

    //    [Required()]
    //    [Display(Name = "NIF: ")]
    //    public int NIF { get; set; }
    //    [Required()]
    //    [Display(Name = "Numero de Cliente: ")]
    //    public int NumeroCliente { get; set; }

    //    [Required()]
    //    [Display(Name = "Tipo de Cliente: ")]
    //    public virtual List<TipoCliente> ListaTipoCliente { get; set; }

    //    [Required()]
    //    [Display(Name = "Morada: ")]
    //    [DataType(DataType.MultilineText)]
    //    public string Morada { get; set; }

    //    [Required()]
    //    [Display(Name = "Nacionalidade: ")]
    //    public string Nacionalidade { get; set; }


    //    [Display(Name = "Telemóvel: ")]
    //    public string Telemovel { get; set; }

    //    [Display(Name = "Email: ")]
    //    [DataType(DataType.EmailAddress)]
    //    public string Email { get; set; }

    //    [Required()]
    //    [Display(Name = "Balcão: ")]
    //    public string Balcao { get; set; }

    //    [Display(Name = "Contrato?: ")]
    //    public bool Contrato { get; set; }
    //}
}