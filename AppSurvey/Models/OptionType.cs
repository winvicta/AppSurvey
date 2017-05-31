using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSurvey.Models
{
    public class OptionType
    {
        public int OptionTypeID { get; set; }
        public int Rank { get; set; }
        public string Type { get; set; }

        public int OptionID { get; set; }
        public Option Option { get; set; }
    }
}
