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
    
    public partial class Sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursal()
        {
            this.CajaChica = new HashSet<CajaChica>();
            this.FacturaE = new HashSet<FacturaE>();
            this.RegistroInventario = new HashSet<RegistroInventario>();
            this.Series = new HashSet<Series>();
            this.Usuarios = new HashSet<Usuarios>();
            this.RecetaEnc = new HashSet<RecetaEnc>();
            this.RegistroSincronizacion = new HashSet<RegistroSincronizacion>();
            this.PedidosRecibidos = new HashSet<PedidosRecibidos>();
        }
    
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public long CentroSAP { get; set; }
        public short IdSucursal { get; set; }
        public int OficinaVenta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CajaChica> CajaChica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaE> FacturaE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroInventario> RegistroInventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Series> Series { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaEnc> RecetaEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroSincronizacion> RegistroSincronizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosRecibidos> PedidosRecibidos { get; set; }
    }
}
