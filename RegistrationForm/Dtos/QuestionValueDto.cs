using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.Dtos
{
    public class QuestionValueDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public int QuestionId { get; set; }
    }
}
