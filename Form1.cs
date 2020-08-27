using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    public partial class ThumperLevelEditor : Form {
        //script references
        LeafFileEditor editor = new LeafFileEditor();
        Playback playback = new Playback();
        LevelFileEditor lvlEditor = new LevelFileEditor();
        MasterSequenceEditor masterEditor = new MasterSequenceEditor();
        VirtualMode virtualmode = new VirtualMode();
        SamplesLists samples = new SamplesLists();

        public int pbCounter = 0;

        //public SoundPlayer player = new SoundPlayer();

        public ThumperLevelEditor() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you wish to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void Generic_KeyPress(object sender, KeyPressEventArgs e){
            //e.Handled = true;
        }
        private void Generic_KeyDown(object sender, KeyEventArgs e){
            //e.SuppressKeyPress = true;
            //bruh
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e){
            masterEditor.Export(dgvLevelFiles);
            lblLog.Text = "Finished exporting master sequence file!";
        }
        private void exportToolStripMenuItem2_Click(object sender, EventArgs e) {
            lvlEditor.Export(dgvLeafFiles.RowCount, dgvLeafFiles, dgvSamplesList);
            lblLog.Text = "Finished exporting lvl file!";
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e) {
            editor.Export();
            lblLog.Text = "Finished exporting leaf file!";
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            editor.MissingFeatureDialogue();
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("Need additional help and support? Join us here!: https://discord.gg/qaqy3bG", "Discord Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("---Program Dev's info---\nTwitter: @Plasmawario\nDiscord: Plasmawario#7852\n---Thumper Dev's info---\nWebsite: https://thumpergame.com/ \n", "Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkHasCheckpoint_CheckedChanged(object sender, EventArgs e){

        }

        private void chkEnabledInPlayPlus_CheckedChanged(object sender, EventArgs e){

        }

        private void btnClearGrid_Click(object sender, EventArgs e) {
            dgvLeafFiles.RowCount = 0;
            while (lvlEditor.leafFileList.Count > 0) {
                lvlEditor.leafFileList.RemoveAt(0);
            }
            lblLog.Text = "Cleared the leaf Grid";
        }

        private void btnClearSampleGrid_Click(object sender, EventArgs e) {
            dgvSamplesList.RowCount = 0;
            while (lvlEditor.sampleList.Count > 0) {
                lvlEditor.sampleList.RemoveAt(0);
            }
            lblLog.Text = "Cleared the sample Grid";
        }

        private void btnClearList_Click(object sender, EventArgs e) {
            while (combLeafFiles.Items.Count > 0) {
                combLeafFiles.Items.RemoveAt(0);
                combLeafFiles.Text = "";
            }
            lblLog.Text = "Cleared the leaf list";
        }

        private void btnClearLvlList_Click(object sender, EventArgs e){
            while (combLevelFiles.Items.Count > 0){
                combLevelFiles.Items.RemoveAt(0);
                combLevelFiles.Text = "";
            }
            lblLog.Text = "Cleared the level list";
        }

        private void btnClearLvlGrid_Click(object sender, EventArgs e){
            dgvLevelFiles.RowCount = 0;
            while (masterEditor.levelFileList.Count > 0){
                masterEditor.levelFileList.RemoveAt(0);
            }
            lblLog.Text = "Cleared the level Grid";
        }

        private void btnClearRestLvlsList_Click(object sender, EventArgs e){
            while (combLevelFilesRest.Items.Count > 0){
                combLevelFilesRest.Items.Remove(0);
                combLevelFilesRest.Text = "";
            }
            combLevelFilesRest.Items.Add("Rest");
            lblLog.Text = "Cleared the rest level list";
        }

        //playback shit
        private void btnPlay_Click(object sender, EventArgs e){
            btnStop_Click(sender, e);   //executes the btnstop function to remove the green line
            if (masterEditor.bpm != 0) {
                tmrPlayback.Interval = (int)(((60f / masterEditor.bpm) * 1000f));

                pbCounter = -1; //for some reason there's an offset of 1 when i start this from 0, so i'm just gonna set it to -1 and call it good :^)
                tmrPlayback.Enabled = true;
                tmrPlayback.Start();
                lblLog.Text = "Playback started";
            }else{
                MessageBox.Show("BPM Cannot be set to 0 when using playback!", "Negative bpm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnStop_Click(object sender, EventArgs e) {
            tmrPlayback.Stop();
            if (pbCounter > 0) {
                dgvObstacles.Columns[pbCounter].DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
                tmrPlayback.Enabled = false;
            }

            pbCounter = 0;
            lblLog.Text = "Playback stopped";

            //updates the cell coloring of time signatures since they break when playback happens
            UpdateTimingSignatures(dgvObstacles);
        }
        private void btnPause_Click(object sender, EventArgs e) {
            if (tmrPlayback.Enabled) {
                tmrPlayback.Enabled = false;
            } else {
                tmrPlayback.Enabled = true;
            }
            lblLog.Text = "Playback pause toggled";

            //updates the cell coloring of time signatures since they break when playback happens
            UpdateTimingSignatures(dgvObstacles);
        }

        //leaf file menu strips
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e) {
            editor.Save();
        }
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e) {
            editor.MissingFeatureDialogue();
        }

        private void ThumperLevelEditor_Load(object sender, EventArgs e) {
            //call script to initialize thumper editor values
            editor.Initialize();

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;

            InitializeObstacleDGV();
            InitializeComboLane();
            UpdateComboType();
            InitializeLeafDGV();
            InitializeLevelDGV();
            InitializeSampleDGV();
            InitializeComboTutorial();
            InitializeComboSampleTypes();
            InitializeDropSkybox();
            InitializeDropRestLvls();
            UpdateSamples();
        }

        private void tmrPlayback_Tick(object sender, EventArgs e) {
            DataGridViewCellStyle newStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle oldStyle = new DataGridViewCellStyle();
            try{
                newStyle.BackColor = oldStyle.BackColor = dgvObstacles.Columns[pbCounter].HeaderCell.Style.BackColor;
            }catch (Exception ex) {
                Console.WriteLine("I honestly don't care about errors here i'm just too lazy to come up with a proper fix");
            }
            newStyle.BackColor = Color.FromArgb(40, 170, 40);

            try {
                dgvObstacles.Columns[pbCounter + 1].DefaultCellStyle.BackColor = newStyle.BackColor;
                dgvObstacles.Columns[pbCounter].DefaultCellStyle.BackColor = oldStyle.BackColor;
            } catch (Exception ex) {
                Console.WriteLine("I honestly don't care about errors here i'm just too lazy to come up with a proper fix");
            }
            pbCounter++;

            try {
                if (editor.thumpsTL[pbCounter].id != 0 && editor.sentryTL[pbCounter].id == 0) { playback.audioThump.Play(); } else if (editor.thumpsTL[pbCounter].id != 0 && editor.sentryTL[pbCounter].id != 0) { playback.audioSentryThump.Play(); };
                if (editor.barsTL[pbCounter].id != 0) playback.audioBars.Play();
                if (editor.jumpSpikesTL[pbCounter].id != 0) playback.audioSpikes.Play();
                if (editor.jumpFungiTL[pbCounter].id != 0) playback.audioFungi.Play();
                if (editor.turnTL[pbCounter].id >= 15) { playback.audioLeft.Play(); } else if (editor.turnTL[pbCounter].id <= -15) { playback.audioRight.Play(); }
                if (editor.snakesHalfTL[pbCounter].id != 0 || editor.snakesQuarterTL[pbCounter].id != 0) playback.audioSnake.Play();
                if (editor.sentryTL[pbCounter].id != 0 && editor.sentryTL[pbCounter - 1].id == 0) playback.audioSentryS.Play();
                if (editor.sentryTL[pbCounter].id != 0 && editor.sentryTL[pbCounter + 1].id == 0) playback.audioSentryE.Play();
            }
            catch (Exception ex) {
                Console.WriteLine("could not find an audio file to play. Are you checking your audio play requirements properly, or are you missing an audio file?");
            }

            if (pbCounter >= editor.leafLength){
                pbCounter = editor.leafLength - 1;
            }
        }

        private void numBPM_ValueChanged(object sender, EventArgs e) {
            NumericUpDown num = (NumericUpDown)sender;

            masterEditor.bpm = float.Parse(num.Value.ToString());
            lblLog.Text = "level BPM set to: " + masterEditor.bpm;
        }

        private void loadRestLevelToolStripMenuItem_Click(object sender, EventArgs e){
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Text File|*.txt";
            loadFile.Title = "Load a Text file";
            loadFile.ShowDialog();

            //lvlEditor.ImportLeafFile(loadFile);

            try{
                StreamReader reader = new StreamReader(loadFile.OpenFile());
            }catch (Exception ex){

            }
            bool checkdupe = false;
            for (int i = 0; i < combLevelFilesRest.Items.Count; i++) {
                if (combLevelFilesRest.Items[i].Equals(loadFile.SafeFileName)) {
                    checkdupe = true;
                }
            }
            if (!checkdupe) {
                combLevelFilesRest.Items.Add(loadFile.SafeFileName);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e){
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Text File|*.txt";
            loadFile.Title = "Load a Text file";
            loadFile.ShowDialog();

            //lvlEditor.ImportLeafFile(loadFile);

            try{
                StreamReader reader = new StreamReader(loadFile.OpenFile());
            }catch (Exception ex){

            }
            bool checkdupe = false;
            for (int i = 0; i < combLevelFiles.Items.Count; i++) {
                if (combLevelFiles.Items[i].Equals(loadFile.SafeFileName)) {
                    checkdupe = true;
                }
            }
            if (!checkdupe) {
                combLevelFiles.Items.Add(loadFile.SafeFileName);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Text File|*.txt";
            loadFile.Title = "Load a Text file";
            loadFile.ShowDialog();

            //lvlEditor.ImportLeafFile(loadFile);

            try{
                StreamReader reader = new StreamReader(loadFile.OpenFile());
            }catch (Exception ex){

            }
            bool checkdupe = false;
            for (int i = 0; i < combLeafFiles.Items.Count; i++) {
                if (combLeafFiles.Items[i].Equals(loadFile.SafeFileName)) {
                    checkdupe = true;
                }
            }
            if (!checkdupe) {
                combLeafFiles.Items.Add(loadFile.SafeFileName);
            }

        }

        private void combBpmSamples_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateSamples();
        }

        private void btnAddLvlToList_Click(object sender, EventArgs e){
            masterEditor.levelFileList.Add(new LevelFile(combLevelFiles.Text, combLevelFilesRest.Text, chkEnabledInPlayPlus.Checked, chkHasCheckpoint.Checked));
            dgvLevelFiles.RowCount++;
            lblLog.Text = "Added level file to list";
        }

        private void btnAddLeafToList_Click(object sender, EventArgs e) {
            lvlEditor.leafFileList.Add(new LeafFile(combLeafFiles.Text, (int)numBeatCount.Value));
            dgvLeafFiles.RowCount++;
            lblLog.Text = "Added leaf file to list";
        }

        private void btnAddSampleToList_Click(object sender, EventArgs e) {
            lvlEditor.sampleList.Add(new SampleFile(combSampleName.Text, (int)numLoop.Value));
            dgvSamplesList.RowCount++;
            lblLog.Text = "Added sample to list";
        }

        private void combTutorial_SelectedIndexChanged(object sender, EventArgs e) {
            lvlEditor.tutorial = combTutorial.Text;
            lblLog.Text = "Tutorial type changed";
        }

        private void chkAllowInput_CheckedChanged(object sender, EventArgs e) {
            lvlEditor.allowInput = chkAllowInput.Checked;
            lblLog.Text = "Toggled allow input checkbox value";
        }

        private void numLeafDelay_ValueChanged(object sender, EventArgs e) {
            lvlEditor.delay = numLeafDelay.Value;
            lblLog.Text = "Changed delay value to: " + numVolume.Value;
        }
        private void numVolume_ValueChanged(object sender, EventArgs e) {
            lvlEditor.volume = numVolume.Value;
            lblLog.Text = "Changed volume value to: " + numVolume.Value;
        }

        private void dgvLeafFiles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            switch (e.ColumnIndex){
                case 0:
                    e.Value = lvlEditor.leafFileList[e.RowIndex].name;
                    break;
                case 1:
                    e.Value = lvlEditor.leafFileList[e.RowIndex].beatCount;
                    break;
            }
        }

        private void dgvLevelFiles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e){
            switch (e.ColumnIndex){
                case 0:
                    e.Value = masterEditor.levelFileList[e.RowIndex].name;
                    break;
                case 1:
                    e.Value = masterEditor.levelFileList[e.RowIndex].restName;
                    break;
                case 2:
                    e.Value = masterEditor.levelFileList[e.RowIndex].hasCheckpoint;
                    break;
                case 3:
                    e.Value = masterEditor.levelFileList[e.RowIndex].playPlus;
                    break;
            }
        }

        private void dgvSamplesList_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            switch (e.ColumnIndex){
                case 0:
                    e.Value = lvlEditor.sampleList[e.RowIndex].name;
                    break;
                case 1:
                    e.Value = lvlEditor.sampleList[e.RowIndex].loop;
                    break;
            }
        }

        private void dgvLeafFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            DataGridView grid = (DataGridView)sender;
            grid.Rows.RemoveAt(e.RowIndex);
            lvlEditor.leafFileList.RemoveAt(e.RowIndex);

            lblLog.Text = "Removed a leaf file from list at index: " + e.RowIndex;
        }

        private void dgvLevelFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            DataGridView grid = (DataGridView)sender;
            grid.Rows.RemoveAt(e.RowIndex);
            masterEditor.levelFileList.RemoveAt(e.RowIndex);

            lblLog.Text = "Removed a level file from list at index: " + e.RowIndex;
        }

        private void dgvSamplesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            DataGridView grid = (DataGridView)sender;
            grid.Rows.RemoveAt(e.RowIndex);
            lvlEditor.sampleList.RemoveAt(e.RowIndex);
            lblLog.Text = "Removed a sample from lvl file at index: " + e.RowIndex;
        }

        private void numTimeSigLeft_ValueChanged(object sender, EventArgs e){
            UpdateTimingSignatures(dgvObstacles);
        }

        private void btnSetIntroLevel_Click(object sender, EventArgs e){
            lblIntroLevel.Text = combLevelFiles.Text;
            masterEditor.introLevelName = lblIntroLevel.Text;
        }

        private void btnSetCheckpointLevel_Click(object sender, EventArgs e){
            lblCheckpointLevel.Text = combLevelFiles.Text;
            masterEditor.checkpointLevelName = lblCheckpointLevel.Text;
        }

        private void numDefaultValue_ValueChanged(object sender, EventArgs e) {
            NumericUpDown num = (NumericUpDown)sender;

            switch (dgvObstacles.CurrentCellAddress.Y) {
                case 0:
                    editor.pitchTL[0].step_val = num.Value;
                    lblLog.Text = "List pitchTL now has default value of: " + num.Value;
                    break;
                case 1:
                    editor.rollTL[0].step_val = num.Value;
                    lblLog.Text = "List rollTL now has default value of: " + num.Value;
                    break;
                case 2:
                    editor.turnTL[0].step_val = num.Value;
                    lblLog.Text = "List turnTL now has default value of: " + num.Value;
                    break;
                case 3:
                    editor.turnAutoTL[0].step_val = num.Value;
                    lblLog.Text = "List turnAutoTL now has default value of: " + num.Value;
                    break;
                case 4:
                    editor.gameSpeedTL[0].step_val = num.Value;
                    lblLog.Text = "List gameSpeedTL now has default value of: " + num.Value;
                    break;
                case 5:
                    editor.thumpsTL[0].step_val = num.Value;
                    lblLog.Text = "List thumpsTL now has default value of: " + num.Value;
                    break;
                case 6:
                    editor.barsTL[0].step_val = num.Value;
                    lblLog.Text = "List barsTL now has default value of: " + num.Value;
                    break;
                case 7:
                    editor.multiBarsTL[0].step_val = num.Value;
                    lblLog.Text = "List multiBarsTL now has default value of: " + num.Value;
                    break;
                case 8:
                    editor.duckerTL[0].step_val = num.Value;
                    lblLog.Text = "List duckerTL now has default value of: " + num.Value;
                    break;
                case 9:
                    editor.jumpFungiTL[0].step_val = num.Value;
                    lblLog.Text = "List jumpFungiTL now has default value of: " + num.Value;
                    break;
                case 10:
                    editor.jumpSpikesTL[0].step_val = num.Value;
                    lblLog.Text = "List jumpSpikesTL now has default value of: " + num.Value;
                    break;
                case 11:
                    editor.snakesHalfTL[0].step_val = num.Value;
                    lblLog.Text = "List snakesHalfTL now has default value of: " + num.Value;
                    break;
                case 12:
                    editor.snakesQuarterTL[0].step_val = num.Value;
                    lblLog.Text = "List snakesQuarterTL now has default value of: " + num.Value;
                    break;
                case 13:
                    editor.sentryTL[0].step_val = num.Value;
                    lblLog.Text = "List sentryTL now has default value of: " + num.Value;
                    break;
                case 14:
                    editor.lfLaneTL[0].step_val = num.Value;
                    lblLog.Text = "List lfLaneTL now has default value of: " + num.Value;
                    break;
                case 15:
                    editor.lnLaneTL[0].step_val = num.Value;
                    lblLog.Text = "List lnLaneTL now has default value of: " + num.Value;
                    break;
                case 16:
                    editor.cenLaneTL[0].step_val = num.Value;
                    lblLog.Text = "List cenLaneTL now has default value of: " + num.Value;
                    break;
                case 17:
                    editor.rnLaneTL[0].step_val = num.Value;
                    lblLog.Text = "List rnLaneTL now has default value of: " + num.Value;
                    break;
                case 18:
                    editor.rfLaneTL[0].step_val = num.Value;
                    lblLog.Text = "List rfLaneTL now has default value of: " + num.Value;
                    break;
                case 19:
                    editor.scaleXTL[0].step_val = num.Value;
                    lblLog.Text = "List scaleXTL now has default value of: " + num.Value;
                    break;
                case 20:
                    editor.scaleYTL[0].step_val = num.Value;
                    lblLog.Text = "List scaleYTL now has default value of: " + num.Value;
                    break;
                case 21:
                    editor.scaleZTL[0].step_val = num.Value;
                    lblLog.Text = "List scaleZTL now has default value of: " + num.Value;
                    break;
                case 22:
                    editor.offsetXTL[0].step_val = num.Value;
                    lblLog.Text = "List offsetXTL now has default value of: " + num.Value;
                    break;
                case 23:
                    editor.offsetYTL[0].step_val = num.Value;
                    lblLog.Text = "List offsetYTL now has default value of: " + num.Value;
                    break;
                case 24:
                    editor.offsetZTL[0].step_val = num.Value;
                    lblLog.Text = "List offsetZTL now has default value of: " + num.Value;
                    break;
            }
        }

        private void combLane_SelectionChangeCommitted(object sender, EventArgs e) {
            //when combo box value changes, change object in list
            switch (dgvObstacles.CurrentCellAddress.Y) {
                case 5:
                    if (editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List thumpsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 6:
                    if (editor.barsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.barsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List barsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List multiBarsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List jumpFungiTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List jumpSpikesTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List snakesHalfTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List snakesQuarterTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 13:
                    if (editor.sentryTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.sentryTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                        lblLog.Text = "List sentryTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has lane of " + (combType.SelectedIndex + 1);
                    }
                    break;
            }
        }

        private void combType_SelectionChangeCommitted(object sender, EventArgs e) {
            //UpdateComboType();
            switch (dgvObstacles.CurrentCellAddress.Y) {
                case 5:
                    if (editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List thumpsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 6:
                    if (editor.barsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.barsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List barsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List multiBarsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List jumpFungiTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List jumpSpikesTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "snakesHalfTL barsTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List snakesQuarterTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
                case 13:
                    if (editor.sentryTL[dgvObstacles.CurrentCellAddress.X].id != 0) {
                        editor.sentryTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                        lblLog.Text = "List sentryTL" + " at index " + dgvObstacles.CurrentCellAddress.X + " now has type of " + (combType.SelectedIndex + 1);
                    }
                    break;
            }
        }

        private void numLeafLength_ValueChanged(object sender, EventArgs e) {
            NumericUpDown box = (NumericUpDown)sender;
            editor.leafLength = (int)box.Value;

            dgvObstacles.ColumnCount = editor.leafLength;

            GenerateColumnStyle(dgvObstacles);
        }

        private void dgvObstacles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            switch (e.RowIndex) {
                case 0:
                    if (editor.pitchTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.pitchTL[e.ColumnIndex].id;
                    }
                    break;
                case 1:
                    if (editor.rollTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.rollTL[e.ColumnIndex].id;
                    }
                    break;
                case 2:
                    if (editor.turnTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.turnTL[e.ColumnIndex].id;
                    }
                    break;
                case 3:
                    if (editor.turnAutoTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.turnAutoTL[e.ColumnIndex].id;
                    }
                    break;
                case 4:
                    if (editor.gameSpeedTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.gameSpeedTL[e.ColumnIndex].id;
                    }
                    break;
                case 5:
                    if (editor.thumpsTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.thumpsTL[e.ColumnIndex].id;
                    }
                    break;
                case 6:
                    if (editor.barsTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.barsTL[e.ColumnIndex].id;
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.multiBarsTL[e.ColumnIndex].id;
                    }
                    break;
                case 8:
                    if (editor.duckerTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.duckerTL[e.ColumnIndex].id;
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.jumpFungiTL[e.ColumnIndex].id;
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.jumpSpikesTL[e.ColumnIndex].id;
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.snakesHalfTL[e.ColumnIndex].id;
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.snakesQuarterTL[e.ColumnIndex].id;
                    }
                    break;
                case 13:
                    if (editor.sentryTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.sentryTL[e.ColumnIndex].id;
                    }
                    break;
                case 14:
                    if (editor.lfLaneTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.lfLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 15:
                    if (editor.lnLaneTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.lnLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 16:
                    if (editor.cenLaneTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.cenLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 17:
                    if (editor.rnLaneTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.rnLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 18:
                    if (editor.rfLaneTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.rfLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 19:
                    if (editor.scaleXTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.scaleXTL[e.ColumnIndex].id;
                    }
                    break;
                case 20:
                    if (editor.scaleYTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.scaleYTL[e.ColumnIndex].id;
                    }
                    break;
                case 21:
                    if (editor.scaleZTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.scaleZTL[e.ColumnIndex].id;
                    }
                    break;
                case 22:
                    if (editor.offsetXTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.offsetXTL[e.ColumnIndex].id;
                    }
                    break;
                case 23:
                    if (editor.offsetYTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.offsetYTL[e.ColumnIndex].id;
                    }
                    break;
                case 24:
                    if (editor.offsetZTL[e.ColumnIndex].id != 0) {
                        e.Value = editor.offsetZTL[e.ColumnIndex].id;
                    }
                    break;
            }
        }

        private void dgvObstacles_CellValuePushed(object sender, DataGridViewCellValueEventArgs e) {
            DataGridView cell = (DataGridView)sender;
            float num = 0;
            try {
                if (e.Value != null || (string)e.Value != "") {
                    num = float.Parse(e.Value.ToString());
                }
            } catch (Exception ex) {
                lblLog.Text = "Invalid input";
            }
            //resets the color to default when the value is changed depending on the time signature, then change color again if the cell should be illuminated
            if (cell.CurrentCell.ColumnIndex % (numTimeSigLeft.Value * 2) >= 0 && cell.CurrentCell.ColumnIndex % (numTimeSigLeft.Value * 2) <= 3){
                cell.CurrentCell.Style.BackColor = Color.FromArgb(40, 40, 40);
            }else{
                cell.CurrentCell.Style.BackColor = Color.FromArgb(50, 50, 50);
            }
            //UpdateTimingSignatures(dgvObstacles);
            switch (e.RowIndex) {
                case 0: //---PITCH
                    editor.pitchTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 0) cell.CurrentCell.Style.BackColor = Color.FromArgb(231, 43, 33);
                        lblLog.Text = "List pitchTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 1: //---ROLL
                    editor.rollTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 0) cell.CurrentCell.Style.BackColor = Color.FromArgb(231, 72, 33);
                        lblLog.Text = "List rollTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 2: //---TURN
                    editor.turnTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) >= 15 || float.Parse(cell.CurrentCell.Value.ToString()) <= -15) cell.CurrentCell.Style.BackColor = Color.FromArgb(231, 95, 33);
                        lblLog.Text = "List turnTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 3: //---TURN AUTO
                    editor.turnAutoTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) >= 15 || float.Parse(cell.CurrentCell.Value.ToString()) <= -15) cell.CurrentCell.Style.BackColor = Color.FromArgb(231, 119, 33);
                        lblLog.Text = "List turnAutoTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 4: //---GAME SPEED
                    editor.gameSpeedTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(200, 200, 200);
                        lblLog.Text = "List gameSpeedTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 5: //---THUMPS
                    editor.thumpsTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(32, 47, 233);
                        lblLog.Text = "List thumpsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 6: //---BARS
                    editor.barsTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(238, 176, 116);
                        lblLog.Text = "List barsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 7: //---MULTI BARS
                    editor.multiBarsTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(234, 208, 103);
                        lblLog.Text = "List multiBarsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 8: //---FLYING BARS
                    editor.duckerTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(36, 220, 227);
                        lblLog.Text = "List duckerTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 9: //---FUNGI JUMPS
                    editor.jumpFungiTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(243, 34, 34);
                        lblLog.Text = "List jumpFungiTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 10: //---SPIKE JUMPS
                    editor.jumpSpikesTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(243, 34, 142);
                        lblLog.Text = "List jumpSpikesTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 11: //---SNAKE HALF
                    editor.snakesHalfTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(160, 160, 160);
                        lblLog.Text = "List snakesHalfTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 12: //---SNAKE QUARTER
                    editor.snakesQuarterTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(200, 200, 200);
                        lblLog.Text = "List snakesQuarterTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 13: //---SENTRY
                    editor.sentryTL[e.ColumnIndex].id = (int)num;
                    if (cell.CurrentCell.Value != null) {
                        if ((int)cell.CurrentCell.Value >= 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(74, 32, 227);
                        lblLog.Text = "List sentryTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 14: //---FAR LEFT LANE
                    editor.lfLaneTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(227, 32, 94);
                        lblLog.Text = "List lfLaneTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 15: //---NEAR LEFT LANE
                    editor.lnLaneTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(227, 32, 112);
                        lblLog.Text = "List lnLaneTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 16: //---CENTER LANE
                    editor.cenLaneTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(227, 32, 150);
                        lblLog.Text = "List cenLaneTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 17: //---NEAR RIGHT LANE
                    editor.rnLaneTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(227, 32, 190);
                        lblLog.Text = "List rnLaneTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 18: //---FAR RIGHT LANE
                    editor.rfLaneTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (int.Parse(cell.CurrentCell.Value.ToString()) == 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(227, 32, 227);
                        lblLog.Text = "List rfLaneTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 19: //---SCALE X
                    editor.scaleXTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(32, 227, 113);
                        lblLog.Text = "List scaleXTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 20: //---SCALE Y
                    editor.scaleYTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(32, 227, 79);
                        lblLog.Text = "List scaleYTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 21: //---SCALE Z
                    editor.scaleZTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 1) cell.CurrentCell.Style.BackColor = Color.FromArgb(32, 227, 39);
                        lblLog.Text = "List scaleZTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 22: //---OFFSET X
                    editor.offsetXTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 0) cell.CurrentCell.Style.BackColor = Color.FromArgb(64, 227, 32);
                        lblLog.Text = "List offsetXTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 23: //---OFFSET Y
                    editor.offsetYTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 0) cell.CurrentCell.Style.BackColor = Color.FromArgb(92, 227, 32);
                        lblLog.Text = "List offsetYTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
                case 24: //---OFFSET Z
                    editor.offsetZTL[e.ColumnIndex].id = num;
                    if (cell.CurrentCell.Value != null) {
                        if (float.Parse(cell.CurrentCell.Value.ToString()) != 0) cell.CurrentCell.Style.BackColor = Color.FromArgb(120, 227, 32);
                        lblLog.Text = "List offsetZTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString();
                    }
                    break;
            }
        }

        private void dgvObstacles_CurrentCellChanged(object sender, EventArgs e) {
            DataGridView grid = (DataGridView)sender;
            UpdateComboType();  //repopulates the combo box with values associated with the object you've selected
            switch (grid.CurrentCellAddress.Y) {
                case 0:
                    numDefaultValue.Value = editor.pitchTL[0].step_val;
                    break;
                case 1:
                    numDefaultValue.Value = editor.rollTL[0].step_val;
                    break;
                case 2:
                    numDefaultValue.Value = editor.turnTL[0].step_val;
                    break;
                case 3:
                    numDefaultValue.Value = editor.turnAutoTL[0].step_val;
                    break;
                case 4:
                    numDefaultValue.Value = editor.gameSpeedTL[0].step_val;
                    break;
                case 5:
                    combLane.SelectedIndex = editor.thumpsTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.thumpsTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.thumpsTL[0].step_val;
                    break;
                case 6:
                    combLane.SelectedIndex = editor.barsTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.barsTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.barsTL[0].step_val;
                    Console.WriteLine(editor.barsTL[0].step_val);
                    break;
                case 7:
                    combLane.SelectedIndex = editor.multiBarsTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.multiBarsTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.multiBarsTL[0].step_val;
                    break;
                case 8:
                    numDefaultValue.Value = editor.duckerTL[0].step_val;
                    break;
                case 9:
                    combLane.SelectedIndex = editor.jumpFungiTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.jumpFungiTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.jumpFungiTL[0].step_val;
                    break;
                case 10:
                    combLane.SelectedIndex = editor.jumpSpikesTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.jumpSpikesTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.jumpSpikesTL[0].step_val;
                    break;
                case 11:
                    combLane.SelectedIndex = editor.snakesHalfTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.snakesHalfTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.snakesHalfTL[0].step_val;
                    break;
                case 12:
                    combLane.SelectedIndex = editor.snakesQuarterTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.snakesQuarterTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.snakesQuarterTL[0].step_val;
                    break;
                case 13:
                    combLane.SelectedIndex = editor.sentryTL[grid.CurrentCellAddress.X].laneID;
                    combType.SelectedIndex = editor.sentryTL[grid.CurrentCellAddress.X].id - 1;
                    numDefaultValue.Value = editor.sentryTL[0].step_val;
                    break;
                case 14:
                    numDefaultValue.Value = editor.lfLaneTL[0].step_val;
                    break;
                case 15:
                    numDefaultValue.Value = editor.lnLaneTL[0].step_val;
                    break;
                case 16:
                    numDefaultValue.Value = editor.cenLaneTL[0].step_val;
                    break;
                case 17:
                    numDefaultValue.Value = editor.rnLaneTL[0].step_val;
                    break;
                case 18:
                    numDefaultValue.Value = editor.rfLaneTL[0].step_val;
                    break;
                case 19:
                    numDefaultValue.Value = editor.scaleXTL[0].step_val;
                    break;
                case 20:
                    numDefaultValue.Value = editor.scaleYTL[0].step_val;
                    break;
                case 21:
                    numDefaultValue.Value = editor.scaleZTL[0].step_val;
                    break;
                case 22:
                    numDefaultValue.Value = editor.offsetXTL[0].step_val;
                    break;
                case 23:
                    numDefaultValue.Value = editor.offsetYTL[0].step_val;
                    break;
                case 24:
                    numDefaultValue.Value = editor.offsetZTL[0].step_val;
                    break;
            }
        }

        private void dgvObstacles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            DataGridView grid = sender as DataGridView;

            //checks if the cell's value contains a 0. If so, change the value to write to 1. If not, assume the cell value is already 0 and keep the value to write to 0
            int val;
            if (grid.CurrentCell.Value == null || int.Parse(grid.CurrentCell.Value.ToString()) == 0) {
                val = 1;
            } else {
                val = 0;
            }

            grid.CurrentCell.Value = val;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            //editor.Export();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            //editor.Save();
        }

        //--------------------------------------------------//
        //--------------------Non-events--------------------//
        //--------------------------------------------------//

        public void InitializeComboLane() {
            combLane.Items.Add("Far Left Lane");
            combLane.Items.Add("Near Left Lane");
            combLane.Items.Add("Center Lane");
            combLane.Items.Add("Near Right Lane");
            combLane.Items.Add("Far Right Lane");
        }

        public void InitializeDropRestLvls(){
            //combLevelFilesRest.Items.Add("None");
        }

        public void UpdateComboType() {
            combType.Items.Clear();
            combType.Text = "Select a Type";
            combType.Enabled = true;
            combLane.Enabled = true;
            switch (dgvObstacles.CurrentCellAddress.Y) {
                case 5:
                    combType.Items.Add("thump_rails");
                    combType.Items.Add("thump_checkpoint");
                    combType.Items.Add("thump_boss_bonus");
                    combType.Items.Add("thump_rails_fast_activat");
                    break;
                case 6:
                    combType.Items.Add("grindable_still");
                    combType.Items.Add("left_multi");
                    combType.Items.Add("center_multi");
                    combType.Items.Add("right_multi");
                    break;
                case 7:
                    combType.Items.Add("grindable_with_thump");
                    combType.Items.Add("grindable_double");
                    combType.Items.Add("grindable_triple");
                    combType.Items.Add("grindable_quarter");
                    break;
                case 9:
                    combType.Items.Add("jumper_1_step");
                    combType.Items.Add("jumper_boss");
                    combType.Items.Add("jumper_6_step");
                    break;
                case 10:
                    combType.Items.Add("jump_high");
                    combType.Items.Add("jump_high_2");
                    combType.Items.Add("jump_high_4");
                    combType.Items.Add("jump_high_6");
                    combType.Items.Add("jump_boss");
                    break;
                case 11:
                    combType.Items.Add("millipede_half");
                    combType.Items.Add("millipede_half_phrase");
                    combType.Items.Add("swerve_off");
                    break;
                case 12:
                    combType.Items.Add("millipede_quarter");
                    combType.Items.Add("millipede_quarter_phrase");
                    break;
                case 13:
                    combType.Items.Add("sentry");
                    combType.Items.Add("sentry_boss");
                    combType.Items.Add("sentry_boss_multilane");
                    combType.Items.Add("level_5");
                    combType.Items.Add("level_6");
                    combType.Items.Add("level_7");
                    combType.Items.Add("level_8");
                    combType.Items.Add("level_8_muilti");
                    combType.Items.Add("level_9");
                    combType.Items.Add("level_9_multi");
                    break;
                default:
                    combType.Text = "No Type Available";
                    combType.Enabled = false;
                    combLane.Enabled = false;
                    break;
            }
        }

        public void UpdateSamples() {
            combType.Items.Clear();
            combSampleName.Enabled = true;
            switch (combBpmSamples.SelectedIndex) {
                case 0:
                    for (int i = 0; i < samples.samples_lvl1.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl1[i]);
                    }
                    break;
                case 1:
                    for (int i = 0; i < samples.samples_lvl2.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl2[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < samples.samples_lvl3.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl3[i]);
                    }
                    break;
                case 3:
                    for (int i = 0; i < samples.samples_lvl4.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl4[i]);
                    }
                    break;
                case 4:
                    for (int i = 0; i < samples.samples_lvl5.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl5[i]);
                    }
                    break;
                case 5:
                    for (int i = 0; i < samples.samples_lvl6.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl6[i]);
                    }
                    break;
                case 6:
                    for (int i = 0; i < samples.samples_lvl7.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl7[i]);
                    }
                    break;
                case 7:
                    for (int i = 0; i < samples.samples_lvl8.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl8[i]);
                    }
                    break;
                case 8:
                    for (int i = 0; i < samples.samples_lvl9.Length; i++) {
                        combSampleName.Items.Add(samples.samples_lvl9[i]);
                    }
                    break;
                default:
                    combSampleName.Enabled = false;
                    break;
            }
        }

        public void InitializeComboTutorial() {
            combTutorial.Items.Add("TUTORIAL_NONE");
            combTutorial.Items.Add("TUTORIAL_THUMP");
            combTutorial.Items.Add("TUTORIAL_THUMP_REMINDER");
            combTutorial.Items.Add("TUTORIAL_TURN_LEFT");
            combTutorial.Items.Add("TUTORIAL_TURN_RIGHT");
            combTutorial.Items.Add("TUTORIAL_GRIND");
            combTutorial.Items.Add("TUTORIAL_POWER_GRIND");
            combTutorial.Items.Add("TUTORIAL_JUMP");
            combTutorial.Items.Add("TUTORIAL_POUND");
            combTutorial.Items.Add("TUTORIAL_POUND_REMINDER");
            combTutorial.Items.Add("TUTORIAL_LANES");
        }

        public void InitializeComboSampleTypes() {
            combBpmSamples.Items.Add("Select level 1 samples (320bpm)");
            combBpmSamples.Items.Add("Select level 2 samples (340bpm)");
            combBpmSamples.Items.Add("Select level 3 samples (360bpm)");
            combBpmSamples.Items.Add("Select level 4 samples (380bpm)");
            combBpmSamples.Items.Add("Select level 5 samples (400bpm)");
            combBpmSamples.Items.Add("Select level 6 samples (420bpm)");
            combBpmSamples.Items.Add("Select level 7 samples (440bpm)");
            combBpmSamples.Items.Add("Select level 8 samples (460bpm)");
            combBpmSamples.Items.Add("Select level 9 samples (480bpm)");
        }

        public void InitializeSampleDGV() {
            DataGridView grid = dgvSamplesList;

            //double buffering for DGV, found here: https://10tec.com/articles/why-datagridview-slow.aspx
            //used to significantly improve rendering performance
            if (!SystemInformation.TerminalServerSession) {
                Type dgvType = grid.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grid, true, null);
            }

            for (int i = 0; i < 2; i++) {
                DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
                switch (i) {
                    case 0:
                        dgvColumn.HeaderText = "Sample";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(string);
                        dgvColumn.CellTemplate.Value = "";
                        break;
                    case 1:
                        dgvColumn.HeaderText = "BpL";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(int);
                        dgvColumn.CellTemplate.Value = 0;
                        break;
                }
                grid.Columns.Add(dgvColumn);
            }

            GenerateInfo(grid);
            grid.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
            grid.RowTemplate.Height = 15;
            GenerateColumnStyle_lvl(grid, 2);
        }

        public void InitializeLeafDGV() {
            DataGridView grid = dgvLeafFiles;

            //double buffering for DGV, found here: https://10tec.com/articles/why-datagridview-slow.aspx
            //used to significantly improve rendering performance
            if (!SystemInformation.TerminalServerSession) {
                Type dgvType = grid.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grid, true, null);
            }

            for (int i = 0; i < 2; i++) {
                DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
                switch (i) {
                    case 0:
                        dgvColumn.HeaderText = "Leaf name";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(string);
                        dgvColumn.CellTemplate.Value = "";
                        break;
                    case 1:
                        dgvColumn.HeaderText = "BeatCnt";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(int);
                        dgvColumn.CellTemplate.Value = 0;
                        break;
                }
                grid.Columns.Add(dgvColumn);
            }

            GenerateInfo(grid);
            grid.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
            grid.RowTemplate.Height = 15;
            GenerateColumnStyle_lvl(grid, 2);
        }

        public void InitializeLevelDGV(){
            DataGridView grid = dgvLevelFiles;

            //double buffering for DGV, found here: https://10tec.com/articles/why-datagridview-slow.aspx
            //used to significantly improve rendering performance
            if (!SystemInformation.TerminalServerSession){
                Type dgvType = grid.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grid, true, null);
            }

            for (int i = 0; i < 4; i++){
                DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
                switch (i){
                    case 0:
                        dgvColumn.HeaderText = "Level name";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(string);
                        dgvColumn.CellTemplate.Value = "";
                        break;
                    case 1:
                        dgvColumn.HeaderText = "Rest lvl name";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(string);
                        dgvColumn.CellTemplate.Value = "";
                        break;
                    case 2:
                        dgvColumn.HeaderText = "Has Checkpoint";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(bool);
                        dgvColumn.CellTemplate.Value = true;
                        break;
                    case 3:
                        dgvColumn.HeaderText = "Play Plus Enabled";
                        dgvColumn.ReadOnly = true;
                        dgvColumn.ValueType = typeof(bool);
                        dgvColumn.CellTemplate.Value = true;
                        break;
                }
                grid.Columns.Add(dgvColumn);
            }

            GenerateInfo(grid);
            grid.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
            grid.RowTemplate.Height = 15;
            GenerateColumnStyle_mast(grid, 4);
        }

        public void InitializeObstacleDGV() {
            //Generate cells and shit
            DataGridView grid = dgvObstacles;

            //double buffering for DGV, found here: https://10tec.com/articles/why-datagridview-slow.aspx
            //used to significantly improve rendering performance
            if (!SystemInformation.TerminalServerSession) {
                Type dgvType = dgvObstacles.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgvObstacles, true, null);
            }

            int rowNum = 25;

            for (int i = 0; i < editor.leafLength; i++) {
                DataGridViewTextBoxColumn dgvTextColumn = new DataGridViewTextBoxColumn();
                dgvTextColumn.ValueType = typeof(string);
                dgvTextColumn.ReadOnly = false;
                dgvTextColumn.HeaderText = i.ToString();
                dgvTextColumn.CellTemplate.Value = 0;
                grid.Columns.Add(dgvTextColumn);
            }

            grid.RowCount = 0;
            //generate cells and information
            GenerateInfo(grid);
            for (int i = 0; i <= rowNum; i++) {
                grid.RowCount++;
            }
            GenerateColumnStyle(grid);
            GenerateRowHeaderText(grid);
        }

        public void InitializeDropSkybox(){
            combSkybox.Items.Add("skybox_cube");
            combSkybox.Items.Add("overlay_skybox");
        }

        public void GenerateInfo(DataGridView grid) {
            grid.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromName("Highlight");
            grid.DefaultCellStyle.SelectionForeColor = Color.FromName("HighlightText");
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.ReadOnly = false;
            grid.DataSource = null;
            grid.RowTemplate.Height = 20;
        }

        public void GenerateColumnStyle(DataGridView grid) {
            for (int i = 0; i < editor.leafLength; i++) {
                grid.Columns[i].Name = i.ToString();
                grid.Columns[i].Resizable = DataGridViewTriState.False;
                grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[i].DividerWidth = 1;
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[i].Frozen = false;
                grid.Columns[i].Width = 60;
                grid.Columns[i].MinimumWidth = 60;
                grid.Columns[i].ReadOnly = false;

                UpdateTimingSignatures(grid);
            }
        }

        public void UpdateTimingSignatures(DataGridView grid) {
            bool altColor = false;

            for (int i = 1; i <= editor.leafLength; i++) {

                switch (altColor) {
                    case false:
                        grid.Columns[i - 1].HeaderCell.Style.BackColor = Color.FromArgb(40, 40, 40);
                        grid.Columns[i - 1].DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
                        break;
                    case true:
                        grid.Columns[i - 1].HeaderCell.Style.BackColor = Color.FromArgb(50, 50, 50);
                        grid.Columns[i - 1].DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                        break;
                }

                if (i % numTimeSigLeft.Value == 0){
                    if (altColor) altColor = false;
                    else altColor = true;
                }
            }
        }

        public void GenerateColumnStyle_lvl(DataGridView grid, int iterate){
            for (int i = 0; i < iterate; i++) { 
                grid.Columns[0].Name = grid.Columns[0].ToString();
                grid.Columns[0].Resizable = DataGridViewTriState.False;
                grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[0].DividerWidth = 1;
                grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[0].Frozen = false;
                switch (i){
                    case 0:
                        grid.Columns[i].Width = 160;
                        grid.Columns[i].MinimumWidth = 160;
                        break;
                    case 1:
                        grid.Columns[i].Width = 60;
                        grid.Columns[i].MinimumWidth = 60;
                        break;
                }
            }
        }

        public void GenerateColumnStyle_mast(DataGridView grid, int iterate){
            for (int i = 0; i < iterate; i++){
                grid.Columns[0].Name = grid.Columns[0].ToString();
                grid.Columns[0].Resizable = DataGridViewTriState.False;
                grid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[0].DividerWidth = 1;
                grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[0].Frozen = false;
                switch (i){
                    case 0:
                        grid.Columns[i].Width = 120;
                        grid.Columns[i].MinimumWidth = 120;
                        break;
                    case 1:
                        grid.Columns[i].Width = 120;
                        grid.Columns[i].MinimumWidth = 120;
                        break;
                    case 2:
                        grid.Columns[i].Width = 120;
                        grid.Columns[i].MinimumWidth = 120;
                        break;
                    case 3:
                        grid.Columns[i].Width = 120;
                        grid.Columns[i].MinimumWidth = 120;
                        break;
                }
            }
        }

        public void GenerateRowHeaderText(DataGridView grid){
            grid.Rows[0].HeaderCell.Value = "pitch";
            grid.Rows[1].HeaderCell.Value = "roll";
            grid.Rows[2].HeaderCell.Value = "turn";
            grid.Rows[3].HeaderCell.Value = "turn auto";
            grid.Rows[4].HeaderCell.Value = "Game Speed";
            grid.Rows[5].HeaderCell.Value = "Thumps";
            grid.Rows[6].HeaderCell.Value = "Bars";
            grid.Rows[7].HeaderCell.Value = "Multi Bars";
            grid.Rows[8].HeaderCell.Value = "Flying Bars";
            grid.Rows[9].HeaderCell.Value = "Fungi Jumps";
            grid.Rows[10].HeaderCell.Value = "Spike Jumps";
            grid.Rows[11].HeaderCell.Value = "Snakes Half";
            grid.Rows[12].HeaderCell.Value = "Snakes Quarter";
            grid.Rows[13].HeaderCell.Value = "Sentry";
            grid.Rows[14].HeaderCell.Value = "Far Left lane";
            grid.Rows[15].HeaderCell.Value = "Near Left lane";
            grid.Rows[16].HeaderCell.Value = "Center lane";
            grid.Rows[17].HeaderCell.Value = "Near Right lane";
            grid.Rows[18].HeaderCell.Value = "Far Right lane";
            grid.Rows[19].HeaderCell.Value = "scale X";
            grid.Rows[20].HeaderCell.Value = "scale Y";
            grid.Rows[21].HeaderCell.Value = "scale Z";
            grid.Rows[22].HeaderCell.Value = "offset X";
            grid.Rows[23].HeaderCell.Value = "offset Y";
            grid.Rows[24].HeaderCell.Value = "offset Z";
        }

    }
}
