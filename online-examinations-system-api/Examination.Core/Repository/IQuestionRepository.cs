using Examination.Core.Entities;
using System.Collections.Generic;

namespace Examination.Core.Repository
{
    public interface IQuestionRepository
    {
        Question Add(Question question);
        void Delete(int questionqno);
        Question FindByQuestionName(string question);
        Question FindQuestionByQNo(int qno);
        List<Question> GetQuestion();
        Question Update(Question question);
        Question FindById(int id);
    }
}