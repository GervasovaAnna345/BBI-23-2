using System;
using System.Collections.Generic;
using System.Linq;


abstract class Runner
{
    public string LastName { get; }
    public string Group { get; }
    public string TeacherLastName { get; }
    public abstract double Result { get; }
    public bool Norm => Result <= 300; 

    public Runner(string lastName, string group, string teacherLastName)
    {
        LastName = lastName;
        Group = group;
        TeacherLastName = teacherLastName;
    }

    public abstract void PrintResult();
}


class FiveHundredMeterRunner : Runner
{
    public override double Result { get; }

    public FiveHundredMeterRunner(string lastName, string group, string teacherLastName, double result)
        : base(lastName, group, teacherLastName)
    {
        Result = result;
    }

    public override void PrintResult()
    {
        Console.WriteLine($"{LastName}\t{Group}\t{TeacherLastName}\t{Result}\t{(Norm ? "Да" : "Нет")}");
    }
}

class OneHundredMeterRunner : Runner
{
    public override double Result { get; }

    public OneHundredMeterRunner(string lastName, string group, string teacherLastName, double result)
        : base(lastName, group, teacherLastName)
    {
        Result = result;
    }

    public override void PrintResult()
    {
        Console.WriteLine($"{LastName}\t{Group}\t{TeacherLastName}\t{Result}\t{(Norm ? "Да" : "Нет")}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Runner> runners = new List<Runner>();

        
        runners.Add(new FiveHundredMeterRunner("Бутылочкина", "Группа 1", "Петрова", 290));
        runners.Add(new FiveHundredMeterRunner("Кулакова", "Группа 2", "Сидорова", 310));

        
        runners.Add(new OneHundredMeterRunner("Тетрадкина", "Группа 1", "Иванова", 95));
        runners.Add(new OneHundredMeterRunner("Ручкина", "Группа 2", "Петрова", 110));

        
        var fiveHundredMetersRunners = runners.OfType<FiveHundredMeterRunner>().OrderBy(r => r.Result);
        var oneHundredMetersRunners = runners.OfType<OneHundredMeterRunner>().OrderBy(r => r.Result);

        
        Console.WriteLine("500 м:");
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");
        foreach (var runner in fiveHundredMetersRunners)
        {
            runner.PrintResult();
        }

        Console.WriteLine();

        Console.WriteLine("100 м:");
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");
        foreach (var runner in oneHundredMetersRunners)
        {
            runner.PrintResult();
        }

        
        int countNorm = runners.Count(r => r.Norm);
        Console.WriteLine($"Суммарное количество участниц, выполнивших норматив: {countNorm}");
    }
}




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
    public int StudentID { get; }
    public double AverageGrade { get; }

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
        foreach (var student in students)
        {
            student.PrintInfo();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

abstract class FootballTeam
{
    public string TeamName { get; }
    public int Points { get; }

    public abstract string GetGender();

    public FootballTeam(string teamName, int points)
    {
        TeamName = teamName;
        Points = points;
    }
}

class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(string teamName, int points) : base(teamName, points)
    {
    }

    public override string GetGender()
    {
        return "женская";
    }
}

class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(string teamName, int points) : base(teamName, points)
    {
    }

    public override string GetGender()
    {
        return "мужская";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<FootballTeam> allTeams = new List<FootballTeam>();
        allTeams.Add(new WomenFootballTeam("ЦСКА", 13));
        allTeams.Add(new MenFootballTeam("Динамо", 12));
        allTeams.Add(new MenFootballTeam("Спартак", 10));
        allTeams.Add(new WomenFootballTeam("Зенит", 11));

        
        var topWomenTeams = allTeams.OfType<WomenFootballTeam>().OrderByDescending(t => t.Points).Take(6);
        var topMenTeams = allTeams.OfType<MenFootballTeam>().OrderByDescending(t => t.Points).Take(6);

        
        var topTeams = topWomenTeams.Cast<FootballTeam>().Union(topMenTeams.Cast<FootballTeam>()).OrderByDescending(t => t.Points);

        Console.WriteLine("Рейтинг команд:");
        int rank = 1;
        foreach (var team in topTeams)
        {
            Console.WriteLine($"{rank}. {team.TeamName} {team.GetGender()} команда {team.Points} очков");
            rank++;
        }
    }
}

