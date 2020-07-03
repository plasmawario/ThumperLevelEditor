using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class JumpHighProperties {

        enum id : int {
            none = 0,
            JumpSpikes = 1,
            JumpSpikes2 = 2,
            JumpSpikes4 = 3,
            JumpSpikes6 = 4,
            JumpSpikesBoss = 5
        }

        int currentID;
        string type = "", description = "";

        public JumpHighProperties(int id){
            this.currentID = id;
        }
        public JumpHighProperties(){
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
                    type = "jump_high.ent";
                    description = "Spike jump obstacle";
                    break;
                case 2:
                    type = "jump_high_2.ent";
                    description = "Spike jump obstacle";
                    break;
                case 3:
                    type = "jump_high_4.ent";
                    description = "Spike jump obstacle with long length";
                    break;
                case 4:
                    type = "jump_high_6.ent";
                    description = "Spike jump obstacle with long length and longer warning";
                    break;
                case 5:
                    type = "jump_boss.ent";
                    description = "Spike jump obstacle from a miniboss";
                    break;
            }
        }

    }
}
