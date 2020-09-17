using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    class ConfigEditor {
        public int levelNumber = -1;
        public float bpm;
        public string customlevel, customLevelObj, cache, configCache;
        public Color rgbaRails, rgbaGlowRails, rgbaPath, rgbaJoy;

        public ConfigEditor(){
            this.bpm = 320;
            this.customlevel = "";
            this.customLevelObj = "";
            this.cache = "";
            this.configCache = "";
            this.rgbaRails = Color.FromArgb(255, 255, 255, 255);
            this.rgbaGlowRails = Color.FromArgb(255, 255, 255, 255);
            this.rgbaPath = Color.FromArgb(255, 255, 255, 255);
            this.rgbaJoy = Color.FromArgb(255, 255, 255, 255);
        }

        public StreamWriter destinationFile;

        public void Export() {
            if (!customlevel.Equals("")) {
                if (levelNumber != -1){
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

                        //save all lists into a file with all the data
                        try{
                            using (destinationFile){
                                string linetoWrite = null;

                                //Write leaf file data
                                linetoWrite = "[\n" + "{\n" + "'obj_type': 'LevelLib',";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'level_name': '" + customlevel + "',";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'objlib_path': 'levels/custom/" + customLevelObj + ".objlib',";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'cache_filename': '"+ cache +"',";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'config_cache_filename': '" + configCache + "',";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'bpm': " + bpm + ",";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'level_sections': [";
                                destinationFile.WriteLine(linetoWrite);

                                for (int i = 0; i < levelNumber; i++){  //write the level sections
                                    linetoWrite = "    'SECTION_LINEAR'";
                                    if (i + 1 != levelNumber){
                                        linetoWrite += ",";
                                    }
                                    destinationFile.WriteLine(linetoWrite);
                                }

                                linetoWrite = "    ],";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'rails_color': (" + Convert255to1(rgbaRails.R) + ", " + Convert255to1(rgbaRails.G) + ", " + Convert255to1(rgbaRails.B) + ", " + Convert255to1(rgbaRails.A) +"),";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'rails_glow_color': (" + Convert255to1(rgbaGlowRails.R) + ", " + Convert255to1(rgbaGlowRails.G) + ", " + Convert255to1(rgbaGlowRails.B) + ", " + Convert255to1(rgbaGlowRails.A) + "),";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'path_color': (" + Convert255to1(rgbaPath.R) + ", " + Convert255to1(rgbaPath.G) + ", " + Convert255to1(rgbaPath.B) + ", " + Convert255to1(rgbaPath.A) + "),";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "'joy_color': (" + Convert255to1(rgbaJoy.R) + ", " + Convert255to1(rgbaJoy.G) + ", " + Convert255to1(rgbaJoy.B) + ", " + Convert255to1(rgbaJoy.A) + ")";
                                destinationFile.WriteLine(linetoWrite);
                                linetoWrite = "}\n]";
                                destinationFile.WriteLine(linetoWrite);
                            }

                        }
                        catch (IOException ex){
                            MessageBox.Show("An unexpected problem has occured when trying to save the file. Please try again. If the problem persists, contact the developer or submit a bug report\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fs.Close();
                            fs.Dispose();
                            return;
                        }

                        fs.Close();
                        fs.Dispose();
                    }
                    Console.WriteLine("File Writing Finished!");
                }else{
                    MessageBox.Show("No Master Sequence File loaded, or could not correctly find the level counter. Please load a Master Sequence File that contains level count data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }else{
                MessageBox.Show("No level name selected. Please select a level name", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool loadMasterSequenFile(){
            bool hasFoundFile = false;
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Text file|*.txt";
            loadFile.Title = "Export a Text file";
            loadFile.ShowDialog();

            if (loadFile.FileName != ""){
                StreamReader reader = new StreamReader(loadFile.OpenFile());
                string linetoRead = null;
                while ((linetoRead = reader.ReadLine()) != null){
                    if (linetoRead.Length > 7 && linetoRead.Substring(0, 8).Equals("#levels:")){
                        int.TryParse(linetoRead.Substring(9), out levelNumber);
                        hasFoundFile = true;
                        Console.WriteLine(levelNumber);
                    }
                }
                if (levelNumber == -1){
                    MessageBox.Show("Could not find the level count in this file. Please load a different master sequence txt file that has a levels levels tag\n\nexample: #levels: 7", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return hasFoundFile;
        }

        public double Convert255to1(decimal num){
            double result;
            result = Math.Pow(Math.Pow((double)num / 255, 2.2), 0.4545);
            return result;
        }

    }
}
