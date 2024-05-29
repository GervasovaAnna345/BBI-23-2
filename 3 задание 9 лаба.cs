using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static LR9_13.Serializaztor.Serializator;

[Serializable]
[ProtoContract]
[XmlInclude(typeof(WomenFootballTeam)), ProtoInclude(1, typeof(WomenFootballTeam))]
[XmlInclude(typeof(MenFootballTeam)), ProtoInclude(2, typeof(MenFootballTeam))]
public class FootballTeam
{
    [XmlAttribute("TeamName")]
    [ProtoMember(3)]
    public string TeamName { get; set; }
    [XmlAttribute("Points")]
    [ProtoMember(4)]
    public int Points { get; set; }
    [XmlIgnore]
    [JsonIgnore]
    [ProtoIgnore]
    public string Gender { get; set; }

    public FootballTeam() { }
    [JsonConstructor]
    public FootballTeam(string teamName, int points)
    {
        TeamName = teamName;
        Points = points;
    }
}

[ProtoContract]
public class WomenFootballTeam : FootballTeam
{    
    [JsonConstructor]
    public WomenFootballTeam(string teamName, int points) : base(teamName, points)
    {
        Gender = "женская";
    }
    public WomenFootballTeam() { }

}

[ProtoContract]
public class MenFootballTeam : FootballTeam
{
    [JsonConstructor]
    public MenFootballTeam(string teamName, int points) : base(teamName, points)
    {
        Gender = "мужская";
    }
    public MenFootballTeam() { }
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


        var topTeams = topWomenTeams.Cast<FootballTeam>().Union(topMenTeams.Cast<FootballTeam>()).OrderByDescending(t => t.Points).ToArray();

        Console.WriteLine("Рейтинг команд:");
        int rank = 1;
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
            mySerializers[i].Write<FootballTeam[]>(topTeams, Path.Combine(path, file_names[i]));
        }

        for (int i = 0; i < mySerializers.Length; i++)
        {
            var answer = mySerializers[i].Read<FootballTeam[]>(Path.Combine(path, file_names[i]));
            foreach (var team in answer)
            {
                Console.WriteLine($"{rank}. {team.TeamName} {team.Gender} команда {team.Points} очков");
                rank++;
            }
        }
    }
}