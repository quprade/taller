
using TallerMVCRazorChallenge.LoadData;

namespace TallerMVCRazorChallenge.Repository
{
    public class SeedDataBase
    {
        internal static void Seed(TallerDbContext dbContext)
        {
            dbContext.Cars.AddRange(InternalData.GetCars());
            dbContext.SaveChanges();
        }
    }
}
