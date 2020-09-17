using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;

namespace ThumperLevelEditor {
    class LeafFileEditor {

        //Thumper general properties
        public int leafLength = 255;
        public int ObjectsToWrite = 0;  //i don't have time to come up with a proper fix for this, but this is supposed to hit zero and stop printing commas after each object chunk is written. But for some reason it doesn't do that so now i'll stop printing commas once it hits 1. I just don't care anymore

        //lists for timelines of buttons the player can interact with
        public List<ObjectProperties> thumpsTL, barsTL, multiBarsTL, jumpFungiTL, jumpSpikesTL, snakesHalfTL, snakesQuarterTL, sentryTL, duckerTL;
        public List<ObjectSimpleProperties> pitchTL, rollTL, turnTL, turnAutoTL, gameSpeedTL, scaleXTL, scaleYTL, scaleZTL, offsetXTL, offsetYTL, offsetZTL, lfLaneTL, lnLaneTL, cenLaneTL, rnLaneTL, rfLaneTL;

        //public StreamReader sourceFile = new StreamReader("ExportFileTemplate.txt", true);
        public StreamWriter destinationFile;

        public void Initialize() {

            InitializeLeafObjects leafObjects = new InitializeLeafObjects();

            //Thumper editor timeline lists
            thumpsTL = new List<ObjectProperties>(leafLength);
            barsTL = new List<ObjectProperties>(leafLength);
            multiBarsTL = new List<ObjectProperties>(leafLength);
            jumpFungiTL = new List<ObjectProperties>(leafLength);
            jumpSpikesTL = new List<ObjectProperties>(leafLength);
            snakesHalfTL = new List<ObjectProperties>(leafLength);
            snakesQuarterTL = new List<ObjectProperties>(leafLength);
            sentryTL = new List<ObjectProperties>(leafLength);
            turnTL = new List<ObjectSimpleProperties>(leafLength);
            turnAutoTL = new List<ObjectSimpleProperties>(leafLength);
            pitchTL = new List<ObjectSimpleProperties>(leafLength);
            rollTL = new List<ObjectSimpleProperties>(leafLength);
            scaleXTL = new List<ObjectSimpleProperties>(leafLength);
            scaleYTL = new List<ObjectSimpleProperties>(leafLength);
            scaleZTL = new List<ObjectSimpleProperties>(leafLength);
            offsetXTL = new List<ObjectSimpleProperties>(leafLength);
            offsetYTL = new List<ObjectSimpleProperties>(leafLength);
            offsetZTL = new List<ObjectSimpleProperties>(leafLength);
            lfLaneTL = new List<ObjectSimpleProperties>(leafLength);
            lnLaneTL = new List<ObjectSimpleProperties>(leafLength);
            cenLaneTL = new List<ObjectSimpleProperties>(leafLength);
            rnLaneTL = new List<ObjectSimpleProperties>(leafLength);
            rfLaneTL = new List<ObjectSimpleProperties>(leafLength);
            gameSpeedTL = new List<ObjectSimpleProperties>(leafLength);
            duckerTL = new List<ObjectProperties>(leafLength);

            for (int i = 0; i < thumpsTL.Capacity; i++){
                thumpsTL.Add(new ObjectProperties(0, 2, "thump.spn","thump_rails", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "thumpsTL"));
                thumpsTL[i].type = new string[] {"", "thump_rails", "thump_checkpoint", "thump_boss_bonus", "thump_rails_fast_activat"};
            }
            for (int i = 0; i < barsTL.Capacity; i++){
                barsTL.Add(new ObjectProperties(0, 2, "grindable.spn", "grindable_still", ".ent", "kTraitBool", "(2, 1, 2, 1, 2, 'kIntensityScale', 'kIntensityScale', 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0)", true, 0, "barsTL"));
                barsTL[i].type = new string[] { "", "grindable_still", "left_multi", "center_multi", "right_multi" };
            }
            for (int i = 0; i < multiBarsTL.Capacity; i++){
                multiBarsTL.Add(new ObjectProperties(0, 2, "grindable_multi.spn", "grindable_with_thump", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "multiBarsTL"));
                multiBarsTL[i].type = new string[] { "", "grindable_with_thump", "grindable_double", "grindable_triple", "grindable_quarter" };
            }
            for (int i = 0; i < jumpFungiTL.Capacity; i++){
                jumpFungiTL.Add(new ObjectProperties(0, 2, "jump.spn", "jumper_1_step", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "jumpFungiTL"));
                jumpFungiTL[i].type = new string[] { "", "jumper_1_step", "jumper_boss", "jumper_6_step" };
            }
            for (int i = 0; i < jumpSpikesTL.Capacity; i++){
                jumpSpikesTL.Add(new ObjectProperties(0, 2, "jump_high.spn", "jump_high", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "jumpSpikesTL"));
                jumpSpikesTL[i].type = new string[] { "", "jump_high", "jump_high_2", "jump_high_4", "jump_high_6", "jump_boss" };
            }
            for (int i = 0; i < snakesHalfTL.Capacity; i++){
                snakesHalfTL.Add(new ObjectProperties(0, 2, "millipede_half.spn", "millipede_half", ".ent", "ktraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "snakesHalfTL"));
                snakesHalfTL[i].type = new string[] { "", "millipede_half", "millipede_half_phrase", "swerve_off" };
            }
            for (int i = 0; i < snakesQuarterTL.Capacity; i++){
                snakesQuarterTL.Add(new ObjectProperties(0, 2, "millipede_quarter.spn", "millipede_quarter", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "snakesQuarterTL"));
                snakesQuarterTL[i].type = new string[] { "", "millipede_quarter", "millipede_quarter_phrase" };
            }
            for (int i = 0; i < sentryTL.Capacity; i++){
                sentryTL.Add(new ObjectProperties(0, 2, "sentry.spn", "sentry", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "sentryTL"));
                sentryTL[i].type = new string[] { "", "sentry", "sentry_boss", "sentry_boss_multilane", "level_5", "level_6", "level_7", "level_8", "level_8_muilti", "level_9", "level_9_multi" };
            }
            for (int i = 0; i < turnTL.Capacity; i++){
                turnTL.Add(new ObjectSimpleProperties(0, "turn", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "turnTL"));
            }
            for (int i = 0; i < turnAutoTL.Capacity; i++){
                turnAutoTL.Add(new ObjectSimpleProperties(0, "turn_auto", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "turnAutoTL"));
            }
            for (int i = 0; i < pitchTL.Capacity; i++){
                pitchTL.Add(new ObjectSimpleProperties(0, "pitch", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "pitchTL"));
            }
            for (int i = 0; i < rollTL.Capacity; i++){
                rollTL.Add(new ObjectSimpleProperties(0, "roll", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "rollTL"));
            }
            for (int i = 0; i < scaleXTL.Capacity; i++){
                scaleXTL.Add(new ObjectSimpleProperties(0, "scale_x", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 1, "scaleXTL"));
            }
            for (int i = 0; i < scaleYTL.Capacity; i++){
                scaleYTL.Add(new ObjectSimpleProperties(0, "scale_y", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 1, "scaleYTL"));
            }
            for (int i = 0; i < scaleZTL.Capacity; i++){
                scaleZTL.Add(new ObjectSimpleProperties(0, "scale_z", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 1, "scaleZTL"));
            }
            for (int i = 0; i < offsetXTL.Capacity; i++){
                offsetXTL.Add(new ObjectSimpleProperties(0, "offset_x", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "offsetXTL"));
            }
            for (int i = 0; i < offsetYTL.Capacity; i++){
                offsetYTL.Add(new ObjectSimpleProperties(0, "offset_y", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "offsetYTL"));
            }
            for (int i = 0; i < offsetZTL.Capacity; i++){
                offsetZTL.Add(new ObjectSimpleProperties(0, "offset_z", "kTraitFloat", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "offsetZTL"));
            }
            for (int i = 0; i < lfLaneTL.Capacity; i++){
                lfLaneTL.Add(new ObjectSimpleProperties(0, "visibla01", "kTraitBool", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "lfLaneTL"));
            }
            for (int i = 0; i < lnLaneTL.Capacity; i++){
                lnLaneTL.Add(new ObjectSimpleProperties(0, "visibla02", "kTraitBool", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "lnLaneTL"));
            }
            for (int i = 0; i < cenLaneTL.Capacity; i++){
                cenLaneTL.Add(new ObjectSimpleProperties(0, "visible", "kTraitBool", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 1, "cenLaneTL"));
            }
            for (int i = 0; i < rnLaneTL.Capacity; i++){
                rnLaneTL.Add(new ObjectSimpleProperties(0, "visiblz01", "kTraitBool", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "cenLaneTL"));
            }
            for (int i = 0; i < rfLaneTL.Capacity; i++){
                rfLaneTL.Add(new ObjectSimpleProperties(0, "visiblz01", "kTraitBool", "(4,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "rfLaneTL"));
            }
            for (int i = 0; i < gameSpeedTL.Capacity; i++){
                gameSpeedTL.Add(new ObjectSimpleProperties(0, "sequin_speed", "kTraitFloat", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 1, "gameSpeedTL"));
            }
            for (int i = 0; i < duckerTL.Capacity; i++){
                duckerTL.Add(new ObjectProperties(0, 2, "ducker.spn", "ducker_crak", ".ent", "kTraitBool", "(2,1,2,1,2,'kIntensityScale','kIntensityScale',1,0,1,1,1,1,1,1,0,0,0)", true, 0, "duckerTL"));
                duckerTL[i].type = new string[] { "", "ducker_crak" };
            }
        }

        public void MissingFeatureDialogue(){
            MessageBox.Show("Sorry, this feature is not working yet!", "Missing Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void validatedata(List<int> dataList, RichTextBox button){
            if (dataList.ToString().Equals(thumpsTL.ToString()) || dataList.ToString().Equals(barsTL.ToString()) || dataList.ToString().Equals(multiBarsTL.ToString())){
                if (int.Parse(button.Text) != 1){
                    button.Text = "1";
                }
            }else{
                for (int i = 0; i < button.TextLength; i++){
                    if (!char.IsDigit(button.Text.ToCharArray()[i])){
                        button.Text = "1";
                    }
                }
            }
        }
        public void validatedata(List<float> dataList, RichTextBox button){
            for (int i = 0; i < button.TextLength; i++){
                if (!char.IsDigit(button.Text.ToCharArray()[i])){
                    button.Text = "1";
                }
            }
        }
        public void Save(){
            //file save information
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Thumper Level Editor Leaf File|*.tleLeaf";
            saveFile.Title = "Save a Thumper Level Editor Leaf file";
            saveFile.ShowDialog();

            if (saveFile.FileName != ""){
                FileStream fs = (FileStream)saveFile.OpenFile();

                //remove file if it exists
                if (saveFile.CheckFileExists){
                    File.Delete(fs.Name);
                }
                fs.Close();

                //save all lists into a file with all the data
                try{
                    SaveWrite(fs, pitchTL);
                    SaveWrite(fs, rollTL);
                    SaveWrite(fs, turnTL);
                    SaveWrite(fs, turnAutoTL);
                    SaveWrite(fs, gameSpeedTL);
                    SaveWrite(fs, thumpsTL);
                    SaveWrite(fs, barsTL);
                    SaveWrite(fs, multiBarsTL);
                    SaveWrite(fs, duckerTL);
                    SaveWrite(fs, jumpFungiTL);
                    SaveWrite(fs, jumpSpikesTL);
                    SaveWrite(fs, snakesHalfTL);
                    SaveWrite(fs, snakesQuarterTL);
                    SaveWrite(fs, sentryTL);
                    SaveWrite(fs, lfLaneTL);
                    SaveWrite(fs, lnLaneTL);
                    SaveWrite(fs, cenLaneTL);
                    SaveWrite(fs, rnLaneTL);
                    SaveWrite(fs, rfLaneTL);
                    SaveWrite(fs, scaleXTL);
                    SaveWrite(fs, scaleYTL);
                    SaveWrite(fs, scaleZTL);
                    SaveWrite(fs, offsetXTL);
                    SaveWrite(fs, offsetYTL);
                    SaveWrite(fs, offsetZTL);
                    Console.WriteLine("File saved!");
                }catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveWrite(FileStream fs, List<ObjectSimpleProperties> list){
            using (fs = File.Open(fs.Name, FileMode.Append)){
                //print the next pieces of data

                byte[] info = new UTF8Encoding(true).GetBytes("editortype:" + 0 + "\n");
                byte[] seperator = new UTF8Encoding(true).GetBytes(",");
                byte[] newline = new UTF8Encoding(true).GetBytes(" \n");
                fs.Write(info, 0, info.Length);
                //fs.Write(newline, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes(list[0].name);   //character to define new object when reading and writing
                fs.Write(info, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes("\ndefault_value:" + list[0].step_val + "\n");
                fs.Write(info, 0, info.Length);
                //fs.Write(newline, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes("\ndata_points:\n");
                for (int i = 0; i < leafLength; i++){
                    info = new UTF8Encoding(true).GetBytes(list[i].id.ToString());
                    fs.Write(info, 0, info.Length);
                    if (i < leafLength - 1){
                        fs.Write(seperator, 0, seperator.Length);   //will write a comma after each datapoint except the last one
                    }else{
                        //seperator = new UTF8Encoding(true).GetBytes("|");
                        //fs.Write(seperator, 0, seperator.Length);
                        fs.Write(newline, 0, newline.Length);
                    }
                }
            }
        }
        public void SaveWrite(FileStream fs, List<ObjectProperties> list){
            using (fs = File.Open(fs.Name, FileMode.Append)){
                //print the next pieces of data

                byte[] info = new UTF8Encoding(true).GetBytes("editortype:" + 1 + "\n");
                byte[] seperator = new UTF8Encoding(true).GetBytes(",");
                byte[] newline = new UTF8Encoding(true).GetBytes(" \n");
                fs.Write(info, 0, info.Length);
                //fs.Write(newline, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes(list[0].name);    //character to define new object when reading and writing
                fs.Write(info, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes("\ndefault_value:" + list[0].step_val + "\n");
                fs.Write(info, 0, info.Length);
                //fs.Write(newline, 0, info.Length);
                info = new UTF8Encoding(true).GetBytes("\ndata_points:\n");
                for (int i = 0; i < leafLength; i++){
                    info = new UTF8Encoding(true).GetBytes("{" + list[i].id.ToString());
                    fs.Write(info, 0, info.Length);
                    fs.Write(seperator, 0, seperator.Length);
                    /*info = new UTF8Encoding(true).GetBytes(list[i].param_objType);
                    fs.Write(info, 0, info.Length);
                    fs.Write(seperator, 0, seperator.Length);*/
                    info = new UTF8Encoding(true).GetBytes(list[i].laneID + "}");
                    fs.Write(info, 0, info.Length);
                    if (i < leafLength - 1){
                        fs.Write(seperator, 0, seperator.Length);   //will write a comma after each datapoint except the last one
                    }else{
                        //seperator = new UTF8Encoding(true).GetBytes("|");
                        //fs.Write(seperator, 0, seperator.Length);
                        fs.Write(newline, 0, newline.Length);
                    }
                }
            }
        }

        public int load(){
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Thumper Level Editor Leaf File|*.tleLeaf";
            loadFile.Title = "Load a Thumper Level Editor Leaf file";
            loadFile.ShowDialog();

            if (loadFile.FileName != ""){ 
                StreamReader reader = new StreamReader(loadFile.OpenFile());
                //StringBuilder sb;
                string linetoRead = null;
                List<List<ObjectSimpleProperties>> simpleObjList = new List<List<ObjectSimpleProperties>>();
                List<List<ObjectProperties>> objList = new List<List<ObjectProperties>>();
                char[] datapoints;
                int counter = 0, jSimple = -1, jComplex = -1, beatCount = 0;
                bool objectTypeIsSimple = true;
                decimal datapoint_value;

                try{
                    simpleObjList.Add(pitchTL);
                    simpleObjList.Add(rollTL);
                    simpleObjList.Add(turnTL);
                    simpleObjList.Add(turnAutoTL);
                    simpleObjList.Add(gameSpeedTL);
                    objList.Add(thumpsTL);
                    objList.Add(barsTL);
                    objList.Add(multiBarsTL);
                    objList.Add(duckerTL);
                    objList.Add(jumpFungiTL);
                    objList.Add(jumpSpikesTL);
                    objList.Add(snakesHalfTL);
                    objList.Add(snakesQuarterTL);
                    objList.Add(sentryTL);
                    simpleObjList.Add(lfLaneTL);
                    simpleObjList.Add(lnLaneTL);
                    simpleObjList.Add(cenLaneTL);
                    simpleObjList.Add(rnLaneTL);
                    simpleObjList.Add(rfLaneTL);
                    simpleObjList.Add(scaleXTL);
                    simpleObjList.Add(scaleYTL);
                    simpleObjList.Add(scaleZTL);
                    simpleObjList.Add(offsetXTL);
                    simpleObjList.Add(offsetYTL);
                    simpleObjList.Add(offsetZTL);

                    //read each character until 
                    while ((linetoRead = reader.ReadLine()) != null) {
                        switch (counter){
                            case 0:
                                linetoRead = linetoRead.Substring(11);
                                if (int.Parse(linetoRead) == 0){    //Gets what type of object it's reading and flags appropriately
                                    jSimple++;
                                    objectTypeIsSimple = true;
                                }else{
                                    jComplex++;
                                    objectTypeIsSimple = false;
                                }
                                break;
                            case 2:
                                linetoRead = linetoRead.Substring(14);    //reads default value
                                if (objectTypeIsSimple){
                                    simpleObjList[jSimple][0].step_val = int.Parse(linetoRead);
                                }else{
                                    objList[jComplex][0].step_val = int.Parse(linetoRead);
                                }
                                break;
                            case 3:
                                List<int> datapoints_raw = new List<int>();
                                if (objectTypeIsSimple){
                                    datapoints = linetoRead.ToCharArray();
                                    for (int i = 0; i < datapoints.Length; i++){
                                        if (decimal.TryParse(datapoints[i].ToString(), out datapoint_value)){
                                            datapoints_raw.Add(int.Parse(datapoint_value.ToString()));
                                        }
                                    }
                                    for (int i = 0; i < datapoints_raw.Capacity; i++){
                                        simpleObjList[jSimple][i].id = datapoints_raw[i];
                                    }
                                }
                                else{
                                    List<int> datapoints_raw2 = new List<int>();
                                    bool isCheckingID = true;
                                    datapoints = linetoRead.ToCharArray();
                                    for (int i = 0; i < datapoints.Length; i++){
                                        if (decimal.TryParse(datapoints[i].ToString(), out datapoint_value)){
                                            if (isCheckingID){
                                                datapoints_raw.Add(int.Parse(datapoint_value.ToString()));
                                                isCheckingID = false;
                                            }else{
                                                datapoints_raw2.Add(int.Parse(datapoint_value.ToString()));
                                                isCheckingID = true;
                                            }
                                    
                                        }
                                    }
                                    for (int i = 0; i < datapoints_raw.Capacity; i++){
                                        objList[jComplex][i].id = datapoints_raw[i];
                                        objList[jComplex][i].laneID = datapoints_raw2[i];
                                    }
                                }
                                beatCount = datapoints_raw.Capacity;
                                break;
                        }

                        counter++;
                        if (counter % 4 == 0){
                            counter = 0;
                        }
                    }
                    Console.WriteLine("File loaded!");
                    return beatCount;
                }catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to load the file. This could be due to an unsupported file type or corrupted/broken file. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return -1;
        }

        public void Export(){
            SaveFileDialog exportFile = new SaveFileDialog();
            exportFile.Filter = "Text file|*.txt";
            exportFile.Title = "Export a Text file";
            exportFile.ShowDialog();

            if (exportFile.FileName != ""){
                FileStream fs = (FileStream)exportFile.OpenFile();

                //remove file if it exists
                if (exportFile.CheckFileExists){
                    File.Delete(fs.Name);
                }
                fs.Close();
                fs.Dispose();
                exportFile.Dispose();

                destinationFile = new StreamWriter(fs.Name, true);

                //string to hold the file name without the "leaf_" prefix
                string leafName = Path.GetFileNameWithoutExtension(fs.Name);

                //save all lists into a file with all the data
                try{
                    using (destinationFile){
                        string linetoWrite = null;

                        //sorts through all lists to see if datapoints are present. If so, add them to the list. If not, don't add em.
                        ExportLeaf_CheckForData(pitchTL);
                        ExportLeaf_CheckForData(rollTL);
                        ExportLeaf_CheckForData(turnTL);
                        ExportLeaf_CheckForData(turnAutoTL);
                        ExportLeaf_CheckForData(gameSpeedTL);
                        ExportLeaf_CheckForData(thumpsTL);
                        ExportLeaf_CheckForData(barsTL);
                        ExportLeaf_CheckForData(multiBarsTL);
                        ExportLeaf_CheckForData(duckerTL);
                        ExportLeaf_CheckForData(jumpFungiTL);
                        ExportLeaf_CheckForData(jumpSpikesTL);
                        ExportLeaf_CheckForData(snakesHalfTL);
                        ExportLeaf_CheckForData(snakesQuarterTL);
                        ExportLeaf_CheckForData(sentryTL);
                        ExportLeaf_CheckForData(lfLaneTL);
                        ExportLeaf_CheckForData(lnLaneTL);
                        ExportLeaf_CheckForData(cenLaneTL);
                        ExportLeaf_CheckForData(rnLaneTL);
                        ExportLeaf_CheckForData(rfLaneTL);
                        ExportLeaf_CheckForData(scaleXTL);
                        ExportLeaf_CheckForData(scaleYTL);
                        ExportLeaf_CheckForData(scaleZTL);
                        ExportLeaf_CheckForData(offsetXTL);
                        ExportLeaf_CheckForData(offsetYTL);
                        ExportLeaf_CheckForData(offsetZTL);
                        //yes i know this was probably the worst possible way to do it but at this point i don't give a fuck, if it works it works.

                        Console.WriteLine("Found " + ObjectsToWrite + " rows with data");

                        //Write leaf file data
                        linetoWrite = "[\n" + "{\n" + "'obj_type': 'SequinLeaf'," + "\n" + "'obj_name': '" + leafName + ".leaf'," + "\n" + "'seq_objs': [";
                        destinationFile.WriteLine(linetoWrite);

                        ExportLeaf_ObjectData(fs, pitchTL, leafName);
                        ExportLeaf_ObjectData(fs, rollTL, leafName);
                        ExportLeaf_ObjectData(fs, turnTL, leafName);
                        ExportLeaf_ObjectData(fs, turnAutoTL, leafName);
                        ExportLeaf_ObjectData(fs, gameSpeedTL, leafName);
                        ExportLeaf_ObjectData(fs, thumpsTL);
                        ExportLeaf_ObjectData(fs, barsTL);
                        ExportLeaf_ObjectData(fs, multiBarsTL);
                        ExportLeaf_ObjectData(fs, duckerTL);
                        ExportLeaf_ObjectData(fs, jumpFungiTL);
                        ExportLeaf_ObjectData(fs, jumpSpikesTL);
                        ExportLeaf_ObjectData(fs, snakesHalfTL);
                        ExportLeaf_ObjectData(fs, snakesQuarterTL);
                        ExportLeaf_ObjectData(fs, sentryTL);
                        ExportLeaf_ObjectData(fs, lfLaneTL, leafName);
                        ExportLeaf_ObjectData(fs, lnLaneTL, leafName);
                        ExportLeaf_ObjectData(fs, cenLaneTL, leafName);
                        ExportLeaf_ObjectData(fs, rnLaneTL, leafName);
                        ExportLeaf_ObjectData(fs, rfLaneTL, leafName);
                        ExportLeaf_ObjectData(fs, scaleXTL, leafName);
                        ExportLeaf_ObjectData(fs, scaleYTL, leafName);
                        ExportLeaf_ObjectData(fs, scaleZTL, leafName);
                        ExportLeaf_ObjectData(fs, offsetXTL, leafName);
                        ExportLeaf_ObjectData(fs, offsetYTL, leafName);
                        ExportLeaf_ObjectData(fs, offsetZTL, leafName);
                        //add the rest of these AFTER testing the file writing thing again with new algorithm

                        linetoWrite = "    ],";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'beat_cnt': " + leafLength + "\n}\n]";
                        destinationFile.WriteLine(linetoWrite);
                    }

                }catch (IOException ex){
                    MessageBox.Show("An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                    fs.Dispose();
                    return;
                }

                fs.Close();
                fs.Dispose();
            }
            Console.WriteLine("File Writing Finished!");

        }

        public void ExportLeaf_CheckForData(List<ObjectSimpleProperties> list){
            bool hasData = false;
            for (int i = 0; i < list.Capacity; i++){
                if (list[i].id != 0  || list[0].step_val != 0){
                    hasData = true;
                }
            }
            if (hasData){
                ObjectsToWrite++;
            }

        }
        public void ExportLeaf_CheckForData(List<ObjectProperties> list){
            bool hasData = false;
            for (int i = 0; i < list.Capacity; i++){
                if (list[i].id != 0  || list[0].step_val != 0){
                    hasData = true;
                }
            }
            if (hasData){
                ObjectsToWrite++;
            }

        }

        public void ExportLeaf_ObjectData(FileStream fs, List<ObjectSimpleProperties> obj, string leafName){

            using (fs){
                bool rowIsEmpty = true; //used to see if the row is empty. If so, break out of function and don't write to file
                string linetoWrite = null;

                for (int i = 0; i < leafLength; i++){
                    if (obj[i].id != 0 || obj[0].step_val != 0){    //if there is an object present at a cell or if step value is not default
                        rowIsEmpty = false;
                    }
                }
                if (rowIsEmpty || ObjectsToWrite < 1){
                    Console.WriteLine("This row doesn't contain any data/objects for " + obj.ToString() + " or row counter has hit 0. Breaking...");
                    return;
                }

                linetoWrite = "    {\n    " + "'obj_name': '" + leafName + ".leaf',";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    " + "'param_path': '" + obj[0].param_objType + "',";    //something in this line makes the array out of bounds
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    " + "'trait_type': '" + obj[0].trait_type + "',";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    " + "'data_points': {";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "";
                for (int i = 0; i < obj.Capacity; i++){    //search through the list's data
                    if (obj[i].id != 0){     //only prepare the data if the list index contains a number not 0 in it
                        linetoWrite += i + ":" + obj[i].id;
                        destinationFile.Write(linetoWrite);
                        linetoWrite = ",";
                    }
                }
                linetoWrite = "},";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    'step': " + obj[0].step + ",";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    'default': " + obj[0].step_val + ",";
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    'footer': " + obj[0].footer;
                destinationFile.WriteLine(linetoWrite);
                linetoWrite = "    }";
                destinationFile.WriteLine(linetoWrite);

                if (ObjectsToWrite > 1){
                    linetoWrite = ",";
                    destinationFile.WriteLine(linetoWrite);
                    ObjectsToWrite--;
                }
            }
        }
        public void ExportLeaf_ObjectData(FileStream fs, List<ObjectProperties> obj){

            using (fs){

                string linetoWrite = null;
                bool hasDupe;
                bool rowIsEmpty = true; //used to see if the row is empty. If so, break out of function and don't write to file

                List<ObjectForFileWriting> objFile = new List<ObjectForFileWriting>();
                objFile.Add(new ObjectForFileWriting(obj[0].param_objType, obj[0].param_objLane));
                for (int i = 0; i < leafLength; i++){
                    objFile[0].dataPoints[i] = 0;
                }

                //goes through all cells in the row to check for any objects that will be present in a different lane. If so, add type and lane to list
                for (int i = 0; i < leafLength; i++){
                    hasDupe = false;
                    if (obj[i].id != 0  || obj[0].step_val != 0){    //if there is an object present at a cell or if step value is not default
                        for (int j = 0; j < objFile.Count; j++){ //goes through the list's contents
                            if (objFile[j].objectName.Equals(obj[i].param_objType) && objFile[j].objectLane.Equals(obj[i].param_objLane)){    //If the object type AND lane are not present in the list, create new entries
                                hasDupe = true;
                            }
                        }
                        if (!hasDupe) {
                            objFile.Add(new ObjectForFileWriting(obj[i].param_objType, obj[i].param_objLane));  //adds an object containing the lane and type combo. Now only needs datapoints
                        }
                        for (int j = 0; j < objFile.Count; j++){
                            if (objFile[j].objectName.Equals(obj[i].param_objType) && objFile[j].objectLane.Equals(obj[i].param_objLane)){      //ifan object type and lane combo are found, write the datapoint to the object list index
                                objFile[j].dataPoints[i] = obj[i].id;   //adds the data to the appropriate list index
                                Console.WriteLine("added data point");
                            }else{
                                objFile[j].dataPoints[i] = 0;
                            }
                        }
                        
                        rowIsEmpty = false;
                    }
                }
                if (rowIsEmpty || ObjectsToWrite < 1){
                    Console.WriteLine("This row doesn't contain any data/objects for " + obj.ToString() + " or row counter has hit 0. Breaking...");
                    return;
                }

                for (int j = 0; j < objFile.Count; j++){
                    linetoWrite = "{    " + "'obj_name': '" + obj[0].obj_name + "',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    " + "'param_path': '" + objFile[j].objectName + objFile[j].objectLane + "',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    " + "'trait_type': '" + obj[0].trait_type + "',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    " + "'data_points': {";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "";
                    for (int i = 0; i < obj.Capacity; i++){    //search through the list's data
                        if (objFile[j].dataPoints[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                            linetoWrite += i + ":" + 1;
                            destinationFile.Write(linetoWrite);
                            linetoWrite = ",";
                        }
                    }
                    linetoWrite = "\n},";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'step': " + obj[0].step + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'default': " + obj[0].step_val + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'footer': " + obj[0].footer;
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    }";
                    destinationFile.WriteLine(linetoWrite);

                    if (ObjectsToWrite > 1){
                        linetoWrite = ",";
                        destinationFile.WriteLine(linetoWrite);
                        ObjectsToWrite--;
                    }
                }
            }
        }

    }

}