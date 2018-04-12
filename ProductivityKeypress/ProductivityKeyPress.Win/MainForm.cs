using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductivityKeyPress.Win
{
    public partial class MainForm : Form
    {
        private volatile int _counter;
        private Stopwatch _stopwatch;

        public MainForm()
        {
            InitializeComponent();

            InitStopWatch();

            SneakyListener.KeyPress += (sender, args) =>
            {
                _counter++;
                Task.Run(() =>
                {
                    keypressesTxtBox.Invoke((Action)(() =>
                   {
                       keypressesTxtBox.Text = _counter.ToString();
                   }));
                    averageSecTxtBox.Invoke((Action)(() =>
                   {
                       averageSecTxtBox.Text = ComputeAverageSecKey().ToString(CultureInfo.InvariantCulture);
                   }));
                    averageMinTxtBox.Invoke((Action)(() =>
                   {
                       averageMinTxtBox.Text = ComputeAverageMinKey().ToString(CultureInfo.InvariantCulture);
                   }));
                });
            };
        }

        private decimal ComputeAverageSecKey()
        {
            return _counter / (decimal)_stopwatch.Elapsed.TotalSeconds;
        }

        private decimal ComputeAverageMinKey()
        {
            return _counter / (decimal)_stopwatch.Elapsed.TotalMinutes;
        }

        private void InitStopWatch()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _counter = default(int);
            InitStopWatch();

            averageSecTxtBox.Clear();
            keypressesTxtBox.Clear();
            averageMinTxtBox.Clear();
        }
    }
}
