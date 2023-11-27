using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Web.Models.dbModels
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            DetalleVps = new HashSet<DetalleVp>();
        }

        [Key]
        [Column("id_prod")]
        public int IdProd { get; set; }
        [Column("id_cat_prod")]
        public int IdCatProd { get; set; }
        [Column("imagen")]
        [StringLength(200)]
        [Unicode(false)]
        public string Imagen { get; set; } = null!;
        [Column("sku")]
        [StringLength(100)]
        [Unicode(false)]
        public string Sku { get; set; } = null!;
        [Column("costo_prod", TypeName = "decimal(10, 2)")]
        public decimal CostoProd { get; set; }
        [Column("existencia_prod", TypeName = "decimal(10, 2)")]
        public decimal ExistenciaProd { get; set; }
        [Column("descuento_prod")]
        public int DescuentoProd { get; set; }
        [Column("precio_prod", TypeName = "decimal(10, 2)")]
        public decimal PrecioProd { get; set; }
        [Column("descripcion_prod")]
        [StringLength(1)]
        [Unicode(false)]
        public string DescripcionProd { get; set; } = null!;

        [ForeignKey("IdCatProd")]
        [InverseProperty("Productos")]
        public virtual CategoriaProducto IdCatProdNavigation { get; set; } = null!;
        [InverseProperty("IdProdCarritoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdProductoDvpNavigation")]
        public virtual ICollection<DetalleVp> DetalleVps { get; set; }
    }
}
