using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Direccion")]
    public partial class Direccion
    {
        public Direccion()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("id_dir")]
        public int IdDir { get; set; }
        [Column("num_ext_usuario")]
        [StringLength(15)]
        [Unicode(false)]
        public string NumExtUsuario { get; set; } = null!;
        [Column("id_est_usuario")]
        public int IdEstUsuario { get; set; }
        [Column("id_mun_usuario")]
        public int IdMunUsuario { get; set; }

        [ForeignKey("IdEstUsuario")]
        [InverseProperty("Direccions")]
        public virtual Estado IdEstUsuarioNavigation { get; set; } = null!;
        [ForeignKey("IdMunUsuario")]
        [InverseProperty("Direccions")]
        public virtual Municipio IdMunUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdDirNavigation")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
