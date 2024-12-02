using MatchesConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchesConsole.Services
{
    public interface ILeagueService
    {
        IEnumerable<Team> CalculateRanking(IEnumerable<string> gameResults);
    }
}
