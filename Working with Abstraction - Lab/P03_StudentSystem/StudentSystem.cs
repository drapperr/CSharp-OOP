using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get;set; }
    }
}
