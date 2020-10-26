using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alegra.Data_Access.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alegra.Controllers
{
    [Route("api/[controller]")]
    public class DataTestController : Controller
    {

        private readonly IDataTestRepository _dataAccess;
        public DataTestController(IDataTestRepository dataAccess) => this._dataAccess = dataAccess;

        [HttpPost]
        [Route("Seed")]
        public async Task<IActionResult> SeedDatabase()
        {
            var result = this._dataAccess.SeedDatabase();
            return this.Ok(result.Result);
        }

    }
}
