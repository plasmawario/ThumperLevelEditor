using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class GrindableMultiProperties {

        enum id : int {
            none = 0,
            WithThump = 1,
            Doubles = 2,
            Thirds = 3,
            Quarters = 4
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

        public GrindableMultiProperties(int id, int lane){
            this.currentID = id;
            this.currentLane = lane;
        }
        public GrindableMultiProperties(){
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
                    description = "No multi-grindable on this beat";
                    break;
                case 1:
                    type = "grindable_with_thump" + suffix;
                    description = "Grindable that spawns with a thump in front of it";
                    break;
                case 2:
                    type = "grindable_double" + suffix;
                    description = "2 grindables that spawn within a half-beat of each other";
                    break;
                case 3:
                    type = "grindable_triple" + suffix;
                    description = "3 grindables that spawn within triplet beats of each other";
                    break;
                case 4:
                    type = "grindable_quarter" + suffix;
                    description = "4 grindables that spawn within a quarter-beat of each other";
                    break;
            }
        }

    }
}
