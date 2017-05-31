using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppSurvey.Models
{
    public class Record
    {
        public int RecordID { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StudentNumber { get; set; }

        public string Date { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
