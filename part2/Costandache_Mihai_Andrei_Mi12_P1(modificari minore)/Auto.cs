//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auto()
        {
            this.Comenzi = new HashSet<Comanda>();
        }
    
        public int AutoId { get; set; }
        public string NumarAuto { get; set; }
        public string SerieSasiu { get; set; }
        public int ClientClientId { get; set; }
        public int SasiuSasiuId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Sasiu Sasiu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comenzi { get; set; }
    }
}
