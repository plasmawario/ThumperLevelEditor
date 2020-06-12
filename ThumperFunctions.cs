using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ThumperLevelEditor {
    class ThumperFunctions {

        //Thumper general properties
        public int bpm = 160;
        public int leafLength = 255;

        //lists for timelines of buttons the player can interact with
        public List<int> thumpsTL, barsTL, doubleBarsTL;
        public List<float> turnTL, pitchTL, gammaTL;
        public List<int> tentaclesTL, stalactitesTL;

        public StreamReader sourceFile = new StreamReader("ExportFileTemplate.txt", true);
        public StreamWriter destinationFile;

        public void Initialize() {

            //Thumper editor timeline lists
            thumpsTL = new List<int>(leafLength);
            barsTL = new List<int>(leafLength);
            doubleBarsTL = new List<int>(leafLength);
            turnTL = new List<float>(leafLength);
            pitchTL = new List<float>(leafLength);
            //List<uint> snakeTL = new List<uint>(leafLength);

            //List<uint> laserRingTL = new List<uint>(leafLength);
            gammaTL = new List<float>(leafLength);
            //List<uint> trackColorTL = new List<uint>(leafLength);
            tentaclesTL = new List<int>(leafLength);
            stalactitesTL = new List<int>(leafLength);
            //List<uint> tunnelsTL = new List<uint>(leafLength);

            //set all lists to 0
            for (int i = 0; i < thumpsTL.Capacity; i++){
                thumpsTL.Add(0);
            }
            for (int i = 0; i < barsTL.Capacity; i++){
                barsTL.Add(0);
            }
            for (int i = 0; i < doubleBarsTL.Capacity; i++){
                doubleBarsTL.Add(0);
            }
            for (int i = 0; i < turnTL.Capacity; i++){
                turnTL.Add(0);
            }
            for (int i = 0; i < pitchTL.Capacity; i++){
                pitchTL.Add(0);
            }

            for (int i = 0; i < gammaTL.Capacity; i++){
                gammaTL.Add(0);
            }
            for (int i = 0; i < tentaclesTL.Capacity; i++){
                tentaclesTL.Add(0);
            }
            for (int i = 0; i < stalactitesTL.Capacity; i++){
                stalactitesTL.Add(0);
            }
        }

        public void MissingFeatureDialogue(){
            MessageBox.Show("Sorry, this feature is not working yet!", "Missing Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ResetListLengths(){
            /*thumpsTL.Capacity = leafLength;
            barsTL.Capacity = leafLength;
            doubleBarsTL.Capacity = leafLength;
            turnTL.Capacity = leafLength;
            pitchTL.Capacity = leafLength;
            gammaTL.Capacity = leafLength;
            tentaclesTL.Capacity = leafLength;
            stalactitesTL.Capacity = leafLength;*/
        }

        public void validatedata(List<int> dataList, RichTextBox button){
            if (dataList.ToString().Equals(thumpsTL.ToString()) || dataList.ToString().Equals(barsTL.ToString()) || dataList.ToString().Equals(doubleBarsTL.ToString())){
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
            saveFile.Filter = "Thumper Level Editor File|*.tle";
            saveFile.Title = "Save a Thumper Level Editor file";
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
                    SaveWrite(fs, turnTL);
                    SaveWrite(fs, gammaTL);
                    SaveWrite(fs, stalactitesTL);
                    SaveWrite(fs, tentaclesTL);
                    SaveWrite(fs, thumpsTL);
                    SaveWrite(fs, barsTL);
                    SaveWrite(fs, doubleBarsTL);
                    Console.WriteLine("File saved!");
                }catch (Exception ex){
                    MessageBox.Show("Error", "An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveWrite(FileStream fs, List<int> list){
            using (fs = File.Open(fs.Name, FileMode.Append)){
                //print the next pieces of data
                for (int i = 0; i < list.Capacity; i++){     //write all numbers from pitchTL's list
                    byte[] info = new UTF8Encoding(true).GetBytes(list[i].ToString());
                    fs.Write(info, 0, info.Length);
                    if (i < list.Capacity - 1){
                        byte[] seperator = new UTF8Encoding(true).GetBytes(",");
                        fs.Write(seperator, 0, seperator.Length);
                    }else{
                        byte[] seperator = new UTF8Encoding(true).GetBytes("|");
                        byte[] newline = new UTF8Encoding(true).GetBytes("\n");
                        fs.Write(seperator, 0, seperator.Length);
                        fs.Write(newline, 0, newline.Length);
                    }
                }
            }
        }
        public void SaveWrite(FileStream fs, List<float> list){
            using (fs = File.Open(fs.Name, FileMode.Append)){
                //print the next pieces of data
                for (int i = 0; i < list.Capacity; i++){     //write all numbers from pitchTL's list
                    byte[] info = new UTF8Encoding(true).GetBytes(list[i].ToString());
                    fs.Write(info, 0, info.Length);
                    if (i < list.Capacity - 1){
                        byte[] seperator = new UTF8Encoding(true).GetBytes(",");
                        fs.Write(seperator, 0, seperator.Length);
                    }else{
                        byte[] seperator = new UTF8Encoding(true).GetBytes("|");
                        byte[] newline = new UTF8Encoding(true).GetBytes("\n");
                        fs.Write(seperator, 0, seperator.Length);
                        fs.Write(newline, 0, newline.Length);
                    }
                }
            }
        }

        public void Export(){
            SaveFileDialog exportFile = new SaveFileDialog();
            exportFile.Filter = "Customized Python File|*.py";
            exportFile.Title = "Export a Thumper Level Editor file";
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

                string srcfile = "ExportFileTemplate.txt";

                //copy's file contents from the template file to a new file
                destinationFile = new StreamWriter(fs.Name, true);
            }

            //save all lists into a file with all the data
            try{
                Console.WriteLine("File exported!");
                string linetoWrite = null;
                //bool writeLevelData = false;
                while ((linetoWrite = sourceFile.ReadLine()) != null){
                    //if the file line contains "objData" the first time, prepare saving level data. Else, copy line to new file without altering anything
                    if (linetoWrite.Equals("beatCnt = 200")){
                        linetoWrite = "beatCnt = " + leafLength.ToString();
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "objData = [";
                        destinationFile.WriteLine(linetoWrite);
                        Console.WriteLine("Prepairing to write level data");
                        //writeLevelData = true;
                        //overwrite objData portion of code, and when finished, continue writing rest of file after the objData block
                        linetoWrite = "\n{ #pitch of the track per beat\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < pitchTL.Capacity; i++){    //search through the pitch list's data
                            if (pitchTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                                linetoWrite += i + ":" + pitchTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #turn of the track per beat\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < turnTL.Capacity; i++){    //search through the turn list's data
                            if (turnTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                                linetoWrite += i + ":" + turnTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #gamma (higher = more red)\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < gammaTL.Capacity; i++){    //search through the gamma list's data
                            linetoWrite += i + ":" + gammaTL[i];
                            destinationFile.Write(linetoWrite);
                            linetoWrite = ",";
                        }
                        linetoWrite = "\n},\n\n{ #stalactites (appear under the track)\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < stalactitesTL.Capacity; i++){    //search through the stalactites list's data
                            if (stalactitesTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                                linetoWrite += i + ":" + stalactitesTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #tentacles (1 instance lasts 16 beats)\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < tentaclesTL.Capacity; i++){    //search through the tentacles list's data
                            if (tentaclesTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                                linetoWrite += i + ":" + tentaclesTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #thump\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < thumpsTL.Capacity; i++){    //search through the thumps list's data
                            if (thumpsTL[i] == 1) {     //only prepare the data if the list index contains a 1 in it
                                linetoWrite += i + ":" + thumpsTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #sing bar on beat\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < barsTL.Capacity; i++){    //search through the bars list's data
                            if (barsTL[i] == 1){     //only prepare the data if the list index contains a 1 in it
                                linetoWrite += i + ":" + barsTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n},\n\n{ #double bar on beat\n";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "";
                        for (int i = 0; i < doubleBarsTL.Capacity; i++){    //search through the double bars list's data
                            if (doubleBarsTL[i] == 1){     //only prepare the data if the list index contains a 1 in it
                                linetoWrite += i + ":" + doubleBarsTL[i];
                                destinationFile.Write(linetoWrite);
                                linetoWrite = ",";
                            }
                        }
                        linetoWrite = "\n}\n]";
                        destinationFile.WriteLine(linetoWrite);
                        while (!(linetoWrite = sourceFile.ReadLine()).Equals("###")) { } //keep reading the next line until it find the line containing ###
                    }
                    else{
                        destinationFile.WriteLine(linetoWrite);
                    }
                }
            }catch (Exception ex){
                MessageBox.Show("Error", "An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("File Writing Finished!");

        }

    }

}