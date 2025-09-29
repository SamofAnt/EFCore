using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
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