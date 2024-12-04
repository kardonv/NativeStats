using static System.Formats.Asn1.AsnWriter;

namespace NativeStats.Models
{
    public class Match
    {
        public Area Area { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public int Id { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }
        public Odds Odds { get; set; }
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class Season
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public object Winner { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Crest { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public ScoreDetails FullTime { get; set; }
        public ScoreDetails HalfTime { get; set; }
    }

    public class ScoreDetails
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
    }

    public class Odds
    {
        public string Msg { get; set; }
    }
}
