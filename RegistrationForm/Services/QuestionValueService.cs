using RegistrationForm.Data;
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
    }
}
