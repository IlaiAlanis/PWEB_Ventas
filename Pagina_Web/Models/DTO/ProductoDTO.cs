using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{
    public partial class ProductoDTO
    {

        [Required]
        [Display(Name = "ID")]
        public int IdProd { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int IdCatProd { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = null!;
        [Required]
        [StringLength(100)]
        [Display(Name = "Imagen")]
        public string Sku { get; set; } = null!;
        [Required]
        [Display(Name = "Imagen")]
        public decimal CostoProd { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public decimal ExistenciaProd { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public int DescuentoProd { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public decimal PrecioProd { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Imagen")]
        public string DescripcionProd { get; set; } = null!;
    }
}
