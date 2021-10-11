using dtos;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class ColorsRotator
    {
        private int LastUsedIndex;
        private List<Color> colors;

        public ColorsRotator()
        {
            this.LastUsedIndex = 0;

            this.colors = new List<Color>();
            this.colors.Add(new Color() { code = "#58D46F", name = "green" });
            this.colors.Add(new Color() { code = "#FF58C6", name = "pink" });
            this.colors.Add(new Color() { code = "#C75151", name = "red" });
            this.colors.Add(new Color() { code = "#C7A651", name = "yellow" });
            this.colors.Add(new Color() { code = "#4C72B8", name = "blue" });
            this.colors.Add(new Color() { code = "#786c50", name = "gold" });
        }

        public Color getColor()
        {
            if (LastUsedIndex >= this.colors.Count())
            {
                LastUsedIndex = 1;
            }
            else
            {
                ++LastUsedIndex;
            }

            Color c = this.colors[LastUsedIndex-1];
            return c;
        }
    }
}
