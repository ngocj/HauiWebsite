using Haui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.Configurations
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.ToTable(nameof(UserSkill));
            builder.HasKey(x => new { x.UserId, x.SkillId });
            builder.HasOne(x => x.Skill).WithMany(x => x.userSkills).HasForeignKey(x => x.SkillId);
            builder.HasOne(x => x.User).WithMany(x => x.userSkills).HasForeignKey(x => x.UserId);

        }
    }
}
