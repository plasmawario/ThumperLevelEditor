using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace ThumperLevelEditor {
    class Playback {

        public SoundPlayer audioThump = new SoundPlayer("audio\\thump.wav");
        public SoundPlayer audioBars = new SoundPlayer("audio\\grindable.wav");
        public SoundPlayer audioDucker = new SoundPlayer("audio\\ducker.wav");
        public SoundPlayer audioFungi = new SoundPlayer("audio\\fungi.wav");
        public SoundPlayer audioSpikes = new SoundPlayer("audio\\spikes.wav");
        public SoundPlayer audioLeft = new SoundPlayer("audio\\turn_left.wav");
        public SoundPlayer audioRight = new SoundPlayer("audio\\turn_right.wav");
        public SoundPlayer audioLong = new SoundPlayer("audio\\turn_long.wav");
        public SoundPlayer audioSnake = new SoundPlayer("audio\\snake.wav");
        public SoundPlayer audioSentryS = new SoundPlayer("audio\\sentry_start.wav");
        public SoundPlayer audioSentryE = new SoundPlayer("audio\\sentry_end.wav");
        public SoundPlayer audioSentryThump = new SoundPlayer("audio\\sentry_thump.wav");

    }
}
