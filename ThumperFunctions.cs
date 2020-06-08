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

        public StreamReader sourceFile = new StreamReader("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Thumper\\custom_level_script\\custom_level_leaf.py", true);
        public StreamWriter destinationFile = new StreamWriter("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Thumper\\custom_level_script\\custom_level_leafTEMP.py", true);

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
            thumpsTL.Capacity = leafLength;
            barsTL.Capacity = leafLength;
            doubleBarsTL.Capacity = leafLength;
            turnTL.Capacity = leafLength;
            pitchTL.Capacity = leafLength;
            gammaTL.Capacity = leafLength;
            tentaclesTL.Capacity = leafLength;
            stalactitesTL.Capacity = leafLength;
        }

        //----------------//
        //-----REMOVE-----//
        //----------------//
        //creates a new button with preset properties
        /*public RichTextBox CreateButton(int x, int y, string element, int r, int g, int b, TableLayoutPanel group) {
            RichTextBox thumperButton = new RichTextBox();
            thumperButton.Parent = group;
            thumperButton.Height = 60;
            thumperButton.Width = 60;
            thumperButton.Multiline = false;
            thumperButton.ScrollBars = 0;
            thumperButton.Margin = Padding.Empty;
            thumperButton.BackColor = Color.FromArgb(r, g, b);
            thumperButton.BorderStyle = BorderStyle.None;
            thumperButton.Text = "1";
            thumperButton.Name = element + "TimelineButton";
            thumperButton.Font = new Font("Arial", 12);
            group.Controls.Add(thumperButton, x, y);
            Console.WriteLine("New " + element + " created at: (" + x + ", " + y + ") relative to " + group.ToString());

            return thumperButton;
        }*/

        //write data to list
        /*public void updateList(List<int> dataList, RichTextBox button){
            if (button == null){
                //needs to update list when removing a button
                return ;
            }
            int num = button.Location.X % 60;
            Console.WriteLine("button location: " + button.Location.X);
            Console.WriteLine("Created an object at beat: " + num);

            //validate data
            validatedata(dataList, button);

            dataList[num] = int.Parse(button.Text);
            Console.WriteLine(dataList.ToString() + " now contains a value of " + dataList.ElementAt(num) + " at beat/index " + dataList[num]);
        }*/
        /*public void updateList(List<float> dataList, RichTextBox button){
            if (button == null){
                //needs to update list when removing a button
                return;
            }
            int num = button.Location.X % 60;
            Console.WriteLine("button location: " + button.Location.X);
            Console.WriteLine("Created an object at beat: " + num);

            //validate data
            validatedata(dataList, button);

            dataList[num] = float.Parse(button.Text);
            Console.WriteLine(dataList.ToString() + " now contains a value of " + dataList.ElementAt(num) + " at beat/index " + dataList[num]);
        }*/

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
                /*fs = File.Create(fs.Name);
                fs.Close();*/

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

        //these two functions seem to overwrite existing data every time they are called. It needs to find the "|" character and print after from the previous entry (the data check doesn't work either ffs)
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
            if (sourceFile == null){
                Console.WriteLine("The file in the custom level folder cannot be found!");
                return;
            }

            string linetoWrite = null;
            //bool writeLevelData = false;
            while ((linetoWrite = sourceFile.ReadLine()) != null){
                //if the file line contains "objData" the first time, prepare saving level data. Else, copy line to new file without altering anything
                if (linetoWrite.Equals("objData = [")){
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
                    linetoWrite = "\n{ #turn of the track per beat\n";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "";
                    for (int i = 0; i < turnTL.Capacity; i++){    //search through the turn list's data
                        if (turnTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                            linetoWrite += i + ":" + turnTL[i];
                            destinationFile.Write(linetoWrite);
                            linetoWrite = ",";
                        }
                    }
                    linetoWrite = "\n{ #gamma (higher = more red)\n";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "";
                    for (int i = 0; i < gammaTL.Capacity; i++){    //search through the gamma list's data
                        linetoWrite += i + ":" + gammaTL[i];
                        destinationFile.Write(linetoWrite);
                        linetoWrite = ",";
                    }
                    linetoWrite = "\n{ #stalactites (appear under the track)\n";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "";
                    for (int i = 0; i < stalactitesTL.Capacity; i++){    //search through the stalactites list's data
                        if (stalactitesTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                            linetoWrite += i + ":" + stalactitesTL[i];
                            destinationFile.Write(linetoWrite);
                            linetoWrite = ",";
                        }
                    }
                    linetoWrite = "\n{ #tentacles (1 instance lasts 16 beats)\n";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "";
                    for (int i = 0; i < tentaclesTL.Capacity; i++){    //search through the tentacles list's data
                        if (tentaclesTL[i] != 0){     //only prepare the data if the list index contains a number not 0 in it
                            linetoWrite += i + ":" + tentaclesTL[i];
                            destinationFile.Write(linetoWrite);
                            linetoWrite = ",";
                        }
                    }
                    linetoWrite = "\n{ #thump\n";
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
            Console.WriteLine("File Writing Finished!");

            
        }

        //eventhandler for custom button
        private void thumperButtonBar_Click(object sender, EventArgs e){
            Console.WriteLine("Bars!");
        }
        private void thumperButtonDoubleBar_Click(object sender, EventArgs e){
            Console.WriteLine("Double Bars!");
        }
        private void thumperButtonTurn_Click(object sender, EventArgs e){
            Console.WriteLine("Turn!");
        }
        private void thumperButtonPitch_Click(object sender, EventArgs e){
            Console.WriteLine("Pitch!");
        }

        private void thumperButtonGamma_Click(object sender, EventArgs e){
            Console.WriteLine("Gamma!");
        }
    }

}