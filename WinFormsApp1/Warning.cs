using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Warning : Form
    {
        public bool pressBtnYes = false;
        public Warning()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        public string ButtonText
        {
            get
            {
                return this.buttonExit.Text;
            }
            set
            {
                this.buttonExit.Text = value;
            }
        }

        public bool ButtonVisible
        {
            get
            {
                return this.buttonYes.Visible;
            }
            set
            {
                this.buttonYes.Visible = value;
            }
        }

        private void Warning_Activated(object sender, EventArgs e)
        {
            if (buttonYes.Visible)
            {
                buttonYes.Focus();
            }
        }


        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            pressBtnYes = true;
            this.Close();
        }
    }
}
