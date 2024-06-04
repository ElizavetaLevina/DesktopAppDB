using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class FeaturesClient : Form
    {
        public bool save = false;
        public FeaturesClient(int id)
        {
            InitializeComponent();
            Context context = new();
            var list = context.Clients.Where(i => i.Id == id).ToList();

            textBoxName.Text = list[0].NameClient;
            textBoxAddress.Text = list[0].Address;
            textBoxHomePhone.Text = list[0].NumberPhoneHome;
            textBoxWorkPhone.Text = list[0].NumberPhoneWork;

            switch (list[0].TypeClient)
            {
                case "normal":
                    radioButtonNormal.Checked = true; break;
                case "white":
                    radioButtonWhite.Checked = true; break;
                case "black":
                    radioButtonBlack.Checked = true; break;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            save = true;

            this.Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string NameClient
        {
            get
            {
                return this.textBoxName.Text;
            }
            set
            {
                this.textBoxName.Text = value;
            }
        }

        public string AdressClient
        {
            get
            {
                return this.textBoxAddress.Text;
            }
            set
            {
                this.textBoxAddress.Text = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return this.textBoxHomePhone.Text;
            }
            set
            {
                this.textBoxHomePhone.Text = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return this.textBoxWorkPhone.Text;
            }
            set
            {
                this.textBoxWorkPhone.Text = value;
            }
        }

        public bool NormalType
        {
            get
            {
                return radioButtonNormal.Checked;
            }
            set
            {
                radioButtonNormal.Checked = value;
            }
        }

        public bool WhiteType
        {
            get
            {
                return radioButtonWhite.Checked;
            }
            set
            {
                radioButtonWhite.Checked = value;
            }
        }

        public bool BlackType
        {
            get
            {
                return radioButtonBlack.Checked;
            }
            set
            {
                radioButtonBlack.Checked = value;
            }
        }
    }
}
