using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    class LevelFileEditor {
        public string lvlName, tutorial;
        public int ObjectsToWrite = 0, beatCount;
        public decimal delay = 16, volume = 0.5M;
        public bool allowInput = true;

        public List<LeafFile> leafFileList = new List<LeafFile>();
        public List<SampleFile> sampleList = new List<SampleFile>();

        public StreamWriter destinationFile;

        public void Export(int rowNum, DataGridView gridLeaf, DataGridView gridSamp){
            SaveFileDialog exportFile = new SaveFileDialog();
            exportFile.Filter = "Text file|*.txt";
            exportFile.Title = "Export a Text file";
            exportFile.ShowDialog();

            if (exportFile.FileName != ""){

                //stores the directory and file name itself to make it possible to manipulate the file name itself
                string storePath = Path.GetDirectoryName(exportFile.FileName);
                string tempFileName = Path.GetFileName(exportFile.FileName);

                //if the file doesn't have the lvl_ prefix in its name, add it
                if (!tempFileName.ToString().Substring(0, 4).Equals("lvl_")){
                    exportFile.FileName = storePath + "\\lvl_" + tempFileName;
                }

                FileStream fs = (FileStream)exportFile.OpenFile();

                //remove file if it exists
                if (exportFile.CheckFileExists){
                    File.Delete(fs.Name);
                }
                fs.Close();
                fs.Dispose();
                exportFile.Dispose();

                //string to hold the file name without the "lvl_" prefix
                string levelname = Path.GetFileNameWithoutExtension(fs.Name);

                destinationFile = new StreamWriter(fs.Name, true);

                //remove the leaf_ prefix from leafName for writing inside the lvl file
                levelname = levelname.ToString().Substring(5);

                ObjectsToWrite = rowNum;

                //save all lists into a file with all the data
                try{
                    using (destinationFile){
                        string linetoWrite = null;

                        //Write leaf file data
                        linetoWrite = "[\n" + "{\n" + "'obj_type': 'SequinLevel'," + "\n" + "'obj_name': '" + levelname + ".lvl'," + "\n" + "'approach_beats': " + delay + ",\n" + "'seq_objs': [\n    ],\n" + "'leaf_seq': [";
                        destinationFile.WriteLine(linetoWrite);

                        //writing leaf files here
                        ExportLevel_LeafData(fs, gridLeaf);

                        linetoWrite = "    ],";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'loops': [";
                        destinationFile.WriteLine(linetoWrite);

                        //writing loop entries here
                        ExportLevel_SampleData(fs, gridSamp);

                        linetoWrite = "    ],";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'volume': " + volume + ",";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'input_allowed': " + allowInput + ",";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'tutorial_type': '" + tutorial + "',";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "'start_angle_fracs': " + "(1, 1, 1)" + "";
                        destinationFile.WriteLine(linetoWrite);
                        linetoWrite = "}\n]";
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

        public void ExportLevel_SampleData(FileStream fs, DataGridView grid){
            using (fs){
                string linetoWrite = null;
                linetoWrite = "";
                for (int i = 0; i < grid.RowCount; i++){
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    {\n    'samp_name': '" + grid.Rows[i].Cells[0].Value + "',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'beats_per_loop': " + grid.Rows[i].Cells[1].Value;
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    }";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = ",";
                }
            }
        }

        public void ExportLevel_LeafData(FileStream fs, DataGridView grid){
            using (fs){
                string linetoWrite = null;

                for (int i = 0; i < grid.RowCount; i++){
                    linetoWrite = "    {\n    " + "'beat_cnt': " + grid.Rows[i].Cells[1].Value + ",";
                    destinationFile.WriteLine(linetoWrite);
                    //remove the lvl_ prefix from leafName for writing inside the lvl file
                    string leafName = grid.Rows[i].Cells[0].Value.ToString().Substring(5);
                    linetoWrite = "    " + "'leaf_name': '" + leafName.ToString().Substring(0, leafName.ToString().Length - 3) + "leaf',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    " + "'main_path': '" + "default.path" + "',";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    " + "'sub_paths': [";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "],";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'pos': " + "(0, 0, 0)" + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'rot_x': " + "(1, 0, 0)" + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'rot_y': " + "(0, 1, 0)" + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'rot_z': " + "(0, 0, 1)" + ",";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    'scale': " + "(1, 1, 1)";
                    destinationFile.WriteLine(linetoWrite);
                    linetoWrite = "    }";
                    destinationFile.WriteLine(linetoWrite);
                    if (i < grid.RowCount - 1){
                        linetoWrite = ",";
                        destinationFile.WriteLine(linetoWrite);
                    }
                }
            }
        }

        public void Save(ComboBox combLeafs, DataGridView dgvLeaf, DataGridView dgvSample){
            //file save information
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Thumper Level Editor Level File|*.tleLvl";
            saveFile.Title = "Save a Thumper Level Editor Level file";
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

                        byte[] info = new UTF8Encoding(true).GetBytes("Leafs{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < combLeafs.Items.Count; i++){
                            info = new UTF8Encoding(true).GetBytes(combLeafs.Items[i] + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Leafs in list{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < dgvLeaf.RowCount; i++){
                            info = new UTF8Encoding(true).GetBytes("beat count:" + leafFileList[i].beatCount + "\n");
                            fs.Write(info, 0, info.Length);
                            info = new UTF8Encoding(true).GetBytes("leaf name:" + leafFileList[i].name + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Tutorial Type:" + tutorial + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Allow Input:" + allowInput + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Beat Delay:" + delay + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Volume:" + volume + "\n");
                        fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Samples in list{\n");
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < dgvSample.RowCount; i++){
                            info = new UTF8Encoding(true).GetBytes("sample loop:" + sampleList[i].loop + "\n");
                            fs.Write(info, 0, info.Length);
                            info = new UTF8Encoding(true).GetBytes("sample name:" + sampleList[i].name + "\n");
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("}\n");
                        fs.Write(info, 0, info.Length);
                    }
                        Console.WriteLine("File saved!");
                }
                catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load(ComboBox combLeafs, DataGridView dgvLeafs, ComboBox combTutorial, CheckBox chkInput, NumericUpDown numDelay, NumericUpDown numVolume, DataGridView dgvSamp){
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Thumper Level Editor Level File|*.tleLvl";
            loadFile.Title = "Load a Thumper Level Editor Level file";
            loadFile.ShowDialog();

            if (loadFile.FileName != ""){
                StreamReader reader = new StreamReader(loadFile.OpenFile());
                string linetoRead = null;

                try { 
                    linetoRead = reader.ReadLine(); //reads the Leafs{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")){    //load leafs into dropdown
                        combLeafs.Items.Add(linetoRead);
                    }
                    linetoRead = reader.ReadLine(); //reads the Leafs in list{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")){    //load leafs into datagridview
                        dgvLeafs.RowCount++;
                        int tempBeatNum = int.Parse(linetoRead.Substring(11));
                        linetoRead = reader.ReadLine();
                        string tempLeafName = linetoRead.Substring(10);
                        leafFileList.Add(new LeafFile(tempLeafName, tempBeatNum));
                    }
                    linetoRead = reader.ReadLine(); //tutorial
                    combTutorial.Text = linetoRead.Substring(14);
                    linetoRead = reader.ReadLine(); //allow input
                    chkInput.Checked = bool.Parse(linetoRead.Substring(12));
                    linetoRead = reader.ReadLine(); //delay
                    numDelay.Value = int.Parse(linetoRead.Substring(11));
                    linetoRead = reader.ReadLine(); //volume
                    numVolume.Value = decimal.Parse(linetoRead.Substring(7));
                    linetoRead = reader.ReadLine(); //reads the Samples in list{ line
                    while (!(linetoRead = reader.ReadLine()).Equals("}")){    //load samples into datagridview
                        dgvSamp.RowCount++;
                        int tempSampLoop = int.Parse(linetoRead.Substring(12));
                        linetoRead = reader.ReadLine();
                        string tempSampName = linetoRead.Substring(12);
                        sampleList.Add(new SampleFile(tempSampName, tempSampLoop));
                    }

                    Console.WriteLine("File loaded!");
                }catch (Exception ex){
                    MessageBox.Show("An unexpected problem has occured when trying to load the file. This could be due to an unsupported file type or corrupted/broken file. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
