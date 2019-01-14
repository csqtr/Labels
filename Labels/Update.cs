using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labels
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        public Update(int index, string currentText)
        {
            InitializeComponent();
            this.index = index;
            this.currentText = currentText;
            this.bftxbUpdate.Text = currentText;
        }

        int index;
        string currentText;

        private mainLabels main = System.Windows.Forms.Application.OpenForms["mainLabels"] as mainLabels;
        private Methods methods = new Methods();

        // == Form Draggable ==
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        

        // == End Form Draggable Functions

           
        // Close button top right
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bftxbUpdate_KeyDown(object sender, KeyEventArgs e)
        {


            string text = bftxbUpdate.Text;

            
            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }

                //MessageBox.Show("Pressed enter.");
                GlobalV.updateText = text;
                main.pnlPage.Controls[index].Text = text;
                this.Close();
            }
            
        }

        //Drag on MouseDown header panel
        private void pnlHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
