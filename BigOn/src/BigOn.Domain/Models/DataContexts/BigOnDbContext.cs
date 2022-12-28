using BigOn.Domain.Models.DataContexts.Configurations;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigOn.Domain.Models.DataContexts
{
    public class BigOnDbContext : IdentityDbContext<BigonUser, BigonRole, int, BigonUserClaim, BigonUserRole,
        BigonUserLogin, BigonRoleClaim, BigonUserToken>//: DbContext
    {
        public BigOnDbContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<Subscribe> Subscribers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductMaterial> Materials { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTagCloud> BlogPostTagCloud { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCatalogItem> ProductCatalog { get; set; }
        public DbSet<Basket> Baskets { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BigOnDbContext).Assembly);
        }
    }
}
