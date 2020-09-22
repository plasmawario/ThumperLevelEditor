using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    class MasterSequenceEditor {
        public int ObjectsToWrite = 0, levelCounter = 0;
        public string skyboxName, introLevelName, checkpointLevelName;

        public List<LevelFile> levelFileList = new List<LevelFile>();

        public StreamWriter destinationFile;

        public MasterSequenceEditor(){
            this.skyboxName = "skybox_cube";
            this.introLevelName = "intro.lvl";
            this.checkpointLevelName = "checkpoint.lvl";
        }

        public void Export(DataGridView gridLeaf){
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
                string levelname = Path.GetFileNameWithoutExtension(fs.Name);

                //ObjectsToWrite = rowNum;  //rowNum is the row number of the datagridview containing lvl data

                //save all lists into a file with all the data
                try{
                    using (destinationFile){
                        string linetoWrite = null;

                        //Write leaf file data
                        linetoWrite = "[\n" + "{\n" + "'obj_type': 'SequinMaster'," + "\n" + "'obj_name': 'sequin.master'," + "\n" + "'skybox_name': '" + skyboxName + "',\n" + "'intro_lvl_name': '" + introLevelName.ToString().Substring(introLevelName.ToString().Length - 3) + ".lvl',\n" + "'groupings': [";
                        destinationFile.WriteLine(linetoWrite);

                        //writing lvl files here
                        ExportMaster_LevelData(fs, gridLeaf);

                        linetoWrite = "    ],";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'checkpoint_lvl_name': '" + checkpointLevelName.ToString().Substring(checkpointLevelName.ToString().Length - 3) + ".lvl'";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "}\n]";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "#levels: " + levelCounter;
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

        public void ExportMaster_LevelData(FileStream fs, DataGridView grid){
            using (fs){
                string linetoWrite = null;

                for (int i = 0; i < grid.RowCount; i++){
                    linetoWrite = "    {\n    'lvl_name': " + grid.Rows[i].Cells[0].Value.ToString().Substring(0, grid.Rows[i].Cells[0].Value.ToString().Length - 3) + "lvl',";
                    //linetoWrite = "    {\n'lvl_name': '" + levelFileList[i].name + ".lvl',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'gate_name': '',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'checkpoint': " + levelFileList[i].hasCheckpoint + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'checkpoint_leader_lvl_name': '',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'rest_lvl_name': '";
                    if (!levelFileList[i].restName.Equals("")) { linetoWrite += levelFileList[i].restName + ".lvl',"; } else { linetoWrite += "',"; }
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'play_plus': " + levelFileList[i].playPlus + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    }";
                    destinationFile.WriteLine(linetoWrite);
                    if (i < grid.RowCount - 1){
                        linetoWrite = ",";
                        destinationFile.WriteLine(linetoWrite);
                    }
                    if (levelFileList[i].hasCheckpoint == true) levelCounter++;
                }
            }
        }

        public void Save(ComboBox combLvls, ComboBox combRest, DataGridView dgvLevels){
            //file save information
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Thumper Level Editor Master Sequen File|*.tleMas";
            saveFile.Title = "Save a Thumper Level Editor Master Sequen file";
            saveFile.ShowDialog();

            if (saveFile.FileName != ""){
                FileStream fs = (FileStream)saveFile.OpenFile();

                //remove file if it exists
                if (saveFile.CheckFileExists){
                    File.Delete(fs.Name);
                }
                fs.Close();

                try{
                    using (fs = File.Open(fs.Name, FileMode.Append)) {
                        byte[] info = new UTF8Encoding(true).GetBytes("Skybox:" + skyboxName + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("levels{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < combLvls.Items.Count; i++) {
                            info = new UTF8Encoding(true).GetBytes(combLvls.Items[i] + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("rest levels{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < combRest.Items.Count; i++) {
                            info = new UTF8Encoding(true).GetBytes(combRest.Items[i] + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("level info{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < dgvLevels.RowCount; i++){
                            info = new UTF8Encoding(true).GetBytes("has Checkpoint:" + levelFileList[i].hasCheckpoint + "\n");
                            fs.Write(info, 0, info.Length);
                            info = new UTF8Encoding(true).GetBytes("present in play plus:" + levelFileList[i].playPlus + "\n");
                            fs.Write(info, 0, info.Length);
                            info = new UTF8Encoding(true).GetBytes("lvl name:" + levelFileList[i].name + "\n");
                            fs.Write(info, 0, info.Length);
                            info = new UTF8Encoding(true).GetBytes("rest name:" + levelFileList[i].restName + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("CheckpointLevel:" + checkpointLevelName + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("IntroLevel:" + introLevelName + "\n");
                        fs.Write(info, 0, info.Length);

                        Console.WriteLine("File saved!");
                    }
                }catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void load(ComboBox combSkybox, ComboBox combLevels, ComboBox combRest, DataGridView dgvLvls, Label lblChk, Label lblIntro){
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Thumper Level Editor Master Sequen File|*.tleMas";
            loadFile.Title = "Load a Thumper Level Editor Master Sequen file";
            loadFile.ShowDialog();

            if (loadFile.FileName != "") {
                StreamReader reader = new StreamReader(loadFile.OpenFile());
                string linetoRead = null;

                try {
                    linetoRead = reader.ReadLine().Substring(7);
                    combSkybox.Text = linetoRead;
                    linetoRead = reader.ReadLine(); //reads levels{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")) {    //load levels into dropdown
                        combLevels.Items.Add(linetoRead);
                    }
                    linetoRead = reader.ReadLine(); //reads restlevels{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")) {    //load levels into dropdown
                        combRest.Items.Add(linetoRead);
                    }
                    linetoRead = reader.ReadLine(); //reads level info{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")) {    //load levels into datagridview
                        dgvLvls.RowCount++;
                        bool tempChk = bool.Parse(linetoRead.Substring(15));
                        linetoRead = reader.ReadLine();
                        bool tempPlus = bool.Parse(linetoRead.Substring(21));
                        linetoRead = reader.ReadLine();
                        string tempLvl = linetoRead.Substring(9);
                        linetoRead = reader.ReadLine();
                        string tempRest = linetoRead.Substring(10);
                        levelFileList.Add(new LevelFile(tempLvl, tempRest, tempPlus, tempChk));
                    }
                    linetoRead = reader.ReadLine().Substring(16);
                    lblChk.Text = linetoRead;
                    linetoRead = reader.ReadLine().Substring(11);
                    lblIntro.Text = linetoRead;

                    Console.WriteLine("File loaded!");
                }catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to load the file. This could be due to an unsupported file type or corrupted/broken file. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
