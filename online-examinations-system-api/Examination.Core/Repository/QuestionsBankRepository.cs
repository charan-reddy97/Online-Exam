
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Core;
using Examination.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examination.Core.Repository
{
    public class QuestionsBankRepository : IQuestionsBankRepository
    {
        AdminDbContext dbContext;
        public QuestionsBankRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public QuestionsBank Add(QuestionsBank questionsBank)
        {
            questionsBank.CreatedDate = DateTime.Now;
            dbContext.QuestionBanks.Add(questionsBank);
            dbContext.SaveChanges();
            return questionsBank;
        }
        public void Delete(int qnum)
        {
            QuestionsBank questionsBank = dbContext.QuestionBanks.FirstOrDefault(d => d.QNum == qnum);
            questionsBank.DeletedDate = DateTime.Now;
            dbContext.Update(questionsBank);
            dbContext.SaveChanges();
        }

        public QuestionsBank FindById(int id)
        {
            return dbContext.QuestionBanks.Include(d => d.Questions1)
                                          .ThenInclude(d => d.Options)
                                          .FirstOrDefault(d => d.Id == id);
        }

        public QuestionsBank FindByQuestionsTitle(string qtitle)
        {
            return dbContext.QuestionBanks.FirstOrDefault(d => d.DeletedDate == null && d.QTitle == qtitle);
        }
        public QuestionsBank FindQuestionsByQNum(int qnum)
        {
            var questionsBank = dbContext.QuestionBanks.FirstOrDefault(d => d.QNum == qnum);
            if (questionsBank == null)
                throw new Exception($"Item with the QNum : {qnum} cannot be found");
            return questionsBank;
        }
        public List<QuestionsBank> GetQuestionBank()
        {
            return dbContext.QuestionBanks.Where(d => d.DeletedDate == null).ToList();
        }

        public QuestionsBank Update(QuestionsBank questionsBank)
        {
            //QuestionsBank currentQuestionsbank = dbContext.QuestionBanks.FirstOrDefault(d => d.QNum == d.QNum);
            //currentQuestionsbank.QTitle = questionsBank.QTitle;
            //currentQuestionsbank.QNum = questionsBank.QNum;
            //currentQuestionsbank.LastModifiedDate = DateTime.Now;
            //currentQuestionsbank.Questions1 = questionsBank.Questions1;

            questionsBank.LastModifiedDate = DateTime.Now;

            dbContext.Update(questionsBank);
            dbContext.SaveChanges();
            return questionsBank;
        }
    }
}

