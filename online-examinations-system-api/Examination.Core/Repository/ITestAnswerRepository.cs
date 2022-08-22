using Examination.Core.Entities;
using System.Collections.Generic;

namespace Examination.Core.Repository
{
    public interface ITestAnswerRepository
    {
        TestAnswer Add(TestAnswer testAnswer);
        void Delete(int testAnswerid);
        TestAnswer FindByTestAnsweName(string tesAnswerQuestion);
        TestAnswer FindTestAnswerById(int testAnswerid);
        List<TestAnswer> GetTestAnswer();
        TestAnswer Update(TestAnswer testAnswer);
    }
}