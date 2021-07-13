using System;

namespace LR8_Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxCurator = new System.Windows.Forms.TextBox();
            this.txtBxGroupName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxSemestr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stud_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxEdit = new System.Windows.Forms.ComboBox();
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            this.radiobtnEditNum = new System.Windows.Forms.RadioButton();
            this.radiobtnEditKey = new System.Windows.Forms.RadioButton();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.labelAddInstruction = new System.Windows.Forms.Label();
            this.comboBoxAddIndex = new System.Windows.Forms.ComboBox();
            this.radiobtnAdd = new System.Windows.Forms.RadioButton();
            this.radiobtnEdit = new System.Windows.Forms.RadioButton();
            this.radiobtnDel = new System.Windows.Forms.RadioButton();
            this.groupBoxDel = new System.Windows.Forms.GroupBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.textBoxDelKey = new System.Windows.Forms.TextBox();
            this.comboBoxDelNum = new System.Windows.Forms.ComboBox();
            this.radiobtnDelNum = new System.Windows.Forms.RadioButton();
            this.radiobtnDelKey = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.groupBoxDel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.updateStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveStripMenuItem1
            // 
            this.saveStripMenuItem1.Name = "saveStripMenuItem1";
            this.saveStripMenuItem1.Size = new System.Drawing.Size(217, 28);
            this.saveStripMenuItem1.Text = "Сохранить";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(266, 27);
            this.createToolStripMenuItem.Text = "Сформировать файл 1 курса";
            // 
            // updateStripMenuItem1
            // 
            this.updateStripMenuItem1.Name = "updateStripMenuItem1";
            this.updateStripMenuItem1.Size = new System.Drawing.Size(106, 27);
            this.updateStripMenuItem1.Text = "Обновить";
            this.updateStripMenuItem1.Click += new System.EventHandler(this.UpdateView);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 60);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.2449F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.82469F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.92129F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.944544F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.8423F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.97403F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBxCurator, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBxGroupName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBxSemestr, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(559, 60);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Группа";
            // 
            // txtBxCurator
            // 
            this.txtBxCurator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBxCurator.Location = new System.Drawing.Point(415, 16);
            this.txtBxCurator.Name = "txtBxCurator";
            this.txtBxCurator.Size = new System.Drawing.Size(125, 27);
            this.txtBxCurator.TabIndex = 5;
            // 
            // txtBxGroupName
            // 
            this.txtBxGroupName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBxGroupName.Location = new System.Drawing.Point(71, 16);
            this.txtBxGroupName.Name = "txtBxGroupName";
            this.txtBxGroupName.Size = new System.Drawing.Size(102, 27);
            this.txtBxGroupName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Куратор";
            // 
            // txtBxSemestr
            // 
            this.txtBxSemestr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBxSemestr.Location = new System.Drawing.Point(282, 16);
            this.txtBxSemestr.Name = "txtBxSemestr";
            this.txtBxSemestr.Size = new System.Drawing.Size(44, 27);
            this.txtBxSemestr.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Семестр";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(470, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 605);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stud_id,
            this.sName,
            this.fName,
            this.rating});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(3, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(553, 539);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // stud_id
            // 
            this.stud_id.HeaderText = "ИД";
            this.stud_id.MinimumWidth = 6;
            this.stud_id.Name = "stud_id";
            this.stud_id.ReadOnly = true;
            // 
            // sName
            // 
            this.sName.HeaderText = "Фамилия";
            this.sName.MinimumWidth = 6;
            this.sName.Name = "sName";
            this.sName.ReadOnly = true;
            this.sName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fName
            // 
            this.fName.HeaderText = "Имя";
            this.fName.MinimumWidth = 6;
            this.fName.Name = "fName";
            this.fName.ReadOnly = true;
            this.fName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // rating
            // 
            this.rating.HeaderText = "Рейтинг";
            this.rating.MinimumWidth = 6;
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            this.rating.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.70792F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.29208F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxMain, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1029, 605);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Enabled = false;
            this.groupBoxMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxMain.Location = new System.Drawing.Point(10, 10);
            this.groupBoxMain.Margin = new System.Windows.Forms.Padding(10);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(450, 585);
            this.groupBoxMain.TabIndex = 4;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Работы с записями";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel4.Controls.Add(this.groupBoxEdit, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBoxAdd, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.radiobtnAdd, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.radiobtnEdit, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.radiobtnDel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.groupBoxDel, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.1426F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.07861F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.88483F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.89397F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(444, 559);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.buttonEdit);
            this.groupBoxEdit.Controls.Add(this.comboBoxEdit);
            this.groupBoxEdit.Controls.Add(this.textBoxEdit);
            this.groupBoxEdit.Controls.Add(this.radiobtnEditNum);
            this.groupBoxEdit.Controls.Add(this.radiobtnEditKey);
            this.groupBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEdit.Location = new System.Drawing.Point(117, 152);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(318, 164);
            this.groupBoxEdit.TabIndex = 0;
            this.groupBoxEdit.TabStop = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(202, 126);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(110, 29);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // comboBoxEdit
            // 
            this.comboBoxEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEdit.FormattingEnabled = true;
            this.comboBoxEdit.Location = new System.Drawing.Point(162, 82);
            this.comboBoxEdit.Name = "comboBoxEdit";
            this.comboBoxEdit.Size = new System.Drawing.Size(45, 28);
            this.comboBoxEdit.TabIndex = 3;
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Location = new System.Drawing.Point(162, 40);
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.Size = new System.Drawing.Size(125, 27);
            this.textBoxEdit.TabIndex = 2;
            // 
            // radiobtnEditNum
            // 
            this.radiobtnEditNum.AutoSize = true;
            this.radiobtnEditNum.Location = new System.Drawing.Point(18, 82);
            this.radiobtnEditNum.Name = "radiobtnEditNum";
            this.radiobtnEditNum.Size = new System.Drawing.Size(109, 24);
            this.radiobtnEditNum.TabIndex = 1;
            this.radiobtnEditNum.TabStop = true;
            this.radiobtnEditNum.Text = "По номеру";
            this.radiobtnEditNum.UseVisualStyleBackColor = true;
            // 
            // radiobtnEditKey
            // 
            this.radiobtnEditKey.AutoSize = true;
            this.radiobtnEditKey.Location = new System.Drawing.Point(18, 40);
            this.radiobtnEditKey.Name = "radiobtnEditKey";
            this.radiobtnEditKey.Size = new System.Drawing.Size(101, 24);
            this.radiobtnEditKey.TabIndex = 0;
            this.radiobtnEditKey.TabStop = true;
            this.radiobtnEditKey.Text = "По ключу";
            this.radiobtnEditKey.UseVisualStyleBackColor = true;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.buttonAddStudent);
            this.groupBoxAdd.Controls.Add(this.labelAddInstruction);
            this.groupBoxAdd.Controls.Add(this.comboBoxAddIndex);
            this.groupBoxAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAdd.Location = new System.Drawing.Point(117, 9);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(318, 137);
            this.groupBoxAdd.TabIndex = 0;
            this.groupBoxAdd.TabStop = false;
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Location = new System.Drawing.Point(144, 76);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(94, 29);
            this.buttonAddStudent.TabIndex = 2;
            this.buttonAddStudent.Text = "Добавить";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // labelAddInstruction
            // 
            this.labelAddInstruction.AutoSize = true;
            this.labelAddInstruction.Location = new System.Drawing.Point(18, 43);
            this.labelAddInstruction.Name = "labelAddInstruction";
            this.labelAddInstruction.Size = new System.Drawing.Size(220, 20);
            this.labelAddInstruction.TabIndex = 1;
            this.labelAddInstruction.Text = "Выберите индекс и добавить";
            // 
            // comboBoxAddIndex
            // 
            this.comboBoxAddIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddIndex.FormattingEnabled = true;
            this.comboBoxAddIndex.Location = new System.Drawing.Point(18, 77);
            this.comboBoxAddIndex.Name = "comboBoxAddIndex";
            this.comboBoxAddIndex.Size = new System.Drawing.Size(55, 28);
            this.comboBoxAddIndex.TabIndex = 0;
            // 
            // radiobtnAdd
            // 
            this.radiobtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radiobtnAdd.AutoSize = true;
            this.radiobtnAdd.Location = new System.Drawing.Point(9, 65);
            this.radiobtnAdd.Name = "radiobtnAdd";
            this.radiobtnAdd.Size = new System.Drawing.Size(101, 24);
            this.radiobtnAdd.TabIndex = 0;
            this.radiobtnAdd.TabStop = true;
            this.radiobtnAdd.Text = "Добавить";
            this.radiobtnAdd.UseVisualStyleBackColor = true;
            // 
            // radiobtnEdit
            // 
            this.radiobtnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radiobtnEdit.AutoSize = true;
            this.radiobtnEdit.Location = new System.Drawing.Point(9, 222);
            this.radiobtnEdit.Name = "radiobtnEdit";
            this.radiobtnEdit.Size = new System.Drawing.Size(102, 24);
            this.radiobtnEdit.TabIndex = 1;
            this.radiobtnEdit.TabStop = true;
            this.radiobtnEdit.Text = "Изменить";
            this.radiobtnEdit.UseVisualStyleBackColor = true;
            // 
            // radiobtnDel
            // 
            this.radiobtnDel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radiobtnDel.AutoSize = true;
            this.radiobtnDel.Location = new System.Drawing.Point(9, 386);
            this.radiobtnDel.Name = "radiobtnDel";
            this.radiobtnDel.Size = new System.Drawing.Size(87, 24);
            this.radiobtnDel.TabIndex = 2;
            this.radiobtnDel.TabStop = true;
            this.radiobtnDel.Text = "Удалить";
            this.radiobtnDel.UseVisualStyleBackColor = true;
            // 
            // groupBoxDel
            // 
            this.groupBoxDel.Controls.Add(this.buttonDel);
            this.groupBoxDel.Controls.Add(this.textBoxDelKey);
            this.groupBoxDel.Controls.Add(this.comboBoxDelNum);
            this.groupBoxDel.Controls.Add(this.radiobtnDelNum);
            this.groupBoxDel.Controls.Add(this.radiobtnDelKey);
            this.groupBoxDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDel.Location = new System.Drawing.Point(117, 322);
            this.groupBoxDel.Name = "groupBoxDel";
            this.groupBoxDel.Size = new System.Drawing.Size(318, 152);
            this.groupBoxDel.TabIndex = 7;
            this.groupBoxDel.TabStop = false;
            // 
            // buttonDel
            // 
            this.buttonDel.Enabled = false;
            this.buttonDel.Location = new System.Drawing.Point(202, 114);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(110, 29);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // textBoxDelKey
            // 
            this.textBoxDelKey.Location = new System.Drawing.Point(162, 35);
            this.textBoxDelKey.Name = "textBoxDelKey";
            this.textBoxDelKey.Size = new System.Drawing.Size(125, 27);
            this.textBoxDelKey.TabIndex = 3;
            // 
            // comboBoxDelNum
            // 
            this.comboBoxDelNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDelNum.FormattingEnabled = true;
            this.comboBoxDelNum.Location = new System.Drawing.Point(162, 75);
            this.comboBoxDelNum.Name = "comboBoxDelNum";
            this.comboBoxDelNum.Size = new System.Drawing.Size(45, 28);
            this.comboBoxDelNum.TabIndex = 2;
            // 
            // radiobtnDelNum
            // 
            this.radiobtnDelNum.AutoSize = true;
            this.radiobtnDelNum.Location = new System.Drawing.Point(18, 75);
            this.radiobtnDelNum.Name = "radiobtnDelNum";
            this.radiobtnDelNum.Size = new System.Drawing.Size(109, 24);
            this.radiobtnDelNum.TabIndex = 1;
            this.radiobtnDelNum.TabStop = true;
            this.radiobtnDelNum.Text = "По номеру";
            this.radiobtnDelNum.UseVisualStyleBackColor = true;
            // 
            // radiobtnDelKey
            // 
            this.radiobtnDelKey.AutoSize = true;
            this.radiobtnDelKey.Location = new System.Drawing.Point(18, 35);
            this.radiobtnDelKey.Name = "radiobtnDelKey";
            this.radiobtnDelKey.Size = new System.Drawing.Size(101, 24);
            this.radiobtnDelKey.TabIndex = 0;
            this.radiobtnDelKey.TabStop = true;
            this.radiobtnDelKey.Text = "По ключу";
            this.radiobtnDelKey.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 636);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "База данных кафедры";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            this.groupBoxDel.ResumeLayout(false);
            this.groupBoxDel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxCurator;
        private System.Windows.Forms.TextBox txtBxGroupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxSemestr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.RadioButton radiobtnDel;
        private System.Windows.Forms.RadioButton radiobtnEdit;
        private System.Windows.Forms.RadioButton radiobtnAdd;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelAddInstruction;
        private System.Windows.Forms.ComboBox comboBoxAddIndex;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.ToolStripMenuItem updateStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stud_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
        private System.Windows.Forms.GroupBox groupBoxDel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.TextBox textBoxDelKey;
        private System.Windows.Forms.ComboBox comboBoxDelNum;
        private System.Windows.Forms.RadioButton radiobtnDelNum;
        private System.Windows.Forms.RadioButton radiobtnDelKey;
        private System.Windows.Forms.RadioButton DEl;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxEdit;
        private System.Windows.Forms.TextBox textBoxEdit;
        private System.Windows.Forms.RadioButton radiobtnEditNum;
        private System.Windows.Forms.RadioButton radiobtnEditKey;
        private System.Windows.Forms.TextBox Edi;
    }
}

