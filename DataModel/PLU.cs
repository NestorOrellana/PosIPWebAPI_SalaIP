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
    
    public partial class PLU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLU()
        {
            this.DetalleFactura = new HashSet<DetalleFactura>();
        }
    
        public long IdPLU { get; set; }
        public long IdRecetaEnc { get; set; }
        public long IdProducto { get; set; }
        public bool Estado { get; set; }
        public Nullable<bool> SeDetalla { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual RecetaEnc RecetaEnc { get; set; }
    }
}
