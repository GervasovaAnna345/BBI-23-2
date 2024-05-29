using LR9_1.Serialize;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;


[Serializable]
[ProtoContract]
[XmlInclude(typeof(FiveHundredMeterRunner)), ProtoInclude(1, typeof(FiveHundredMeterRunner))]
[XmlInclude(typeof(OneHundredMeterRunner)), ProtoInclude(2, typeof(OneHundredMeterRunner))]
public abstract class Runner
{
    [ProtoMember(3)]
    [XmlAttribute("LastName")]
    public string LastName { get; set; }
    [ProtoMember(4)]
    [XmlAttribute("Group")]
    public string Group { get; set; }
    [ProtoMember(5)]
    [XmlAttribute("TeacherLastName")]
    public string TeacherLastName { get; set; }
    [ProtoMember(6)]
    [XmlAttribute("Result")]
    public  double Result { get; set; }
    [JsonIgnore]
    [XmlIgnore]
    [ProtoIgnore]
    public bool Norm => Result <= 300; 
    

    [JsonConstructor]
    public Runner(string lastName, string group, string teacherLastName)
    {
        LastName = lastName;
        Group = group;
        TeacherLastName = teacherLastName;
    }
        
    public Runner() { }
    public abstract void PrintResult();
}

[ProtoContract]
public class FiveHundredMeterRunner : Runner
{
    [JsonConstructor]
    public FiveHundredMeterRunner(string lastName, string group, string teacherLastName, double result)
        : base(lastName, group, teacherLastName)
    {
        Result = result;
    }

    public FiveHundredMeterRunner() { }

    public override void PrintResult()
    {
        Console.WriteLine($"{LastName}\t{Group}\t{TeacherLastName}\t{Result}\t{(Norm ? "Да" : "Нет")}");
    }
}

[ProtoContract]
public class OneHundredMeterRunner : Runner
{
    [JsonConstructor]
    public OneHundredMeterRunner(string lastName, string group, string teacherLastName, double result)
        : base(lastName, group, teacherLastName)
    {
        Result = result;
    }

    public OneHundredMeterRunner() { }

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


        var fiveHundredMetersRunners = runners.OfType<FiveHundredMeterRunner>().OrderBy(r => r.Result).ToArray();
        var oneHundredMetersRunners = runners.OfType<OneHundredMeterRunner>().OrderBy(r => r.Result).ToArray();


        Console.WriteLine("500 м:");
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");
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
            mySerializers[i].Write<FiveHundredMeterRunner[]>(fiveHundredMetersRunners, Path.Combine(path, file_names[i]));
        }

        for (int i = 0; i < mySerializers.Length; i++)
        {
            var answer = mySerializers[i].Read<FiveHundredMeterRunner[]>(Path.Combine(path, file_names[i]));
            foreach(var runner in answer)
            {
                runner.PrintResult();
            }
        }
        Console.WriteLine();

        Console.WriteLine("100 м:");
        Console.WriteLine("Фамилия\tГруппа\tПреподаватель\tРезультат\tНорматив");

        for (int i = 0; i < mySerializers.Length; i++)
        {
            System.IO.File.WriteAllText(Path.Combine(path, file_names[i]), string.Empty);
            mySerializers[i].Write<OneHundredMeterRunner[]>(oneHundredMetersRunners, Path.Combine(path, file_names[i]));
        }

        for (int i = 0; i < mySerializers.Length; i++)
        {
            var answer = mySerializers[i].Read<OneHundredMeterRunner[]>(Path.Combine(path, file_names[i]));
            foreach (var runner in answer)
            {
                runner.PrintResult();
            }
        }


        int countNorm = runners.Count(r => r.Norm);
        Console.WriteLine($"Суммарное количество участниц, выполнивших норматив: {countNorm}");
    }
}
