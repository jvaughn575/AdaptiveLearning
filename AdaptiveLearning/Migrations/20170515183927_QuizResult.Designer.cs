using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AdaptiveLearning.Data;

namespace AdaptiveLearning.Migrations
{
    [DbContext(typeof(MathQuizDbContext))]
    [Migration("20170515183927_QuizResult")]
    partial class QuizResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdaptiveLearning.Models.ResultMathQuiz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmotionalStatePerQuestion");

                    b.Property<int>("SavedMathQuizID");

                    b.Property<DateTime>("created");

                    b.Property<string>("points");

                    b.Property<string>("secsperquestion");

                    b.HasKey("ID");

                    b.HasIndex("SavedMathQuizID");

                    b.ToTable("ResultMathQuizzes");
                });

            modelBuilder.Entity("AdaptiveLearning.Models.SavedMathQuiz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserID");

                    b.Property<DateTime>("created");

                    b.Property<string>("questions");

                    b.HasKey("ID");

                    b.ToTable("SavedMathQuizzes");
                });

            modelBuilder.Entity("AdaptiveLearning.Models.ResultMathQuiz", b =>
                {
                    b.HasOne("AdaptiveLearning.Models.SavedMathQuiz")
                        .WithMany("Results")
                        .HasForeignKey("SavedMathQuizID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
