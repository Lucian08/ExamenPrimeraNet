//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenPrimeraInternet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pedido
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Cliente")]
        public Nullable<int> IdCliente { get; set; }

        [Display(Name = "Nombre Producto")]
        public Nullable<int> IdProducto { get; set; }
        public Nullable<decimal> Descuento { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
