using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR8_Forms
{
    public partial class Form1 : Form
    {    
        private readonly FileWorker<Group> fw = new FileWorker<Group>("E:/DB/");
        private bool IsFile = false;

        public Form1()
        {        
            InitializeComponent();
            UpdateComponents();
        }
        
        private void UpdateComponents()
        {
            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(PaintRowNumber);

            createToolStripMenuItem.Click += new EventHandler(CreateFirstYearGroup);

            openToolStripMenuItem.Click += new System.EventHandler(this.openFileClick);
            saveStripMenuItem1.Click += new System.EventHandler(this.saveFileClick);

            radiobtnAdd.CheckedChanged += new EventHandler(PanelActivator);
            radiobtnDel.CheckedChanged += new EventHandler(PanelActivator);
            radiobtnEdit.CheckedChanged += new EventHandler(PanelActivator);

            radiobtnDelKey.CheckedChanged += new EventHandler(DelPanelActivator);
            radiobtnDelNum.CheckedChanged += new EventHandler(DelPanelActivator);

            radiobtnEditKey.CheckedChanged += new EventHandler(EditPanelActivator);
            radiobtnEditNum.CheckedChanged += new EventHandler(EditPanelActivator);

            buttonDel.Click += new EventHandler(buttonDelClicked);

            groupBoxDel.EnabledChanged += new EventHandler(groupBoxDelFocus);
            groupBoxEdit.EnabledChanged += new EventHandler(groupBoxEditFocus);

            textBoxEdit.TextChanged += new EventHandler((sender, e) => ButtonActivator(sender, buttonEdit));
            textBoxDelKey.TextChanged += new EventHandler((sender, e) => ButtonActivator(sender, buttonDel));
            //radiobtnEditNum.CheckedChanged += new EventHandler((sender, e) => ButtonActivator(sender, e, buttonDel, radiobtnDelKey.Checked));

            buttonEdit.Click += new EventHandler(buttonEditClicked);
        }

        private void CreateFirstYearGroup(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Group group = fw.GetFirstYearGroup();
                //fw.SaveFile(group, saveFileDialog1.OpenFile());
                fw.SaveFileTXT(group, saveFileDialog1.OpenFile());
            }
        }

        private void buttonEditClicked(object sender, EventArgs e)
        {
            if (radiobtnEditKey.Checked)
            {
                string[] studInfo = fw.GetStudentInfo(textBoxEdit.Text);
                if (studInfo.Length != 0)
                {
                    EditForm popup = new EditForm(true,"Редактирование", studInfo);
                    DialogResult dialogresult = popup.ShowDialog();
                    if (dialogresult == DialogResult.OK)
                        fw.EditStudent(textBoxEdit.Text, popup.GetText());
                    popup.Dispose();
                }
                else
                {
                    string message = "Студентов с таким номером не найдено";
                    string caption = "Ошибка в редактировани записи";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
            if (radiobtnEditNum.Checked)
            {
                string[] studInfo = fw.GetStudentInfo(comboBoxEdit.SelectedIndex);
                EditForm popup = new EditForm(true, "Редактирование", studInfo);
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                    fw.EditStudent(comboBoxEdit.SelectedIndex, popup.GetText());
                popup.Dispose();
            }

            ShowGroup(fw.OpenFileTXT(fw.CurrentFile));
        } 

        private void EditPanelActivator(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;         
                switch (temp.Name)
                {
                    case "radiobtnEditKey":
                        textBoxEdit.Enabled = true;
                        comboBoxEdit.Enabled = false;                   
                        buttonEdit.Enabled = textBoxEdit.TextLength != 0;                    
                        break;
                    case "radiobtnEditNum":
                        textBoxEdit.Enabled = false;
                        comboBoxEdit.Enabled = true;
                        buttonEdit.Enabled = comboBoxEdit.Items.Count != 0;
                        break;
                }            
        }

        private void DelPanelActivator(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;

            switch (temp.Name)
            {
                case "radiobtnDelKey":
                    textBoxDelKey.Enabled = true;
                    comboBoxDelNum.Enabled = false;
                    buttonDel.Enabled = textBoxDelKey.TextLength != 0;
                    break;
                case "radiobtnDelNum":
                    textBoxDelKey.Enabled = false;
                    comboBoxDelNum.Enabled = true;
                    buttonDel.Enabled = comboBoxDelNum.Items.Count != 0;
                    break;
            }         
        }

        private void ButtonActivator(object sender, Button button)
        {
            if (((TextBox)sender).TextLength > 0)
                button.Enabled = true;
            else
                button.Enabled = false;
        }

        private void groupBoxDelFocus(object sender, EventArgs e)
        {
            radiobtnDelKey.Checked = ((GroupBox)sender).Enabled;
        }
        
        private void groupBoxEditFocus(object sender, EventArgs e)
        {
            radiobtnEditKey.Checked = ((GroupBox)sender).Enabled;
        }

        private void PanelActivator(object sender, EventArgs e)
        {
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked)
            {
                switch (temp.Name)
                {
                    case "radiobtnAdd":
                        groupBoxAdd.Enabled = true;
                        groupBoxDel.Enabled = false;
                        groupBoxEdit.Enabled = false;
                        break;
                    case "radiobtnDel":
                        groupBoxAdd.Enabled = false;
                        groupBoxDel.Enabled = true;
                        groupBoxEdit.Enabled = false;
                        break;
                    case "radiobtnEdit":
                        groupBoxAdd.Enabled = false;
                        groupBoxDel.Enabled = false;
                        groupBoxEdit.Enabled = true;
                        break;
                }
            }
            
        }

        private void buttonDelClicked(object sender, EventArgs e)
        {
            if (radiobtnDelKey.Checked)
                if (!fw.DeleteStudent(textBoxDelKey.Text))
                {
                    string message = "Студентов с таким номером не найдено";
                    string caption = "Ошибка в удалении записи";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            if (radiobtnDelNum.Checked)
                fw.DeleteStudent(comboBoxDelNum.SelectedIndex);

            ShowGroup(fw.OpenFileTXT(fw.CurrentFile));
        }

        private void radiobtnDelNum_Changed(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                comboBoxDelNum.Enabled = true;
            }

            else
            {
                comboBoxDelNum.Enabled = false;
            }
        }

        private void radiobtnDelKey_Changed(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                textBoxDelKey.Enabled = true;
            }

            else
            {
                textBoxDelKey.Enabled = false;
            }
        }

        private void UpdateView(object sender, EventArgs e)
        {
            if (fw.CurrentFile != null)
                ShowGroup(fw.OpenFileTXT(fw.CurrentFile));
        }
        
        private void EnableGrouBox()
        {
            groupBoxMain.Enabled = true;
            radiobtnAdd.Checked = true;
        }
        
        private void SetIndexList(int length)
        {
            comboBoxAddIndex.Items.Clear();
            foreach (var index in Enumerable.Range(1, length))
                comboBoxAddIndex.Items.Add(index);
            comboBoxAddIndex.SelectedIndex = 0;

            comboBoxDelNum.Items.Clear();
            if (length != 1)
            {
                foreach (var index in Enumerable.Range(1, length - 1))
                    comboBoxDelNum.Items.Add(index);
                comboBoxDelNum.SelectedIndex = 0;
                buttonDel.Enabled = true;
            }
            else
                buttonDel.Enabled = false;

                comboBoxEdit.Items.Clear();
            if (length != 1)
            {
                foreach (var index in Enumerable.Range(1, length - 1))
                    comboBoxEdit.Items.Add(index);
                comboBoxEdit.SelectedIndex = 0;
                buttonEdit.Enabled = true;
            }
            else
                buttonEdit.Enabled = false;

        }

        private void PaintRowNumber(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void saveFileClick(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Group group = new Group()
                {
                    Name = txtBxGroupName.Text,
                    Semestr = Convert.ToInt32(txtBxSemestr.Text),
                    Curator = txtBxCurator.Text,
                    Students = ReadStudents()
                };

                //fw.SaveFile(group, saveFileDialog1.OpenFile());
                fw.SaveFileTXT(group, saveFileDialog1.OpenFile());             
            }
        }

        public List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index != dataGridView1.Rows.Count - 1)
                {
                    Student student = new Student
                    {
                        StudentId = row.Cells["stud_id"].Value.ToString(),
                        LastName = row.Cells["sName"].Value.ToString(),
                        FirstName = row.Cells["fName"].Value.ToString(),
                        Rating = Convert.ToDouble(row.Cells["rating"].Value.ToString())
                    };
                    students.Add(student);
                }                             
            }
            return students;
        }       

        private void openFileClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                ShowGroup(fw.OpenFileTXT(openFileDialog1.FileName));
            EnableGrouBox();
            //ShowGroup(fw.OpenFile(openFileDialog1.FileName));


            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    //Get the path of specified file
            //    var filePath = openFileDialog1.FileName;
            //    StreamReader sw = File.OpenText(filePath);
            //    var str = sw.ReadToEnd();

            //    var GroupRIS = JsonSerializer.Deserialize<Group>(str);

            //    ShowGroup(GroupRIS);
            //}

        }

        private void ShowGroup(Group group)
        {
            dataGridView1.Rows.Clear();
            txtBxGroupName.Text = group.Name;
            txtBxSemestr.Text = group.Semestr.ToString();
            txtBxCurator.Text = group.Curator;

            foreach (Student st in group.Students)
                dataGridView1.Rows.Add(st.StudentId, st.LastName, st.FirstName, st.Rating);
            dataGridView1.Rows.Add();

            SetIndexList(dataGridView1.Rows.Count);
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            //AddStudentForm popup = new AddStudentForm();
            EditForm popup = new EditForm(false, "Добавление");
            DialogResult dialogresult = popup.ShowDialog();

            if (dialogresult == DialogResult.OK)
                fw.AddStudent(comboBoxAddIndex.SelectedIndex, popup.GetText());
            popup.Dispose();
            ShowGroup(fw.OpenFileTXT(fw.CurrentFile));

        }

        private void panelAdd_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
