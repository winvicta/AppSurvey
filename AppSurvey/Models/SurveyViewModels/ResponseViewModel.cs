using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSurvey.Models.SurveyViewModels
{
    public class ResponseViewModel
    {
        public List<QA> QAs { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
    }

    public class QA
    {
        public string qText { get; set; }
        public List<string> aCates { get; set; }
        public string aText { get; set; }
    }
}
