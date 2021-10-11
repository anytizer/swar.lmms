using System.IO;

namespace libraries
{
    public static class Helpers
    {
        // eg. D:\project-one\notations\notations-sargams.txt => project-one
        // eg. D:\project-one\notations-sargams.txt => project-one
        public static string SongTitle(string notations_file = "")
        {
            DirectoryInfo parent = Directory.GetParent(notations_file);
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
