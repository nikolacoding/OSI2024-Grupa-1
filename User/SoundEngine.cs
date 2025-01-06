using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace User {
    public sealed class SoundEngine {
        public readonly static SoundPlayer failSound = new(@"C:\Windows\Media\Windows Error.wav");
        public readonly static SoundPlayer successSound = new(@"C:\Windows\Media\Windows Unlock.wav");
    }
}
