
namespace Students_IS_Frontend
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStudentsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGroupsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFirstYearStudentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSecondYearStudentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showThirdYearStudentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbxChooseController = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 27;
            this.dataGridViewMain.Size = new System.Drawing.Size(530, 419);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.showToolStripMenuItem, this.saveChangesToolStripMenuItem, this.queriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(530, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.showStudentsStripMenuItem, this.showGroupsStripMenuItem});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.showToolStripMenuItem.Text = "Показать";
            // 
            // showStudentsStripMenuItem
            // 
            this.showStudentsStripMenuItem.Name = "showStudentsStripMenuItem";
            this.showStudentsStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.showStudentsStripMenuItem.Text = "Студенты";
            this.showStudentsStripMenuItem.Click += new System.EventHandler(this.showStudentsStripMenuItem_Click);
            // 
            // showGroupsStripMenuItem
            // 
            this.showGroupsStripMenuItem.Name = "showGroupsStripMenuItem";
            this.showGroupsStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.showGroupsStripMenuItem.Text = "Группы";
            this.showGroupsStripMenuItem.Click += new System.EventHandler(this.showGroupsStripMenuItem_Click);
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.saveChangesToolStripMenuItem.Text = "Сохранить изменения";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.showFirstYearStudentsMenuItem, this.showSecondYearStudentsMenuItem, this.showThirdYearStudentsMenuItem});
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.queriesToolStripMenuItem.Text = "Запросы";
            // 
            // showFirstYearStudentsMenuItem
            // 
            this.showFirstYearStudentsMenuItem.Name = "showFirstYearStudentsMenuItem";
            this.showFirstYearStudentsMenuItem.Size = new System.Drawing.Size(369, 24);
            this.showFirstYearStudentsMenuItem.Text = "Вывести студентов 1 курса по алфавиту";
            this.showFirstYearStudentsMenuItem.Click += new System.EventHandler(this.showFirstYearStudentsMenuItem_Click);
            // 
            // showSecondYearStudentsMenuItem
            // 
            this.showSecondYearStudentsMenuItem.Name = "showSecondYearStudentsMenuItem";
            this.showSecondYearStudentsMenuItem.Size = new System.Drawing.Size(369, 24);
            this.showSecondYearStudentsMenuItem.Text = "Вывести студентов 2 курса по алфавиту";
            this.showSecondYearStudentsMenuItem.Click += new System.EventHandler(this.showSecondYearStudentsMenuItem_Click);
            // 
            // showThirdYearStudentsMenuItem
            // 
            this.showThirdYearStudentsMenuItem.Name = "showThirdYearStudentsMenuItem";
            this.showThirdYearStudentsMenuItem.Size = new System.Drawing.Size(369, 24);
            this.showThirdYearStudentsMenuItem.Text = "Вывести студентов 3 курса по алфавиту";
            this.showThirdYearStudentsMenuItem.Click += new System.EventHandler(this.showThirdYearStudentsMenuItem_Click);
            // 
            // cmbxChooseController
            // 
            this.cmbxChooseController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxChooseController.FormattingEnabled = true;
            this.cmbxChooseController.Location = new System.Drawing.Point(357, 3);
            this.cmbxChooseController.Name = "cmbxChooseController";
            this.cmbxChooseController.Size = new System.Drawing.Size(161, 25);
            this.cmbxChooseController.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.cmbxChooseController);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbxChooseController;

        private System.Windows.Forms.ToolStripMenuItem showSecondYearStudentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showThirdYearStudentsMenuItem;

        private System.Windows.Forms.ToolStripMenuItem showFirstYearStudentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showGroupsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStudentsStripMenuItem;

        private System.Windows.Forms.DataGridView dataGridViewMain;

        #endregion
    }
}

