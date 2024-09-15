using System;
using System.Collections.Generic;

namespace DotNetCoreApi_Practice.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentGender { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string Standard { get; set; } = null!;
        public string FatherName { get; set; } = null!;
        public string? MobileNumber { get; set; }
    }
}
