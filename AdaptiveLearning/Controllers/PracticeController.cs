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

    }  
}