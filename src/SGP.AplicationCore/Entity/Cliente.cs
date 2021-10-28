using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGP.AplicationCore.Entity
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
