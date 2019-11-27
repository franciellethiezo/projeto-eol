using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Condicao
    {
        public Condicao()
        {
            Anuncio = new HashSet<Anuncio>();
        }

        [Key]
        [Column("idCondicao")]
        public int IdCondicao { get; set; }
        [Required]
        [Column("avaliacaoCondicao")]
        [StringLength(6)]
        public string AvaliacaoCondicao { get; set; }

        [InverseProperty("FkIdCondicaoNavigation")]
        public virtual ICollection<Anuncio> Anuncio { get; set; }
    }
}
