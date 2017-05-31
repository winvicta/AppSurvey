using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppSurvey.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public int QID { get; set; }

        public int RecordID { get; set; }
        public Record Record { get; set; }
    }
}
