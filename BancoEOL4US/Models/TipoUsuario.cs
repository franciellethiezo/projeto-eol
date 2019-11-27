using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEOL4US.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column("idTipoUsuario")]
        public int IdTipoUsuario { get; set; }
        [Column("permissaoTU")]
        public bool PermissaoTu { get; set; }

        [InverseProperty("FkIdTipoUsuarioNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
