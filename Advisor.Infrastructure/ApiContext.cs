using Advisor.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Advisor.Infrastructure
{
    public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
    {
        public DbSet<Advisor.Domain.Advisor> Advisors { get; set; }

    }
}
