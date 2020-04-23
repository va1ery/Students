using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Classes
    {
        public Classes()
        {
            StudentsAndClasses = new HashSet<StudentsAndClasses>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int? DepartmentId { get; set; }
        public short? Section { get; set; }
        public int? InstructorId { get; set; }
        public string Term { get; set; }
        public string Units { get; set; }
        public short? Year { get; set; }
        public string Location { get; set; }
        public string DaysAndTimes { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<StudentsAndClasses> StudentsAndClasses { get; set; }
    }
}
