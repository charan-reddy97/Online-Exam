using Examination.Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Repository
{
    public class OptionsRepository : IOptionsRepository
    {


        AdminDbContext dbContext;
        public OptionsRepository(AdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public Option Add(Option option)
        {

            option.CreatedDate = DateTime.Now;
            dbContext.Options.Add(option);
            dbContext.SaveChanges();
            return option;
        }
        public Option Update(Option option)
        {
            Option currentOption = dbContext.Options.FirstOrDefault(d => d.Id == option.Id);
            if (currentOption != null)
            {

                currentOption.Title = option.Title;
                currentOption.IsCorrectAns = option.IsCorrectAns;
                currentOption.LastModifiedDate = DateTime.Now;




                dbContext.Options.Update(currentOption);
                dbContext.SaveChanges();

            }

            return option;
        }

        public void Delete(int optionid)
        {
            Option currentOption = dbContext.Options.FirstOrDefault(d => d.Id == optionid);
            if (currentOption != null)
            {
                currentOption.DeletedDate = DateTime.Now;
                dbContext.Options.Update(currentOption);
                dbContext.SaveChanges();

            }
        }

        public Option FindOptionById(int optionsid)
        {
            return dbContext.Options.FirstOrDefault(d => d.Id == optionsid);
        }

        public Option FindByOptionTitle(string title)
        {
            var option = dbContext.Options.FirstOrDefault(d => d.Title == title);


            if (option == null)
                throw new Exception($"option does not exist");

            return option;
        }
        public List<Option> GetOption()
        {
            return dbContext.Options.Where(d => d.DeletedDate == null).ToList();
        }


    }
}
