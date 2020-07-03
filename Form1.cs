﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    public partial class ThumperLevelEditor : Form {
        //script references
        LeafFileEditor editor = new LeafFileEditor();
        Playback playback = new Playback();
        LevelFileEditor lvlEditor = new LevelFileEditor();
        MasterSequenceEditor masterEditor = new MasterSequenceEditor();
        VirtualMode virtualmode = new VirtualMode();

        public int obstPaintInitial = 0;
        public int generPaintInitial = 0;

        public ThumperLevelEditor(){
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e){
            DialogResult result = MessageBox.Show("Are you sure you wish to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes){
                Application.Exit();
            }
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e){
            editor.Export();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e){
            editor.MissingFeatureDialogue();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("---Program Dev's info---\nTwitter: @Plasmawario\nDiscord: Plasmawario#7852\n---Thumper Dev's info---\nWebsite: https://thumpergame.com/ \n", "Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("- completely reworked the ui\n- Now supports most of everything RainbowUnicorn's tools supports\n- i forgot the rest lmao", "Changelog betav0.2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("Thumps - accepts 0 or 1\nBars - accepts 0 or 1\nDouble bars - accepts 0 or 1\nTurn - accepts any numberic value. Any value greater than 15 (left) or less than -15 (right) will spawn a turn that requires input. Consecutive beats requiring input connect into long turns\nPitch - accepts any numeric value. Beats with no value default to flat track\nGamma - accepts any numeric value. 0 has no effect\nStalactites - accepts 0 or 1\nTentacles - accepts 0 or 1", "Object values format list", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //leaf file menu strips
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e){
            editor.MissingFeatureDialogue();
        }
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e){
            editor.MissingFeatureDialogue();
        }

        private void ThumperLevelEditor_Load(object sender, EventArgs e){
            //call script to initialize thumper editor values
            editor.Initialize();

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;

            InitializeObstacleDGV();
            InitializeComboLane();
            UpdateComboType();

        }

        private void numDefaultValue_ValueChanged(object sender, EventArgs e){
            NumericUpDown num = (NumericUpDown)sender;
            
            switch (dgvObstacles.CurrentCellAddress.Y){
                case 0:
                    editor.pitchTL[0].step_val = num.Value;
                    break;
                case 1:
                    editor.rollTL[0].step_val = num.Value;
                    break;
                case 2:
                    editor.turnTL[0].step_val = num.Value;
                    break;
                case 3:
                    editor.turnAutoTL[0].step_val = num.Value;
                    break;
                case 4:
                    editor.gameSpeedTL[0].step_val = num.Value;
                    break;
                case 5:
                    editor.thumpsTL[0].step_val = num.Value;
                    break;
                case 6:
                    editor.barsTL[0].step_val = num.Value;
                    break;
                case 7:
                    editor.multiBarsTL[0].step_val = num.Value;
                    break;
                case 8:
                    editor.duckerTL[0].step_val = num.Value;
                    break;
                case 9:
                    editor.jumpFungiTL[0].step_val = num.Value;
                    break;
                case 10:
                    editor.jumpSpikesTL[0].step_val = num.Value;
                    break;
                case 11:
                    editor.snakesHalfTL[0].step_val = num.Value;
                    break;
                case 12:
                    editor.snakesQuarterTL[0].step_val = num.Value;
                    break;
                case 13:
                    editor.sentryTL[0].step_val = num.Value;
                    break;
                case 14:
                    editor.lfLaneTL[0].step_val = num.Value;
                    break;
                case 15:
                    editor.lnLaneTL[0].step_val = num.Value;
                    break;
                case 16:
                    editor.cenLaneTL[0].step_val = num.Value;
                    break;
                case 17:
                    editor.rnLaneTL[0].step_val = num.Value;
                    break;
                case 18:
                    editor.rfLaneTL[0].step_val = num.Value;
                    break;
                case 19:
                    editor.scaleXTL[0].step_val = num.Value;
                    break;
                case 20:
                    editor.scaleYTL[0].step_val = num.Value;
                    break;
                case 21:
                    editor.scaleZTL[0].step_val = num.Value;
                    break;
                case 22:
                    editor.offsetXTL[0].step_val = num.Value;
                    break;
                case 23:
                    editor.offsetYTL[0].step_val = num.Value;
                    break;
                case 24:
                    editor.offsetZTL[0].step_val = num.Value;
                    break;
            }
        }

        private void combLane_SelectionChangeCommitted(object sender, EventArgs e){
            //when combo box value changes, change object in list
            switch (dgvObstacles.CurrentCellAddress.Y){
                case 5:
                    if (editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 6:
                    if (editor.barsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.barsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
                case 13:
                    if (editor.sentryTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.sentryTL[dgvObstacles.CurrentCellAddress.X].setLane(combLane.SelectedIndex);
                    }
                    break;
            }
        }

        private void combType_SelectionChangeCommitted(object sender, EventArgs e){
            //UpdateComboType();
            switch (dgvObstacles.CurrentCellAddress.Y){
                case 5:
                    if (editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.thumpsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 6:
                    if (editor.barsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.barsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.multiBarsTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.jumpFungiTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.jumpSpikesTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.snakesHalfTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.snakesQuarterTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
                case 13:
                    if (editor.sentryTL[dgvObstacles.CurrentCellAddress.X].id != 0){
                        editor.sentryTL[dgvObstacles.CurrentCellAddress.X].setType(combType.SelectedIndex + 1);
                    }
                    break;
            }
        }

        private void numLeafLength_ValueChanged(object sender, EventArgs e){
            NumericUpDown box = (NumericUpDown)sender;
            editor.leafLength = (int)box.Value;

            dgvObstacles.ColumnCount = editor.leafLength;

            GenerateColumnStyle(dgvObstacles);
        }

        private void dgvObstacles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e){
            switch (e.RowIndex){
                case 0:
                    if (editor.pitchTL[e.ColumnIndex].id != 0){
                        e.Value = editor.pitchTL[e.ColumnIndex].id;
                    }
                    break;
                case 1:
                    if (editor.rollTL[e.ColumnIndex].id != 0){
                        e.Value = editor.rollTL[e.ColumnIndex].id;
                    }
                    break;
                case 2:
                    if (editor.turnTL[e.ColumnIndex].id != 0){
                        e.Value = editor.turnTL[e.ColumnIndex].id;
                    }
                    break;
                case 3:
                    if (editor.turnAutoTL[e.ColumnIndex].id != 0){
                        e.Value = editor.turnAutoTL[e.ColumnIndex].id;
                    }
                    break;
                case 4:
                    if (editor.gameSpeedTL[e.ColumnIndex].id != 0){
                        e.Value = editor.gameSpeedTL[e.ColumnIndex].id;
                    }
                    break;
                case 5:
                    if (editor.thumpsTL[e.ColumnIndex].id != 0){
                        e.Value = editor.thumpsTL[e.ColumnIndex].id;
                    }
                    break;
                case 6:
                    if (editor.barsTL[e.ColumnIndex].id != 0){
                        e.Value = editor.barsTL[e.ColumnIndex].id;
                    }
                    break;
                case 7:
                    if (editor.multiBarsTL[e.ColumnIndex].id != 0){
                        e.Value = editor.multiBarsTL[e.ColumnIndex].id;
                    }
                    break;
                case 8:
                    if (editor.duckerTL[e.ColumnIndex].id != 0){
                        e.Value = editor.duckerTL[e.ColumnIndex].id;
                    }
                    break;
                case 9:
                    if (editor.jumpFungiTL[e.ColumnIndex].id != 0){
                        e.Value = editor.jumpFungiTL[e.ColumnIndex].id;
                    }
                    break;
                case 10:
                    if (editor.jumpSpikesTL[e.ColumnIndex].id != 0){
                        e.Value = editor.jumpSpikesTL[e.ColumnIndex].id;
                    }
                    break;
                case 11:
                    if (editor.snakesHalfTL[e.ColumnIndex].id != 0){
                        e.Value = editor.snakesHalfTL[e.ColumnIndex].id;
                    }
                    break;
                case 12:
                    if (editor.snakesQuarterTL[e.ColumnIndex].id != 0){
                        e.Value = editor.snakesQuarterTL[e.ColumnIndex].id;
                    }
                    break;
                case 13:
                    if (editor.sentryTL[e.ColumnIndex].id != 0){
                        e.Value = editor.sentryTL[e.ColumnIndex].id;
                    }
                    break;
                case 14:
                    if (editor.lfLaneTL[e.ColumnIndex].id != 0){
                        e.Value = editor.lfLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 15:
                    if (editor.lnLaneTL[e.ColumnIndex].id != 0){
                        e.Value = editor.lnLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 16:
                    if (editor.cenLaneTL[e.ColumnIndex].id != 0){
                        e.Value = editor.cenLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 17:
                    if (editor.rnLaneTL[e.ColumnIndex].id != 0){
                        e.Value = editor.rnLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 18:
                    if (editor.rfLaneTL[e.ColumnIndex].id != 0){
                        e.Value = editor.rfLaneTL[e.ColumnIndex].id;
                    }
                    break;
                case 19:
                    if (editor.scaleXTL[e.ColumnIndex].id != 0){
                        e.Value = editor.scaleXTL[e.ColumnIndex].id;
                    }
                    break;
                case 20:
                    if (editor.scaleYTL[e.ColumnIndex].id != 0){
                        e.Value = editor.scaleYTL[e.ColumnIndex].id;
                    }
                    break;
                case 21:
                    if (editor.scaleZTL[e.ColumnIndex].id != 0){
                        e.Value = editor.scaleZTL[e.ColumnIndex].id;
                    }
                    break;
                case 22:
                    if (editor.offsetXTL[e.ColumnIndex].id != 0){
                        e.Value = editor.offsetXTL[e.ColumnIndex].id;
                    }
                    break;
                case 23:
                    if (editor.offsetYTL[e.ColumnIndex].id != 0){
                        e.Value = editor.offsetYTL[e.ColumnIndex].id;
                    }
                    break;
                case 24:
                    if (editor.offsetZTL[e.ColumnIndex].id != 0){
                        e.Value = editor.offsetZTL[e.ColumnIndex].id;
                    }
                    break;
            }
        }

        private void dgvObstacles_CellValuePushed(object sender, DataGridViewCellValueEventArgs e){
            DataGridView cell = (DataGridView)sender;
            float num = 0;
            try{
                if (e.Value != null || (string)e.Value != ""){
                    num = float.Parse(e.Value.ToString());
                }
            }catch(Exception ex){
                lblLog.Text = "Invalid input";
            }
            //resets the color to default when the value is changed, then change color again if the cell should be illuminated
            cell.CurrentCell.Style.BackColor = Color.FromArgb(40, 40, 40);
            switch (e.RowIndex){
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
                    editor.duckerTL[e.ColumnIndex].id = num;
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

        private void dgvObstacles_CurrentCellChanged(object sender, EventArgs e){
            DataGridView grid = (DataGridView)sender;
            UpdateComboType();  //repopulates the combo box with values associated with the object you've selected
            switch (grid.CurrentCellAddress.Y){
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

        private void dgvObstacles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e){
            DataGridView grid = sender as DataGridView;

            //checks if the cell's value contains a 0. If so, change the value to write to 1. If not, assume the cell value is already 0 and keep the value to write to 0
            int val;
            if (grid.CurrentCell.Value == null || int.Parse(grid.CurrentCell.Value.ToString()) == 0){
                val = 1;
            }else{
                val = 0;
            }

            grid.CurrentCell.Value = val;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e){
            //editor.Export();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e){
            //editor.Save();
        }

        //--------------------------------------------------//
        //--------------------Non-events--------------------//
        //--------------------------------------------------//

        public void InitializeComboLane(){
            combLane.Items.Add("Far Left Lane");
            combLane.Items.Add("Near Left Lane");
            combLane.Items.Add("Center Lane");
            combLane.Items.Add("Near Right Lane");
            combLane.Items.Add("Far Right Lane");
        }

        public void UpdateComboType(){
            combType.Items.Clear();
            combType.Enabled = true;
            combLane.Enabled = true;
            switch (dgvObstacles.CurrentCellAddress.Y){
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
                    combType.Items.Add("No Type Available");
                    combType.Enabled = false;
                    combLane.Enabled = false;
                    break;
            }
        }

        public void InitializeObstacleDGV(){
            //Generate cells and shit
            DataGridView grid = dgvObstacles;

            int rowNum = 25;

            for (int i = 0; i < editor.leafLength; i++){
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
            for (int i = 0; i <= rowNum; i++){
                grid.RowCount++;
            }
            GenerateColumnStyle(grid);
            GenerateRowHeaderText(grid);
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

        public void GenerateColumnStyle(DataGridView grid){
            for (int i = 0; i < editor.leafLength; i++){
                grid.Columns[i].Name = i.ToString();
                grid.Columns[i].Resizable = DataGridViewTriState.False;
                grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[i].DividerWidth = 1;
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[i].Frozen = false;
                grid.Columns[i].Width = 60;
                grid.Columns[i].MinimumWidth = 60;
                //grid.Columns[i].
                grid.Columns[i].ReadOnly = false;
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
