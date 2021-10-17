using dtos;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class ColorsRotator
    {
        private int LastUsedIndex;
        private List<Coloring> colors;

        public ColorsRotator()
        {
            this.LastUsedIndex = 0;

            this.colors = new List<Coloring>();
            this.colors.Add(new Coloring() { code = "#58D46F", name = "green" });
            this.colors.Add(new Coloring() { code = "#FF58C6", name = "pink" });
            this.colors.Add(new Coloring() { code = "#4C72B8", name = "blue" });
            this.colors.Add(new Coloring() { code = "#C7A651", name = "yellow" });
            this.colors.Add(new Coloring() { code = "#786C50", name = "gold" });
            this.colors.Add(new Coloring() { code = "#C75151", name = "red" });
        }

        public Coloring getNextColor()
        {
            if (LastUsedIndex >= this.colors.Count())
            {
                LastUsedIndex = 1;
            }
            else
            {
                ++LastUsedIndex;
            }

            Coloring c = this.colors[LastUsedIndex-1];
            return c;
        }
    }
}
