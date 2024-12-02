using MatchesConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchesConsole.Utilities
{
    public static class InputParser
    {
        private static readonly Regex GameResultRegex = new Regex(@"^(?<TeamA>.+?)\s+(?<ScoreA>\d+),\s+(?<TeamB>.+?)\s+(?<ScoreB>\d+)$",
                                                            RegexOptions.Compiled);

        public static GameResult ParseGameResult(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("The input cannot be empty.", nameof(input));
            }

            var match = GameResultRegex.Match(input);

            if (!match.Success)
            {
                throw new FormatException($"Invalid line format: '{input}'");
            }

            return new GameResult
            {
                TeamA = match.Groups["TeamA"].Value.Trim(),
                ScoreA = int.Parse(match.Groups["ScoreA"].Value),
                TeamB = match.Groups["TeamB"].Value.Trim(),
                ScoreB = int.Parse(match.Groups["ScoreB"].Value)
            };
        }
    }
}
