using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class MasterSequenceEditor {
        public float bpm;
        public string skyboxName, introLevelName, checkpointLevelName;

        public MasterSequenceEditor(){
            this.bpm = 400;
            this.skyboxName = "skybox_cube";
            this.introLevelName = "intro.lvl";
            this.checkpointLevelName = "checkpoint.lvl";
        }

    }
}
