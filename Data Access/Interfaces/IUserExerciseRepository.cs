using Alegra.Data_Access.Models;
using Alegra.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Access.Interfaces
{
    public interface IUserExerciseRepository
    {
        //Get Data OR Retrieve Data
         Task<IEnumerable<UserDto>> GetAllUsersAsync();
         Task<IEnumerable<ExerciseLogDto>> GetExerciseLogsAsync();

        //Send Data OR Post Data
        void AddUserAsync(string username);
        void AddUserExerciseAsync(Guid userId, string description, int duration , DateTime date);
    }
}
