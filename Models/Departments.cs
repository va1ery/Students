using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Departments
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentNumber { get; set; }
        public string DepartmentManager { get; set; }
        public string DepartmentChairperson { get; set; }
    }
}
