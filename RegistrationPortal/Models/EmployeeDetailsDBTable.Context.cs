﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RegistrationPortalEntities : DbContext
    {
        public RegistrationPortalEntities()
            : base("name=RegistrationPortalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblBankName> tblBankNames { get; set; }
        public virtual DbSet<tblCompanyName> tblCompanyNames { get; set; }
        public virtual DbSet<tblEmployeeDetail> tblEmployeeDetails { get; set; }
    }
}