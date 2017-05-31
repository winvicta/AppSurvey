using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSurvey.Models
{
    public class Option
    {
        public int OptionID { get; set; }
        public int Rank { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public ICollection<OptionType> OptionTypes { get; set; }
    }
}
