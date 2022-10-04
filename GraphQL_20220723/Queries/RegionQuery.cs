using GraphQL_20220723.EFDbContext;
using GraphQL_20220723.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_20220723.Queries
{
    public class RegionQuery
    {
        //private readonly IAppDbContext db;
        //public RegionQuery(IAppDbContext db)
        //{
        //    this.db = db;
        //}

        public async Task<IEnumerable<Region>> GetRegions()
        {
            var lst = await new AppDbContext().Region.ToListAsync();
            //var lst = await db.Region.ToListAsync();
            return lst;
        }

        public async Task<Region> GetRegionById(int id)
        {
            var item = await new AppDbContext().Region.Where(x => x.Id == id).FirstOrDefaultAsync();
            //var item = await db.Region.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }

        public async Task<Region> AddRegion(Region region)
        {
            var db = new AppDbContext();
            await db.Region.AddAsync(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateRegion(int id, Region region)
        {
            var db = new AppDbContext();
            region.Id = id;
            db.Entry(region).State = EntityState.Modified;
            db.Region.Update(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegion(int id)
        {
            var db = new AppDbContext();
            var region = db.Region.Where(x => x.Id == id).FirstOrDefault();
            db.Entry(region).State = EntityState.Deleted;
            db.Region.Remove(region);
            await db.SaveChangesAsync();
            return region;
        }
    }
}
