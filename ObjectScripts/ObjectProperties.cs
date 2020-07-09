using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class ObjectProperties {

        public string name;
        public string[] type;
        public string[] lane = {".a01", ".a02", ".ent", ".z01", ".z02"};
        public int id; //used as an index for accessing the type array. A 0 indicates no object, and so should reference an empty string in the array to indicate no type
        public int laneID;
        public string obj_name, param_objType, param_objLane, trait_type, footer;
        public decimal step_val;
        public bool step;

        public ObjectProperties(int id, int laneID, string objName, string paramType, string paramLane, string dataType, string footer, bool step, decimal step_val, string name){
            this.id = id;
            this.laneID = laneID;
            this.obj_name = objName;
            this.param_objType = paramType;
            this.param_objLane = paramLane; //make sure to set this default lane to the center lane
            this.trait_type = dataType;
            this.footer = footer;
            this.step = step;
            this.step_val = step_val;
            this.name = name;
        }

        public ObjectProperties(){
            this.id = 0;
            this.laneID = 0;
            this.obj_name = "";
            this.param_objType = "";
            this.param_objLane = ""; //make sure to set this default lane to the center lane
            this.trait_type = "";
            this.footer = "";
            this.step = true;
            this.step_val = 0;
        }

        public void setLane(int val){
            laneID = val;
            param_objLane = lane[val];
        }

        public void setType(int val){
            id = val;
            param_objType = type[val];
        }

    }
}
