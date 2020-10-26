using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Logic.Interfaces
{
    public interface IUserExerciseCommandHandler
    {
        void AddUserAsync(string username);
        void AddUserExerciseAsync(Guid userId, string description, int duration, DateTime date);
    }
}
