using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class ThumpProperties {

        enum id : int {
            none = 0,
            Default = 1,
            Checkpoint = 2,
            BossBonus = 3,
            Short = 4
        }

        enum lane : int {
            Center = 0,
            InnerLeft = 1,
            OuterLeft = 2,
            InnerRight = 3,
            OuterRight = 4
        }

        int currentID, currentLane;
        string type = "", description = "", suffix = "", sufDesc = "";

        public ThumpProperties(int id, int lane){
            this.currentID = id;
            this.currentLane = lane;
        }
        public ThumpProperties(){
            this.currentID = 0;
            this.currentLane = 0;
        }

        public int GetId(){
            return currentID;
        }
        public void SetID(int id){
            this.currentID = id;
            UpdateType();
        }
        public int GetLane(){
            return currentLane;
        }
        public void SetLane(int lane){
            this.currentLane = lane;
            UpdateType();
        }

        private void UpdateType(){
            switch (currentLane){
                case 0:
                    suffix = ".ent";
                    sufDesc = "Center lane";
                    break;
                case 1:
                    suffix = ".a02";
                    sufDesc = "Inner Left lane";
                    break;
                case 2:
                    suffix = ".a01";
                    sufDesc = "Outer Left lane";
                    break;
                case 3:
                    suffix = ".z01";
                    sufDesc = "Inner Right lane";
                    break;
                case 4:
                    suffix = ".z02";
                    sufDesc = "Outer Right lane";
                    break;
            }
            switch (currentID){
                case 0:
                    type = "";
                    description = "No thump at this beat";
                    break;
                case 1:
                    type = "thump_rails" + suffix;
                    description = "Default Thump";
                    break;
                case 2:
                    type = "thump_checkpoint" + suffix;
                    description = "Charged Thump that appears on a checkpoint";
                    break;
                case 3:
                    type = "thump_boss_bonus" + suffix;
                    description = "Charged Thump that appears after a first-try successful boss hit";
                    break;
                case 4:
                    type = "thump_rails_fast_activat" + suffix;
                    description = "Thump that appears with a shortened warning";
                    break;
            }
        }

    }
}
