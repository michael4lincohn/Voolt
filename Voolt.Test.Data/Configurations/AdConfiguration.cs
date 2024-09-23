using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voolt.Test.Domain;

namespace Voolt.Test.Data.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(e => e.AdId);
            builder.Property(e => e.AdId).ValueGeneratedOnAdd();

            builder.Property(e => e.AdExternalId);
            builder.Property(e => e.AdBalance);
            builder.Property(e => e.AdStatus);
            builder.Property(e => e.AdTotalLead);
            builder.Property(e => e.AdCreationDate);
            builder.Property(e => e.AdDescription);
        }
    }
}
