using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Interesse = new HashSet<Interesse>();
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("nomeUsuario")]
        [StringLength(50)]
        public string NomeUsuario { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("telefoneUsuario")]
        [StringLength(14)]
        public string TelefoneUsuario { get; set; }
        [Column("FK_idTipoUsuario")]
        public int? FkIdTipoUsuario { get; set; }

        [ForeignKey(nameof(FkIdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Usuario))]
        public virtual TipoUsuario FkIdTipoUsuarioNavigation { get; set; }
        [InverseProperty("FkIdUsuarioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
        [InverseProperty("FkIdUsuarioNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
