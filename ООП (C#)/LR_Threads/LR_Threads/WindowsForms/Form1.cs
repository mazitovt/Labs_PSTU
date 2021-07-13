using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_Threads;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Label> indexToLabel;

        private SlotMachine _slotMachine = new(3);

        public Form1()
        {
            InitializeComponent();

            InitializeIndexToLabel();

            SubscribeForEvents();
        }

        private void InitializeIndexToLabel()
        {
            indexToLabel = new()
            {
                [0] = lblSlot0Number,
                [1] = lblSlot1Number,
                [2] = lblSlot2Number,
            };
        }

        private void SubscribeForEvents()
        {
            _slotMachine.SlotNumberChanged += SetSlotValue;
        }

        private void BtnSpin_Click(object sender, EventArgs e)
        {
            if (_slotMachine.IsSpinning)
            {
                _slotMachine.StopSpinning();
                btnSpin.Text = "Вращать";
                return;
            }

            _slotMachine.StartSpinning();
            btnSpin.Text = "Остановить";
        }
        
        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            AnalyzeResult();
        }

        private void SetSlotValue(object sender, int slotIndex, int value)
        {
            var label = indexToLabel[slotIndex];

            var action = new Action<Label, string>((label, value) => label.Text = value);

            label.Invoke(action, label, value.ToString());
        }
        
        private void AnalyzeResult()
        {
            var numbers = indexToLabel.Values.Select(label => Int32.Parse(label.Text));

            var analytics = new SlotAnalytics(numbers);

            analytics.AnalyzeSlotsWithRecord();

            AddLogInfo(analytics.Result);
        }

        private void AddLogInfo(string newInfo)
        {
            log.Text += newInfo + "\n" + new string('-', 70) + "\n";
        }
    }
}
