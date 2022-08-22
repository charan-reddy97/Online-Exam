using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Core.Entities
{
  public abstract  class Base
    {
        [Key]
        public int Id { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
