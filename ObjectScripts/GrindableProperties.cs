using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class GrindableProperties {

        enum id : int {
            none = 0,
            Full = 1,
            Center = 2,
            Left = 3,
            Right = 4,
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

        public GrindableProperties(int id, int lane){
            this.currentID = id;
            this.currentLane = lane;
        }
        public GrindableProperties(){
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
                    description = "No grindable on this beat";
                    break;
                case 1:
                    type = "grindable_still" + suffix;
                    description = "Default grindable bar";
                    break;
                case 2:
                    type = "center_multi" + suffix;
                    description = "Center-aligned grindable bar";
                    break;
                case 3:
                    type = "left_multi" + suffix;
                    description = "Left-aligned grindable bar";
                    break;
                case 4:
                    type = "right_multi" + suffix;
                    description = "Right-aligned grindable bar";
                    break;
            }
        }

    }
}
