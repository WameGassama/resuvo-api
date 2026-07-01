using System.Reflection;
using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence
{
    public class ResumeDBContext : DbContext, IUnitOfWork
    {
        public DbSet<Resume> Resumes { get; set; } = null!;

        public ResumeDBContext(DbContextOptions<ResumeDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ResumeDBContext).Assembly);

            base.OnModelCreating(builder);
        }

        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}