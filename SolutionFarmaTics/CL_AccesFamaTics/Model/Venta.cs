//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CL_AccesFamaTics.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.DetalleVentas = new HashSet<DetalleVenta>();
        }
    
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public System.DateTime FechaDeVenta { get; set; }
        public decimal TotalDeVenta { get; set; }
        public string NumeroDeVenta { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}