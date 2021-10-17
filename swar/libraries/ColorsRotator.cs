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

            this.colors = new List<Coloring>
            {
                new Coloring() { code = "#58D46F", name = "green" },
                new Coloring() { code = "#FF58C6", name = "pink" },
                new Coloring() { code = "#4C72B8", name = "blue" },
                new Coloring() { code = "#C7A651", name = "yellow" },
                new Coloring() { code = "#786C50", name = "gold" },
                new Coloring() { code = "#C75151", name = "red" }
            };
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
