using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using ZXing;
using Zen.Barcode;

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

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        Bitmap MemoryImage;
        Panel pannel = null;
        
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
            //Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            //rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);

            //base.OnPaint(e);
            //pnlPage.CreateGraphics().DrawLines(new Pen(Color.Black),
            //  new Point[] { new Point(10, 10), new Point(50, 50) });


           
            base.OnPaint(e);
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

        // Hamburger click, close / open
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
            var b = new Label();
            b.Text = "Text2";
            b.Name = "text2";
            //b.Click += new EventHandler(b_Click);
            b.MouseUp += (s, e2) => { this.BtnDragging = false; };
            b.MouseDown += new MouseEventHandler(this.b_MouseDown);
            b.MouseMove += new MouseEventHandler(this.b_MouseMove);
            this.pnlPage.Controls.Add(b);
        }

        private void b_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void b_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }
        
        public void DragControlDown(object sender)
        {
            Label ct = sender as Label;
            ct.Capture = true;
            this.Origin_Cursor = System.Windows.Forms.Cursor.Position;
            this.Origin_Control = ct.Location;
            this.BtnDragging = true;
        }

        public void DragControlMove(object sender)
        {
            if (this.BtnDragging)
            {
                Label ct = sender as Label;
                ct.Left = this.Origin_Control.X - (this.Origin_Cursor.X - Cursor.Position.X);
                ct.Top = this.Origin_Control.Y - (this.Origin_Cursor.Y - Cursor.Position.Y);
            }
        }

        public void DragMouseUp()
        {
            this.BtnDragging = false;
        }


        public void DragControlDownBarcode(object sender)
        {
            FlowLayoutPanel ct = sender as FlowLayoutPanel;
            ct.Capture = true;
            this.Origin_Cursor = System.Windows.Forms.Cursor.Position;
            this.Origin_Control = ct.Location;
            this.BtnDragging = true;
        }

        public void DragControlMoveBarcode(object sender)
        {
            if (this.BtnDragging)
            {
                FlowLayoutPanel ct = sender as FlowLayoutPanel;
                ct.Left = this.Origin_Control.X - (this.Origin_Cursor.X - Cursor.Position.X);
                ct.Top = this.Origin_Control.Y - (this.Origin_Cursor.Y - Cursor.Position.Y);
            }
        }

        // == PANEL ==
        public void DragControlDownPanel(object sender)
        {
            Panel ct = panel1;
            ct.Capture = true;
            this.Origin_Cursor = System.Windows.Forms.Cursor.Position;
            this.Origin_Control = ct.Location;
            this.BtnDragging = true;
        }

        public void DragControlMovePanel(object sender)
        {
            if (this.BtnDragging)
            {
                Panel ct = panel1;
                ct.Left = this.Origin_Control.X - (this.Origin_Cursor.X - Cursor.Position.X);
                ct.Top = this.Origin_Control.Y - (this.Origin_Cursor.Y - Cursor.Position.Y);
            }
        }





        // == HEADER LABEL
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }
        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            DragMouseUp();
        }

        

        // == SUB HEADER LABEL
        private void lblSubHead_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void lblSubHead_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }

        private void lblSubHead_MouseUp(object sender, MouseEventArgs e)
        {
            DragMouseUp();
        }


        // == BARCODE 
        private void flowBarcode_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDownBarcode(sender);
        }

        private void flowBarcode_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMoveBarcode(sender);
        }

        private void flowBarcode_MouseUp(object sender, MouseEventArgs e)
        {
            DragMouseUp();
        }

        // == NUMBER
        private void lblNumber_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlDown(sender);
        }

        private void lblNumber_MouseMove(object sender, MouseEventArgs e)
        {
            DragControlMove(sender);
        }

        private void lblNumber_MouseUp(object sender, MouseEventArgs e)
        {
            DragMouseUp();
        }

        // == PANEL
        private void pnlPage_MouseDown(object sender, MouseEventArgs e)
        {
            //DragControlDownPanel(sender);
        }

        private void pnlPage_MouseMove(object sender, MouseEventArgs e)
        {
            //DragControlMovePanel(sender);
        }

        private void pnlPage_MouseUp(object sender, MouseEventArgs e)
        {
            //DragMouseUp();
        }


        private void lblHead_DoubleClick(object sender, EventArgs e)
        {
            int index = pnlPage.Controls.IndexOf(lblHead);

            //MessageBox.Show($"Head: {index}");

            Update update = new Update(index,lblHead.Text);
            update.Show();
        }

        // END HEADER LABEL

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    pnlPage.CreateGraphics().DrawLines(new Pen(Color.Black),
        //      new Point[] { new Point(10, 10), new Point(50, 50) });
        //}
        
        private void bfbtnPrint_Click(object sender, EventArgs e)
        {
            Print(pnlPage);
        }

        //public void GetPrintArea(Panel pnl)
        //{
        //    MemoryImage = new Bitmap(pnl.Width, pnl.Height, pnl.CreateGraphics());
        //    Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
        //    pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        //}


        int totalPages = 3;
         

        private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Rectangle pagearea = e.PageBounds;
            //e.Graphics.DrawImage(MemoryImage, (pagearea.Width) - (this.pnlPage.Width), this.pnlPage.Location.Y);


            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //GetPrintArea(pnlPage, e.Graphics);



            //noPages++;
            //if (noPages == 2)
            //{
            //    e.HasMorePages = false;
            //    noPages = 0;
            //} else
            //{
            //    e.HasMorePages = true;
            //}

            const int dotsPerInch = 300;    // define the quality in DPI
            const double widthInInch = 8.27;   // width of the bitmap in INCH
            const double heightInInch = 11.69;  // height of the bitmap in INCH
            while (noPages < totalPages)
            {
                Bitmap bitmap = new Bitmap((int)(widthInInch * dotsPerInch), (int)(heightInInch * dotsPerInch));
                Brush brush = Brushes.Black;
                Pen blackPen = new Pen(Color.Black, 4);
                Graphics graphics = Graphics.FromImage(GlobalV.changeBar);


                Rectangle rect = new Rectangle(40, 50, 768, 525);

                Pen pen = new Pen(Color.Black, 2);
                pen.Alignment = PenAlignment.Inset; //<-- this
                e.Graphics.DrawRectangle(pen, rect);

                // this should recurse...
                // just for demo so kept it simple
                foreach (var ctl in pnlPage.Controls)
                {
                    // for every control type
                    // come up with a way to Draw its
                    // contents
                    if (ctl is Label)
                    {
                        var lbl = (Label)ctl;
                        e.Graphics.DrawString(
                            lbl.Text,
                            lbl.Font,
                            new SolidBrush(lbl.ForeColor),
                            lbl.Location.X,  // simple based on the position in the panel
                            lbl.Location.Y);
                    }
                    else if (ctl is FlowLayoutPanel)
                    {
                        var pic = (FlowLayoutPanel)ctl;


                        e.Graphics.DrawImage(GlobalV.changeBar, pic.Location.X, pic.Location.Y);

                    }
                }

                if (noPages < totalPages)
                {
                    e.HasMorePages = true;
                    noPages++;
                    return;
                } else
                {
                    e.HasMorePages = false;
                }
                

            }

            if (noPages >= totalPages)
            {
                e.HasMorePages = false;
            }

        }

        public void Print(Panel pnl)
        {
            try
            {
                pannel = pnl;

                PaperSize pp = new PaperSize("A5", 595, 842);
                printdoc1.DefaultPageSettings.PaperSize = pp;
                printdoc1.PrinterSettings.DefaultPageSettings.PaperSize = pp;
                //printdoc1.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                //GetPrintArea(pnl);
                previewdlg.Width = pnlPage.Width;
                previewdlg.Height = pnlPage.Height;
                previewdlg.Document = printdoc1;

                previewdlg.ShowDialog();
            } catch (Exception)
            {

            }
        }
        
        int noPages = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            noPages = 0;
            successfullyPrint();
        }

        private void successfullyPrint()
        {
            try
            {
                printdoc1.OriginAtMargins = true;
                PrinterSettings ps = new PrinterSettings();
                printdoc1.PrinterSettings = ps;
                IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
                printdoc1.DefaultPageSettings.PaperSize = sizeA4;

                this.printdoc1.DefaultPageSettings.PaperSize.RawKind = 300;

                printdoc1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);


                previewdlg.Document = printdoc1;
                previewdlg.ShowDialog();

                //printdoc1.Print();
            }
            catch (Exception param)
            {
                MessageBox.Show(param.Message);
            }


        }
       
        private void printDynamicallyConvert()
        {
            const int dotsPerInch = 600;    // define the quality in DPI
            const double widthInInch = 8.27;   // width of the bitmap in INCH
            const double heightInInch = 11.69;  // height of the bitmap in INCH

            using (Bitmap bitmap = new Bitmap((int)(widthInInch * dotsPerInch), (int)(heightInInch * dotsPerInch)))
            
            {
                bitmap.SetResolution(dotsPerInch, dotsPerInch);

                using (Font font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point))
                using (Brush brush = Brushes.Black)
                using (Pen blackPen = new Pen(Color.Black, 3))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawString("LARGE FORMAT REPLACMENT SHEET", font, brush, 12, 33);
                    graphics.DrawRectangle(blackPen, 1, 1, 590, 421);
                }
                // Save the bitmap







                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
                sf.ShowDialog();
                var path = sf.FileName;
                bitmap.Save(path);
                // Print the bitmap
                //using (PrintDocument printDocument = new PrintDocument())
                //{
                //    printDocument.PrintPage += (object sender, PrintPageEventArgs e) =>
                //    {
                //        e.Graphics.DrawImage(bitmap, 0, 0);
                //    };
                //    printDocument.Print();
                //}
            }



        }

        public void GetPrintArea(Panel pnl, Graphics gr)
        {
            // scale to fit on width of page...
            if (pnl.Width > 0)
            {
                //gr.PageScale = gr.VisibleClipBounds.Width / pnl.Width;
            }


            const int dotsPerInch = 300;    // define the quality in DPI
            const double widthInInch = 8.27;   // width of the bitmap in INCH
            const double heightInInch = 11.69;  // height of the bitmap in INCH
            using (Bitmap bitmap = new Bitmap((int)(widthInInch * dotsPerInch), (int)(heightInInch * dotsPerInch)))

                bitmap.SetResolution(dotsPerInch, dotsPerInch);


            using (Brush brush = Brushes.Black)
            using (Pen blackPen = new Pen(Color.Black, 4))
            using (Graphics graphics = Graphics.FromImage(GlobalV.changeBar))
            {
                


                // this should recurse...
                // just for demo so kept it simple
                foreach (var ctl in pnl.Controls)
                {
                    // for every control type
                    // come up with a way to Draw its
                    // contents
                    if (ctl is Label)
                    {
                        //var lbl = (Label)ctl;
                        //gr.DrawString(
                        //    lbl.Text,
                        //    lbl.Font,
                        //    new SolidBrush(lbl.ForeColor),
                        //    lbl.Location.X,  // simple based on the position in the panel
                        //    lbl.Location.Y);
                    }
                    else if (ctl is FlowLayoutPanel)
                    {
                        var pic = (FlowLayoutPanel)ctl;


                        //gr.DrawImage(GlobalV.changeBar, pic.Location.X, pic.Location.Y);







                        //var barcodeWriter = new BarcodeWriter();

                        //barcodeWriter.Format = BarcodeFormat.CODE_39;

                        //barcodeWriter.Options = new ZXing.Common.EncodingOptions
                        //{
                        //    Height = 182,
                        //    Width = 413,
                        //    Margin = 1,
                        //    PureBarcode = true
                        //};




                        //using (Bitmap bp = barcodeWriter.Write("#LF006499"))
                        //{
                        //    gr.DrawImageUnscaledAndClipped(bp, new Rectangle(
                        //        pic.Location.X,
                        //        pic.Location.Y,
                        //        pic.Width,
                        //        pic.Height));
                        //}
                    }
                }


                //SaveFileDialog sf = new SaveFileDialog();
                //sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
                //sf.ShowDialog();
                //var path = sf.FileName;
                //bitmap.Save(path);
            }
        
            
            



        }

        private void printertest(object sender, PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GetPrintArea(pnlPage, e.Graphics);
        }
        
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private void printdoc1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            GlobalV.changeBarcode = BarcodeDrawFactory.Code39WithoutChecksum;
            GlobalV.changeBar = GlobalV.changeBarcode.Draw("#LF00649", 100, 2);
            
        }

        private void pnlPage_Click(object sender, EventArgs e)
        {
            if (this.BtnDragging)
            {
                this.BtnDragging = false;
            }
        }
    }
}
