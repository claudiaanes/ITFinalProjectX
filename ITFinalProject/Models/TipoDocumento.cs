using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITFinalProject.Models
{
    public class TipoDocumento
    {
        public int TipoDocumentoID { get; set; }

        [Required()]
        [Display(Name = "Descrição: ")]
        public string Descricao { get; set; }

    }
}