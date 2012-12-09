namespace sudoku
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
            this.txtRow1 = new System.Windows.Forms.TextBox();
            this.txtRow2 = new System.Windows.Forms.TextBox();
            this.txtRow3 = new System.Windows.Forms.TextBox();
            this.txtRow4 = new System.Windows.Forms.TextBox();
            this.txtRow5 = new System.Windows.Forms.TextBox();
            this.txtRow6 = new System.Windows.Forms.TextBox();
            this.txtRow7 = new System.Windows.Forms.TextBox();
            this.txtRow8 = new System.Windows.Forms.TextBox();
            this.txtRow9 = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRow1
            // 
            this.txtRow1.Location = new System.Drawing.Point(12, 11);
            this.txtRow1.Name = "txtRow1";
            this.txtRow1.Size = new System.Drawing.Size(81, 20);
            this.txtRow1.TabIndex = 0;
            // 
            // txtRow2
            // 
            this.txtRow2.Location = new System.Drawing.Point(12, 37);
            this.txtRow2.Name = "txtRow2";
            this.txtRow2.Size = new System.Drawing.Size(81, 20);
            this.txtRow2.TabIndex = 1;
            // 
            // txtRow3
            // 
            this.txtRow3.Location = new System.Drawing.Point(12, 63);
            this.txtRow3.Name = "txtRow3";
            this.txtRow3.Size = new System.Drawing.Size(81, 20);
            this.txtRow3.TabIndex = 2;
            // 
            // txtRow4
            // 
            this.txtRow4.Location = new System.Drawing.Point(12, 105);
            this.txtRow4.Name = "txtRow4";
            this.txtRow4.Size = new System.Drawing.Size(81, 20);
            this.txtRow4.TabIndex = 3;
            // 
            // txtRow5
            // 
            this.txtRow5.Location = new System.Drawing.Point(12, 131);
            this.txtRow5.Name = "txtRow5";
            this.txtRow5.Size = new System.Drawing.Size(81, 20);
            this.txtRow5.TabIndex = 4;
            // 
            // txtRow6
            // 
            this.txtRow6.Location = new System.Drawing.Point(12, 157);
            this.txtRow6.Name = "txtRow6";
            this.txtRow6.Size = new System.Drawing.Size(81, 20);
            this.txtRow6.TabIndex = 5;
            // 
            // txtRow7
            // 
            this.txtRow7.Location = new System.Drawing.Point(12, 196);
            this.txtRow7.Name = "txtRow7";
            this.txtRow7.Size = new System.Drawing.Size(81, 20);
            this.txtRow7.TabIndex = 6;
            // 
            // txtRow8
            // 
            this.txtRow8.Location = new System.Drawing.Point(12, 222);
            this.txtRow8.Name = "txtRow8";
            this.txtRow8.Size = new System.Drawing.Size(81, 20);
            this.txtRow8.TabIndex = 7;
            // 
            // txtRow9
            // 
            this.txtRow9.Location = new System.Drawing.Point(12, 248);
            this.txtRow9.Name = "txtRow9";
            this.txtRow9.Size = new System.Drawing.Size(81, 20);
            this.txtRow9.TabIndex = 8;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(144, 47);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 9;
            this.btnSolve.Text = "SOLVE";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(144, 86);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 308);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.txtRow9);
            this.Controls.Add(this.txtRow8);
            this.Controls.Add(this.txtRow7);
            this.Controls.Add(this.txtRow6);
            this.Controls.Add(this.txtRow5);
            this.Controls.Add(this.txtRow4);
            this.Controls.Add(this.txtRow3);
            this.Controls.Add(this.txtRow2);
            this.Controls.Add(this.txtRow1);
            this.Name = "Form1";
            this.Text = "EnterPuzzleData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRow1;
        private System.Windows.Forms.TextBox txtRow2;
        private System.Windows.Forms.TextBox txtRow3;
        private System.Windows.Forms.TextBox txtRow4;
        private System.Windows.Forms.TextBox txtRow5;
        private System.Windows.Forms.TextBox txtRow6;
        private System.Windows.Forms.TextBox txtRow7;
        private System.Windows.Forms.TextBox txtRow8;
        private System.Windows.Forms.TextBox txtRow9;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnClear;




    }
}

