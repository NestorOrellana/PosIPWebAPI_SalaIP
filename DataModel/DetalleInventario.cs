//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleInventario
    {
        public int IdDetalle { get; set; }
        public long IdProducto { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public int IdRegistro { get; set; }
    
        public virtual RegistroInventario RegistroInventario { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual Productos Productos1 { get; set; }
    }
}
