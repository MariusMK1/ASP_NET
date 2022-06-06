using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Dtos;
using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.Services
{
    public class QuestionService
    {
        private DataContext _dataContext;

        public QuestionService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<QuestionDto> GetAll()
        {
            List<Question> entities =  _dataContext.Questions.Include(si => si.QuestionValues).ToList();
            var dtos = entities.Select(e => new QuestionDto 
            {
                Id = e.Id,
                Text = e.Text,
                QuestionValues = e.QuestionValues.Select(x => new QuestionValueDto
                {
                    Id = x.Id,
                    Text = x.Text,
                }).ToList()
            }).ToList();
            return dtos;
        }
        public void Add(Question question)
        {
            _dataContext.Questions.Add(question);
            _dataContext.SaveChanges();
        }
        public void Update(List<QuestionDto> questions)
        {
            foreach (QuestionDto questionDto in questions)
            {
                Question existing = _dataContext.Questions.FirstOrDefault(x => x.Id == questionDto.Id);
                existing.QuestionValueAnswerId = questionDto.QuestionValueAnswerId;
            }
            _dataContext.SaveChanges();
        }
    }
}
