﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballAppListView
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FootballEntities : DbContext
    {
        private static FootballEntities _context;
        public FootballEntities()
        : base("name=FootballEntities")
        {
        }
        public static FootballEntities GetContext()
        {
            if (_context == null)
                _context = new FootballEntities();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Coaches> Coaches { get; set; }
        public virtual DbSet<Date_Location> Date_Location { get; set; }
        public virtual DbSet<Fans> Fans { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Results> Results { get; set; }
    
        public virtual ObjectResult<Coaches_proc_Result> Coaches_proc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Coaches_proc_Result>("Coaches_proc");
        }
    
        public virtual ObjectResult<Match_Location_Result> Match_Location()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Match_Location_Result>("Match_Location");
        }
    
        public virtual ObjectResult<Score_In_Match_Result> Score_In_Match()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Score_In_Match_Result>("Score_In_Match");
        }
    
        public virtual ObjectResult<Top_Scorer_Clubs3_Result> Top_Scorer_Clubs3()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Top_Scorer_Clubs3_Result>("Top_Scorer_Clubs3");
        }
    
        public virtual ObjectResult<Top_Scorer5_Result> Top_Scorer5()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Top_Scorer5_Result>("Top_Scorer5");
        }
    
        public virtual ObjectResult<Top_ScorerAll_Result> Top_ScorerAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Top_ScorerAll_Result>("Top_ScorerAll");
        }
    }
}
