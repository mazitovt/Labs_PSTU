using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysApp
{
    public partial class PopupWindow : Form
    {
        bool KeyHandled = true;
        private int Type;
        private string first = "";
        string result = "";
        private int rowCount = 0;

        public PopupWindow(int type)
        {
            Type = type;
            InitializeComponent();
            UpdateTextBox();
            ChangeCurRowNum();

            switch (Type)
            {
                case 1: SettingsForOne(); break;
                case 2: SettingsForTwo(); break;
                case 3: SettingsForThree(); break;
            }
            KeyPreview = true;
            textBox1_TextChanged(this, new EventArgs());
        }
     
        private void ChangeCurRowNum()
        {
            label_rowNumber.Text = "[" + (rowCount + 1).ToString() + "]";
        }
        
        private void SettingsForOne()
        {
            label_Instruction.Text = "Вводите элементы массива через пробел. Количество элементов: не больше 9";
            button_AddRow.Hide();
        }
        
        private void SettingsForTwo()
        {
            label_Instruction.Text = "Вводите элементы строки через пробел. Количество элементов в каждой строке должны быть равны. '+' - добавление введенной строки.";
        }
        
        private void SettingsForThree()
        {
            label_Instruction.Text = "Вводите элементы строки через пробел. '+' - следующая строка.";

        }
        
        private void IncreaseRow()
        {
            rowCount++;
            ChangeCurRowNum();
        }
        
        private void UpdateTextBox()
        {
            textBox1.KeyDown += new KeyEventHandler(this.textBoxKeyDown);
            textBox1.KeyPress += new KeyPressEventHandler(this.textBoxKeyPress);
        }
        
        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyHandled)
            {
                e.Handled = true;
            }
        }
        
        private void textBoxKeyDown(object sender, KeyEventArgs e)
         {


            KeyHandled = false;
            System.Windows.Forms.TextBox temp = (TextBox)sender;
            bool flag = e.KeyCode == Keys.Space;

            if (e.KeyValue == 13)
            {
                KeyHandled = true;
                button_AddRow.PerformClick();
            }

            if (temp.Text.Length == 17 && e.KeyValue != 8)
                KeyHandled = true;
            bool f = temp.Text.Length > 0 ? Char.IsWhiteSpace(temp.Text, temp.Text.Length - 1) : false;
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Type == 1)
            {
                if (textBox1.Text.Length == 0)
                    button_OK.Enabled = false;
                else
                    button_OK.Enabled = true;
            }

            if (Type == 2)
            {
                if (result == "")
                    button_OK.Enabled = false;
                else
                    button_OK.Enabled = true;

                if ((first != "" && textBox1.Text.Trim(' ').Length != first.Length) || textBox1.Text.Trim(' ').Length == 0)
                    button_AddRow.Enabled = false;
                else
                    button_AddRow.Enabled = true;

            }
            if (Type == 3)
            {
                if (result == "")
                    button_OK.Enabled = false;
                else
                    button_OK.Enabled = true;
            }
        }

        private void button_AddRow_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if (rowCount != 0)
                    result += "\r\n";
                result += textBox1.Text.Trim(' ');

                if (first == "")
                    first = textBox1.Text.Trim(' ');

                textBox1.Clear();


                if (Type == 3)
                {
                    if (rowCount > 6)
                    {
                        button_AddRow.Enabled = false;
                        textBox1.Enabled = false;
                    }
                }

                if (rowCount > 7)
                {
                    button_AddRow.Enabled = false;
                    textBox1.Enabled = false;
                }
                else
                    IncreaseRow();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (Type == 1)
                result = textBox1.Text.Trim(' ');

            //if (Type == 3)
            //    result = rowCount.ToString() + "\r\n" + result;

            ArrayWorker.ArrayFromString(result, Type);
        }
    
    } 
}
