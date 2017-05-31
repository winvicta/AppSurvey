using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSurvey.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionID { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
