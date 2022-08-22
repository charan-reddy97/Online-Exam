using Examination.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Repository
{
    public class TestAnswerRepository : ITestAnswerRepository
    {
        AdminDbContext dbContext;
        public TestAnswerRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public TestAnswer Add(TestAnswer testAnswer)
        {
            testAnswer.LastModifiedDate = DateTime.Now;
            dbContext.TestAnswers.Add(testAnswer);
            dbContext.SaveChanges();
            return testAnswer;

        }

        public TestAnswer Update(TestAnswer testAnswer)
        {
            TestAnswer currentTestAnswer = dbContext.TestAnswers.FirstOrDefault(d => d.Id == testAnswer.Id);
            if (currentTestAnswer != null)
            {
               
                currentTestAnswer.Question = testAnswer.Question;
                currentTestAnswer.Student = testAnswer.Student;
                currentTestAnswer.Options = testAnswer.Options;
                currentTestAnswer.LastModifiedDate = DateTime.Now;




                dbContext.TestAnswers.Update(currentTestAnswer);
                dbContext.SaveChanges();

            }

            return testAnswer;
        }

        public void Delete(int testAnswerid)
        {
            TestAnswer currentTestAnswer = dbContext.TestAnswers.FirstOrDefault(d => d.Id == testAnswerid);
            if (currentTestAnswer != null)
            {
                currentTestAnswer.DeletedDate = DateTime.Now;
                dbContext.TestAnswers.Update(currentTestAnswer);
                dbContext.SaveChanges();

            }
        }

        public TestAnswer FindTestAnswerById(int testAnswerid)
        {
            return dbContext.TestAnswers.FirstOrDefault(d => d.Id == testAnswerid);
        }

        public TestAnswer FindByTestAnsweName(string tesAnswerQuestion)
        {
            var testAnswer = dbContext.TestAnswers.FirstOrDefault(d => d.DeletedDate == null);


            if (testAnswer == null)
                throw new Exception($"TestAnswe does not exist");

            return testAnswer;
        }
        public List<TestAnswer> GetTestAnswer()
        {
            return dbContext.TestAnswers.Where(d => d.DeletedDate == null).ToList();
        }
    }
}
