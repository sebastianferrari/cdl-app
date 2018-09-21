using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public class CDLContext : IdentityDbContext<StoreUser>
    {
        public CDLContext(DbContextOptions<CDLContext> options) : base(options) { }

        public DbSet<CustomerDriverLicense> Licenses { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<CustomerDriverLicense>()
        //        .HasData(new CustomerDriverLicense
        //        {
        //            ID = Guid.NewGuid().ToString(),
        //            Address = "Customer License Address",
        //            BirthDate = new DateTime().AddYears(-30),
        //            Class = 'A',
        //            ExpirationDate = new DateTime().AddYears(1),
        //            FirstName = "Sebastian",
        //            IssuedDate = new DateTime().AddYears(-4),
        //            LastName = "Ferrari",
        //            Restrictions = "Glasses required",
        //            State = "Florida"
        //        });
        //}
    }
}