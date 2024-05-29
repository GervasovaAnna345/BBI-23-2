using Lab9_12.Serializator;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[ProtoContract]
[XmlInclude(typeof(Student)), ProtoInclude(1, typeof(Student))]
public class Person
{
    [XmlAttribute("FullName")]
    [ProtoMember(2)]
    public string FullName { get; set; }

    public Person() { }
    public Person(string fullName)
    {
        FullName = fullName;
    }
}

[ProtoContract]
public class Student : Person
{
    [XmlAttribute("StudentID")]
    [ProtoMember(3)]
    public int StudentID { get; set; }
    [XmlAttribute("AverageGrade")]
    [ProtoMember(4)]
    public double AverageGrade { get; set; }

    public Student() { }
    public Student(string fullName, int studentID, double averageGrade) : base(fullName)
    {
        StudentID = studentID;
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
        students.Add(new Student("Булочкин Вася", 12345, 4.2));
        students.Add(new Student("Фанточкин Саша", 54321, 3.8));
        students.Add(new Student("Ёлочкина Люся", 98765, 4.5));
        students.Add(new Student("Овечкина Оля", 67890, 3.9));

        Console.WriteLine("ФИО\t\t\t№ студ. билета\tСредний балл");
        string path = @"C:\Users\user\Desktop"; //путь до рабочего стола
        string folderName = "Test";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        Serialize[] mySerializers = [
            new Json(),
                new Xml(),
                new Bin()];
        string[] file_names = new string[]
        {
                "result.json",
                "result.xml",
                "result.bin"
        };

        for (int i = 0; i < mySerializers.Length; i++)
        {
            System.IO.File.WriteAllText(Path.Combine(path, file_names[i]), string.Empty);
            mySerializers[i].Write<Student[]>(students.ToArray(), Path.Combine(path, file_names[i]));
        }
        for (int i = 0; i < mySerializers.Length; i++)
        {
            var answer = mySerializers[i].Read<Student[]> (Path.Combine(path, file_names[i]));
            foreach (var student in answer)
            {
                student.PrintInfo();
            }
        }

    }
}