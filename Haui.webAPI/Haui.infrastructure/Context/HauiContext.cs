using Haui.Domain.Entities;
using Haui.infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.Context
{
    // db context day la lop co so cua EFC cung cap API de lam viec vs CSDL
    // chua cac bang DBset
    
    public class HauiContext : DbContext
    {
        // dbcontextoptions chua cac cau hinh cho dbcontext nhu connectstring ..., loai csdl:  mysql,sql...
        public HauiContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        // EF se anh xa class users thanh 1 bang user
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<UserSkill> userSkills { get; set; }

        public DbSet<Image>Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new UserSkillConfiguration());
            modelBuilder.ApplyConfiguration(new ImageFileConfiguration());

            // seed data
            modelBuilder.Entity<Role>().HasData(
                new Role {Id = new Guid("a5e36cff-9698-4a1c-a8ac-b3e8b0dc25f0"), RoleName = "Admin",CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Role { Id = new Guid("64c68fc8-7974-4622-b042-e1c3b58ecb43"), RoleName = "User", CreateDate = DateTime.Now, UpdateDate = DateTime.Now }
                );
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = new Guid("327afb34-6df6-4297-b00b-adb37832af14"), Name = "SQL", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Skill { Id = new Guid("88e2fb0f-d378-4fec-b84d-6bce7ecb8ef7"), Name = "C#", CreateDate = DateTime.Now, UpdateDate = DateTime.Now }
                );
            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b"), 
                    Email = " ngoc@gmail.com",
                    FullName = "Nguyen Bao Ngoc", 
                    RoleId = new Guid("a5e36cff-9698-4a1c-a8ac-b3e8b0dc25f0"),
                    DateOfBirth = DateTime.Now, 
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                });
            modelBuilder.Entity<UserSkill>().HasData(
                new UserSkill
                {
                    UserId = new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b"),
                    SkillId = new Guid("327afb34-6df6-4297-b00b-adb37832af14")
                },
                new UserSkill
                {
                    UserId = new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b"),
                    SkillId = new Guid("88e2fb0f-d378-4fec-b84d-6bce7ecb8ef7")
                });
        }
    }
}
