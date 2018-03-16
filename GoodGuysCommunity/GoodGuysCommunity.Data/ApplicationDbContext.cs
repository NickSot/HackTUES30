using GoodGuysCommunity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId);

            builder.Entity<Comment>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(p => p.AuthorId);

            builder.Entity<Comment>()
                .HasOne(p => p.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.PostId);

            builder
                .Entity<Resource>()
                .HasOne(r => r.Author)
                .WithMany(a => a.Uploads)
                .HasForeignKey(r => r.AuthorId);
        }
    }
}
