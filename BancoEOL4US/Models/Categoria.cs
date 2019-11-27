using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("marcaCategoria")]
        [StringLength(25)]
        public string MarcaCategoria { get; set; }

        [InverseProperty("FkIdCategoriaNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
