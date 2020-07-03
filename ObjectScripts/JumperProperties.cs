using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class JumperProperties {

        enum id : int {
            none = 0,
            JumpFungi = 1,
            JumpFungiBoss = 2,
            JumpFungiLong = 3,
        }

        int currentID;
        string type = "", description = "";

        public JumperProperties(int id){
            this.currentID = id;
        }
        public JumperProperties(){
            this.currentID = 0;
        }

        public int GetId(){
            return currentID;
        }
        public void SetID(int id){
            this.currentID = id;
            UpdateType();
        }

        private void UpdateType(){
            switch (currentID){
                case 0:
                    type = "";
                    description = "No jump obstacle on this beat";
                    break;
                case 1:
                    type = "jumper_1_step.ent";
                    description = "Fungi jump obstacle";
                    break;
                case 2:
                    type = "jumper_boss.ent";
                    description = "Fungi jump obstacle from level 2 miniboss";
                    break;
                case 3:
                    type = "jumper_6_step.ent";
                    description = "Fungi jump obstacle with long length";
                    break;
            }
        }

    }
}
