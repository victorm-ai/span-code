using MatchesConsole.Models;
using MatchesConsole.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchesConsole.Services
{
    public class LeagueService : ILeagueService
    {
        public IEnumerable<Team> CalculateRanking(IEnumerable<string> gameResults)
        {
            if (gameResults == null)
            {
                throw new ArgumentNullException(nameof(gameResults));
            }

            var teams = new Dictionary<string, Team>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in gameResults)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue; 
                }

                var game = InputParser.ParseGameResult(line);

                if (!teams.ContainsKey(game.TeamA))
                {
                    teams[game.TeamA] = new Team(game.TeamA);
                }

                if (!teams.ContainsKey(game.TeamB))
                {
                    teams[game.TeamB] = new Team(game.TeamB);
                }

                var teamA = teams[game.TeamA];
                var teamB = teams[game.TeamB];

                if (game.ScoreA > game.ScoreB)
                {
                    teamA.Points += 3;
                }
                else if (game.ScoreA < game.ScoreB)
                {
                    teamB.Points += 3;
                }
                else
                {
                    teamA.Points += 1;
                    teamB.Points += 1;
                }
            }

            return teams.Values.OrderBy(t => t).ToList();
        }
    }
}
