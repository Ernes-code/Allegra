using Alegra.Data_Design.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Design
{
    public class AlegraDbContext: DbContext
    {
        public AlegraDbContext(DbContextOptions<AlegraDbContext> options): base(options)
        {

        }

        public AlegraDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AllegraDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            //User Table
            _ = builder.Entity<User>();
            _ = builder.Entity<User>().HasKey(x => x.UserId);
            //Properties
            _ = builder.Entity<User>().Property(x => x.Username).IsRequired();
            _ = builder.Entity<User>().Property(x => x.Username).HasMaxLength(25);
            _ = builder.Entity<User>().Property(x => x.TimeStamp).IsRequired(false);
            _ = builder.Entity<User>().Property(x => x.TimeStamp).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //Indexes 
            _ = builder.Entity<User>().HasIndex(x => x.Username).HasName("UsernameIndex");
            /////////////////////////////////////////////////////////////////////////////////////////////
            //Exersice Table
            _ = builder.Entity<Exercise>();
            _ = builder.Entity<Exercise>().HasKey(x => x.ExerciseId);
            //Properties
            _ = builder.Entity<Exercise>().Property(x => x.Description).IsRequired();
            _ = builder.Entity<Exercise>().Property(x => x.Duration).IsRequired();
            _ = builder.Entity<Exercise>().Property(x => x.Date).IsRequired();
            _ = builder.Entity<Exercise>().Property(x => x.TimeStamp).IsRequired(false);
            _ = builder.Entity<Exercise>().Property(x => x.TimeStamp).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
            //Indexes 
            _ = builder.Entity<Exercise>().HasIndex(x => x.Date).HasName("DateIndex");
            _ = builder.Entity<Exercise>().HasIndex(x => x.Duration).HasName("DurationIndex");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
