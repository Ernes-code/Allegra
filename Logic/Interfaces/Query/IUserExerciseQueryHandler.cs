using Alegra.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Logic.Interfaces.Query
{
    public interface IUserExerciseQueryHandler
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<ExerciseLogDto>> GetExerciseLogsAsync(Guid userId, DateTime? from = null, DateTime? to = null, int? limit = null);
    }
}
