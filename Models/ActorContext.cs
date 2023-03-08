using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace filmography.Models
{
    public class ActorContext: DbContext
    {
        public ActorContext() : base("DefaultConnection") 
        {
        
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Award> Awards{ get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Producer> Producers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().ToTable("Actors");
            modelBuilder.Entity<Film>().ToTable("Films");
            modelBuilder.Entity<Character>().ToTable("Characters");
            modelBuilder.Entity<Studio>().ToTable("Studios");
            modelBuilder.Entity<Award>().ToTable("Awards");
            modelBuilder.Entity<Nomination>().ToTable("Nominations");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            base.OnModelCreating(modelBuilder);
        }
    }
}
