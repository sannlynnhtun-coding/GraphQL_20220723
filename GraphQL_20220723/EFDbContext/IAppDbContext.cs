using GraphQL_20220723.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_20220723.EFDbContext
{
    public interface IAppDbContext
    {
        DbSet<Region> Region { get; set; }
    }
}