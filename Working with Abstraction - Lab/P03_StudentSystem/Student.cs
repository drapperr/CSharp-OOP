namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public override string ToString()
        {
            string view = $"{this.Name} is {this.Age} years old. ";

            if (this.Grade >= 5.00)
            {
                view += "Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                view += "Average student.";
            }
            else
            {
                view += "Very nice person.";
            }

            return view;
        }
    }
}