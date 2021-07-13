using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LR8_Forms
{
    class EditForm: Form
    {
        protected bool KeyHandled;

        protected System.Windows.Forms.TextBox textBox0;
        protected System.Windows.Forms.TextBox textBox1;
        protected System.Windows.Forms.TextBox textBox2;
        protected System.Windows.Forms.TextBox textBox3;
        protected System.Windows.Forms.Button buttonOK;
        protected System.Windows.Forms.Button buttonCancel;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        protected System.Windows.Forms.Label label4;

        protected System.ComponentModel.IContainer components = null;

        public EditForm(bool IsEditable,string title, params string [] studInfo)
        {
            InitializeComponent();
            SetTextBoxes(studInfo);

            if (IsEditable)
            {
                buttonOK.Enabled = true;
                buttonOK.Text = "Изменить";
            }
            else
            {
                buttonOK.Enabled = false;
                buttonOK.Text = "Добавить";
            }

            Text = title;


            KeyPreview = true;

            textBox0.KeyDown += new KeyEventHandler(textBoxKeyDown);
            textBox0.KeyPress += new KeyPressEventHandler(textBoxKeyPressID);
            textBox0.TextChanged += new EventHandler(textChanged);

            textBox1.KeyDown += new KeyEventHandler(textBoxKeyDownLetter);
            textBox1.KeyPress += new KeyPressEventHandler(textBoxKeyPressLetter);
            textBox1.TextChanged += new EventHandler(textChanged);

            textBox2.KeyDown += new KeyEventHandler(textBoxKeyDownLetter);
            textBox2.KeyPress += new KeyPressEventHandler(textBoxKeyPressLetter);
            textBox3.TextChanged += new EventHandler(textChanged);

            textBox3.KeyDown += new KeyEventHandler(textBoxKeyDownNum);
            textBox3.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBox3.TextChanged += new EventHandler(textChanged);
        }


        private void textBoxKeyPressID(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                KeyHandled = true;

            if (KeyHandled)
                e.Handled = true;
        }

        private void textBoxKeyPressLetter(object sender, KeyPressEventArgs e)
        {           
            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]").Success)
                if (KeyHandled)
                    e.Handled = true;
        }

        private void textBoxKeyDownLetter(object sender, KeyEventArgs e)
        {
            KeyHandled = false;

            //// Запрет вставки CTRL + V
            if (e.KeyData == (Keys.Control | Keys.V))
                KeyHandled = true;

            // Разрешенные символы: буквы
            if (!(e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyValue == 8 ))
                KeyHandled = true;         
        }

        protected void SetTextBoxes(params string[] studInfo)
        {
            if (studInfo.Length != 0)
            {
                textBox0.Text = studInfo[0];
                textBox1.Text = studInfo[1];
                textBox2.Text = studInfo[2];
                textBox3.Text = studInfo[3];
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(13, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 30);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(13, 183);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 30);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(13, 251);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(293, 30);
            this.textBox3.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(149, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(140, 37);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Добавить";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(139, 37);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Рейтинг";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.47573F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.20388F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 369);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonOK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 311);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox0
            // 
            this.textBox0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox0.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox0.Location = new System.Drawing.Point(13, 47);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(293, 30);
            this.textBox0.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Индивидуальный номер";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 369);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить студента";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected void textChanged(object sender, EventArgs e)
        {
            if (textBox0.TextLength != 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0)
                buttonOK.Enabled = true;
            else
                buttonOK.Enabled = false;
        }

        public string[] GetText()
        {
            return new string[] { textBox0.Text, textBox1.Text, textBox2.Text, textBox3.Text };
        }

        protected void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyHandled)
            {
                e.Handled = true;
            }
        }

        protected void textBoxKeyDownNum(object sender, KeyEventArgs e)
        {
            KeyHandled = false;
            bool IsPeriod = false;
            TextBox temp = (TextBox)sender;

            // Enter
            //if (e.KeyValue == 13)
            //{
            //    KeyHandled = true;
            //}

            //// Запрет вставки CTRL + V
            if (e.KeyData == (Keys.Control | Keys.V))
                KeyHandled = true;

            foreach (var ch in temp.Text)
                if (ch == ',')
                    IsPeriod = true;

            if (e.KeyData == Keys.Oemcomma && (IsPeriod || temp.Text.Length == 0))
                KeyHandled = true;

            // Разрешенные символы: цифры и точка
            if (!(char.IsDigit((char)e.KeyCode) || e.KeyData == Keys.Oemcomma))
                KeyHandled = true;


            if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                KeyHandled = true;
            //if (temp.Text.Length == 1 && e.KeyData == Keys.D0)
            //    KeyHandled = true;

            // Запрет нуля в целой части
            if (temp.Text.Length == 1 && temp.Text[0] == '0' && e.KeyData != Keys.Oemcomma)
                temp.Clear();
            // Запрет пробела как первого символа и запрет двух пробелов подряд
            //if ((temp.Text.Length == 0 || char.IsWhiteSpace(temp.Text, temp.Text.Length - 1)) && char.IsWhiteSpace((char)e.KeyCode))
            //KeyHandled = true;

            //Удаление последнего символа
            if (temp.Text.Length != 0 && e.KeyValue == 8)
            {
                temp.Text = temp.Text.Remove(temp.Text.Length - 1);
                temp.SelectionStart = temp.Text.Length;
                temp.SelectionLength = 0;
            }
        }

        protected void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            KeyHandled = false;
            TextBox temp = (TextBox)sender;

            if (e.KeyValue == 13)
            {
                KeyHandled = true;
            }

            // Запрет вставки CTRL + V
            if (e.KeyData == (Keys.Control | Keys.V))
                KeyHandled = true;

            // Разрешенные символы: цифры, буквы, пробел, нижнее подчеркивание
            if (!(
                    char.IsLetterOrDigit((char)e.KeyCode)
                    ||
                    (e.KeyData == (Keys.Shift | Keys.OemMinus))
                ))
                KeyHandled = true;

            // Запрет пробела как первого символа и запрет двух пробелов подряд
            //if ((temp.Text.Length == 0 || char.IsWhiteSpace(temp.Text, temp.Text.Length - 1)) && char.IsWhiteSpace((char)e.KeyCode))
            //   KeyHandled = true;

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
