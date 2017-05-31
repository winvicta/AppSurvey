using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSurvey.Models.SurveyViewModels
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }
        public int id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        
        public List<Option> Options { get; set; }
        public IEnumerable<OptionType> OptionTypes { get; set; }
    }
}
