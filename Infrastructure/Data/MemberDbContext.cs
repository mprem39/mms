using System;
using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace Infrastructure.Data
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Point> Points { get; set; }

    }
}