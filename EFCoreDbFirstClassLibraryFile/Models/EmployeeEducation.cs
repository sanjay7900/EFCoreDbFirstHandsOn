﻿using System;
using System.Collections.Generic;

namespace EFCoreDbFirstClassLibraryFile.Models
{
    public partial class EmployeeEducation
    {
        public int EduId { get; set; }
        public string? EducationName { get; set; }
        public int? EmpId { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}
