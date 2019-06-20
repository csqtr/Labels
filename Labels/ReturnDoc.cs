using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace Labels
{
    public partial class ReturnDoc : Form
    {
        public ReturnDoc()
        {
            InitializeComponent();
        }

        int noPages = 0;
        int totalPages = 1;
        List<int> upperLower;
        List<string> values;
        List<string> valuesCopy;

        public ReturnDoc(int totalPages, List<int> upperLower)
        {
            InitializeComponent();
            this.totalPages = totalPages;
            this.upperLower = upperLower;
        }


        public ReturnDoc(int totalPages, List<int> upperLower, List<string> values)
        {
            InitializeComponent();
            this.totalPages = totalPages;
            this.upperLower = upperLower;
            this.values = values;
            this.valuesCopy = values;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //try
            //{
            printdoc1.OriginAtMargins = true;
            PrinterSettings ps = new PrinterSettings();
            printdoc1.PrinterSettings = ps;
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
            printdoc1.DefaultPageSettings.PaperSize = sizeA4;

            this.printdoc1.DefaultPageSettings.PaperSize.RawKind = 300;

            printdoc1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);


            previewdlg.Document = printdoc1;
            //printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            //previewdlg.ShowDialog();





            printdoc1.Print();
            //}
            //catch (Exception param)
            //{
            //    MessageBox.Show(param.Message);
            //}
        }

        private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            const int dotsPerInch = 300;    // define the quality in DPI
            const double widthInInch = 8.27;   // width of the bitmap in INCH
            const double heightInInch = 11.69;  // height of the bitmap in INCH
            //Bitmap bitmap = new Bitmap((int)(widthInInch * dotsPerInch), (int)(heightInInch * dotsPerInch));

            while (noPages <= totalPages)
            {


                GlobalV.changeBar.Dispose();
                GC.Collect();

                changeBarcodeLabelValues(valuesCopy, noPages);

                //Bitmap bitmap = new Bitmap(pnlLargeFormat.Width, pnlLargeFormat.Height);
                Brush brush = Brushes.Black;
                Pen blackPen = new Pen(Color.Black, 4);
                Graphics graphics = Graphics.FromImage(GlobalV.changeBar);


                Rectangle rect = new Rectangle(30, 40, 768, 525);
                Rectangle rect2 = new Rectangle(30, 608, 768, 525);
                Pen pen = new Pen(Color.Black, 1);
                pen.Alignment = PenAlignment.Inset; //<-- this
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawRectangle(pen, rect2);

                // this should recurse...
                // just for demo so kept it simple
                foreach (var ctl in pnlLargeFormat.Controls)
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
                    else if (ctl is PictureBox)
                    {
                        var pic = (PictureBox)ctl;

                        Bitmap img = new Bitmap(Properties.Resources.logo4jpg2);

                        Size picSize = new Size(pic.Width, pic.Height);

                        e.Graphics.InterpolationMode = InterpolationMode.High;
                        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                        //e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        e.Graphics.DrawImage(img, pic.Location.X, pic.Location.Y);


                        //Properties.Resources.PEN_LOGO_BLACK_ON_WHITE

                        img.Dispose();
                        GC.Collect();
                    }
                }

                if (noPages < totalPages - 1)
                {
                    e.HasMorePages = true;
                    noPages++;
                    GlobalV.changeBar.Dispose();
                    lblLFNumber.Text = "";
                    lblLFNumber2.Text = "";
                    GC.Collect();
                    return;
                }

                if (noPages == totalPages - 1)
                {
                    e.HasMorePages = false;
                    noPages = 0;
                    this.Close();
                    return;
                }


            }

            if (noPages >= totalPages)
            {
                e.HasMorePages = false;
                noPages = 0;
            }


        }
        
        private void changeBarcodeLabelValues(List<string> values, int index)
        {
            GlobalV.changeBarcode = BarcodeDrawFactory.Code39WithoutChecksum;

            string prefix = GlobalV.RDPrefix;
            string value = (prefix + values[index]);

            GlobalV.changeBar = GlobalV.changeBarcode.Draw(value, 110, 2);
            lblLFNumber.Text = value;
            lblLFNumber2.Text = value;
        }

        private void printdoc1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            GlobalV.changeBarcode = BarcodeDrawFactory.Code39WithoutChecksum;
            GlobalV.changeBar = GlobalV.changeBarcode.Draw("#LF00649", 100, 2);
        }

        private void ReturnDoc_Shown(object sender, EventArgs e)
        {
            btnPrint.PerformClick();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            printdoc1.OriginAtMargins = true;
            PrinterSettings ps = new PrinterSettings();
            printdoc1.PrinterSettings = ps;
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
            printdoc1.DefaultPageSettings.PaperSize = sizeA4;

            this.printdoc1.DefaultPageSettings.PaperSize.RawKind = 300;

            printdoc1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);


            previewdlg.Document = printdoc1;
            //printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            //previewdlg.ShowDialog();





            printdoc1.Print();
            //}
            //catch (Exception param)
            //{
            //    MessageBox.Show(param.Message);
            //}
        }
    }
}
