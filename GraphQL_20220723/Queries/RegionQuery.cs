using GraphQL_20220723.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace GraphQL_20220723.Queries
{
    public class RegionQuery
    {
        public async Task<IEnumerable<EFDbContext.Region>> GetRegions()
        {
            var lst = await new AppDbContext().Region.ToListAsync();
            return lst;
        }

        public async Task<EFDbContext.Region> GetRegionById(int id)
        {
            var item = await new AppDbContext().Region.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }

        public async Task<EFDbContext.Region> AddRegion(EFDbContext.Region region)
        {
            var db = new AppDbContext();
            await db.Region.AddAsync(region);
            await db.SaveChangesAsync();
            return region;
        }
    }
}
