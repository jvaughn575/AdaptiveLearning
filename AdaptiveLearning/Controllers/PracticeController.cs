using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AdaptiveLearning.Models.MathQuizViewModels;
using AdaptiveLearning.Models;
using AdaptiveLearning.Helpers;
using AdaptiveLearning.Data;



namespace AdaptiveLearning.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private MathQuizDbContext context;

        public PracticeController(MathQuizDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("Math/Random")]
        [HttpGet]
        public IActionResult MathRandomSelect()
        {
            return View();
        }



        [HttpPost]
        public IActionResult MathRandomDisplay(MathQuizRandomViewModel mathQuizRandomViewModel)
        {
            MathQuizModel mathQuizModel = new MathQuizModel();

            var number1 = mathQuizRandomViewModel.Number1.Split(' ');
            
            mathQuizModel.Number1LowRange = int.Parse(number1[0]);
            mathQuizModel.Number1HighRange = int.Parse(number1[1]);

            var number2 = mathQuizRandomViewModel.Number2.Split(' ');
            mathQuizModel.Number2LowRange = int.Parse(number2[0]);
            mathQuizModel.Number2HighRange = int.Parse(number2[1]);

            mathQuizModel.Operations = mathQuizRandomViewModel.Operations;

            mathQuizModel.NumQuestions = mathQuizRandomViewModel.NumQuestions;

            

            return View(mathQuizModel);

        }

        
        private static QuizResultBundle _datas;
        
        [HttpPost]
        public JsonResult PostJson(QuizResultBundle data)              
        {
            
            if (data != null && ModelState.IsValid)
            {
                
                _datas = data;
                SavedMathQuiz quiz = _datas.quiz;
                ResultMathQuiz result = _datas.result;

                // Add data to the models on the c# side
                quiz.UserID = User.getUserId();
                               
                // Save quiz to db
                context.SavedMathQuizzes.Add(quiz);
                context.SaveChanges();

                int quizId = quiz.ID;
                

                // Add quiz id to result and save to db
                result.SavedMathQuizID = quizId;
                context.ResultMathQuizzes.Add(result);
                context.SaveChanges();
                                
            }

            return Json(new
            {
                state = 0,
                msg = string.Empty
            });
            
        }
        [HttpGet]
        public IActionResult PostJson() {
            return View( _datas);
            
        }
    }
}