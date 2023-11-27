using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{   
    [Table("Marca_Producto")]
    public partial class MarcaProductoDTO
    {
        [Required]
        [Display(Name = "Identificador")]
        public int IdMarca { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Marca")]
        public string NombreMar { get; set; } = null!;
        [Required]
        [StringLength(255)]
        [Display(Name = "Descripcion")]
        public string DescripcionMar { get; set; } = null!;
    }
}
