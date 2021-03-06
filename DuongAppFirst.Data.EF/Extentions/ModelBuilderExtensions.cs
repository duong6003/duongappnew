using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuongAppFirst.Data.EF.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
            this ModelBuilder modelBuider,
            DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuider.Entity<TEntity>(entityConfiguration.Configure);
        }
    }

    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}