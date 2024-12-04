using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NativeStats.Models;
using NativeStats.Services;

namespace NativeStats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FootballDataService _footballService;
        public readonly List<League> LeagueList;

        public IndexModel(ILogger<IndexModel> logger, FootballDataService footballService)
        {
            _logger = logger;
            _footballService = footballService;
            LeagueList = new List<League>()
            {
                   new League() { Name = "Primeira Liga (Portugal)", Code = "PPL" },
                   new League() { Name = "Premier League (England)", Code = "PL" },
                   new League() { Name = "Eredivisie (Netherlands)", Code = "DED" },
                   new League() { Name = "Bundesliga (Germany)", Code = "BL1" },
                   new League() { Name = "Serie A (Italy)", Code = "SA" },
                   new League() { Name = "La Liga (Spain)", Code = "PD" },
                   new League() { Name = "Serie A (Brazil)", Code = "BSA" }
            };
        }

        public async Task OnGetAsync(string status = "scheduled")
        {
            var competitionCodes = new List<string>();

            foreach (var league in LeagueList)
            {
                var matches = await _footballService.GetMatchesAsync(league.Code, status);
                league.Matches = matches;
                league.HasMatches = matches?.Count > 0;
            }
        }

        public IActionResult OnPostRegister()
        {
            return RedirectToPage("Index");
        }

        public IActionResult OnPostLogin()
        {
            return RedirectToPage("Index");
        }
    }
}
