//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkCodeFirst
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;
    
    using System.ComponentModel.DataAnnotations.Schema;
    internal partial class Klientat_Mapping : EntityTypeConfiguration<Klientat>
    {
        public Klientat_Mapping()
        {					
    		this.HasKey(t => t.ID);		
    		this.ToTable("Klientat");
    		this.Property(t => t.ID).HasColumnName("ID");
    		this.Property(t => t.Emri).HasColumnName("Emri").IsRequired().HasMaxLength(50);
    		this.Property(t => t.Mbiemri).HasColumnName("Mbiemri").IsRequired().HasMaxLength(50);
    		this.Property(t => t.Adresa).HasColumnName("Adresa").IsRequired().HasMaxLength(50);
    		Initialize();
    	}
    	partial void Initialize();
    }
}
