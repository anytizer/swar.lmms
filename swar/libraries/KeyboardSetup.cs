using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraries
{
    public abstract class KeyboardSetup
    {
        protected int height;
        protected int width;
        protected int bgcolor;
        protected int forecolor;
    }
    public class SemiTone : KeyboardSetup
    {
        SemiTone()
        {
            this.height = 100;
            this.width = 50;
        }
    }

    public class FullTone : KeyboardSetup
    {
        FullTone()
        {
            this.height = 70;
            this.width = 70;
        }
    }
}
