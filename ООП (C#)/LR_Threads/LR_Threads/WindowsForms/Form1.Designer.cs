
namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSpin = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSlot0Number = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSlot1Number = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSlot2Number = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSlot0Name = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblSlot1Name = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblSlot2Name = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpin
            // 
            this.btnSpin.Location = new System.Drawing.Point(660, 183);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(125, 54);
            this.btnSpin.TabIndex = 0;
            this.btnSpin.Text = "Вращать";
            this.btnSpin.UseVisualStyleBackColor = true;
            this.btnSpin.Click += new System.EventHandler(this.BtnSpin_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 304);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(776, 177);
            this.log.TabIndex = 2;
            this.log.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 286);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.lblSlot0Number);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 223);
            this.panel1.TabIndex = 0;
            // 
            // lblSlot0Number
            // 
            this.lblSlot0Number.AutoSize = true;
            this.lblSlot0Number.Font = new System.Drawing.Font("Segoe UI Semibold", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot0Number.Location = new System.Drawing.Point(32, 24);
            this.lblSlot0Number.Name = "lblSlot0Number";
            this.lblSlot0Number.Size = new System.Drawing.Size(149, 177);
            this.lblSlot0Number.TabIndex = 0;
            this.lblSlot0Number.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.lblSlot1Number);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(217, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 223);
            this.panel2.TabIndex = 1;
            // 
            // lblSlot1Number
            // 
            this.lblSlot1Number.AutoSize = true;
            this.lblSlot1Number.Font = new System.Drawing.Font("Segoe UI Semibold", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot1Number.Location = new System.Drawing.Point(33, 24);
            this.lblSlot1Number.Name = "lblSlot1Number";
            this.lblSlot1Number.Size = new System.Drawing.Size(149, 177);
            this.lblSlot1Number.TabIndex = 0;
            this.lblSlot1Number.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.lblSlot2Number);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(432, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 223);
            this.panel3.TabIndex = 2;
            // 
            // lblSlot2Number
            // 
            this.lblSlot2Number.AutoSize = true;
            this.lblSlot2Number.Font = new System.Drawing.Font("Segoe UI Semibold", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot2Number.Location = new System.Drawing.Point(35, 24);
            this.lblSlot2Number.Name = "lblSlot2Number";
            this.lblSlot2Number.Size = new System.Drawing.Size(149, 177);
            this.lblSlot2Number.TabIndex = 0;
            this.lblSlot2Number.Text = "0";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.lblSlot0Name);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 51);
            this.panel4.TabIndex = 3;
            // 
            // lblSlot0Name
            // 
            this.lblSlot0Name.AutoSize = true;
            this.lblSlot0Name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot0Name.Location = new System.Drawing.Point(58, 9);
            this.lblSlot0Name.Name = "lblSlot0Name";
            this.lblSlot0Name.Size = new System.Drawing.Size(85, 31);
            this.lblSlot0Name.TabIndex = 0;
            this.lblSlot0Name.Text = "Слот 1";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.lblSlot1Name);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(217, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 51);
            this.panel5.TabIndex = 4;
            // 
            // lblSlot1Name
            // 
            this.lblSlot1Name.AutoSize = true;
            this.lblSlot1Name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot1Name.Location = new System.Drawing.Point(58, 9);
            this.lblSlot1Name.Name = "lblSlot1Name";
            this.lblSlot1Name.Size = new System.Drawing.Size(85, 31);
            this.lblSlot1Name.TabIndex = 0;
            this.lblSlot1Name.Text = "Слот 2";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.lblSlot2Name);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(432, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(210, 51);
            this.panel6.TabIndex = 5;
            // 
            // lblSlot2Name
            // 
            this.lblSlot2Name.AutoSize = true;
            this.lblSlot2Name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlot2Name.Location = new System.Drawing.Point(59, 9);
            this.lblSlot2Name.Name = "lblSlot2Name";
            this.lblSlot2Name.Size = new System.Drawing.Size(85, 31);
            this.lblSlot2Name.TabIndex = 0;
            this.lblSlot2Name.Text = "Слот 3";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(660, 243);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(125, 52);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "Анализ";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.btnSpin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSlot0Number;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSlot1Number;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSlot2Number;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSlot0Name;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblSlot1Name;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblSlot2Name;
        private System.Windows.Forms.Button btnAnalyze;
    }
}

