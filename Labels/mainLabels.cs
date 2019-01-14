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
    public partial class mainLabels : Form
    {
        public mainLabels()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }


        













        private void mainLabels_Load(object sender, EventArgs e)
        {
            
        }


        // == Drag Form Functions ==
        private void mainLabels_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picHamb_Click(object sender, EventArgs e)
        {
            if(pnlSide.Width == 185)
            {
                pnlSide.Width = 50;
                picHamb.Location = new Point(10,picHamb.Location.Y);
                pnlSideContents.Visible = false;
            } else
            {
                pnlSideContents.Visible = true;
                pnlSide.Width = 185;
                picHamb.Location = new Point(147, picHamb.Location.Y);
            }
        }


        private Point Origin_Cursor;
        private Point Origin_Control;
        private bool BtnDragging = false;

        private void button1_Click(object sender, EventArgs e)
        {
            var b = new Button();
            b.Text = "My Button";
            b.Name = "button";
            //b.Click += new EventHandler(b_Click);
            b.MouseUp += (s, e2) => { this.BtnDragging = false; };
            b.MouseDown += new MouseEventHandler(this.b_MouseDown);
            b.MouseMove += new MouseEventHandler(this.b_MouseMove);
            this.panel1.Controls.Add(b);
        }

        private void b_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void b_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }


        private void DragControlDown(object sender)
        {
            Label ct = sender as Label;
            ct.Capture = true;
            this.Origin_Cursor = System.Windows.Forms.Cursor.Position;
            this.Origin_Control = ct.Location;
            this.BtnDragging = true;
        }

        private void DragControlMove(object sender)
        {
            if (this.BtnDragging)
            {
                Label ct = sender as Label;
                ct.Left = this.Origin_Control.X - (this.Origin_Cursor.X - Cursor.Position.X);
                ct.Top = this.Origin_Control.Y - (this.Origin_Cursor.Y - Cursor.Position.Y);
            }
        }

        private void DragMouseUp()
        {
            this.BtnDragging = false;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            DragMouseUp();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }
    }
}
