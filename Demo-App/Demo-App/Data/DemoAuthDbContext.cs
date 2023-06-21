using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Data
{
    public class DemoAuthDbContext : IdentityDbContext
    {
        public DemoAuthDbContext(DbContextOptions<DemoAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "2a9823ea-9fd2-4416-b29f-cfadcb495133";
            var writterRoleId = "2137b0de-75d6-4890-9a00-6b669ee5de1e";
            var roles = new List<IdentityRole>
            { new IdentityRole
             {
                Id=readerRoleId,
                ConcurrencyStamp=readerRoleId,
                Name="Reader",
                NormalizedName="Reader.ToUpper()",
             },
            new IdentityRole
             {
                Id=writterRoleId,
                ConcurrencyStamp=writterRoleId,
                Name="Writer",
                NormalizedName="Writer.ToUpper()",
             }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
