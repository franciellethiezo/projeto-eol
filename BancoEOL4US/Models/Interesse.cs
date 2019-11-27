using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Interesse
    {
        [Key]
        [Column("idInteresse")]
        public int IdInteresse { get; set; }
        [Column("dataInteresse", TypeName = "date")]
        public DateTime DataInteresse { get; set; }
        [Column("FK_idUsuario")]
        public int? FkIdUsuario { get; set; }
        [Column("FK_idAnuncio")]
        public int? FkIdAnuncio { get; set; }

        [ForeignKey(nameof(FkIdAnuncio))]
        [InverseProperty(nameof(Anuncio.Interesse))]
        public virtual Anuncio FkIdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(FkIdUsuario))]
        [InverseProperty(nameof(Usuario.Interesse))]
        public virtual Usuario FkIdUsuarioNavigation { get; set; }
    }
}
