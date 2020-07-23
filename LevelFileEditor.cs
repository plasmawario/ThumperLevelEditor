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
                    linetoWrite = "    " + "'leaf_name': '" + grid.Rows[i].Cells[0].Value.ToString().Substring(0, grid.Rows[i].Cells[0].Value.ToString().Length - 3) + "leaf',";
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
    }
}
