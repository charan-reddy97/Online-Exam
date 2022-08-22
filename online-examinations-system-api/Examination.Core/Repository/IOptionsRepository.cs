using Examination.Core.Entities;
using System.Collections.Generic;

namespace Examination.Core.Repository
{
    public interface IOptionsRepository
    {
        Option Add(Option option);
        void Delete(int optionid);
        Option FindByOptionTitle(string title);
        Option FindOptionById(int optionsid);
        List<Option> GetOption();
        Option Update(Option option);
    }
}