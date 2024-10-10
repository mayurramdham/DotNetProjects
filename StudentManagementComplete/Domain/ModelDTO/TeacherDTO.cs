using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int CourseId { get; set; }
    }
}
