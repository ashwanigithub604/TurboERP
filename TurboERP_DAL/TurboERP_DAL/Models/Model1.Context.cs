﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurboERP_DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TurboEMSEntities : DbContext
    {
        public TurboEMSEntities()
            : base("name=TurboEMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BankHdr> BankHdrs { get; set; }
        public virtual DbSet<BuyCat> BuyCats { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<CartPly> CartPlies { get; set; }
        public virtual DbSet<Continen> Continens { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CPMaster> CPMasters { get; set; }
        public virtual DbSet<CurrMast> CurrMasts { get; set; }
        public virtual DbSet<DutyMast> DutyMasts { get; set; }
        public virtual DbSet<EventMst> EventMsts { get; set; }
        public virtual DbSet<Fin_Mast> Fin_Mast { get; set; }
        public virtual DbSet<GstMast> GstMasts { get; set; }
        public virtual DbSet<IndCity> IndCities { get; set; }
        public virtual DbSet<ItemGrp> ItemGrps { get; set; }
        public virtual DbSet<ItemMaster> ItemMasters { get; set; }
        public virtual DbSet<ItemSgrp> ItemSgrps { get; set; }
        public virtual DbSet<ItmCat> ItmCats { get; set; }
        public virtual DbSet<ManUnit> ManUnits { get; set; }
        public virtual DbSet<MisPrty> MisPrties { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ModelSL> ModelSLs { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Modules31012018> Modules31012018 { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PartyType> PartyTypes { get; set; }
        public virtual DbSet<PayTerm> PayTerms { get; set; }
        public virtual DbSet<PortMast> PortMasts { get; set; }
        public virtual DbSet<ProcMast> ProcMasts { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UnitMast> UnitMasts { get; set; }
        public virtual DbSet<Usergroup> Usergroups { get; set; }
        public virtual DbSet<UserGroupRight> UserGroupRights { get; set; }
        public virtual DbSet<Usermast> Usermasts { get; set; }
        public virtual DbSet<UserRight> UserRights { get; set; }
        public virtual DbSet<VehiCat> VehiCats { get; set; }
        public virtual DbSet<VehiMast> VehiMasts { get; set; }
        public virtual DbSet<BankDtl> BankDtls { get; set; }
    }
}
