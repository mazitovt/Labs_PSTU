using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LR8_Forms
{

    public partial class AddStudentForm : Form
    {
        protected bool KeyHandled;

        
        public AddStudentForm()
        {
            InitializeComponent();
            KeyPreview = true;

            textBox0.KeyDown += new KeyEventHandler(textBoxKeyDown);
            textBox0.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBox0.TextChanged += new EventHandler(textChanged);

            textBox1.KeyDown += new KeyEventHandler(textBoxKeyDown);
            textBox1.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBox1.TextChanged += new EventHandler(textChanged);

            textBox2.KeyDown += new KeyEventHandler(textBoxKeyDown);
            textBox2.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBox3.TextChanged += new EventHandler(textChanged);

            textBox3.KeyDown += new KeyEventHandler(textBoxKeyDownNum);
            textBox3.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            textBox3.TextChanged += new EventHandler(textChanged);
        }

        private void textChanged(object sender, EventArgs e)
        {
            if (textBox0.TextLength != 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0)
                buttonOK.Enabled = true;
            else
                buttonOK.Enabled = false;
        }

        public string[] GetText()
        {
            return new string[] {textBox0.Text, textBox1.Text, textBox2.Text, textBox3.Text};
        }

        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyHandled)
            {
                e.Handled = true;
            }
        }

        private void textBoxKeyDownNum(object sender, KeyEventArgs e)
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

        private void textBoxKeyDown(object sender, KeyEventArgs e)
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
