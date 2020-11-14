using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Models
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<LibrarySystem.Models.Test> Test { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<Rule> Rule { get; set; }
        public DbSet<Type> Type { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departmentlist);

            modelBuilder.Entity<User>()
              .HasOne(u => u.Department)
              .WithMany(d => d.Userlist);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Type>()
                .HasAlternateKey(t => t.TypeName);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookType)
                .WithMany(t => t.Booklist);

            modelBuilder.Entity<Book>()
                .HasIndex(n => n.BookName);

            modelBuilder.Entity<Book>()
                .HasIndex(w => w.Writer);

            modelBuilder.Entity<Borrow>().Property(b => b.BorrowDate).HasDefaultValueSql("getdate()");

        }
       

        internal User FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

  
    }
}
