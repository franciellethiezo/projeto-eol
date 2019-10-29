using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Anuncio
    {
        public Anuncio()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("idAnuncio")]
        public int IdAnuncio { get; set; }
        [Column("precoAnuncio", TypeName = "decimal(7, 2)")]
        public decimal PrecoAnuncio { get; set; }
        [Column("dt_finalAnuncio", TypeName = "date")]
        public DateTime DtFinalAnuncio { get; set; }
        [Required]
        [Column("fotoAnuncio")]
        [StringLength(100)]
        public string FotoAnuncio { get; set; }
        [Required]
        [Column("statusAnuncio")]
        public bool? StatusAnuncio { get; set; }
        [Column("FK_idProduto")]
        public int? FkIdProduto { get; set; }
        [Column("FK_idCondicao")]
        public int? FkIdCondicao { get; set; }

        [ForeignKey(nameof(FkIdCondicao))]
        [InverseProperty(nameof(Condicao.Anuncio))]
        public virtual Condicao FkIdCondicaoNavigation { get; set; }
        [ForeignKey(nameof(FkIdProduto))]
        [InverseProperty(nameof(Produto.Anuncio))]
        public virtual Produto FkIdProdutoNavigation { get; set; }
        [InverseProperty("FkIdAnuncioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
