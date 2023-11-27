using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using MessagePack;

namespace Pagina_Web.Models.DTO
{
    [Table("Producto")]
    public partial class ProductoCreateDTO
    {
        [Required]
        [Display(Name = "ID")]
        public int IdProd { get; set; }
        [Required]
        [Display(Name = "Categoria")] 
        public int IdCatProd { get; set; }
        [Required]
        [Display(Name = "Marca")] 
        public int IdMarcProd { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = null!;
        public IFormFile? ImagenArchivo { get; set; }   
        [Required]
        [StringLength(100)]
        [Display(Name = "SKU")]
        public string Sku { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Costo")]
        public decimal CostoProd { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Existencia")]
        public decimal ExistenciaProd { get; set; }
        [Required]
        [Display(Name = "Descuento")]
        public int DescuentoProd { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Precio")]
        public decimal PrecioProd { get; set; }
        [Required]
        [StringLength(100)]
        [Column("Descripcion")]
        public string DescripcionProd { get; set; } = null!;

        [JsonIgnore]
        [IgnoreMember]
        [IgnoreDataMember]
        public SelectList? Categorias { get; set; }
        public SelectList? Marcas { get; set; }
    }
}
