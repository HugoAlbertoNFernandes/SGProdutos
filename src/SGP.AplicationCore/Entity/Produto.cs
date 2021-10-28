using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGP.AplicationCore.Entity
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        public Categoria Categorias { get; set; }
        public int CategoriaID { get; set; }
    }
}
