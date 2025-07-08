using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem
{
    class CollegeStudent : Student
    {
        protected string subject;
        protected int avg;
        public CollegeStudent(string subject, int avg, string studentName, int studentID, int age):
            base(studentName, studentID, age)
        {
            this.subject = subject;
            this.avg = avg;
        }
        public string GetSubject()
        {
            return this.subject;
        }
        public int GetAvg()
        {
            return this.avg;
        }
        public void SetSubject(string subject)
        {
            this.subject = subject;
        }
        public void SetAvg(int avg)
        {
            this.avg = avg;
        }
        public override void DisplayInformation()
        {
            Console.WriteLine($"College Student Name: {studentName}, ID: {studentID}, Age: {age}, Subject: {subject}, Average: {avg}");
        }
        
    }
}
