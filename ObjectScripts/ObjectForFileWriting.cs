using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class ObjectForFileWriting {

        public int[] dataPoints;
        public string objectName, objectLane;

        public ObjectForFileWriting(string name, string lane){
            this.objectName = name;
            this.objectLane = lane;
            this.dataPoints = new int[255];
        }

    }
}
