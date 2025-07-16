using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem
{
    interface IPerson
    {
        void DisplayInformation();
    }
     class Student:IPerson
    {
        protected string studentName;//מאחסן את שם התלמיד
        protected int studentID;//מאחסן את תעודת הזהות של התלמיד
        protected int age;//מאחסן את גיל התלמיד

        public Student(string studentName,int studentID,int age)// בנאי המאתחל את תכונות המחלקה
        {
            this.studentName = studentName;
            this.studentID = studentID;
            this.age = age;
        }
        
        public string GetStudentName()
        {
            return this.studentName;
        }
        public int GetStudentID()
        {
            return this.studentID;
        }
        public int GetAge()
        {
            return this.age;
        }
        public void SetStudentName(string studentName)
        {
            this.studentName = studentName;
        }
        public void SetStudentID(int studentID)
        {
            this.studentID = studentID;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
         public Tuple<string , int , int > GetStudentInfo()
         {
              return Tuple.Create(studentName, studentID, age);
         }
        public virtual void DisplayInformation()
        {
            Console.WriteLine($"Student Name: {studentName}, ID: {studentID}, Age: {age}");
        }
    }
}
