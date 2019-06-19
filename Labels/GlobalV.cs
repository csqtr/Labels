using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;

namespace Labels
{
    public class GlobalV
    {
        //Datatron Sever
        public static string connString = ("SERVER=10.67.10.101;PORT=3306;DATABASE=datatron_headers;UID=indexer;PASSWORD=Lastand$97;SslMode=none;");
        public static string NoDBConnString = ("SERVER=10.67.10.101;PORT=3306;UID=indexer;PASSWORD=Lastand$97;SslMode=none;");

        public static string LFPrefix = "#LF";
        public static string RDPrefix = "#RD";

        public static string updateText;
        public static Code39BarcodeDraw changeBarcode;
        public static Image changeBar;
        public static string barcodeValue;
    }
}
