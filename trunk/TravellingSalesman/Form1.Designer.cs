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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusObjective = new System.Windows.Forms.ToolStripStatusLabel();
            this.butBasicFeasible = new System.Windows.Forms.Button();
            this.digraph = new TravellingSalesman.Presentation.Digraph();
            this.list = new TravellingSalesman.Presentation.GridList();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSimAnnealing
            // 
            this.butSimAnnealing.Location = new System.Drawing.Point(12, 28);
            this.butSimAnnealing.Name = "butSimAnnealing";
            this.butSimAnnealing.Size = new System.Drawing.Size(120, 25);
            this.butSimAnnealing.TabIndex = 0;
            this.butSimAnnealing.Text = "Simulated Annealing";
            this.butSimAnnealing.UseVisualStyleBackColor = true;
            this.butSimAnnealing.Click += new System.EventHandler(this.butSimAnnealing_Click);
            // 
            // butDiagraph
            // 
            this.butDiagraph.Location = new System.Drawing.Point(138, 3);
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
            this.panel1.Controls.Add(this.butBasicFeasible);
            this.panel1.Controls.Add(this.butDiagraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 34);
            this.panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusObjective});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusObjective
            // 
            this.statusObjective.Name = "statusObjective";
            this.statusObjective.Size = new System.Drawing.Size(82, 17);
            this.statusObjective.Tag = "";
            this.statusObjective.Text = "Total Distance: ";
            // 
            // butBasicFeasible
            // 
            this.butBasicFeasible.Location = new System.Drawing.Point(228, 3);
            this.butBasicFeasible.Name = "butBasicFeasible";
            this.butBasicFeasible.Size = new System.Drawing.Size(75, 23);
            this.butBasicFeasible.TabIndex = 2;
            this.butBasicFeasible.Text = "BFS";
            this.butBasicFeasible.UseVisualStyleBackColor = true;
            this.butBasicFeasible.Click += new System.EventHandler(this.butBasicFeasible_Click);
            // 
            // digraph
            // 
            this.digraph.BackColor = System.Drawing.Color.White;
            this.digraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digraph.Location = new System.Drawing.Point(242, 59);
            this.digraph.Margin = new System.Windows.Forms.Padding(50);
            this.digraph.Name = "digraph";
            this.digraph.Size = new System.Drawing.Size(583, 499);
            this.digraph.TabIndex = 4;
            // 
            // list
            // 
            this.list.Dock = System.Windows.Forms.DockStyle.Left;
            this.list.Location = new System.Drawing.Point(0, 59);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(242, 499);
            this.list.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 580);
            this.Controls.Add(this.butSimAnnealing);
            this.Controls.Add(this.digraph);
            this.Controls.Add(this.list);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
            this.Text = "Travelling Salesman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSimAnnealing;
        private System.Windows.Forms.Button butDiagraph;
        private TravellingSalesman.Presentation.GridList list;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butGenerateProblem;
        private TravellingSalesman.Presentation.Digraph digraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusObjective;
        private System.Windows.Forms.Button butBasicFeasible;
    }
}

