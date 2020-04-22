using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class StudentsAndClasses
    {
        public int StudentClassId { get; set; }
        public int ClassId { get; set; }
        public int? StudentId { get; set; }
        public string Grade { get; set; }
    }
}
