namespace DeSparceISO
{
    partial class UnSparseIso
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
            this.components = new System.ComponentModel.Container();
            this.prgExecution = new System.Windows.Forms.ProgressBar();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.getFileNameLocation = new System.Windows.Forms.OpenFileDialog();
            this.btnUnSparse = new System.Windows.Forms.Button();
            this.toolTipRemoveSparceFlag = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // prgExecution
            // 
            this.prgExecution.Location = new System.Drawing.Point(2, 58);
            this.prgExecution.Maximum = 50;
            this.prgExecution.Name = "prgExecution";
            this.prgExecution.Size = new System.Drawing.Size(280, 10);
            this.prgExecution.TabIndex = 0;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(2, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(199, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(207, 1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // getFileNameLocation
            // 
            this.getFileNameLocation.Filter = "ISO|*.iso|All files|*.*";
            this.getFileNameLocation.InitialDirectory = "./";
            // 
            // btnUnSparse
            // 
            this.btnUnSparse.Location = new System.Drawing.Point(2, 29);
            this.btnUnSparse.Name = "btnUnSparse";
            this.btnUnSparse.Size = new System.Drawing.Size(280, 23);
            this.btnUnSparse.TabIndex = 3;
            this.btnUnSparse.Text = "Remove Sparse Flag";
            this.btnUnSparse.UseVisualStyleBackColor = true;
            this.btnUnSparse.Click += new System.EventHandler(this.btnDeSparce_Click);
            // 
            // UnSparseIso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 72);
            this.Controls.Add(this.btnUnSparse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.prgExecution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UnSparseIso";
            this.Text = "Remove Sparce Flag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ProgressBar prgExecution;
        private System.Windows.Forms.OpenFileDialog getFileNameLocation;
        private System.Windows.Forms.Button btnUnSparse;
        private System.Windows.Forms.ToolTip toolTipRemoveSparceFlag;
    }
}

