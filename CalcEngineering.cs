using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace csh_wf_calculator
{
    public partial class CalcEngineering : Form
    {
        // MANUALLY COPIED 

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

        public CalcEngineering()
        {
            //this.Text = "Engineering Calculator";
            //this.Size = new System.Drawing.Size(300, 280);

            InitializeComponent();

            textBoxOutResult.Text = "0";
        }

        // MANUALLY COPIED 

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

        // Engineering Operators
        private void buttonReciprocal_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBoxOutResult.Text);
            textBoxOutResult.Text = CalcEngine.CalcReciprocal(input);
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBoxOutResult.Text);
            textBoxOutResult.Text = CalcEngine.CalcSquareRoot(input);
        }

        private void buttonCubicRoot_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBoxOutResult.Text);
            textBoxOutResult.Text = CalcEngine.CalcCubicRoot(input);
        }

        private void buttonSquared_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBoxOutResult.Text);
            textBoxOutResult.Text = CalcEngine.CalcSquared(input);
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBoxOutResult.Text);
            textBoxOutResult.Text = CalcEngine.CalcFactorial(input);
        }

        // Engineering Operators with two operands

        // Power (x^N)
        private void buttonPower_Click(object sender, EventArgs e)
        {
            // base then exp
            CalcEngine.CalcOperation(CalcEngine.Operator.ePower);

            textBoxOutResult.Text = ""; // input exp
        }

        // Perform the calculation (=)
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            textBoxOutResult.Text = CalcEngine.CalcEqual();

            CalcEngine.CalcReset(); // X + Y then keep operating by X 
        }

        // Clear result
        private void buttonClear_Click(object sender, EventArgs e)
        {
            CalcEngine.CalcReset();
            textBoxOutResult.Text = "0";
        }

        // Engineering Operators with Dialog
        private void buttonQEquation_Click(object sender, EventArgs e)
        {
            // using temporary resource
            using (InputDialog dialog = new InputDialog())
            {
                // input vars
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    double a = dialog.CoefA;
                    double b = dialog.CoefB;
                    double c = dialog.CoefC;

                    string result = CalcEngine.CalcQuadEquation(a, b, c);
                    textBoxOutResult.Text = result;

                    MessageBox.Show("DEBUG other examples:\n" +
                                    "No real roots: a = 1, b = 2, c = 3\n" +
                                    "One root (double): a = 1, b = -4, c = 4 (x1 = x2 = 2)\n" +
                                    "Two distinct roots: a = 1, b = -5, c = 6 (x1 = 3, x2 = 2)\n" +
                                    "Two distinct roots: a = 2, b = -8, c = 6 (x1 = 3, x2 = 1)");
                }
            }
        }

        // Modes
        private void SwitchToStandard()
        {
            this.Hide();
            var standardForm = new CalcStandard();
            standardForm.ShowDialog();
            this.Show();
        }
        private void SwitchToEngineering()
        {

        }

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
            SwitchToStandard();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("DEBUG: Already in Engineering mode.");
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string ver = CalcEngine.GetVersion();
            MessageBox.Show($"This is a basic calculator.\nUse 'Mode > Engineering' for advanced features.\n\n{ver}", "Help");
        }

        private void CalcEngineering_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
