﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Direccions = new HashSet<Direccion>();
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Column("id_estado")]
        public int IdEstado { get; set; }
        [Column("nombre_estado")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreEstado { get; set; } = null!;

        [InverseProperty("IdEstUsuarioNavigation")]
        public virtual ICollection<Direccion> Direccions { get; set; }
        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
