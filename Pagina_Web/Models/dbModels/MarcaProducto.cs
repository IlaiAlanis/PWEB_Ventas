﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Marca_Producto")]
    public partial class MarcaProducto
    {
        [Key]
        [Column("id_marca")]
        public int IdMarca { get; set; }
        [Column("nombre_mar")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreMar { get; set; } = null!;
        [Column("descripcion_mar")]
        [StringLength(255)]
        [Unicode(false)]
        public string DescripcionMar { get; set; } = null!;
    }
}