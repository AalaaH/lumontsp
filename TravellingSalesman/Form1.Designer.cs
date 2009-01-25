namespace TravellingSalesman
{
    partial class Form1
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
            this.butSimAnnealing = new System.Windows.Forms.Button();
            this.butDiagraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butSimAnnealing
            // 
            this.butSimAnnealing.Location = new System.Drawing.Point(90, 186);
            this.butSimAnnealing.Name = "butSimAnnealing";
            this.butSimAnnealing.Size = new System.Drawing.Size(161, 23);
            this.butSimAnnealing.TabIndex = 0;
            this.butSimAnnealing.Text = "Simulated Annealing";
            this.butSimAnnealing.UseVisualStyleBackColor = true;
            this.butSimAnnealing.Click += new System.EventHandler(this.butSimAnnealing_Click);
            // 
            // butDiagraph
            // 
            this.butDiagraph.Location = new System.Drawing.Point(98, 137);
            this.butDiagraph.Name = "butDiagraph";
            this.butDiagraph.Size = new System.Drawing.Size(152, 35);
            this.butDiagraph.TabIndex = 1;
            this.butDiagraph.Text = "Diagraph";
            this.butDiagraph.UseVisualStyleBackColor = true;
            this.butDiagraph.Click += new System.EventHandler(this.butDiagraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.butDiagraph);
            this.Controls.Add(this.butSimAnnealing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSimAnnealing;
        private System.Windows.Forms.Button butDiagraph;
    }
}

