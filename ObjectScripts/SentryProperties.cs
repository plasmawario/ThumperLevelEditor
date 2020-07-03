using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThumperLevelEditor {
    class SentryProperties {

        enum id : int {
            none = 0,
            Default = 1,
            SentryBoss = 2,
            SentryBoss_Multilane = 3,
            Sentry_Lvl5 = 4,
            Sentry_Lvl6 = 5,
            Sentry_Lvl7 = 6,
            Sentry_Lvl8 = 7,
            Sentry_Lvl8_Multilane = 8,
            Sentry_Lvl9 = 9,
            Sentry_Lvl9_Multilane = 10
        }

        int currentID;
        string type = "", description = "";

        public SentryProperties(int id){
            this.currentID = id;
        }
        public SentryProperties(){
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
                    description = "No sentry on this beat";
                    break;
                case 1:
                    type = "sentry.ent";
                    description = "Default Laser Ring obstacle";
                    break;
                case 2:
                    type = "sentry_boss.ent";
                    description = "Laser Ring obstacle during a boss";
                    break;
                case 3:
                    type = "sentry_boss_multilane.ent";
                    description = "Larger Laser Ring obstacle for multilanes";
                    break;
                case 4:
                    type = "level_5.ent";
                    description = "Laser Ring obstacle using level 5's animations";
                    break;
                case 5:
                    type = "level_6.ent";
                    description = "Laser Ring obstacle using level 6's animations";
                    break;
                case 6:
                    type = "level_7.ent";
                    description = "Laser Ring obstacle using level 7's animations";
                    break;
                case 7:
                    type = "level_8.ent";
                    description = "Laser Ring obstacle using level 8's animations";
                    break;
                case 8:
                    type = "level_8_muilti.ent";
                    description = "Larger Laser Ring obstacle using level 8's animations for multilanes";
                    break;
                case 9:
                    type = "level_9.ent";
                    description = "Laser Ring obstacle using level 9's animations";
                    break;
                case 10:
                    type = "level_9_multi.ent";
                    description = "Larger Laser Ring obstacle using level 9's animations for multilanes";
                    break;
            }
        }

    }
}
