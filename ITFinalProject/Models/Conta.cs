using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITFinalProject.Models
{
    public class Conta
    {
        [Key]
        public int ContaID { get; set; }

        [Display(Name = "Data de Criação: ")]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        [Required()]
        [Display(Name = "Numero de Conta: ")]
        public int NumeroConta { get; set; }

        [Required()]
        [Display(Name = "IBAN: ")]
        public string IBAN { get; set; }

        //[Required()]
        [Display(Name = "Saldo: ")]
        public decimal Saldo { get; set; }

        //[Required()]
        [Display(Name = "Cliente: ")]
        public virtual Cliente ClienteID { get; set; }
    }

    public class ContaViewModel
    {
        [Key]
        public int ContaID { get; set; }

        [Display(Name = "Data de Criação: ")]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        [Required()]
        [Display(Name = "Numero de Conta: ")]
        public int NumeroConta { get; set; }

        [Required()]
        [Display(Name = "IBAN: ")]
        public string IBAN { get; set; }

        [Required()]
        [Display(Name = "Saldo: ")]
        public decimal Saldo { get; set; }

        [Required()]
        [Display(Name = "Cliente: ")]
        public virtual List<Cliente> ListaCliente { get; set; }

    }

}