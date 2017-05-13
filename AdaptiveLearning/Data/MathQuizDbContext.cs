using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdaptiveLearning.Models;

namespace AdaptiveLearning.Data
{
    public class MathQuizDbContext : DbContext
    {
        
        public MathQuizDbContext(DbContextOptions<MathQuizDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<QuizResult>().HasKey(c => new { c.ResultMathQuizID, c.SavedMathQuizID });
        //}

        public DbSet<SavedMathQuiz> SavedMathQuizzes { get; set; }
        public DbSet<ResultMathQuiz> ResultMathQuizzes { get; set; }
        //public DbSet<QuizResult> QuizResult { get; set; }


    }



    
}
