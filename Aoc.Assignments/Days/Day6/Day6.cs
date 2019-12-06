using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day6
{
    public class Day6
    {
        private List<Planet> planets;

        public Day6()
        {
            this.planets = new List<Planet>();
        }

        public int GetDirectAndIndirectOrbits()
        {
            var com = planets.First(p => p.Name == "COM");
            return com.GetOrbits();
        }

        public void CreateOrbitalMap(List<string> orbits)
        {
            foreach (var planet in orbits)
            {
                var names = planet.Split(')');
                var parentName = names[0];
                var childName = names[1];

                var parentPlanet = this.planets.FirstOrDefault(p => p.Name == parentName) ?? new Planet(parentName);
                var childPlanet = this.planets.FirstOrDefault(p => p.Name == childName) ?? new Planet(childName);

                parentPlanet.AddChildPlanet(childPlanet);

                var parentOfParent = this.planets.FirstOrDefault(p => p.HasChild(parentPlanet.Name));

                if (parentOfParent != null)
                {
                    if (!parentOfParent.HasChild(parentPlanet.Name))
                    {
                        parentOfParent.AddChildPlanet(parentPlanet);
                    }
                }

                this.planets.Add(parentPlanet);
                this.planets.Add(childPlanet);
            }
        }
    }
}