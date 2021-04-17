using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CumulativeProject2.Models
{
    public class Teacher
    {
        //The following fields define the teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string TeacherEmployeeNum;
        public DateTime TeacherHireDate;
        public Decimal TeacherSalary;

        //parameter-less constructor function
        public Teacher() { }
    }
}