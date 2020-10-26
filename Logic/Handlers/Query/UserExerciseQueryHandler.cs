using Alegra.Data_Access.Interfaces;
using Alegra.Data_Access.Models;
using Alegra.Data_Design.Entities;
using Alegra.Logic.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Logic.Handlers.Query
{
    public class UserExerciseQueryHandler : IUserExerciseQueryHandler
    {
        private readonly IUserExerciseRepository _repository;
        public UserExerciseQueryHandler(IUserExerciseRepository repository) => this._repository = repository;

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await this._repository.GetAllUsersAsync();
        }

        public async Task<IEnumerable<ExerciseLogDto>> GetExerciseLogsAsync(Guid userId, DateTime? from = null, DateTime? to = null, int? limit = null)
        {
            var result = await this._repository.GetExerciseLogsAsync();

            return result.Where(x => (x.UserId.ToString().CompareTo(userId.ToString()) == 0))
                .Where(x => !limit.HasValue || x.Duration == limit)
                .Where(x => !from.HasValue || x.Date.Ticks >= to.Value.Ticks)
                .Where(x => !to.HasValue || x.Date.Ticks <= to.Value.Ticks);
        }
    }
}
