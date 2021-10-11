using dtos;
using System.Collections.Generic;

namespace libraries
{
    public class Converters
    {
        public List<ComboItem> getConverters()
        {
            List<ComboItem> ci = new List<ComboItem>();

            ci.Add(new ComboItem()
            {
                Text = "Single Character Representation",
                Value = "1",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "Proper Sargam Representation",
                Value = "2",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "Pre-Converted Scales",
                Value = "3",
                ExtraValue = "",
            });

            return ci;
        }
    }
}
