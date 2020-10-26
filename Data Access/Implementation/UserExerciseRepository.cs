using Alegra.Data_Access.Interfaces;
using Alegra.Data_Access.Models;
using Alegra.Data_Design;
using Alegra.Data_Design.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Alegra.Data_Access.Implementation
{
    public class UserExerciseRepository : IUserExerciseRepository
    {
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            using AlegraDbContext dataAccess = new AlegraDbContext();
            return await Task.FromResult(from u in dataAccess.Users.ToList() select new UserDto { UserId = u.UserId, Username = u.Username });
        }

        public async Task<IEnumerable<ExerciseLogDto>> GetExerciseLogsAsync()
        {
            using AlegraDbContext dataAccess = new AlegraDbContext();

            var result = dataAccess.Exercises.ToList()
                .Select(y => new ExerciseLogDto
                {
                    UserId = y.UserId,
                    Date = y.Date,
                    ExerciseId = y.ExerciseId,
                    Description = y.Description,
                    Duration = y.Duration
                });
            return await Task.FromResult(result);
        }

        //Post
        public void AddUserExerciseAsync(Guid userId, string description, int duration, DateTime date)
        {
            using (AlegraDbContext dataAccess = new AlegraDbContext())
            {
                _ = Task.FromResult(dataAccess.Exercises.Add(new Exercise
                {
                    ExerciseId = Guid.NewGuid(),
                    UserId = userId,
                    Description = description,
                    Duration = duration,
                    Date = date
                }));
                _ = dataAccess.SaveChanges();
            }
        }

        public void AddUserAsync(string username)
        {
            using (AlegraDbContext dataAccess = new AlegraDbContext())
            {

                _ = Task.FromResult(dataAccess.Users.Add(new User { UserId = Guid.NewGuid(), Username = username }));
                _ = dataAccess.SaveChanges();
            };
        }
    }
}
