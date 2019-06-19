using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labels
{
    public partial class SerialControlPanel : UserControl
    {


        private System.Delegate _delPageMethod;
        int index;
        public SerialControlPanel(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        
        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            int indexOfControl = index;
            _delPageMethod.DynamicInvoke(indexOfControl);

            this.Dispose();
        }
    }
}
