using configs;
using System.IO;

namespace libraries
{
    public class License
    {
        public bool validate()
        {
            return true;
        }

        public int mode()
        {
            // read license.txt's mode and other details
            // @todo read more details like: owner, expiry, validity
            string license = File.ReadAllText(Configurations.ReadWriteDirectory + "/license.txt");
            int mode = int.Parse(license);

            switch(mode)
            {
                case FeaturesUnlocked.FREE:
                case FeaturesUnlocked.PREMIUM:
                case FeaturesUnlocked.DEMO:
                    // mode unchanged
                    break;
                default:
                    mode = FeaturesUnlocked.DEMO;
                    break;
            }
            
            return mode;
        }
    }
}
