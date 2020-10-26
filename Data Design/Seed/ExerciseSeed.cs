using Alegra.Data_Design.Entities;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Design.Seed
{
    public static class ExerciseSeed
    {
        public static void Seed(AlegraDbContext dbContext)
        {
            var userConst = Global.Constants.User.Guids;
            var exerciseConst = Global.Constants.Exercise.Guids;
            dbContext.AddRange
                    (
                    new Exercise { UserId = userConst[0], ExerciseId = exerciseConst[0], Description = "Running", Duration = 10, Date = new Date().Recent(14,DateTime.Now), TimeStamp = DateTime.Now },
                    new Exercise { UserId = userConst[0], ExerciseId = exerciseConst[1], Description = "Jogging", Duration = 30, Date = new Date().Recent(14, DateTime.Now), TimeStamp = DateTime.Now },
                    new Exercise { UserId = userConst[1], ExerciseId = exerciseConst[2], Description = "Hurdels", Duration = 40, Date = new Date().Recent(14, DateTime.Now), TimeStamp = DateTime.Now },
                    new Exercise { UserId = userConst[2], ExerciseId = exerciseConst[3], Description = "Weight Lifting", Duration = 20, Date = new Date().Recent(14, DateTime.Now), TimeStamp = DateTime.Now },
                    new Exercise { UserId = userConst[3], ExerciseId = exerciseConst[4], Description = "Push Ups", Duration = 15, Date = new Date().Recent(14, DateTime.Now), TimeStamp = DateTime.Now },
                    new Exercise { UserId = userConst[4], ExerciseId = exerciseConst[5], Description = "Sit Ups", Duration = 10, Date = new Date().Recent(14, DateTime.Now), TimeStamp = DateTime.Now }
                    );
            _ = dbContext.SaveChanges();
            dbContext.Dispose();
        }
    }
}
