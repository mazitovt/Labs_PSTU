using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysApp
{
    public partial class Form1 : Form
    {
        private bool KeyHandled = true;
        private TabPageModified REFtabPage2;
        private TabPageModified REFtabPage3;

        public Form1()
        {
            InitializeComponent();
            UpdateForm();
            UpdateDataGridView();
            UpdateTabControl();
            WritePanelsRowsColumns();
        }

        private void UpdateTabControl()
        {

            TabPageModified tabPage1 = new TabPageModified("[  ]", "tabPage1", "Одномерный массив",1);
            tabPage1.PrintEvent += new EventHandler(PrintArrayRouter);         
            tabControl1.Controls.Add(tabPage1);

            TabPageModified tabPage2 = new TabPageModified("[ , ]", "tabPage2", "Двумерный массив",2);
            tabPage2.PrintEvent += new EventHandler(PrintArrayRouter);           
            tabPage2.DeleteRowsEvent += new EventHandler(DeleteRows);
            REFtabPage2 = tabPage2;
            tabControl1.Controls.Add(tabPage2);           

            TabPageModified tabPage3 = new TabPageModified("[  ] [  ]","tabPage3", "Рваный массив",3);
            tabPage3.PrintEvent += new EventHandler(PrintArrayRouter);
            REFtabPage3 = tabPage3;
            tabControl1.Controls.Add(tabPage3);

           
            ArrayWorker.AddPage(tabPage1.Type, ArrayWorker.array1);
            ArrayWorker.AddPage(tabPage2.Type, ArrayWorker.array2);
            ArrayWorker.AddPage(tabPage3.Type, ArrayWorker.array3);

            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            tabControl1.SelectedIndexChanged += new EventHandler(PageChanged);

            PageChanged(tabControl1, new EventArgs());

        }

        private void PageChanged(object sender, EventArgs e)
        {
            TabPageModified page = (TabPageModified)tabControl1.TabPages[tabControl1.SelectedIndex];
            page.SetListFiles(FileWorker.GetFilesList());
            MultiSelection(tabControl1.SelectedIndex);
            PrintArrayRouter(page, new EventArgs());
        }

        private void MultiSelection(int index)
        {
            if (index == 1)
                dataGridView2.MultiSelect = true;
            if (index == 2)
                dataGridView2.MultiSelect = false;
        }

        public void ClearDataGridView()
        {
            for (int i=0; i< dataGridView2.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    dataGridView2[i, j].Value = "";
                }
            }
        }

        public void PrintArrayRouter(object page, EventArgs e)
        {
            SetRows(0);
            var array = ArrayWorker.GetArray(((TabPageModified)page).Type);
            if (array != null)
                PrintArray(array);
        }
     
        public void PrintArray(string[] array)
        {
            if (array.Length != 0)
            {
                SetRows(1);
                for (int i = 0; i < array.Length; i++)
                    dataGridView2[i, 0].Value = array[i];
            }
           
        }

        public void PrintArray(string[,] array)
        {
            SetRows(array.GetLength(0));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    dataGridView2[j, i].Value = array[i, j];
            }
        }

        public void PrintArray(string[][] array)
        {
            SetRows(array.Length + 1);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    dataGridView2[j, i].Value = array[i][j];
            }
        }

        private void WritePanelsRowsColumns()
        {

            for (int i = 0; i < tableLayoutPanel_Columns.ColumnCount; i++)
            {
                Label temp = new Label
                {
                    Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Text = $"[{i + 1}]"
                };
                
                tableLayoutPanel_Columns.Controls.Add(temp, i, 0);

                temp.Dock = DockStyle.Fill;
            }

            for (int i = 0; i < tableLayoutPanel_Rows.RowCount; i++)
            {
                Label temp = new Label
                {
                    Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Text = $"[{i + 1}]"
                };
                tableLayoutPanel_Rows.Controls.Add(temp, 0, i);

                temp.Dock = DockStyle.Fill;
            }
        }
      
        public void UpdateForm()
        {
            KeyPreview = true;     
        }

        public void SetRows(int n)
        {
            dataGridView2.Rows.Clear();
            if (n < 10)
            {
                for (int i = 0; i < n ; i++)
                    dataGridView2.Rows.Add();
            }
        }
        
        public void UpdateDataGridView()
        {     
            dataGridView2.SelectionChanged += new EventHandler(RowsSelection);
            dataGridView2.RowTemplate.Height = dataGridView2.Size.Height / 9;
        }

        private void RowsSelection(object sender, EventArgs e)
        {
            int[] indexes = new int[dataGridView2.SelectedRows.Count];
            int i = 0;
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                indexes[i] = row.Index;
                i++;            
            }
            foreach (var item in indexes)
                Console.Write(item);
            Console.WriteLine();
            ArrayWorker.Main_indexes = indexes;

            if (indexes.Length == 0)
            {
                REFtabPage2.DisableBtn1();
                REFtabPage3.DisableBtn2();
            }
            else
            {
                REFtabPage2.EnableBtn1();
                REFtabPage3.EnableBtn2();
            }

            if (ArrayWorker.GetArray(3) != null && ArrayWorker.GetArray(3).Length == 8)
            {
                REFtabPage3.DisableBtn2();
                //REFtabPage3.DisableTxtBox();
            }
            else
            {
                REFtabPage3.EnableBtn2();
                //REFtabPage3.EnableTxtBox();
            }
        }

        private void DeleteRows(object sender, EventArgs e)
        {
            ArrayWorker.DeleteRows();            
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                //g.FillRectangle(Brushes.Silver, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }


            Font _tabFont = new Font("Arial", 15.0f, FontStyle.Bold, GraphicsUnit.Pixel);


            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }

}
