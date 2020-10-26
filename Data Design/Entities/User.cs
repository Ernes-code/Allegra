using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Design.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public DateTime? TimeStamp { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
