using MatchesConsole.Models;
using MatchesConsole.Services;

namespace MatchesConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> inputLines;

            if (args.Length > 0)
            {
                var filePath = args[0];
                
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"The file '{filePath}' does not exist.");
                    Environment.Exit(1);
                }

                try
                {
                    inputLines = File.ReadAllLines(filePath);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error reading file: {ex.Message}");
                    Environment.Exit(1);

                    return;
                }
            }
            else
            {
                inputLines = ReadFromConsole();
            }

            var leagueService = new LeagueService();

            try
            {
                var ranking = leagueService.CalculateRanking(inputLines);
                PrintRanking(ranking);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error processing data: {ex.Message}");
                Environment.Exit(1);
            }

            Console.Read();
        }

        private static List<string> ReadFromConsole()
        {
            var lines = new List<string>();
            string line;

            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                lines.Add(line);
            }

            return lines;
        }

        private static void PrintRanking(IEnumerable<Team> ranking)
        {
            var currentRank = 1;
            var previousPoints = -1;
            var teamsAtPreviousRank = 0;

            foreach (var team in ranking)
            {
                if (team.Points != previousPoints)
                {
                    currentRank += teamsAtPreviousRank;
                    teamsAtPreviousRank = 1;
                }
                else
                {
                    teamsAtPreviousRank++;
                }

                Console.WriteLine($"{currentRank}. {team.Name}, {team.Points} {(team.Points == 1 ? "pt" : "pts")}");
                previousPoints = team.Points;
            }
        }
    }
}
