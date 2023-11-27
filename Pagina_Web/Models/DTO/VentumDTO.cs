using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{
    public partial class VentumDTO
    {
        [Required]
        [Display(Name = "Imagen")]
        public DateTime FechaVenta { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public TimeSpan HoraVenta { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public int IdPagos { get; set; }
    }
}
