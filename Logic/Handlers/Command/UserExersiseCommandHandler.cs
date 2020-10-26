using Alegra.Data_Access.Interfaces;
using Alegra.Data_Design.Entities;
using Alegra.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Logic.Handlers.Command
{
    public class UserExersiseCommandHandler : IUserExerciseCommandHandler
    {
        private readonly IUserExerciseRepository _repository;
        public UserExersiseCommandHandler(IUserExerciseRepository repository) => this._repository = repository;

        public void AddUserAsync(string username)
        {
            this._repository.AddUserAsync(username);
        }

        public void AddUserExerciseAsync(Guid userId, string description, int duration, DateTime date)
        {
            this._repository.AddUserExerciseAsync(userId, description, duration, date);
        }
    }
}
