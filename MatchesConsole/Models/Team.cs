using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchesConsole.Models
{
    public class Team : IComparable<Team>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The team name cannot be empty.", nameof(name));
            }

            Name = name;
            Points = 0;
        }

        public int CompareTo(Team other)
        {
            if (other == null)
            {
                return -1;
            }

            //Sort by descending points
            var pointComparison = other.Points.CompareTo(this.Points);

            if (pointComparison != 0)
            {
                return pointComparison;
            }

            // If the dots are equal, sort alphabetically
            return this.Name.CompareTo(other.Name);
        }
    }
}
