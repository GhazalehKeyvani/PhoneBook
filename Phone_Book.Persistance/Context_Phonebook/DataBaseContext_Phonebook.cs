using Phone_Book.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Application.Interface;
using Phone_Book.Common.Roles;

namespace Phone_Book.Persistance.Context
{
    public class DataBaseContext_Phonebook :DbContext,IDataBaseContext_Phonebook
    {
        public DataBaseContext_Phonebook(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User_Phonebook> Users { get; set; }
        public DbSet<Role_Phonebook> Roles { get; set; }
        //public DbSet<Province> Provinces { get; set; }
        public DbSet<UserInRoles_Phonebook> UserInRoles { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role_Phonebook>().HasData(new Role_Phonebook { Id = 1, Name = "مدیریت" });
            modelBuilder.Entity<Role_Phonebook>().HasData(new Role_Phonebook { Id = 2, Name = "اپراتور" });
            modelBuilder.Entity<Role_Phonebook>().HasData(new Role_Phonebook { Id = 3, Name = "همکار" });

            modelBuilder.Entity<User_Phonebook>().HasIndex(E=>E.Email).IsUnique();

            modelBuilder.Entity<User_Phonebook>().HasQueryFilter(p => !p.Isremoved);
            modelBuilder.Entity<Role_Phonebook>().HasQueryFilter(p => !p.Isremoved);
            //modelBuilder.Entity<Province>().HasQueryFilter(p => !p.Isremoved);
            modelBuilder.Entity<UserInRoles_Phonebook>().HasQueryFilter(p => !p.Isremoved);
            //modelBuilder.Entity<User>().HasQueryFilter(c => c.Company_Name );
        }
    }
}
