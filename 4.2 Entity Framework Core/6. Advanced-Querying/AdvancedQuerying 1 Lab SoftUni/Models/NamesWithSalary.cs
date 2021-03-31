using System;
using System.Collections.Generic;

#nullable disable

namespace AdvancedQuerying_1_Lab_SoftUni.Models
{
    public partial class NamesWithSalary
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
    }
}
