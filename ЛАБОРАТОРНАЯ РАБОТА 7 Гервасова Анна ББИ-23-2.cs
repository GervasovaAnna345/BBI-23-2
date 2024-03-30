//задание 1
using System;
using System.Collections.Generic;

class Participant
{
    public string LastName { get; set; }
    public string Group { get; set; }
    public string TeacherLastName { get; set; }
    public double ResultInSeconds { get; set; }
    public bool Norm { get; set; }

    public Participant(string lastName, string group, string teacherLastName, double resultInSeconds)
    {
        LastName = lastName;
        Group = group;
        TeacherLastName = teacherLastName;
        ResultInSeconds = resultInSeconds;
        Norm = resultInSeconds <= 300;
    }

    public virtual void PrintResult()
    {
        Console.WriteLine($"{LastName}\t{Group}\t{TeacherLastName}\t{ResultInSeconds}\t{(Norm ? "Да" : "Нет")}");
    }
}

class WomanRunner : Participant
{
    public WomanRunner(string lastName, string group, string teacherLastName, double resultInSeconds)
        : base(lastName, group, teacherLastName, resultInSeconds)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<WomanRunner> womenRunners = new List<WomanRunner>();

        
        womenRunners.Add(new WomanRunner("Перекресткова", "Группа 1", "Петрова", 290));
        womenRunners.Add(new WomanRunner("Пятерочкина", "Группа 2", "Сидорова", 310));

        
        womenRunners.Sort((x, y) => x.ResultInSeconds.CompareTo(y.ResultInSeconds));

        
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");
        foreach (var womanRunner in womenRunners)
        {
            womanRunner.PrintResult();
        }

        
        int countNorm = womenRunners.Count(wr => wr.Norm);
        Console.WriteLine($"Количество участниц, выполнивших норматив: {countNorm}");
    }
}
//задание 2
using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Exam1 { get; set; }
    public int Exam2 { get; set; }
    public int Exam3 { get; set; }
    public int Exam4 { get; set; }

    public Student(string name, int exam1, int exam2, int exam3, int exam4)
    {
        Name = name;
        Exam1 = exam1;
        Exam2 = exam2;
        Exam3 = exam3;
        Exam4 = exam4;
    }

    public virtual double CalculateAverage()
    {
        return (Exam1 + Exam2 + Exam3 + Exam4) / 4.0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{Name}\t{Exam1}\t{Exam2}\t{Exam3}\t{Exam4}\t{CalculateAverage()}");
    }
}

class HighPerformanceStudent : Student
{
    public HighPerformanceStudent(string name, int exam1, int exam2, int exam3, int exam4)
        : base(name, exam1, exam2, exam3, exam4)
    {
    }

    public override double CalculateAverage()
    {
        return base.CalculateAverage();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<HighPerformanceStudent> highPerformanceStudents = new List<HighPerformanceStudent>();

        
        highPerformanceStudents.Add(new HighPerformanceStudent("<Булочкин", 4, 5, 4, 4));
        highPerformanceStudents.Add(new HighPerformanceStudent("Фанточкин", 5, 5, 4, 3));

        
        var filteredStudents = highPerformanceStudents.Where(s => s.CalculateAverage() >= 4).OrderByDescending(s => s.CalculateAverage());

        
        Console.WriteLine("Имя\tЭкзамен 1\tЭкзамен 2\tЭкзамен 3\tЭкзамен 4\tСредний балл");
        foreach (var student in filteredStudents)
        {
            student.PrintInfo();
        }
    }
}
//задание 3
using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    public string Name { get; set; }
    public int StagePoints { get; set; }

    public Team(string name, int stagePoints)
    {
        Name = name;
        StagePoints = stagePoints;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{Name}\t{StagePoints}");
    }
}

class TopTeam : Team
{
    public TopTeam(string name, int stagePoints)
        : base(name, stagePoints)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<TopTeam> topTeams = new List<TopTeam>();

        
        topTeams.Add(new TopTeam("Team A", 20));
        topTeams.Add(new TopTeam("Team B", 18));
        topTeams.Add(new TopTeam("Team C", 25));
        topTeams.Add(new TopTeam("Team D", 15));
        topTeams.Add(new TopTeam("Team E", 22));
        topTeams.Add(new TopTeam("Team F", 17));
        topTeams.Add(new TopTeam("Team G", 23));
        topTeams.Add(new TopTeam("Team H", 19));
        topTeams.Add(new TopTeam("Team I", 21));
        topTeams.Add(new TopTeam("Team J", 24));
        topTeams.Add(new TopTeam("Team K", 16));
        topTeams.Add(new TopTeam("Team L", 20));

        
        var selectedTeams = topTeams.OrderByDescending(t => t.StagePoints).Take(6);

        
        Console.WriteLine("Команда\tОчки первого этапа");
        foreach (var team in selectedTeams)
        {
            team.PrintInfo();
        }
    }
}

