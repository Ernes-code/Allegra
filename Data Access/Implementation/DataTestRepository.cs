using Alegra.Data_Access.Interfaces;
using Alegra.Data_Design;
using Alegra.Data_Design.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Access.Implementation
{
    public class DataTestRepository : IDataTestRepository
    {
        public async Task<string> SeedDatabase()
        {
            this.TruncateDatabaseTables();
            using(AlegraDbContext dbContext = new AlegraDbContext())
            {
                try
                {
                    UserSeed.Seed(dbContext);
                    ExerciseSeed.Seed(dbContext);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return await Task.FromResult("Success");
        }

        private void TruncateDatabaseTables()
        {
            using (AlegraDbContext dbContext = new AlegraDbContext())
            {
                var usersAll = from c in dbContext.Users select c;
                dbContext.Users.RemoveRange(usersAll);
                var exerciseAll = from c in dbContext.Exercises select c;
                dbContext.Exercises.RemoveRange(exerciseAll);
                _ = dbContext.SaveChanges();
            }
        }
    }
}
