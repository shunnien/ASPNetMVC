﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IdentityDbFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataEntities : DbContext
    {
        public DataEntities()
            : base("name=DataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }
        public virtual DbSet<IdentityUserClaim> IdentityUserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }
        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }
    }
}