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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butGenerateProblem = new System.Windows.Forms.ToolStripButton();
            this.txtNumCities = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSwapNodes = new System.Windows.Forms.Button();
            this.butReset = new System.Windows.Forms.Button();
            this.butSimBFS = new System.Windows.Forms.Button();
            this.butBasicFeasible = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusObjective = new System.Windows.Forms.ToolStripStatusLabel();
            this.digraph = new TravellingSalesman.Presentation.Digraph();
            this.list = new TravellingSalesman.Presentation.GridList();
            this.lblDistance = new System.Windows.Forms.Label();
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butGenerateProblem,
            this.txtNumCities});
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
            // txtNumCities
            // 
            this.txtNumCities.Name = "txtNumCities";
            this.txtNumCities.Size = new System.Drawing.Size(100, 25);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblDistance);
            this.panel1.Controls.Add(this.butSwapNodes);
            this.panel1.Controls.Add(this.butReset);
            this.panel1.Controls.Add(this.butSimBFS);
            this.panel1.Controls.Add(this.butBasicFeasible);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 34);
            this.panel1.TabIndex = 5;
            // 
            // butSwapNodes
            // 
            this.butSwapNodes.Location = new System.Drawing.Point(494, 3);
            this.butSwapNodes.Name = "butSwapNodes";
            this.butSwapNodes.Size = new System.Drawing.Size(136, 23);
            this.butSwapNodes.TabIndex = 4;
            this.butSwapNodes.Text = "Swap Random Nodes";
            this.butSwapNodes.UseVisualStyleBackColor = true;
            this.butSwapNodes.Click += new System.EventHandler(this.butSwapNodes_Click);
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(413, 3);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(75, 23);
            this.butReset.TabIndex = 3;
            this.butReset.Text = "Reset Cities";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // butSimBFS
            // 
            this.butSimBFS.Location = new System.Drawing.Point(332, 3);
            this.butSimBFS.Name = "butSimBFS";
            this.butSimBFS.Size = new System.Drawing.Size(75, 23);
            this.butSimBFS.TabIndex = 2;
            this.butSimBFS.Text = "Simon\'s";
            this.butSimBFS.UseVisualStyleBackColor = true;
            this.butSimBFS.Click += new System.EventHandler(this.butSimBFS_Click);
            // 
            // butBasicFeasible
            // 
            this.butBasicFeasible.Location = new System.Drawing.Point(228, 3);
            this.butBasicFeasible.Name = "butBasicFeasible";
            this.butBasicFeasible.Size = new System.Drawing.Size(98, 23);
            this.butBasicFeasible.TabIndex = 2;
            this.butBasicFeasible.Text = "Basic Feasible";
            this.butBasicFeasible.UseVisualStyleBackColor = true;
            this.butBasicFeasible.Click += new System.EventHandler(this.butBasicFeasible_Click);
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
            this.statusObjective.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusObjective.Name = "statusObjective";
            this.statusObjective.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.statusObjective.Size = new System.Drawing.Size(82, 17);
            this.statusObjective.Tag = "";
            this.statusObjective.Text = "Total Distance: ";
            // 
            // digraph
            // 
            this.digraph.BackColor = System.Drawing.Color.White;
            this.digraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digraph.Cities = null;
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
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(648, 8);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(35, 13);
            this.lblDistance.TabIndex = 5;
            this.lblDistance.Text = "label1";
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travelling Salesman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSimAnnealing;
        private TravellingSalesman.Presentation.GridList list;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butGenerateProblem;
        private TravellingSalesman.Presentation.Digraph digraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusObjective;
        private System.Windows.Forms.Button butBasicFeasible;
        private System.Windows.Forms.Button butSimBFS;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Button butSwapNodes;
        private System.Windows.Forms.ToolStripTextBox txtNumCities;
        private System.Windows.Forms.Label lblDistance;
    }
}

