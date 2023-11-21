using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Municipio")]
    public partial class Municipio
    {
        public Municipio()
        {
            Direccions = new HashSet<Direccion>();
        }

        [Key]
        [Column("id_municipio")]
        public int IdMunicipio { get; set; }
        [Column("nombre_municipio")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreMunicipio { get; set; } = null!;
        [Column("id_estado")]
        public int? IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        [InverseProperty("Municipios")]
        public virtual Estado? IdEstadoNavigation { get; set; }
        [InverseProperty("IdMunUsuarioNavigation")]
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
