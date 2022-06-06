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
    public class QuestionValueService
    {
        private DataContext _dataContext;

        public QuestionValueService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<QuestionValueDto> GetAll()
        {
            var entities = _dataContext.QuestionValues.ToList();
            return entities.Select(e => new QuestionValueDto
            {
                Id = e.Id,
                Text = e.Text
            }).ToList();
        }
        public void Add(QuestionValueDto questionValueDto)
        {
            QuestionValue entity = new QuestionValue
            {
                Text = questionValueDto.Text,
                QuestionId = questionValueDto.QuestionId
            };

            _dataContext.QuestionValues.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
