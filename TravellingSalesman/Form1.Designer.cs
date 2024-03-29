﻿namespace TravellingSalesman
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtTemp = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtDelta = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSwapNodes = new System.Windows.Forms.Button();
            this.butReset = new System.Windows.Forms.Button();
            this.butCollision = new System.Windows.Forms.Button();
            this.lblDistance = new System.Windows.Forms.Label();
            this.butSimBFS = new System.Windows.Forms.Button();
            this.butBasicFeasible = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusObjective = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yMouse = new System.Windows.Forms.Label();
            this.xMouse = new System.Windows.Forms.Label();
            this.digraph = new TravellingSalesman.Presentation.Digraph();
            this.graph = new TravellingSalesman.Presentation.Graph();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSimAnnealing
            // 
            this.butSimAnnealing.Location = new System.Drawing.Point(12, 6);
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
            this.txtNumCities,
            this.toolStripLabel1,
            this.txtTemp,
            this.toolStripLabel2,
            this.txtDelta,
            this.toolStripSeparator1});
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel1.Text = "temperature";
            // 
            // txtTemp
            // 
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(50, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel2.Text = "delta";
            // 
            // txtDelta
            // 
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.Size = new System.Drawing.Size(50, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.butSwapNodes);
            this.panel1.Controls.Add(this.butReset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 34);
            this.panel1.TabIndex = 5;
            // 
            // butSwapNodes
            // 
            this.butSwapNodes.Location = new System.Drawing.Point(231, 5);
            this.butSwapNodes.Name = "butSwapNodes";
            this.butSwapNodes.Size = new System.Drawing.Size(136, 23);
            this.butSwapNodes.TabIndex = 4;
            this.butSwapNodes.Text = "Swap Random Nodes";
            this.butSwapNodes.UseVisualStyleBackColor = true;
            this.butSwapNodes.Click += new System.EventHandler(this.butSwapNodes_Click);
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(150, 5);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(75, 23);
            this.butReset.TabIndex = 3;
            this.butReset.Text = "Reset Cities";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // butCollision
            // 
            this.butCollision.Location = new System.Drawing.Point(12, 37);
            this.butCollision.Name = "butCollision";
            this.butCollision.Size = new System.Drawing.Size(120, 23);
            this.butCollision.TabIndex = 6;
            this.butCollision.Text = "Test Collision";
            this.butCollision.UseVisualStyleBackColor = true;
            this.butCollision.Click += new System.EventHandler(this.butCollision_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(12, 131);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(35, 13);
            this.lblDistance.TabIndex = 5;
            this.lblDistance.Text = "label1";
            // 
            // butSimBFS
            // 
            this.butSimBFS.Location = new System.Drawing.Point(12, 95);
            this.butSimBFS.Name = "butSimBFS";
            this.butSimBFS.Size = new System.Drawing.Size(120, 23);
            this.butSimBFS.TabIndex = 2;
            this.butSimBFS.Text = "Quick Path";
            this.butSimBFS.UseVisualStyleBackColor = true;
            this.butSimBFS.Click += new System.EventHandler(this.butSimBFS_Click);
            // 
            // butBasicFeasible
            // 
            this.butBasicFeasible.Location = new System.Drawing.Point(12, 66);
            this.butBasicFeasible.Name = "butBasicFeasible";
            this.butBasicFeasible.Size = new System.Drawing.Size(120, 23);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.digraph);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.graph);
            this.splitContainer1.Size = new System.Drawing.Size(825, 499);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.xMouse);
            this.panel2.Controls.Add(this.yMouse);
            this.panel2.Controls.Add(this.lblDistance);
            this.panel2.Controls.Add(this.butCollision);
            this.panel2.Controls.Add(this.butSimAnnealing);
            this.panel2.Controls.Add(this.butBasicFeasible);
            this.panel2.Controls.Add(this.butSimBFS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 395);
            this.panel2.TabIndex = 5;
            // 
            // yMouse
            // 
            this.yMouse.AutoSize = true;
            this.yMouse.Location = new System.Drawing.Point(77, 162);
            this.yMouse.Name = "yMouse";
            this.yMouse.Size = new System.Drawing.Size(35, 13);
            this.yMouse.TabIndex = 7;
            this.yMouse.Text = "label1";
            // 
            // xMouse
            // 
            this.xMouse.AutoSize = true;
            this.xMouse.Location = new System.Drawing.Point(25, 162);
            this.xMouse.Name = "xMouse";
            this.xMouse.Size = new System.Drawing.Size(35, 13);
            this.xMouse.TabIndex = 8;
            this.xMouse.Text = "label2";
            // 
            // digraph
            // 
            this.digraph.Arcs = null;
            this.digraph.BackColor = System.Drawing.Color.White;
            this.digraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digraph.Cities = null;
            this.digraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digraph.Location = new System.Drawing.Point(150, 0);
            this.digraph.Margin = new System.Windows.Forms.Padding(50);
            this.digraph.Name = "digraph";
            this.digraph.Size = new System.Drawing.Size(675, 395);
            this.digraph.TabIndex = 4;
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.Color.White;
            this.graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph.Location = new System.Drawing.Point(0, 0);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(825, 100);
            this.graph.TabIndex = 7;
            this.graph.TotalDistance = ((System.Collections.Generic.List<double>)(resources.GetObject("graph.TotalDistance")));
            this.graph.Load += new System.EventHandler(this.graph_Load);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 580);
            this.Controls.Add(this.splitContainer1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSimAnnealing;
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtTemp;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtDelta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private TravellingSalesman.Presentation.Graph graph;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butCollision;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label xMouse;
        private System.Windows.Forms.Label yMouse;
    }
}

