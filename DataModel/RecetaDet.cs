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
    
    public partial class RecetaDet
    {
        public long IdRecetaDet { get; set; }
        public long IdProducto { get; set; }
        public long IdRecetaEnc { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
    
        public virtual RecetaEnc RecetaEnc { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
