using Alegra.Data_Design.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Design.Seed
{
    public static class UserSeed
    {
        public static void Seed(AlegraDbContext dbContext)
        {
            var userConst = Global.Constants.User.Guids;
            dbContext.AddRange
                    (
                    new User { UserId = userConst[0], TimeStamp = DateTime.Now, Username = "KoosIsBoos"},
                    new User { UserId = userConst[1],  TimeStamp = DateTime.Now, Username = "JaniieSannie" },
                    new User { UserId = userConst[2],  TimeStamp = DateTime.Now, Username = "KatrinaDelLill" },
                    new User { UserId = userConst[3],  TimeStamp = DateTime.Now, Username = "FrikkieSeStukkie" },
                    new User { UserId = userConst[4],  TimeStamp = DateTime.Now, Username = "MarinaSeKonsertina" },
                    new User { UserId = userConst[5],  TimeStamp = DateTime.Now, Username = "GertSeTert" }
                    );
            _ = dbContext.SaveChanges();
        }
    }
}
