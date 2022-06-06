using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Dtos;
using RegistrationForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.Controllers
{
    public class QuestionValueController : Controller
    {
        private QuestionValueService _questionValueService;
        private QuestionService _questionService;

        public QuestionValueController(QuestionValueService questionValueService, QuestionService questionService)
        {
            _questionValueService = questionValueService;
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            QuestionValueDto questionValue = new QuestionValueDto();

            questionValue.Questions = _questionService.GetAll();
            return View(questionValue);
        }
        [HttpPost]
        public IActionResult Add(QuestionValueDto questionValue)
        {
            _questionValueService.Add(questionValue);
            questionValue.Questions = _questionService.GetAll();
            return View(questionValue);
            //return RedirectToAction("Index");
        }
    }
}
