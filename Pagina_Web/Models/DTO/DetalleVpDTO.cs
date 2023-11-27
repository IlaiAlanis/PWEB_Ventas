using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{
    [Table("DetalleVP")]
    public partial class DetalleVpDTO
    {
        [Required]
        [Display(Name = "Venta")]
        public int IdVentaDvp { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public int IdProductoDvp { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Venta")]
        public decimal PrecioDvp { get; set; }
        [Required]
        [Display(Name = "Total")]
        public int CantidadDvp { get; set; }
    }
}
