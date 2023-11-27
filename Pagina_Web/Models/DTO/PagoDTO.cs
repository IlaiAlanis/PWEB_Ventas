using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pagina_Web.Models.DTO;

namespace Pagina_Web.Models.DTO
{

    public partial class PagoDTO
    {
        [Key]
        [Column("id_pagos")]
        public int IdPagos { get; set; }
        [Column("metodosPago_pagos")]
        [StringLength(50)]
        [Unicode(false)]
        public string? MetodosPagoPagos { get; set; }
        [Column("descripcion_pagos")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DescripcionPagos { get; set; }
    }
}
