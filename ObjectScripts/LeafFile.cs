using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class LeafFile {

        public string name;
        public int beatCount;

        public LeafFile(string name, int beatCount){
            this.name = name;
            this.beatCount = beatCount;
        }

    }
}
