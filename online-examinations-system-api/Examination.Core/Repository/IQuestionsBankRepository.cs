using Examination.Core.Entities;
using System.Collections.Generic;

namespace Examination.Core.Repository
{
    public interface IQuestionsBankRepository
    {
        QuestionsBank Add(QuestionsBank questionsBank);
        void Delete(int qnum);
        QuestionsBank FindByQuestionsTitle(string qtitle);
        QuestionsBank FindQuestionsByQNum(int qnum);
        List<QuestionsBank> GetQuestionBank();
        QuestionsBank Update(QuestionsBank questionsBank);
        QuestionsBank FindById(int id);
    }
}