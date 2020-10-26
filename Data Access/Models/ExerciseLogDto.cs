using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alegra.Data_Access.Models
{
    public class ExerciseLogDto
    {
        public Guid ExerciseId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
