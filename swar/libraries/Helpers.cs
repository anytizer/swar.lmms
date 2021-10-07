using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraries
{
    public static class Helpers
    {
        // eg. D:\songs\song\notations\notations-sargam.txt => song
        public static string SongTitle(string file_notations_sargam = "")
        {
            DirectoryInfo parent = Directory.GetParent(file_notations_sargam);
            string title = parent.Name;

            /**
             * If we had put all notations within a standard directory name.
             */
            if (title == "notations")
            {
                title = parent.Parent.Name;
            }

            return title;
        }
    }
}
