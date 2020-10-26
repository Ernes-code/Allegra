using System;
using System.Threading.Tasks;
using Alegra.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Alegra.Logic.Interfaces;
using Alegra.Logic.Interfaces.Query;

namespace Alegra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IUserExerciseCommandHandler _commandHandler;
        private readonly IUserExerciseQueryHandler _queryHandler;
        public ExerciseController(IUserExerciseCommandHandler commandHandler, IUserExerciseQueryHandler queryHandler)
        {
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
         }

        [HttpGet]
        [Route("users")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateOrder()
        {
           var result = await this._queryHandler.GetAllUsersAsync().ConfigureAwait(false);

            return this.Ok(result);
        }

        [HttpGet]
        [Route("log")]
        public async Task<IActionResult> GetAll([FromQuery] Guid userId, DateTime? from = null, DateTime? to = null, int? limit = null)
        {
            var result = await this._queryHandler.GetExerciseLogsAsync(userId, from, to, limit).ConfigureAwait(false);
            return this.Ok(result);
        }

        //Post
        [HttpPost]
        [Route("new-user")]
        public async Task<IActionResult> NewUser(UserViewModel model)
        {
            try
            {
                this._commandHandler.AddUserAsync(model.Username);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
            return this.Ok();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddExercise(ExerciseViewModel model)
        {
            try
            {
                this._commandHandler.AddUserExerciseAsync(model.UserId, model.Description, model.Duration, model.Date);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
            return this.Ok();
        }
    }
}