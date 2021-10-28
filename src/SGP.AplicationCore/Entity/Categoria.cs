using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGP.AplicationCore.Entity
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
