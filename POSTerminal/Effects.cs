using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal
{
    class Effects
    {

        public static SoundPlayer simpleSound;
        public static bool overrideplaysound = true;
        public static void playsimplesound(string soundfilepath)
        {
            simpleSound = new SoundPlayer(@"" + soundfilepath);
            simpleSound.Play();
        }

        public static void stopsimplesound()
        {
            simpleSound.Stop();
        }

        public static void loopsimplesound(string soundfilepath)
        {
            simpleSound = new SoundPlayer(@"" + soundfilepath);
            simpleSound.PlayLooping();
        }
    }
}
