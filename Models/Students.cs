using System;
using System.Collections.Generic;

namespace StudentsDB.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentsNames { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailName { get; set; }
        public string Major { get; set; }
        public string StudentNumber { get; set; }
        public string Notes { get; set; }
    }
}
