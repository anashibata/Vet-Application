using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Argus.Models
{
    public class Porte
    {
        [Key]
        public int CODIGO { get; set; }
        public string NOME { get; set; }
    }
}