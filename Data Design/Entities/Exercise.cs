using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Design.Entities
{
    public class Exercise
    {
        public Guid ExerciseId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
