using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nombre_usuario")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreUsuario { get; set; } = null!;
        [Column("apellido_usuario")]
        [StringLength(60)]
        [Unicode(false)]
        public string ApellidoUsuario { get; set; } = null!;
        [Column("userfecha_nac_usuario", TypeName = "date")]
        public DateTime UserfechaNacUsuario { get; set; }
        [Column("tel_usuario")]
        [StringLength(15)]
        [Unicode(false)]
        public string? TelUsuario { get; set; }
        [Column("correo_usuario")]
        [StringLength(40)]
        [Unicode(false)]
        public string CorreoUsuario { get; set; } = null!;
        [Column("usuario_usario")]
        [StringLength(40)]
        [Unicode(false)]
        public string UsuarioUsario { get; set; } = null!;
        [Column("contraseña_usuario")]
        [StringLength(20)]
        [Unicode(false)]
        public string ContraseñaUsuario { get; set; } = null!;
        [Column("id_cargo")]
        public int IdCargo { get; set; }
        [Column("id_dir")]
        public int IdDir { get; set; }

        [ForeignKey("IdCargo")]
        [InverseProperty("Usuarios")]
        public virtual Cargo IdCargoNavigation { get; set; } = null!;
        [ForeignKey("IdDir")]
        [InverseProperty("Usuarios")]
        public virtual Direccion IdDirNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioVentaNavigation")]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
