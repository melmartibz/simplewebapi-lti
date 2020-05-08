using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Data
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> opt) : base(opt)
        { 

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid onModeCreateID = Guid.NewGuid();
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = Guid.NewGuid(), Name = "Kitchewares" },
                new Category { ID = Guid.NewGuid(), Name = "Gadgets and Electronics" },
                new Category { ID = Guid.NewGuid(), Name = "Gardening Tools" },
                new Category { ID = Guid.NewGuid(), Name = "Sports Equipment" },
                new Category { ID = onModeCreateID, Name = "Gaming" }
            );

            modelBuilder.Entity<Product>().Ignore(p => p.Category).HasData(
                new Product { ID = Guid.NewGuid(), Name = "FF7 Remake", Description = "Final Fantasy 7 Remake", Image = "https://gadgetpilipinas.net/wp-content/uploads/2019/09/ff7remake1st.jpg", CategoryID = onModeCreateID }
            );

            modelBuilder.Entity<User>().HasData(
               new User { UserID = Guid.NewGuid(), Username = "Weeddnim", Password="123password", Email="user@useremail.com" }
           );
        }
    }
}
