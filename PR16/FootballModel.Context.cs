//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR16
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FootballModel : DbContext
    {
        public FootballModel()
            : base("name=Football_dbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Commands> Commands { get; set; }
        public virtual DbSet<Lands> Lands { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Varehouses> Varehouses { get; set; }
    }
}
