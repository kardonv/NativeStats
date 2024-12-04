namespace NativeStats.Models
{
    public class League
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool HasMatches { get; set; }
        public List<Match> Matches { get; set; } = new();
    }
}
