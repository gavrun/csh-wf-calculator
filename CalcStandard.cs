using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_calculator
{
    public partial class CalcStandard : Form
    {
        private const string outZero = "0";
        private const string outOne = "1";
        private const string outTwo = "2";
        private const string outThree = "3";
        private const string outFour = "4";
        private const string outFive = "5";
        private const string outSix = "6";
        private const string outSeven = "7";
        private const string outEight = "8";
        private const string outNine = "9";

        public CalcStandard()
        {
            //this.Text = "Standard Calculator";
            //this.Size = new System.Drawing.Size(300, 280);

            InitializeComponent();

            //VersionInfo.Text = CalcEngine.GetVersion();

            // cleared textBoxOutResult
            textBoxOutResult.Text = "0";
        }

        // Programmatically vs by Designer

        //private void InitializeComponent()
        //{

        //}

        // Numeric key click methods
        private void buttonZero_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outZero);
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outOne);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outTwo);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outThree);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outFour);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outFive);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outSix);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outSeven);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outEight);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcNumber(outNine);
        }

        // Other non-numeric key click methods
        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcDecimal();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcSign();
        }

        //
        //protected void KeyDate_Click(object sender, System.EventArgs e)
        //{
        //    OutputDisplay.Text = CalcEngine.GetDate();
        //    CalcEngine.CalcReset();
        //}

        // Operators
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eAdd);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eSubtract);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eMultiply);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eDivide);
        }

        // Perform the calculation
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcEqual();
            
            //CalcEngine.CalcReset(); // X + Y then keep operating by X 
        }

        // Clear result
        private void buttonClear_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcReset();
            textBoxOutResult.Text = "0";
        }

        // Modes

        private void SwitchToStandard()
        {
            
        }

        private void SwitchToEngineering()
        {
            this.Hide();
            var engineeringForm = new CalcEngineering(); // form keeps hanging
            engineeringForm.ShowDialog();
            this.Show();
        }
        //private void SwitchToEngineering()
        //{
        //    var currentForm = this;
        //    var engineeringForm = new CalcEngineering();
        //    engineeringForm.FormClosed += (s, args) => currentForm.Close();
        //    engineeringForm.Show();
        //    this.Hide();
        //}

        // Main menu
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            toolStripMenuItem5.Checked = this.TopMost;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = !this.MaximizeBox;
            toolStripMenuItem6.Checked = this.MaximizeBox;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.FixedSingle)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // checked in designer
            toolStripMenuItem7.Checked = this.FormBorderStyle == FormBorderStyle.FixedSingle;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("DEBUG: Already in Standard mode.");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SwitchToEngineering();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string ver = CalcEngine.GetVersion();
            MessageBox.Show($"This is a basic calculator.\nUse 'Mode > Engineering' for advanced features.\n\n{ver}", "Help");
        }

        private void textBoxOutResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // block keys
        }

        private void CalcStandard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
