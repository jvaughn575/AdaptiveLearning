using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AdaptiveLearning.Models.MathQuizViewModels;
using AdaptiveLearning.Models;

namespace AdaptiveLearning.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
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
            //return Content(number1[0] + number1[1]);
            mathQuizModel.Number1LowRange = int.Parse(number1[0]);
            mathQuizModel.Number1HighRange = int.Parse(number1[1]);

            var number2 = mathQuizRandomViewModel.Number2.Split(' ');
            mathQuizModel.Number2LowRange = int.Parse(number2[0]);
            mathQuizModel.Number2HighRange = int.Parse(number2[1]);

            mathQuizModel.Operations = mathQuizRandomViewModel.Operations;

            mathQuizModel.NumQuestions = mathQuizRandomViewModel.NumQuestions;

            

            return View(mathQuizModel);

        }
    }
}