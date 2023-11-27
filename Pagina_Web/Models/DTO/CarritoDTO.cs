using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.DTO
{
    [Table("Carrito")]
    public partial class CarritoDTO
    {
        [Key]
        [Column("id_usuario_carrito")]
        public int IdUsuarioCarrito { get; set; }
        [Key]
        [Column("id_prod_carrito")]
        public int IdProdCarrito { get; set; }
        [Column("cantidad_carrito")]
        public int? CantidadCarrito { get; set; }

        [ForeignKey("IdProdCarrito")]
        [InverseProperty("Carritos")]
        public virtual ProductoDTO IdProdCarritoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuarioCarrito")]
        [InverseProperty("Carritos")]
        public virtual ApplicationUserDTO IdUsuarioCarritoNavigation { get; set; } = null!;
    }
}
