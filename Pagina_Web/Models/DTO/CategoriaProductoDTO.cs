using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{
    [Table("Categoria_Producto")]
    public partial class CategoriaProductoDTO
    {
        [Key]
        [Column("id_cat")]
        public int IdCat { get; set; }
        [Column("nombre_cat")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreCat { get; set; } = null!;
        [Column("descripcion_cat")]
        [StringLength(255)]
        [Unicode(false)]
        public string DescripcionCat { get; set; } = null!;
    }
}
