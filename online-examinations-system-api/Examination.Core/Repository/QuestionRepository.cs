using Examination.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Repository
{
    public class QuestionRepository : IQuestionRepository
    {


        AdminDbContext dbContext ;
        public QuestionRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public Question Add(Question question)
        {
            question.CreatedDate = DateTime.Now;
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
            return question;

        }

        public Question Update(Question question)
        {
            Question currentquestion = dbContext.Questions.FirstOrDefault(d => d.QNo == question.QNo);
            if (currentquestion != null)
            {
                currentquestion.QNo = question.QNo;
                currentquestion.Questions = question.Questions;
                currentquestion.Options = question.Options;
                currentquestion.LastModifiedDate = DateTime.Now;

                dbContext.Questions.Update(currentquestion);
                dbContext.SaveChanges();

            }

            return question;
        }

        public void Delete(int questionqno)
        {
            Question currentquestion = dbContext.Questions.FirstOrDefault(d => d.QNo == questionqno);
            if (currentquestion != null)
            {
                currentquestion.DeletedDate = DateTime.Now;
                dbContext.Questions.Update(currentquestion);
                dbContext.SaveChanges();

            }
        }

        public Question FindQuestionByQNo(int qno)
        {
            return dbContext.Questions.Include(d => d.Options).FirstOrDefault(d => d.QNo == qno);
        }

        public Question FindByQuestionName(string question)
        {
            var questionq = dbContext.Questions.Include(d => d.Options).FirstOrDefault(d => d.Questions == question);


            if (question == null)
                throw new Exception($"question does not exist");

            return questionq;
        }
        public List<Question> GetQuestion()
        {

            return dbContext.Questions.Include(d => d.Options).Where(d => d.DeletedDate == null).ToList();
            
        }

        public Question FindById(int id)
        {
            return dbContext.Questions.Include(d => d.Options).FirstOrDefault(d => d.Id == id);
        }
    }
}
