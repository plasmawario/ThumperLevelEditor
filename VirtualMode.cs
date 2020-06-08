using System;
using System.Windows.Forms;
using System.Drawing;

namespace ThumperLevelEditor {
    class VirtualMode : Form {

        public DataGridView dgvObstacles = new DataGridView();

        public void Initialize(){
            //add all changed controls
            Controls.Add(dgvObstacles);
            dgvObstacles.VirtualMode = true;
            dgvObstacles.BorderStyle = BorderStyle.Fixed3D;
            dgvObstacles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvObstacles.ColumnHeadersVisible = false;
            dgvObstacles.DefaultCellStyle.BackColor = Color.FromName("Control");
            //
            dgvObstacles.DefaultCellStyle.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            dgvObstacles.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
            dgvObstacles.DefaultCellStyle.SelectionBackColor = Color.FromName("Highlight");
            dgvObstacles.DefaultCellStyle.SelectionForeColor = Color.FromName("HighlightText");
            dgvObstacles.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvObstacles.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //
            dgvObstacles.EnableHeadersVisualStyles = false;
            dgvObstacles.GridColor = Color.FromArgb(0, 0, 0);
            //
            dgvObstacles.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvObstacles.RowHeadersVisible = false;
            dgvObstacles.RowTemplate.Resizable = DataGridViewTriState.False;
            dgvObstacles.RowTemplate.Height = 200;
            //
            dgvObstacles.AllowUserToAddRows = false;
            dgvObstacles.AllowUserToDeleteRows = false;
            dgvObstacles.AllowUserToOrderColumns = false;
            dgvObstacles.AllowUserToResizeColumns = false;
            dgvObstacles.AllowUserToResizeRows = false;
            dgvObstacles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvObstacles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvObstacles.MultiSelect = false;
            dgvObstacles.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvObstacles.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvObstacles.ScrollBars = ScrollBars.Horizontal;
        }
    }
}
