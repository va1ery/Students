using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Instructors
    {
        public int InstructorId { get; set; }
        public string Instructor { get; set; }
        public string EmailName { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
    }
}
