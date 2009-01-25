namespace TravellingSalesman
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.butSimAnnealing = new System.Windows.Forms.Button();
            this.butDiagraph = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butGenerateProblem = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.digraph = new TravellingSalesman.Presentation.Digraph();
            this.dgvCities = new TravellingSalesman.Presentation.GridList();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSimAnnealing
            // 
            this.butSimAnnealing.Location = new System.Drawing.Point(409, 3);
            this.butSimAnnealing.Name = "butSimAnnealing";
            this.butSimAnnealing.Size = new System.Drawing.Size(120, 25);
            this.butSimAnnealing.TabIndex = 0;
            this.butSimAnnealing.Text = "Simulated Annealing";
            this.butSimAnnealing.UseVisualStyleBackColor = true;
            this.butSimAnnealing.Click += new System.EventHandler(this.butSimAnnealing_Click);
            // 
            // butDiagraph
            // 
            this.butDiagraph.Location = new System.Drawing.Point(535, 3);
            this.butDiagraph.Name = "butDiagraph";
            this.butDiagraph.Size = new System.Drawing.Size(84, 25);
            this.butDiagraph.TabIndex = 1;
            this.butDiagraph.Text = "Diagraph";
            this.butDiagraph.UseVisualStyleBackColor = true;
            this.butDiagraph.Click += new System.EventHandler(this.butDiagraph_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butGenerateProblem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butGenerateProblem
            // 
            this.butGenerateProblem.Image = ((System.Drawing.Image)(resources.GetObject("butGenerateProblem.Image")));
            this.butGenerateProblem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butGenerateProblem.Name = "butGenerateProblem";
            this.butGenerateProblem.Size = new System.Drawing.Size(72, 22);
            this.butGenerateProblem.Text = "Generate";
            this.butGenerateProblem.Click += new System.EventHandler(this.butGenerateProblem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.butSimAnnealing);
            this.panel1.Controls.Add(this.butDiagraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(194, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 34);
            this.panel1.TabIndex = 5;
            // 
            // digraph
            // 
            this.digraph.BackColor = System.Drawing.Color.White;
            this.digraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digraph.Location = new System.Drawing.Point(194, 25);
            this.digraph.Name = "digraph";
            this.digraph.Size = new System.Drawing.Size(631, 555);
            this.digraph.TabIndex = 4;
            // 
            // dgvCities
            // 
            this.dgvCities.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCities.Location = new System.Drawing.Point(0, 25);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.Size = new System.Drawing.Size(194, 555);
            this.dgvCities.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 580);
            
            this.Controls.Add(this.digraph);
            this.Controls.Add(this.dgvCities);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            
            this.Name = "frmMain";
            this.Text = "Travelling Salesman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSimAnnealing;
        private System.Windows.Forms.Button butDiagraph;
        private TravellingSalesman.Presentation.GridList dgvCities;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butGenerateProblem;
        private TravellingSalesman.Presentation.Digraph digraph;
        private System.Windows.Forms.Panel panel1;
    }
}

