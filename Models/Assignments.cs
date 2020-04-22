using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Assignments
    {
        public int AssignmentId { get; set; }
        public string AssignmentDescription { get; set; }
        public int ClassId { get; set; }
        public bool Exam { get; set; }
        public double? PercentOfGrade { get; set; }
        public float MaximumPoints { get; set; }
    }
}
