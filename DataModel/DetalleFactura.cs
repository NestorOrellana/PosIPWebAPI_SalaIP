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
    
    public partial class DetalleFactura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetalleFactura()
        {
            this.DetallePluAdquirido = new HashSet<DetallePluAdquirido>();
        }
    
        public int IdDetalle { get; set; }
        public decimal PrecioPlu { get; set; }
        public decimal SubTotal { get; set; }
        public string NoSerie { get; set; }
        public string NoCorrelativo { get; set; }
        public long IdPlu { get; set; }
        public short UnidadMedida { get; set; }
        public double Cantidad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePluAdquirido> DetallePluAdquirido { get; set; }
        public virtual FacturaE FacturaE { get; set; }
        public virtual PLU PLU { get; set; }
    }
}
