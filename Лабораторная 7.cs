using System;
using System.Collections.Generic;

class Person
{
    public string FullName { get; }

    public Person(string fullName)
    {
        FullName = fullName;
    }
}

class Student : Person
{
    private static int nextStudentID = 10000;
    public int StudentID { get; }
    public double AverageGrade { get; }

    public Student(string fullName, double averageGrade) : base(fullName)
    {
        StudentID = nextStudentID++;
        AverageGrade = averageGrade;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{FullName}\t{StudentID}\t{AverageGrade}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Булочкин Вася", 4.2));
        students.Add(new Student("Фанточкин Саша", 3.8));
        students.Add(new Student("Ёлочкина Люся", 4.5));
        students.Add(new Student("Овечкина Оля", 3.9));

        Console.WriteLine("ФИО\t\t\t№ студ. билета\tСредний балл");
        foreach (var student in students)
        {
            student.PrintInfo();
        }
    }
}