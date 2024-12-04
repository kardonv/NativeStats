namespace NativeStats.Models
{
    public class FootballApiResponse
    {
        //public Filters Filters { get; set; }
        //public ResultSet ResultSet { get; set; }
        //public Competition Competition { get; set; }
        public List<Match> Matches { get; set; }
    }

    public class Filters
    {
        public string Season { get; set; }
        public List<string> Status { get; set; }
    }

    public class ResultSet
    {
        public int Count { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Played { get; set; }
    }

    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Emblem { get; set; }
    }
}
