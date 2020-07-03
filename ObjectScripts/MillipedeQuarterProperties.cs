using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class MillipedeQuarterProperties {

        enum id : int {
            none = 0,
            Default = 1,
            QuarterPhrase = 2
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

        public MillipedeQuarterProperties(int id, int lane) {
            this.currentID = id;
            this.currentLane = lane;
        }
        public MillipedeQuarterProperties(){
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
                    description = "No half millipede on this beat";
                    break;
                case 1:
                    type = "millipede_quarter" + suffix;
                    description = "Default quarter millipede";
                    break;
                case 2:
                    type = "millipedE_quarter_phrase" + suffix;
                    description = "Quarter millipede with swerve animation";
                    break;
            }
        }

    }
}
