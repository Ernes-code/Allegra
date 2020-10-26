using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alegra.App.ViewModels;
using Alegra.Data_Access.Interfaces;
using Alegra.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Alegra.AllegraApp.Controllers
{
    public class UserExerciseController : Controller
    {
        private readonly IUserExerciseCommandHandler _handler;
        public UserExerciseController(IUserExerciseCommandHandler handler) => this._handler = handler;

        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            this._handler.AddUserAsync(model.Username);
            return await Task.FromResult(this.RedirectToAction("User", "Home"));
        }

        public async Task<IActionResult> AddExercise(ExerciseViewModel model)
        {
            this._handler.AddUserExerciseAsync(model.UserId, model.Description, model.Duration, model.Date);
            return await Task.FromResult(this.RedirectToAction("Exercise", "Home"));
        }
    }
}