using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Services;
using System.Collections.Generic;

namespace ArraysApp
{
    public class TabPageModified : System.Windows.Forms.TabPage
    {

        public event EventHandler PrintEvent;
        public event EventHandler DeleteRowsEvent;

        public void PrintArrayEvent(EventArgs e)
        {
            var handler = PrintEvent;
            handler?.Invoke(this, e);
        }
        public void OnDeleteRowsEvent(EventArgs e)
        {
            var handler = DeleteRowsEvent;
            handler?.Invoke(this, e);
        }

        public int Type { get; set; }
        private bool KeyHandled;

        private ComboBox refcomboBox_OpenFromFile;
        private TableLayoutPanel REFtableLayoutPanel_Make;
        private TableLayoutPanel REFtableLayoutPanel_Function;
        private Panel REFpnl;
        public Button REFbtn1;
        public Button REFbtn2;

        private TableLayoutPanel tableLayoutPanelMain = new TableLayoutPanel();

        private TableLayoutPanel tableLayoutPanel_Header;
        private TableLayoutPanel tableLayoutPanel_File;
        private GroupBox groupBox_Make;
        private GroupBox groupBox_Function;

        public static Font font15 = new Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static Font font12 = new Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static Font font10 = new Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

//------- КОНСТРУКТОР ----------

        public TabPageModified(string tabText, string name,string text, int type): base()
        {            
            Type = type;
            Name = name;
            Size = new Size(300, 400);
            BackColor = SystemColors.Control;
            Location = new System.Drawing.Point(0,0);
            Margin = new System.Windows.Forms.Padding(0);
            Text = tabText;
            BorderStyle = BorderStyle.None;


            Controls.Add(tableLayoutPanelMain);

            CreateContext(text);
            UpdateMake(this);
            UpdateFunction(this);

            ModifyMainLayout();
        }

//------- МЕТОДЫ ДЛЯ ВНЕШНИХ ВЫЗОВОВ -----------

        public void SetListFiles(string[] files)
        {
            refcomboBox_OpenFromFile.Items.Clear();

            foreach (string file in files)
                refcomboBox_OpenFromFile.Items.Add(file);

        }

        public void EnableBtn1()
        {
            REFbtn1.Enabled = true;
        }
        public void EnableBtn2()
        {
            REFbtn2.Enabled = true;
        }

        public void DisableBtn1()
        {
            REFbtn1.Enabled = false;
        }
        public void DisableBtn2()
        {
            REFbtn2.Enabled = false;
        }


//------- МЕТОДЫ ДЛЯ ВНУТРЕННИХ ВЫЗОВОВ -----------

        private void UpdateMake(TabPageModified page)
        {
            ComboBox cmbBox = new ComboBox
            {
                Name = "columns",
                Location = new Point(0, 10),
                Size = new Size(40, 40),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = font12,
            };

            for (int i = 1; i < 10; i++)
                cmbBox.Items.Add(i);

            cmbBox.SelectedIndex = 0;

            Panel pnl = new Panel();
            REFpnl = pnl;

            pnl.Controls.Add(cmbBox);

            Label lbl = new Label
            {
                AutoSize = true,
                Text = "Выберите размерность массива"
            };


            if (page.Type == 2 || page.Type == 3)
            {
                ComboBox cmbBox2 = new ComboBox
                {
                    Name = "rows",
                    Location = new Point(45, 10),
                    Size = new Size(40, 40),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = font12
                };

                for (int i = 1; i < 10; i++)
                    cmbBox2.Items.Add(i);

                cmbBox2.SelectedIndex = 0;

                pnl.Controls.Add(cmbBox2);
            }

            if (Type == 3)
                cmbBox.Items.RemoveAt(8);

            page.REFtableLayoutPanel_Make.Controls.Add(pnl, 1, 0);
            page.REFtableLayoutPanel_Make.Controls.Add(lbl, 1, 1);
        }
        
        private void UpdateFunction(TabPageModified tabPageModified)
        {
           
            switch(Type){
                case 1:
                    Function1(REFtableLayoutPanel_Function);
                    break;
                case 2:
                    Function2(REFtableLayoutPanel_Function);
                    break;
                case 3:
                    Function3(REFtableLayoutPanel_Function);
                    break;
            }
            REFtableLayoutPanel_Function.Enabled = false;



        }

        private void Function1(TableLayoutPanel lpnl)
        {
            var lbl = lpnl.GetControlFromPosition(0, 0);
            var btn = (Button)lpnl.GetControlFromPosition(0, 2);


            lbl.Text = "Добавление элементов в начало массива.";
            btn.Text = "Добавить";
            btn.Enabled =  false;
            btn.Name = "btn1";

            TextBox txtBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Font = font12
            };

            btn.Click += new EventHandler((sender, e) => AddElements(txtBox, this));
            
            txtBox.KeyDown += new KeyEventHandler((sender, e) => textBoxKeyDown1(sender,e,btn));
            txtBox.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            txtBox.TextChanged += new EventHandler((sender , e) => Function1textChanged(txtBox.Text, btn));


            lpnl.Controls.Add(txtBox, 0, 1);

        }

        private void Function1textChanged(string text, Button btn)
        {
            //if (ArrayWorker.GetArray(1) != null)
            //{
                if (text == "")
                    btn.Enabled = false;
                else
                    btn.Enabled = true;

            //}
            //else
            //    btn.Enabled = false;
            }

        private void Function2(TableLayoutPanel lpnl)
        {
            var lbl = lpnl.GetControlFromPosition(0, 0);
            var btn = (Button)lpnl.GetControlFromPosition(0, 2);
            btn.Enabled = false;
            REFbtn1 = btn;

            lbl.Text = "Выберите строки на панели справа.";
            btn.Text = "Удалить";

            Label lbl2 = new Label
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Font = font12,
                
            };

            btn.Click += new EventHandler(btn_Click);

            lpnl.Controls.Add(lbl2, 0, 1);
        }

        private void Function3(TableLayoutPanel lpnl)
        {
            var lbl = lpnl.GetControlFromPosition(0, 0);
            var btn = (Button)lpnl.GetControlFromPosition(0, 2);
            btn.Name = "btn3";

            lbl.Text = "Добавление в позицию.";
            btn.Text = "Добавить";
            btn.Enabled = false;
            REFbtn2 = btn;

            TextBox txtBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Font = font12
            };
            txtBox.TextChanged += new EventHandler((sender, e) => Function3textChanged(txtBox, btn));

            btn.Click += new EventHandler((sender, e) => AddRow(txtBox, this));

            txtBox.KeyDown += new KeyEventHandler((sender, e) => textBoxKeyDown1(sender, e, btn));
            txtBox.KeyPress += new KeyPressEventHandler(textBoxKeyPress);

            lpnl.Controls.Add(txtBox, 0, 1);
        }

        private void Function3textChanged(TextBox box, Button btn)
        {
            if (ArrayWorker.GetArray(3) != null)
            {
                if (ArrayWorker.GetArray(3).Length < 8 && box.Text != "")
                    btn.Enabled = true;
                else
                    btn.Enabled = false;
            }
            else
                btn.Enabled = false;

            
        }
        
        private void AddRow(TextBox Box, TabPageModified tabPageModified)
        {
            if (Box.Text.Length != 0)
            {
                ArrayWorker.AddRow(Box.Text);
                Box.Clear();
                PrintArrayEvent(new EventArgs());
            }
        }


//------- МЕТОДЫ, ВЫЗЫВАЕМЫЕ ПРИ СОЗДАНИИ ОБЪЕКТА-------

        private void ModifyMainLayout()
        {
 
            this.tableLayoutPanelMain.BackColor = SystemColors.Control;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(423, 689);

        }

        private void CreateContext(string text)
        {
            CreateHeader(text);
            CreateFile();
            CreateMake();
            CreateFunction();
        }

        private void CreateHeader(string text)
        {
            tableLayoutPanel_Header = new TableLayoutPanel
            {
                BackColor = System.Drawing.SystemColors.Control,
                ColumnCount = 1,             
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(5, 5),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "tableLayoutPanel_Header",
                Padding = new System.Windows.Forms.Padding(3),
                RowCount = 2,             
                Size = new System.Drawing.Size(413, 101),
                TabIndex = 8
            };

            Panel panel_UnderHeader = new Panel
            {
                Anchor = System.Windows.Forms.AnchorStyles.Top,
                BackColor = Color.LightGray,
                Location = new Point(16, 58),
                Margin = new Padding(0),
                Size = new Size(381, 5),
                Name = "panel_UnderHeader"
            };

            Label label_Header = new Label
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                AutoSize = true,
                Font = font15,
                Location = new Point(6, 15),
                Name = "label_Header",
                Size = new System.Drawing.Size(145, 35),
                Text = text,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                //UseMnemonic = false
        };

            Label label_UnderHeaderStatus = new Label
            {
                AutoSize = true,
                Font = font12,
                Name = "label_UnderHeaderStatus",
                Location = new Point(6, 73),
                Size = new Size(161, 23),
                Text = "Статус: array_status"
            };

            
            //tableLayoutPanel_Header.Controls.Add(label_UnderHeaderStatus);

            tableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //tableLayoutPanel_Header.Controls.Add(tableLayoutPanel_Header.Controls[0], 0, 0);
            //tableLayoutPanel_Header.Controls.Add(tableLayoutPanel_Header.Controls[0], 0, 1);
            //tableLayoutPanel_Header.Controls.Add(tableLayoutPanel_Header.Controls[0], 0, 2);
            tableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            //tableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));

            tableLayoutPanel_Header.Controls.Add(label_Header, 0, 0);
            tableLayoutPanel_Header.Controls.Add(panel_UnderHeader, 0, 1);

            tableLayoutPanelMain.Controls.Add(tableLayoutPanel_Header, 0, 0);
        }

        private void CreateFile()
        {
            tableLayoutPanel_File = new TableLayoutPanel();

            Button button_OpenFromFile = new Button
            {
                Dock = System.Windows.Forms.DockStyle.Left,
                Location = new System.Drawing.Point(206, 3),
                Name = "button_OpenFromFile",
                Size = new System.Drawing.Size(188, 67),
                Text = "Открыть",
                UseVisualStyleBackColor = true     
            };



            ComboBox comboBox_OpenFromFile = new ComboBox
            {
                Anchor = System.Windows.Forms.AnchorStyles.Left,
                Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                FormattingEnabled = true,
                Location = new System.Drawing.Point(3, 18),
                Name = "comboBox_OpenFromFile",
                Size = new System.Drawing.Size(189, 36),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            refcomboBox_OpenFromFile = comboBox_OpenFromFile;

            button_OpenFromFile.Click += new System.EventHandler((sender, e) => button_OpenFromFile_Click(sender, e, comboBox_OpenFromFile.SelectedItem, this));            


            TableLayoutPanel tableLayoutPanel_OpenFromFile = new TableLayoutPanel
            {
                BackColor = System.Drawing.SystemColors.Control,
                ColumnCount = 2,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(3, 26),
                Name = "tableLayoutPanel_OpenFromFile",
                RowCount = 1,
                Size = new System.Drawing.Size(407, 73)
            };

            tableLayoutPanel_OpenFromFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_OpenFromFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_OpenFromFile.Controls.Add(comboBox_OpenFromFile, 0, 0);
            tableLayoutPanel_OpenFromFile.Controls.Add(button_OpenFromFile, 1, 0);
            tableLayoutPanel_OpenFromFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            GroupBox groupBox_OpenFromFile = new GroupBox
            {
                BackColor = System.Drawing.SystemColors.Control,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Font = font10,
                Location = new System.Drawing.Point(0, 101),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "groupBox_OpenFromFile",
                Size = new System.Drawing.Size(413, 102),
                TabIndex = 53,
                TabStop = false,
                Text = "Открыть из файла"
            };

            groupBox_OpenFromFile.Controls.Add(tableLayoutPanel_OpenFromFile);            
            
            TextBox textBox_FileName = new TextBox();

            Button button_SaveToFile = new Button
            {
                Dock = System.Windows.Forms.DockStyle.Left,
                Location = new System.Drawing.Point(205, 6),
                Name = "button_SaveToFile",
                Padding = new System.Windows.Forms.Padding(3),
                Size = new System.Drawing.Size(190, 60),
                Text = "Сохранить",
                UseVisualStyleBackColor = true
            };

            button_SaveToFile.Click += new EventHandler((sender, e) => button_SaveToFile_Click(sender, e, textBox_FileName));
          
            textBox_FileName.Anchor = AnchorStyles.Left;
            textBox_FileName.Font = font12;
            textBox_FileName.Location = new Point(6, 19);
            textBox_FileName.Name = "textBox_FileName";
            textBox_FileName.Size = new Size(185, 34);
            textBox_FileName.KeyDown += new KeyEventHandler((sender, e) => textBoxKeyDown(sender, e, button_SaveToFile));
            textBox_FileName.KeyPress += new KeyPressEventHandler(textBoxKeyPress);

            
            TableLayoutPanel tableLayoutPanel_SaveToFile = new TableLayoutPanel
            {
                BackColor = System.Drawing.SystemColors.Control,
                ColumnCount = 2,               
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(3, 26),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "tableLayoutPanel_SaveToFile",
                Padding = new System.Windows.Forms.Padding(3),
                RowCount = 1,              
                Size = new System.Drawing.Size(407, 72),             
            };

            tableLayoutPanel_SaveToFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87013F));
            tableLayoutPanel_SaveToFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.12987F));
            tableLayoutPanel_SaveToFile.Controls.Add(textBox_FileName, 0, 0);
            tableLayoutPanel_SaveToFile. Controls.Add(button_SaveToFile, 1, 0);
            tableLayoutPanel_SaveToFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            GroupBox groupBox_SaveToFile = new GroupBox
            {
               BackColor = System.Drawing.SystemColors.Control,
               
               Dock = System.Windows.Forms.DockStyle.Fill,
               Font = font10,
               Location = new System.Drawing.Point(0, 0),
               Margin = new System.Windows.Forms.Padding(0),
               Name = "groupBox_SaveToFile",
               Size = new System.Drawing.Size(413, 101),
               TabIndex = 54,
               TabStop = false,
               Text = "Сохранить в файл"
            };

            groupBox_SaveToFile.Controls.Add(tableLayoutPanel_SaveToFile);


            tableLayoutPanel_File.BackColor = System.Drawing.Color.Gray;
            tableLayoutPanel_File.ColumnCount = 1;
            tableLayoutPanel_File.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_File.Controls.Add(groupBox_OpenFromFile, 0, 1);
            tableLayoutPanel_File.Controls.Add(groupBox_SaveToFile, 0, 0);
            tableLayoutPanel_File.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel_File.Location = new System.Drawing.Point(5, 106);
            tableLayoutPanel_File.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel_File.Name = "tableLayoutPanel_File";
            tableLayoutPanel_File.RowCount = 2;
            tableLayoutPanel_File.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_File.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel_File.Size = new System.Drawing.Size(413, 203);
            tableLayoutPanel_File.TabIndex = 0;

            tableLayoutPanelMain.Controls.Add(tableLayoutPanel_File, 0, 1);
        }
        
        private void CreateMake()
        {

            RadioButton radioButton_Manual = new RadioButton
            {
                AutoSize = true,
                Dock = System.Windows.Forms.DockStyle.Left,
                Location = new System.Drawing.Point(6, 72),
                Name = "radioButton_Manual",
                Size = new System.Drawing.Size(103, 46),
                TabIndex = 55,
                TabStop = true,
                Text = "Вручную",
                UseVisualStyleBackColor = true
                
            };

           // radioButton_Manual.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);

            RadioButton radioButton_Random = new RadioButton
            {
                Anchor = System.Windows.Forms.AnchorStyles.Left,
                AutoSize = true,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Location = new System.Drawing.Point(6, 21),
                Name = "radioButton_Random",
                Size = new System.Drawing.Size(66, 27),
                TabIndex = 54,
                TabStop = true,
                Text = "ДСЧ",
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                UseVisualStyleBackColor = true
            };

            radioButton_Random.PerformClick();
            radioButton_Random.CheckedChanged += new System.EventHandler((sender ,e) => radioButton1_CheckedChanged(sender, e ,radioButton_Random.Checked));           
            
            Button button_MakeArray = new Button
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(6, 124),
                Name = "button_MakeArray",
                Size = new System.Drawing.Size(141, 47),
                TabIndex = 56,
                Text = "Создать",
                UseVisualStyleBackColor = true
            };

            button_MakeArray.Click += new EventHandler((sender, e) => button_MakeArray_Clicked(sender, e ,radioButton_Random.Checked));            

            TableLayoutPanel tableLayoutPanel_Make = new TableLayoutPanel
            {
                BackColor = System.Drawing.SystemColors.Control,
                ColumnCount = 2,
                
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(3, 26),
                Name = "tableLayoutPanel_Make",
                Padding = new System.Windows.Forms.Padding(3, 0, 0, 0),
                Size = new System.Drawing.Size(407, 174),
                RowCount = 3,
            };
            REFtableLayoutPanel_Make = tableLayoutPanel_Make;

            tableLayoutPanel_Make.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.63366F));
            tableLayoutPanel_Make.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.36634F));
            tableLayoutPanel_Make.Controls.Add(radioButton_Random, 0, 0);
            tableLayoutPanel_Make.Controls.Add(radioButton_Manual, 0, 1);
            tableLayoutPanel_Make.Controls.Add(button_MakeArray, 0, 2);
            
            tableLayoutPanel_Make.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanel_Make.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.45977F));
            tableLayoutPanel_Make.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.88506F));
            
            groupBox_Make = new GroupBox
            {
                BackColor = System.Drawing.SystemColors.Control,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Font = font10,
                Location = new System.Drawing.Point(5, 309),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "groupBox_Make",
                Size = new System.Drawing.Size(413, 203),
                TabIndex = 55,
                TabStop = false,
                Text = "Создание"
            };

            groupBox_Make.Controls.Add(tableLayoutPanel_Make);


            tableLayoutPanelMain.Controls.Add(groupBox_Make, 0, 2);
        }

        private void CreateFunction()
        {

            Button button_FunctionButton = new Button
            {
                Dock = System.Windows.Forms.DockStyle.Right,
                Location = new System.Drawing.Point(270, 107),
                Margin = new System.Windows.Forms.Padding(0,5,0,0),
                Name = "button_FunctionButton",
                Size = new System.Drawing.Size(114, 30),
                TabIndex = 0,
                Text = "button_Func",
                UseVisualStyleBackColor = true
            };

            Label label_Function = new Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))),
                AutoSize = true,
                Font = font12,
                Location = new System.Drawing.Point(6, 20),
                Name = "label_Function",
                Size = new System.Drawing.Size(63, 28),
                TabIndex = 1,
                Text = "label1"
            };

            TableLayoutPanel tableLayoutPanel_Function = new TableLayoutPanel
            {
                BackColor = System.Drawing.SystemColors.Control,
                ColumnCount = 1,               
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(3, 26),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "tableLayoutPanel_Function",
                Padding = new System.Windows.Forms.Padding(3),
                RowCount = 3,               
                Size = new System.Drawing.Size(407, 143)
            };

            REFtableLayoutPanel_Function = tableLayoutPanel_Function;

            tableLayoutPanel_Function.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.5F));
            tableLayoutPanel_Function.Controls.Add(button_FunctionButton, 0, 2);
            tableLayoutPanel_Function.Controls.Add(label_Function, 0, 0);
            tableLayoutPanel_Function.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.61538F));
            tableLayoutPanel_Function.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.38462F));
            tableLayoutPanel_Function.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));

            groupBox_Function = new GroupBox
            {
                BackColor = System.Drawing.SystemColors.Control,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Font = font10,
                Location = new System.Drawing.Point(5, 512),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "groupBox_Function",
                Size = new System.Drawing.Size(413, 172),
                TabIndex = 53,
                TabStop = false,
                Text = "Операция над массивом",
            };
            groupBox_Function.Controls.Add(tableLayoutPanel_Function);


            tableLayoutPanelMain.Controls.Add(groupBox_Function, 0, 3);
        }
  

//-------- ОБРАБОТЧИКИ СОБЫТИЙ -------
        
        private static void AddElements(TextBox txtBox, TabPageModified page)
        {
            ArrayWorker.AddElements(txtBox.Text);
            txtBox.Clear();
            page.PrintArrayEvent(new EventArgs());
        }
        
        private void textBoxKeyDown1(object sender, KeyEventArgs e, Button btn)
        {

            KeyHandled = false;
            System.Windows.Forms.TextBox temp = (TextBox)sender;
            bool flag = e.KeyCode == Keys.Space;

            if (e.KeyData == Keys.Left)
                KeyHandled = true;

            if (temp.Text.Length == 17 && e.KeyValue != 8)
                KeyHandled = true;

            bool f = temp.Text.Length > 0 ? Char.IsWhiteSpace(temp.Text, temp.Text.Length - 1) : false;

            if (btn.Name == "btn1")
            {
                if (ArrayWorker.GetArray(1) != null)
                    if ((temp.Text.Trim(' ').Length + 1) / 2 == 9 - ArrayWorker.GetArray(1).Length)
                        KeyHandled = true;
            }
            if (btn.Name == "btn3")
            {
                if ((temp.Text.Trim(' ').Length + 1) / 2 == 9)
                    KeyHandled = true;
            }

            
            if (flag && f)
            {
                KeyHandled = true;
            }
            if (flag && temp.Text.Length == 0) KeyHandled = true;

            if (!(char.IsDigit((char)e.KeyCode) || flag)) KeyHandled = true;

            if (temp.Text.Length != 0 && e.KeyValue == 8)
            {
                temp.Text = temp.Text.Remove(temp.Text.Length - 1);
                temp.SelectionStart = temp.Text.Length;
                temp.SelectionLength = 0;
            }

            if (char.IsDigit((char)e.KeyCode))
            {
                if (temp.Text.Length != 0)
                {
                    if (char.IsDigit(temp.Text[temp.Text.Length - 1])) KeyHandled = true;
                }
            }

            temp.SelectionStart = temp.TextLength;
            temp.SelectionLength = 0;
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            OnDeleteRowsEvent(new EventArgs());
            PrintArrayEvent(new EventArgs());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e, bool check)
        {

            try
            {
                ((ComboBox)REFpnl.Controls["rows"]).Enabled = (check) ? true : false;
                ((ComboBox)REFpnl.Controls["columns"]).Enabled = (check) ? true : false;
            }
            catch
            {
                ((ComboBox)REFpnl.Controls["columns"]).Enabled = (check) ? true : false;
            }
            
        }

        private void button_MakeArray_Clicked(object sender, EventArgs e, bool IsRandom)
        {
            if (IsRandom)
            {
                try
                {
                    var r = ((ComboBox)REFpnl.Controls["rows"]).SelectedItem;
                    var c = ((ComboBox)REFpnl.Controls["columns"]).SelectedItem;
                    ArrayWorker.CreateArrayRandom(this, (int)c, (int)r);
                }
                catch (Exception exp)
                {
                    var c = ((ComboBox)REFpnl.Controls["columns"]).SelectedItem;
                    ArrayWorker.CreateArrayRandom(this, (int)c);
                }
                PrintArrayEvent(new EventArgs());
                ActivateFunction();
            }
            else
            {
                PopupWindow popup = new PopupWindow(this.Type);
                DialogResult dialogresult = popup.ShowDialog();

                if (dialogresult == DialogResult.OK)
                {
                    PrintArrayEvent(new EventArgs());
                    ActivateFunction();
                }

                else if(dialogresult == DialogResult.Cancel)
                    Console.WriteLine("Модульное окно закрыто");

                popup.Dispose();
            }
        }

        private void button_SaveToFile_Click(object sender, EventArgs e, TextBox txtBox)
        {
            string fileName = txtBox.Text.Trim(' ');
            if (fileName != "")
            {
                FileWorker.SaveToFile(fileName, this);
                txtBox.Clear();
            }
            else
                Console.WriteLine("Введите имя файла");
        }

        static void button_OpenFromFile_Click(object sender, EventArgs e, object obj, TabPageModified page)
        {
            if (obj != null)
            {
                string name = obj.ToString();
                if (FileWorker.IsTypeCorrect(name, page.Type))
                {
                    ArrayWorker.ArrayFromString(FileWorker.ReadFromFile(name), page.Type);
                    page.PrintArrayEvent(new EventArgs());
                    page.ActivateFunction();
                }
                else
                {
                    string message = "Тип массива в файле не соответствует типу страницы";
                    string caption = "Ошибка при открытии файла";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
        }

        private void ActivateFunction()
        {
            REFtableLayoutPanel_Function.Enabled = true;
        }

        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyHandled)
            {
                e.Handled = true;
            }
        }

        private void textBoxKeyDown(object sender, KeyEventArgs e, Button saveToFile)
        {
            KeyHandled = false;
            TextBox temp = (TextBox)sender;

            if (e.KeyValue == 13)
            {
                KeyHandled = true;
                Console.WriteLine("Enter");
                saveToFile.PerformClick();
            }
            // Запрет вставки CTRL + V
            if (e.KeyData == (Keys.Control | Keys.V))
                KeyHandled = true;
            
            // Разрешенные символы: цифры, буквы, пробел, нижнее подчеркивание
            if (!(
                    char.IsLetterOrDigit((char)e.KeyCode) 
                    || 
                    char.IsWhiteSpace((char)e.KeyCode)
                    || 
                    (e.KeyData == (Keys.Shift | Keys.OemMinus))
                ))
                KeyHandled = true;

            // Запрет пробела как первого символа и запрет двух пробелов подряд
            if ((temp.Text.Length == 0 || char.IsWhiteSpace(temp.Text, temp.Text.Length - 1)) && char.IsWhiteSpace((char)e.KeyCode))
                KeyHandled = true;

            //Удаление последнего символа
            if (temp.Text.Length != 0 && e.KeyValue == 8)
            {
                temp.Text = temp.Text.Remove(temp.Text.Length - 1);
                temp.SelectionStart = temp.Text.Length;
                temp.SelectionLength = 0;
            }
        }
    }
}
