using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day6
{
    public class Day6
    {
        private List<Planet> planets;
        private List<Planet> visitedPlanets;
        private List<Planet> goodPlanets;

        public Day6()
        {
            this.planets = new List<Planet>();
            this.visitedPlanets = new List<Planet>();
            this.goodPlanets = new List<Planet>();
        }

        public int GetShortestRoute(string start, string destination)
        {
            var startPlanet = this.planets.First(p => p.Name == start).Parent;
            var previous = this.planets.First(p => p.Name == start);
            return this.GetShortestRoute(startPlanet, previous, destination, 0);
        }

        public int GetShortestRoute(Planet start, Planet previous, string destination, int length)
        {
            if (this.visitedPlanets.Any(p => p.Name == start.Name))
            {
                return 0;
            }
            if (!start.HasChildren())
            {
                this.visitedPlanets.Add(start);
                return 0;
            }
            else if (start.HasChild(destination))
            {
                return length;
            }
            else if (start.HasChildDestination(destination))
            {
                Console.WriteLine(previous.Name + " TO " + start.Name);
                this.goodPlanets.Add(start);
                var route = 0;

                foreach (var planet in start.Children)
                {
                    route = this.GetShortestRoute(planet, previous, destination, length + 1);
                    if (route > 0)
                    {
                        Console.WriteLine(start.Name + " TO " + planet.Name);
                        return route;
                    }
                }

                return 0;
            }
            else
            {
                Console.WriteLine(previous.Name + " TO " + start.Name);
                this.visitedPlanets.Add(start);
                return this.GetShortestRoute(start.Parent, start, destination, length + 1);
            }
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