using Examination.Core.Entities;
using Examinations.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core
{
    public class AdminDbContext : DbContext
    {

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
       
        public DbSet<QuestionsBank> QuestionBanks { get; set; }

        public DbSet<Question> Questions { get; set; }



         public DbSet<Option> Options { get; set; }
        public DbSet<TestAnswer> TestAnswers { get; set; }




        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Integrated Security=SSPI; Server=.;DataBase=AdminLibrary; uid=sa;password=pass@123");
        //}

    }
}
