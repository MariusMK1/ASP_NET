using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionValueAnswerId { get; set; }
        public List<QuestionValue> QuestionValues { get; set; }
    }
}
