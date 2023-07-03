using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class MafiaFamilyConfiguration : IEntityTypeConfiguration<MafiaFamily>
    {
        public void Configure(EntityTypeBuilder<MafiaFamily> builder)
        {
            builder.ToTable("MafiaFamily");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();

            builder.HasOne(t => t.FamilyMembers)
                .WithMany()
                .HasForeignKey(t => t.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}