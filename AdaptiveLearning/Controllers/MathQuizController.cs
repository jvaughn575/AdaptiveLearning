using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdaptiveLearning.Models.MathQuizViewModels;
using AdaptiveLearning.Models;
using AdaptiveLearning.Data;
using AdaptiveLearning.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptiveLearning.Controllers
{
    [Authorize]
    public class MathQuizController : Controller
    {

        private MathQuizDbContext context;

        public MathQuizController(MathQuizDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: SavedMathQuizs
        public async Task<IActionResult> Index()
        {
            return View(await context.SavedMathQuizzes.ToListAsync());
        }

        

        // GET: SavedMathQuizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavedMathQuizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,questions,created,UserID")] SavedMathQuiz savedMathQuiz)
        {
            if (ModelState.IsValid)
            {
                context.Add(savedMathQuiz);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(savedMathQuiz);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedMathQuiz = await context.SavedMathQuizzes.SingleOrDefaultAsync(m => m.ID == id);
            if (savedMathQuiz == null)
            {
                return NotFound();
            }
            return View(savedMathQuiz);
        }

        public async Task<IActionResult> MathRetakeDisplay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedMathQuiz = await context.SavedMathQuizzes.SingleOrDefaultAsync(m => m.ID == id);
            if (savedMathQuiz == null)
            {
                return NotFound();
            }
            return View(savedMathQuiz);
        }

        // POST: SavedMathQuizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,questions,created,UserID")] SavedMathQuiz savedMathQuiz)
        {
            if (id != savedMathQuiz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(savedMathQuiz);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedMathQuizExists(savedMathQuiz.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(savedMathQuiz);
        }

        // GET: SavedMathQuizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedMathQuiz = await context.SavedMathQuizzes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (savedMathQuiz == null)
            {
                return NotFound();
            }

            return View(savedMathQuiz);
        }

        // POST: SavedMathQuizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedMathQuiz = await context.SavedMathQuizzes.SingleOrDefaultAsync(m => m.ID == id);
            context.SavedMathQuizzes.Remove(savedMathQuiz);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SavedMathQuizExists(int id)
        {
            return context.SavedMathQuizzes.Any(e => e.ID == id);
        }

        [Route("MathQuiz/Random")]
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


        [HttpPost]
        public JsonResult PostJsonResult(ResultMathQuiz result)
        {

            if (result != null && ModelState.IsValid)
            {                                   
                
                // Add quiz id to result and save to db                
                context.ResultMathQuizzes.Add(result);
                context.SaveChanges();

            }

            return Json(new
            {
                state = 1,
                msg = string.Empty
            });

        }

        [HttpGet]
        public IActionResult PostJson()
        {
            return View(_datas);

        }

        
        // GET: SavedMathQuizs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            using (context)
            {
                var quiz = context.SavedMathQuizzes
                    .Single(q => q.ID == id);

                var results = context.Entry(quiz)
                    .Collection(q => q.Results)
                    .Query()
                    .Where(r => r.SavedMathQuizID == id)
                    .ToList();

                quiz.Results = results;

                if (quiz == null)
                {
                    return NotFound();
                }

               return View(quiz);
            }
                        
        }
    }
}

