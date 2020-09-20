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

    }
}
