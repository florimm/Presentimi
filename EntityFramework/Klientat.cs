//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klientat
    {
        public Klientat()
        {
            this.Faturats = new HashSet<Faturat>();
        }
    
        public int ID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Adresa { get; set; }
    
        public virtual ICollection<Faturat> Faturats { get; set; }
    }
}
