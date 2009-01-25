namespace TravellingSalesman.Presentation
{
    partial class GridList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colXPos,
            this.colYPos,
            this.colDistance});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(194, 448);
            this.dgvList.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 50;
            // 
            // colXPos
            // 
            this.colXPos.DataPropertyName = "X";
            this.colXPos.HeaderText = "xPos";
            this.colXPos.Name = "colXPos";
            this.colXPos.Width = 50;
            // 
            // colYPos
            // 
            this.colYPos.DataPropertyName = "Y";
            this.colYPos.HeaderText = "yPos";
            this.colYPos.Name = "colYPos";
            this.colYPos.Width = 50;
            // 
            // colDistance
            // 
            this.colDistance.DataPropertyName = "Distance";
            this.colDistance.HeaderText = "Distance";
            this.colDistance.Name = "colDistance";
            this.colDistance.Width = 50;
            // 
            // GridList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvList);
            this.Name = "GridList";
            this.Size = new System.Drawing.Size(194, 448);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
    }
}
