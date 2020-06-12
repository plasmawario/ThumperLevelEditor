using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThumperLevelEditor {
    public partial class ThumperLevelEditor : Form {
        ThumperFunctions editor = new ThumperFunctions();
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e){
            editor.MissingFeatureDialogue();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("---Program Dev's info---\nTwitter: @Plasmawario\nDiscord: Plasmawario#7852\n---Thumper Dev's info---\nWebsite: https://thumpergame.com/ \n", "Contact Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("- Pushed build to public", "Changelog betav0.1", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e){
            MessageBox.Show("Thumps - accepts 0 or 1\nBars - accepts 0 or 1\nDouble bars - accepts 0 or 1\nTurn - accepts any numberic value. Any value greater than 15 (left) or less than -15 (right) will spawn a turn that requires input. Consecutive beats requiring input connect into long turns\nPitch - accepts any numeric value. Beats with no value default to flat track\nGamma - accepts any numeric value. 0 has no effect\nStalactites - accepts 0 or 1\nTentacles - accepts 0 or 1", "Object values format list", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ThumperLevelEditor_Load(object sender, EventArgs e){
            //call script to initialize thumper editor values
            editor.Initialize();

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;

            InitializeObstacleDGV();
            InitializeGeneralDGV();
        }

        private void numLeafLength_ValueChanged(object sender, EventArgs e){
            NumericUpDown box = (NumericUpDown)sender;
            editor.leafLength = (int)box.Value;

            dgvObstacles.ColumnCount = editor.leafLength;
            dgvGeneral.ColumnCount = editor.leafLength;

            editor.ResetListLengths();
            GenerateColumnStyle(dgvObstacles);
            GenerateColumnStyle(dgvGeneral);
        }

        private void dgvObstacles_CellValuePushed(object sender, DataGridViewCellValueEventArgs e){
            DataGridView cell = (DataGridView)sender;
            int num = 0;
            if (e.Value != null){
                num = int.Parse(e.Value.ToString());
            }
            switch (e.RowIndex){
                case 0:
                    editor.thumpsTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List thumpsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 1:
                    editor.barsTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List barsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 2:
                    editor.doubleBarsTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List doubleBarsTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 3:
                    editor.turnTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List turnTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 4:
                    editor.pitchTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List pitchTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 5:
                    editor.MissingFeatureDialogue();
                    break;
            }
            //cell.UpdateCellValue(e.ColumnIndex, e.RowIndex);
            //cell.EditingControl.Text = cell.CurrentCell.EditedFormattedValue.ToString();
            //cell.ClearSelection();
            cell.RefreshEdit();
        }

        private void dgvGeneral_CellValuePushed(object sender, DataGridViewCellValueEventArgs e){
            DataGridView cell = (DataGridView)sender;
            int num = 0;
            if (e.Value != null){
                num = int.Parse(e.Value.ToString());
            }
            switch (e.RowIndex){
                case 0:
                    editor.gammaTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List gammaTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 1:
                    editor.stalactitesTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List stalactitesTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 2:
                    editor.tentaclesTL[e.ColumnIndex] = int.Parse(e.Value.ToString());
                    Console.WriteLine("List tentaclesTL" + " at index " + e.ColumnIndex + " now has value of " + e.Value.ToString());
                    break;
                case 3:
                    editor.MissingFeatureDialogue();
                    break;
            }
            
        }

        private void dgvObstacles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e){
            DataGridView grid = sender as DataGridView;
            if (obstPaintInitial <= 5) {
                switch (e.RowIndex){
                    case 0:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(11, 12, 29);
                        break;
                    case 1:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(11, 24, 29);
                        break;
                    case 2:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(11, 19, 28);
                        break;
                    case 3:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(28, 20, 3);
                        break;
                    case 4:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(28, 10, 10);
                        break;
                    case 5:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(53, 53, 53);
                        break;
                }
                obstPaintInitial++;
            }else{
                dgvObstacles.RowPrePaint -= dgvObstacles_RowPrePaint;   //ok nvm it does work but it still colors every row cell as the last color set pls fix
            }
            Console.WriteLine("h");
        }

        private void dgvGeneral_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e){

            if (generPaintInitial <= 3) {
                DataGridView grid = sender as DataGridView;
                switch (e.RowIndex){
                    case 0:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(41, 11, 37);
                        break;
                    case 1:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(14, 28, 3);
                        break;
                    case 2:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(28, 26, 3);
                        break;
                    case 3:
                        grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(31, 13, 48);
                        break;
                }
                generPaintInitial++;
            }
        }

        private void dgvObstacles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e){
            DataGridView grid = sender as DataGridView;

            //checks if the cell's value contains a 0. If so, change the value to write to 1. If not, assume the cell value is already 0 and keep the value to write to 0
            int val = 0;
            if (int.Parse(grid.CurrentCell.Value.ToString()) == 0){
                val = 1;
            }

            //this switch statement only allows 0/1 rows to have the toggle function. All other cells require manual user input
            switch (e.RowIndex){
                case 0:
                    editor.thumpsTL[e.ColumnIndex] = val;
                    Console.WriteLine("List thumpsTL" + " at index " + e.ColumnIndex + " now has value of " + val);
                    break;
                case 1:
                    editor.barsTL[e.ColumnIndex] = val;
                    Console.WriteLine("List barsTL" + " at index " + e.ColumnIndex + " now has value of " + val);
                    break;
                case 2:
                    editor.doubleBarsTL[e.ColumnIndex] = val;
                    Console.WriteLine("List doubleBarsTL" + " at index " + e.ColumnIndex + " now has value of " + val);
                    break;
            }
        }

        private void dgvGeneral_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e){
            DataGridView grid = sender as DataGridView;

            //checks if the cell's value contains a 0. If so, change the value to write to 1. If not, assume the cell value is already 0 and keep the value to write to 0
            int val = 0;
            if (int.Parse(grid.CurrentCell.Value.ToString()) == 0){
                val = 1;
            }

            //this switch statement only allows 0/1 rows to have the toggle function. All other cells require manual user input
            switch (e.RowIndex){
                case 1:
                    editor.stalactitesTL[e.ColumnIndex] = val;
                    Console.WriteLine("List stalactitesTL" + " at index " + e.ColumnIndex + " now has value of " + val);
                    break;
                case 2:
                    editor.tentaclesTL[e.ColumnIndex] = val;
                    Console.WriteLine("List tentaclesTL" + " at index " + e.ColumnIndex + " now has value of " + val);
                    break;
            }
        }

        private void dgvObstacles_CellParsing(object sender, DataGridViewCellParsingEventArgs e){
            DataGridView cell = (DataGridView)sender;
            cell.CurrentCell.Value = e.Value;
            
            e.ParsingApplied = true;
        }

        //--------------------------------------------------//
        //--------------------My--events--------------------//
        //--------------------------------------------------//
        //-----REMOVE-----//
        /*private void thumperButton_MouseClick(object sender, MouseEventArgs e){
            switch (e.Button){
                case MouseButtons.Left:
                    //
                break;
                case MouseButtons.Right:
                    RichTextBox button = sender as RichTextBox;
                    this.Controls.Remove(button);
                    editor.updateList(editor.thumpsTL, null);
                    break;
            }
        }*/
        private void thumperButtonBool_TextChanged(object sender, EventArgs e){
            //data checking
            RichTextBox button = sender as RichTextBox;
            if (!button.Text.ToString().Equals("1")){
                button.Text = "1";
            }
        }
        private void thumperButtonTurn_TextChanged(object sender, EventArgs e){
            //data checking
            RichTextBox button = sender as RichTextBox;
            editor.validatedata(editor.turnTL, button);

            if (int.Parse(button.Text) >= 15 || int.Parse(button.Text) <= -15){
                button.BackColor = Color.FromArgb(233, 172, 32);
            }else{
                button.BackColor = Color.FromArgb(28, 20, 3);
            }
        }
        private void thumperButtonPitch_TextChanged(object sender, EventArgs e){
            //data checking
            RichTextBox button = sender as RichTextBox;
            editor.validatedata(editor.pitchTL, button);
        }
        private void thumperButtonGamma_TextChanged(object sender, EventArgs e){
            //data checking
            RichTextBox button = sender as RichTextBox;
            editor.validatedata(editor.gammaTL, button);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e){
            editor.Export();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e){
            editor.Save();
        }

        //--------------------------------------------------//
        //--------------------Non-events--------------------//
        //--------------------------------------------------//

        public void InitializeObstacleDGV(){
            //Generate cells and shit
            DataGridView grid = dgvObstacles;

            grid.ColumnCount = editor.leafLength;
            grid.RowCount = 0;
            //generate cells and information
            GenerateInfo(grid);
            for (int i = 0; i <= 5; i++){
                grid.RowCount++;
                //rowsadded event sets color
            }
            GenerateColumnStyle(grid);
        }

        public void InitializeGeneralDGV(){
            //Generate more cells and more shit
            DataGridView grid = dgvGeneral;

            grid.ColumnCount = editor.leafLength;
            grid.RowCount = 0;
            //generate cells and information
            GenerateInfo(grid);
            for (int i = 0; i <= 3; i++){
                grid.RowCount++;
                //rowsadded event sets color
            }
            GenerateColumnStyle(grid);
        }

        public void GenerateInfo(DataGridView grid) {
            grid.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromName("Highlight");
            grid.DefaultCellStyle.SelectionForeColor = Color.FromName("HighlightText");
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.RowTemplate.Height = 60;
        }

        public void GenerateColumnStyle(DataGridView grid){
            for (int i = 0; i < editor.leafLength; i++){
                grid.Columns[i].Name = "Beat" + i;
                grid.Columns[i].Resizable = DataGridViewTriState.False;
                grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[i].DividerWidth = 1;
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grid.Columns[i].Frozen = false;
                grid.Columns[i].Width = 60;
                grid.Columns[i].MinimumWidth = 60;
            }
        }
    }
}
