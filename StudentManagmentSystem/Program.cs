using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IPerson> students = new List<IPerson>();
            while (true)
            {

                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add new student (regular or college)");
                Console.WriteLine("2. Edit student details by ID");
                Console.WriteLine("3. Display all students or specific student");
                Console.WriteLine("0. Exit");
                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                if (choice == "1")
                {
                    Console.Write("Enter student type (1 = Regular, 2 = College): ");
                    string type = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());

                    if (type == "1")
                    {
                        Student s = new Student(name, id, age);
                        students.Add(s);
                        Console.WriteLine("Regular student added.");
                    }
                    else if (type == "2")
                    {
                        Console.Write("Field of subject: ");
                        string subject = Console.ReadLine();
                        Console.Write(" Average grade: ");
                        int avg = int.Parse(Console.ReadLine());

                        CollegeStudent cs = new CollegeStudent(subject, avg, name, id, age);
                        students.Add(cs);
                        Console.WriteLine("College student added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid student type.");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter student ID to update: ");
                    int searchID = int.Parse(Console.ReadLine());
                    bool found = false;

                    foreach (IPerson p in students)
                    {
                        if (p is Student s && s.GetStudentID() == searchID)
                        {
                            while (true)
                            {
                                Console.WriteLine("\nWhat would you like to update?");
                                Console.WriteLine("1. Name");
                                Console.WriteLine("2. Age");

                                if (s is CollegeStudent)
                                {
                                    Console.WriteLine("3. Subject");
                                    Console.WriteLine("4. Average");
                                }

                                Console.WriteLine("0. Cancel");
                                Console.Write(">> ");
                                string option = Console.ReadLine();

                                if (option == "0")
                                    break;

                                if (option == "1")
                                {
                                    Console.Write("Enter new name: ");
                                    s.SetStudentName(Console.ReadLine());
                                    Console.WriteLine("Name updated.");
                                }
                                else if (option == "2")
                                {
                                    Console.Write("Enter new age: ");
                                    s.SetAge(int.Parse(Console.ReadLine()));
                                    Console.WriteLine("Age updated.");
                                }
                                else if (option == "3" && s is CollegeStudent cs)
                                {
                                    Console.Write("Enter new subject: ");
                                    cs.SetSubject(Console.ReadLine());
                                    Console.WriteLine("Subject updated.");
                                }
                                else if (option == "4" && s is CollegeStudent cs2)
                                {
                                    Console.Write("Enter new average: ");
                                    cs2.SetAvg(int.Parse(Console.ReadLine()));
                                    Console.WriteLine("Average updated.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }

                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (choice == "3")
                {
                    if (students.Count == 0)
                        Console.WriteLine("No students to display.");
                    else
                    {
                        Console.WriteLine("Enter 1 to diplay all students information And 2 to diplay specific student inforamtion");
                        string decision = Console.ReadLine();
                        if (decision == "1")
                        {
                            Console.WriteLine("\n--- All Students ---");
                            foreach (IPerson p in students)
                            {
                                p.DisplayInformation();
                            }
                        }
                        else if (decision == "2")
                        {
                            Console.Write("Enter the name of the student whose details you would like to view: ");
                            string searchName = Console.ReadLine();
                            bool flag = false;

                            foreach (IPerson p in students)
                            {
                                if (p is Student s && s.GetStudentName().Equals(searchName, StringComparison.OrdinalIgnoreCase))
                                {
                                    p.DisplayInformation();
                                    flag = true;
                                    break;
                                }
                            }

                            if (!flag)
                            {
                                Console.WriteLine("Student not found.");
                            }
                        }
                    }
                }
            }
        }
    }
}