using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class ObjectSimpleProperties : ObjectProperties {

        public float id;

        public ObjectSimpleProperties(int id, string paramType, string dataType, string footer, bool step, decimal step_val, string name){
            this.id = id;
            this.param_objType = paramType;
            this.trait_type = dataType;
            this.footer = footer;
            this.step = step;
            this.step_val = step_val;
            this.name = name;
        }

    }
}
