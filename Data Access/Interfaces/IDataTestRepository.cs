using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Access.Interfaces
{
    public interface IDataTestRepository
    {
        Task<string> SeedDatabase();
    }
}
