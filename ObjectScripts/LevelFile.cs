using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class LevelFile {

        public string name, restName;
        public bool playPlus, hasCheckpoint;

        public LevelFile(string name, string restName, bool playPlus, bool hasCheckpoint){
            this.name = name;
            this.restName = restName;
            this.playPlus = playPlus;
            this.hasCheckpoint = hasCheckpoint;
        }

    }
}
