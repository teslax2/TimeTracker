﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracker
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TimeTrackerDataModelContainer : DbContext
    {
        public TimeTrackerDataModelContainer()
            : base("name=TimeTrackerDataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectName> ProjectNameSet { get; set; }
    }
}
