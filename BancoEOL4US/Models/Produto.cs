using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Anuncio = new HashSet<Anuncio>();
        }

        [Key]
        [Column("idProduto")]
        public int IdProduto { get; set; }
        [Required]
        [Column("nomeProduto")]
        [StringLength(50)]
        public string NomeProduto { get; set; }
        [Required]
        [Column("fabricanteProduto")]
        [StringLength(50)]
        public string FabricanteProduto { get; set; }
        [Column("dt_lancProduto", TypeName = "date")]
        public DateTime DtLancProduto { get; set; }
        [Required]
        [Column("descricaoProduto", TypeName = "text")]
        public string DescricaoProduto { get; set; }
        [Column("FK_idCategoria")]
        public int? FkIdCategoria { get; set; }
        [Column("FK_idUsuario")]
        public int? FkIdUsuario { get; set; }

        [ForeignKey(nameof(FkIdCategoria))]
        [InverseProperty(nameof(Categoria.Produto))]
        public virtual Categoria FkIdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(FkIdUsuario))]
        [InverseProperty(nameof(Usuario.Produto))]
        public virtual Usuario FkIdUsuarioNavigation { get; set; }
        [InverseProperty("FkIdProdutoNavigation")]
        public virtual ICollection<Anuncio> Anuncio { get; set; }
    }
}
