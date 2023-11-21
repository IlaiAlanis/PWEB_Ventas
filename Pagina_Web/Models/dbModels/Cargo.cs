using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Cargo")]
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("id_cargo")]
        public int IdCargo { get; set; }
        [Column("nombre_cargo")]
        [StringLength(15)]
        [Unicode(false)]
        public string NombreCargo { get; set; } = null!;
        [Column("descripcion_cargo")]
        [StringLength(100)]
        [Unicode(false)]
        public string DescripcionCargo { get; set; } = null!;

        [InverseProperty("IdCargoNavigation")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
