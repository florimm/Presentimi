//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkCodeFirst
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public class Fatura
    {
        public int ID { get; set; }
        public int KlientiID { get; set; }
        public string Nr { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Shuma { get; set; }
    
        public virtual Klienti Klienti { get; set; }
    }
}
