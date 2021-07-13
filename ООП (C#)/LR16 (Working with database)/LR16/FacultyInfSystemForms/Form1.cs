using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacultyISBackend;
using FacultyISBackend.DataAdapterController;
using FacultyISBackend.EntityFrameworkController;

namespace Students_IS_Frontend
{
    public partial class Form1 : Form
    {
        private static IFacultyISController _currentController;
        private static ControllerDA _controllerDA = new();
        private static ControllerEF _controllerEF = new();

        private Dictionary<int, IFacultyISController> _controllers = new()
        {
            [0] = _controllerEF,
            [1] = _controllerDA
        };
        public Form1()
        {
            InitializeComponent();

            SetEditable(false);

            dataGridViewMain.DataError += (sender, e) =>
            {
                var cIn = e.ColumnIndex;
                var rIn = e.RowIndex;
                // dataGridViewMain.Rows[rIn].Cells[cIn].Value = 0;
                MessageBox.Show("Ошибка при редактировании данных", "Ошибка", MessageBoxButtons.OK);
                e.Cancel = true;
                // SetEditable(false);
            };
            
            cmbxChooseController.Items.Add("EntityFramework");
            cmbxChooseController.Items.Add("DataAdapter");
            cmbxChooseController.SelectedIndexChanged += ControllerChanged;

            cmbxChooseController.SelectedIndex = 0;
        }
        
        
        // ----- УПРАВЛЕНИЕ СВОЙСТВАМИ КОНТРОЛОВ (КЛАСС CONTROL) -----

        private void SetEditable(bool isEditable)
        {
            SetReadOnlyMode(!isEditable);
            SetSavingButtonMode(isEditable);
            SetDataSource(null);
        }
        private void SetReadOnlyMode(bool isReadOnly)
        {
            dataGridViewMain.ReadOnly = isReadOnly;
            dataGridViewMain.AllowUserToAddRows = !isReadOnly;
        }
        private void SetSavingButtonMode(bool isEnabled)
        {
            saveChangesToolStripMenuItem.Enabled = isEnabled;
        }
        private void SetDataSource(IList dataSource)
        {
            dataGridViewMain.DataSource = dataSource;
        }
        
        
        // ----- УПРАВЛЕНИЕ / ПОЛУЧЕНИЕ ДАННЫХ -----
        
        private void SetController(IFacultyISController controller)
        {
            _currentController = controller;
        }
        private void GetStudentsTable()
        {
            SetEditable(true);

            var dataSource = _currentController.Students;
            
            if (!IsDataSourceEmpty(dataSource))
            {
                SetDataSource(dataSource);
            }
        }
        private void GetGroupsTable()
        {
            SetEditable(true);

            var dataSource = _currentController.Groups;
            
            if (!IsDataSourceEmpty(dataSource))
            {
                SetDataSource(dataSource);
            }
        }
        private void GetQueryStudentsWithYearResult(int year)
        {
            SetEditable(false);
            
            var dataSource = _currentController.QueryStudentsWithYear(year);
            
            if (!IsDataSourceEmpty(dataSource))
            {
                SetDataSource(dataSource);    
            }
        }
        private bool IsDataSourceEmpty(IList dataSource)
        {
            if (dataSource.Count == 0)
            {
                MessageBox.Show("Пустой результат запроса", "Ошибка", MessageBoxButtons.OK);
                return true;
            }

            return false;
        }

        
        // ----- ОБРАБОТЧИКИ НАЖАТИЯ КНОПОК -----
        
        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewMain.BindingContext[dataGridViewMain.DataSource].EndCurrentEdit();
                dataGridViewMain.EndEdit(DataGridViewDataErrorContexts.Commit);
                _currentController.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении данных", "Ошибка", MessageBoxButtons.OK);
                SetEditable(false);
            }

        }

        private void showStudentsStripMenuItem_Click(object sender, EventArgs e)
        {
            GetStudentsTable();
        }

        private void showGroupsStripMenuItem_Click(object sender, EventArgs e)
        {
            GetGroupsTable();
        }
  
        private void showFirstYearStudentsMenuItem_Click(object sender, EventArgs e)
        {
            GetQueryStudentsWithYearResult(1);
        }

        private void showSecondYearStudentsMenuItem_Click(object sender, EventArgs e)
        {
            GetQueryStudentsWithYearResult(2);
        }

        private void showThirdYearStudentsMenuItem_Click(object sender, EventArgs e)
        {
            GetQueryStudentsWithYearResult(3);
        }
        
        private void ControllerChanged(object sender, EventArgs e)
        {
            SetController(_controllers[cmbxChooseController.SelectedIndex]);
            SetEditable(false);
        }

    }
}

