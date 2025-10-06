using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasMany(m => m.HomeMatches)
            .WithOne(q => q.HomeTeam)
            .HasForeignKey(q => q.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(m => m.AwayMatches)
            .WithOne(q => q.AwayTeam)
            .HasForeignKey(q => q.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(q => q.Name).IsUnique();
        builder.HasData(
            new Team
            {
                Id = 1,
                Name = "Tivoli Gardens F.C.",
                CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
            },
            new Team
            {
                Id = 2,
                Name = "Waterhouse F.C.",
                CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
            },
            new Team
            {
                Id = 3,
                Name = "Humble Lions F.C.",
                CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
            }
        );
    }
}