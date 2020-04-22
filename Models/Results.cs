using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Results
    {
        public int ResultsId { get; set; }
        public int? StudentId { get; set; }
        public int? AssignmentId { get; set; }
        public double? Score { get; set; }
        public bool Late { get; set; }
    }
}
