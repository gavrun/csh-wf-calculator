using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csh_wf_calculator
{
    public partial class InputDialog : Form
    {
        //public double CoefA { get; private set; }

        //public double CoefA
        //{
        //    get { return textBoxA.Text; }
        //    set { textBoxA.Text = value}
        //}
        public double CoefA
        {
            get { return double.Parse(textBoxA.Text); } // parse and only numeric
            set { textBoxA.Text = value.ToString(); }
        }
        public double CoefB
        {
            get { return double.Parse(textBoxB.Text); } 
            set { textBoxA.Text = value.ToString(); }
        }
        public double CoefC
        {
            get { return double.Parse(textBoxC.Text); } 
            set { textBoxA.Text = value.ToString(); }
        }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            //if (double.TryParse(textBoxA.Text, out double a) &&
            //    double.TryParse(textBoxB.Text, out double b) &&
            //    double.TryParse(textBoxC.Text, out double c))
            //{
            //    CoefA = a;
            //    CoefB = b;
            //    CoefC = c;
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid input. Please enter numeric values.");
            //}

            //if (ValidateInput())

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //private bool ValidateInput()
        //{
        //    return double.TryParse(textBoxA.Text, out _) &&
        //           double.TryParse(textBoxB.Text, out _) &&
        //           double.TryParse(textBoxC.Text, out _);
        //}

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only digits, dot . and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; 
            }
            


        }
    }
}
