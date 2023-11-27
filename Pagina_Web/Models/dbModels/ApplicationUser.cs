using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Pagina_Web.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Carritos = new HashSet<Carrito>();
            Venta = new HashSet<Ventum>();
        }

        /*[Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }*/
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
        /*[Column("tel_usuario")]
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
        public int IdDir { get; set; }*/

        /*[ForeignKey("IdCargo")]
        [InverseProperty("Usuarios")]
        public virtual Cargo IdCargoNavigation { get; set; } = null!;*/
        [ForeignKey("IdDir")]
        [InverseProperty("Usuarios")]
        public virtual Direccion IdDirNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioCarritoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdUsuarioVentaNavigation")]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
