using MatchesConsole.Models;
using MatchesConsole.Services;

namespace MatchesUnitTests
{
    [TestFixture]
    public class Tests
    {
        private ILeagueService _leagueService;

        [SetUp]
        public void SetUp()
        {
            _leagueService = new LeagueService();
        }

        [Test]
        public void CalculateRanking_ShouldReturnCorrectRanking()
        {
            // Arrange
            var input = new List<string>
            {
                "Lions 3, Snakes 3",
                "Tarantulas 1, FC Awesome 0",
                "Lions 1, FC Awesome 1",
                "Tarantulas 3, Snakes 1",
                "Lions 4, Grouches 0"
            };

            // Act
            var ranking = _leagueService.CalculateRanking(input).ToList();

            // Assert
            var expected = new List<Team>
            {
                new Team("Tarantulas") { Points = 6 },
                new Team("Lions") { Points = 5 },
                new Team("FC Awesome") { Points = 1 },
                new Team("Snakes") { Points = 1 },
                new Team("Grouches") { Points = 0 }
            };

            Assert.That(expected.Count, Is.EqualTo(ranking.Count), "The number of teams in the ranking does not match.");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(expected[i].Name, Is.EqualTo(ranking[i].Name), $"The name of the team in the position {i + 1} does not match.");
                Assert.That(expected[i].Points, Is.EqualTo(ranking[i].Points), $"The team's points '{expected[i].Name}' does not match.");
            }
        }

        [Test]
        public void CalculateRanking_ShouldHandleEmptyInput()
        {
            // Arrange
            var input = new List<string>();

            // Act
            var ranking = _leagueService.CalculateRanking(input);

            // Assert
            Assert.IsEmpty(ranking, "The ranking should not contain teams for an empty entry.");
        }

        [Test]
        public void CalculateRanking_ShouldThrowException_OnInvalidInputFormat()
        {
            // Arrange
            var input = new List<string>
            {
                "Invalid Input Line"
            };

            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => _leagueService.CalculateRanking(input).ToList());
            Assert.That(ex.Message, Does.Contain("Invalid line format"));
        }

        [Test]
        public void CalculateRanking_ShouldIgnoreEmptyLines()
        {
            // Arrange
            var input = new List<string>
            {
                "Lions 3, Snakes 3",
                "",
                "Tarantulas 1, FC Awesome 0"
            };

            // Act
            var ranking = _leagueService.CalculateRanking(input).ToList();

            // Assert           
            Assert.That(ranking.Count, Is.EqualTo(4), "The ranking must contain 4 teams.");

            Assert.IsTrue(ranking.Any(t => t.Name == "Lions" && t.Points == 1), "It should hold the ‘Lions’ team to 1 point.");
            Assert.IsTrue(ranking.Any(t => t.Name == "Snakes" && t.Points == 1), "It should hold the ‘Snakes’ team to 1 point.");
            Assert.IsTrue(ranking.Any(t => t.Name == "Tarantulas" && t.Points == 3), "It should hold the ‘Tarantulas’ team to 3 points.");
            Assert.IsTrue(ranking.Any(t => t.Name == "FC Awesome" && t.Points == 0), "It should contain the ‘FC Awesome’ team with 0 points.");
        }
    }
}
