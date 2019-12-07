using System.Collections.Generic;
using System.Linq;

namespace Aoc.Assignments.Days.Day6
{
    public class Planet
    {
        public string Name {get;private set;}

        public Planet Parent {get; private set;}
        public List<Planet> Children {get; private set;}

        public Planet(string name)
        {
            this.Name = name;
            this.Children = new List<Planet>();
        }
        public int GetOrbits()
        {
            var orbits = 0;
            if (this.Children.Any())
            {
                this.Children.ForEach(c => orbits += c.GetOrbits());
            }
            orbits += this.GetParentOrbits();
            return orbits;
        }

        public int GetParentOrbits()
        {
            if (this.Parent != null)
            {
                return 1 + this.Parent.GetParentOrbits();
            }
            else
            {
                return 0;
            }
        }

        public void SetParentPlanet(Planet planet)
        {
            this.Parent = planet;
        }

        public void AddChildPlanet(Planet planet)
        {
            this.Children.Add(planet);
            planet.SetParentPlanet(this);
        }

        public bool HasChildren()
        {
            return this.Children.Any();
        }

        public bool HasChild(string name)
        {
            return this.Children.Any(p => p.Name == name);
        }

        public bool HasChildDestination(string name)
        {
            if (this.Name == name)
            {
                return true;
            }
            if (!this.HasChildren())
            {
                return false;
            }
            return this.Children.Any(c => c.HasChildDestination(name));
        }
    }
}