using MySql.Data.MySqlClient;
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
    public partial class UIHome : Form
    {
        
        Color OGPanel;
        bool changedCurrentNumberLF;
        bool changedCurrentNumberRD;
        
        int lfHeaderID;
        int rdHeaderID;

        int LFCurrentNo;
        int RDCurrentNo;

        int LFRecentNo;
        int RDRecentNo;

        public UIHome()
        {
            InitializeComponent();

            txbLFStart.Enabled = false;
            txbRDStart.Enabled = false;


            changedCurrentNumberLF = false;
            changedCurrentNumberRD = false;

            StartGetCurrentHeaderValues();
        }

        //== Set Dragging Header variables
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // ==

        private void StartGetCurrentHeaderValues()
        {


             lfHeaderID = GetIDFromHeaderName("Large Format");
             rdHeaderID = GetIDFromHeaderName("Return Doc");



            LFCurrentNo = GetCurrentNumber(lfHeaderID);
            RDCurrentNo = GetCurrentNumber(rdHeaderID);

            LFRecentNo = GetRecentNoPages(lfHeaderID);
            RDRecentNo = GetRecentNoPages(rdHeaderID);

            //Set Textbox Values
            // Start LF Value
            txbLFStart.Text = LFCurrentNo.ToString();
            // RecentNoPages LF
            txbLFPageCount.Text = LFRecentNo.ToString();

            //Start RD
            txbRDStart.Text = RDCurrentNo.ToString();
            // RecentNoPages RD
            txbRDPageCount.Text = RDRecentNo.ToString();
        }

        // == MYSQL FUNCTIONS ==
        // MySql - Gets and returns the ID for a given header name
        private int GetIDFromHeaderName(string headerName)
        {
            int headerID = 0;

            //essageBox.Show("DiscName: " + DiscName);
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            

            try
            {

                string sql = "SELECT ID FROM headers WHERE HeaderName = '" + headerName + "';";
                //MessageBox.Show("INTERNAL: " + sql);

                conn = new MySqlConnection(GlobalV.connString);
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //if the returned value isnt null, perform nextAvailable on

                    headerID = Convert.ToInt32(reader.GetString("ID"));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("This disc currently contains no files.");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }


            return headerID;
        }

        // MySql - Gets the current number for the given header ID
        private int GetCurrentNumber(int HeaderID)
        {

            //essageBox.Show("DiscName: " + DiscName);
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            int currentNumber = 0;

            try
            {

                string sql = "SELECT CurrentNumber FROM headers WHERE ID = " + HeaderID + ";";
                //MessageBox.Show("INTERNAL: " + sql);

                conn = new MySqlConnection(GlobalV.connString);
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //if the returned value isnt null, perform nextAvailable on
                    
                        currentNumber = Convert.ToInt32(reader.GetString("CurrentNumber"));
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("This disc currently contains no files.");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return currentNumber;

        }

        private int GetRecentNoPages(int HeaderID)
        {

            //essageBox.Show("DiscName: " + DiscName);
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            int recentNoPages = 0;

            try
            {

                string sql = "SELECT RecentNoPages FROM headers WHERE ID = " + HeaderID + ";";
                //MessageBox.Show("INTERNAL: " + sql);

                conn = new MySqlConnection(GlobalV.connString);
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //if the returned value isnt null, perform nextAvailable on

                    recentNoPages = Convert.ToInt32(reader.GetString("RecentNoPages"));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("This disc currently contains no files.");
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return recentNoPages;

        }

        private void SetCurrentNumber(int currentNumber, int headerID)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            
            try
            {
                //UPDATE my_table SET my_column='new value' WHERE something='some value';
                //Update FileNo, where DiscKeyIndex = GlobalVI AND ImageName = imageName;

                string sql = "UPDATE headers SET CurrentNumber = '" + currentNumber + "'";
                sql += " WHERE ID = " + headerID + ";";

                //MessageBox.Show(sql);

                conn = new MySqlConnection(GlobalV.connString);
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }

        private void SetRecentNumberPages(int recentNumber, int headerID)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                //UPDATE my_table SET my_column='new value' WHERE something='some value';
                //Update FileNo, where DiscKeyIndex = GlobalVI AND ImageName = imageName;

                string sql = "UPDATE headers SET RecentNoPages = '" + recentNumber + "'";
                sql += " WHERE ID = " + headerID + ";";

                //MessageBox.Show(sql);

                conn = new MySqlConnection(GlobalV.connString);
                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }


        //Change value for Start No - changes boolean to force DB Update
        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            changedCurrentNumberLF = true;
        }

        // Leave start no txb, changes toggle and deactivates txb
        private void txbLFStart_Leave(object sender, EventArgs e)
        {
            radToggleSwitch1.Value = false;
        }

        //Click Print Button
        private void btnPrintLF_Click(object sender, EventArgs e)
        {
            if (changedCurrentNumberLF)
            {
                LFCurrentNo = Convert.ToInt32(txbLFStart.Text.ToString());
            }


            // number of print pages in txbLFPageCount
            int noLFPages = Convert.ToInt32(txbLFPageCount.Text);

            ////Take 1 off to match index loops - 10 in txb was 11 loops.
            //noLFPages--;

            //Create UpperLower List
            List<int> upperLowerLF = new List<int>(new int[] { LFCurrentNo , (LFCurrentNo+noLFPages) });
            List<string> values = new List<string>();

            int endPlusOne = LFCurrentNo + noLFPages;
            //create a list of LF Values
            for (int i = LFCurrentNo; i < (endPlusOne); i++)
            {
                string val = i.ToString().PadLeft(6, '0');
                //MessageBox.Show(val);
                values.Add(val);
            }

            LargeFormat lf = new LargeFormat(noLFPages, upperLowerLF, values);
            if (printDialogLF.ShowDialog() == DialogResult.OK)
            {
                lf.Show();
            }

            
            //Update DB with new current number
            SetCurrentNumber(endPlusOne, lfHeaderID);
            SetRecentNumberPages(noLFPages, lfHeaderID);


            //reset changed current number;
            changedCurrentNumberLF = false;

            //refresh current number value
            StartGetCurrentHeaderValues();

            //lf.Close();
        }

        //Type into Start No. Only Allows Numbers.
        private void txbLFStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Type into Page Count. Only Allows Numbers.
        private void txbLFPageCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }




        //unused
        private void txbLFStart_DoubleClick(object sender, EventArgs e)
        {
            
        }
        //unused
        private void txbLFStart_MouseHover(object sender, EventArgs e)
        {
            
        }


        /* Change the toggle switch.
         * On - Allow edit Start No
         * Off - Prevent edit Start No
         */

        private void radToggleSwitch1_ValueChanged(object sender, EventArgs e)
        {
            if(radToggleSwitch1.Value is true)
            {
                txbLFStart.Enabled = true;
            } else
            {
                txbLFStart.Enabled = false;
            }
        }
        // == Minimise and Close Form

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // ==== 


        // == Enter and Leave Panel 1 ==
        private void radPanel1_MouseEnter(object sender, EventArgs e)
        {
            //Make Lighter
            //Color lighter = new Color();
            //lighter = Color.FromArgb(100, 0, 162, 208);
            //radPanel1.BackColor = lighter;
        }

        private void radPanel1_MouseLeave(object sender, EventArgs e)
        {
            // Make back to original

            //Color OGPanel = new Color();
            //OGPanel = Color.FromArgb(255, 0, 126, 163);
            //radPanel1.BackColor = OGPanel;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changedCurrentNumberRD)
            {
                RDCurrentNo = Convert.ToInt32(txbRDStart.Text.ToString());
            }


            // number of print pages in txbLFPageCount
            int noRDPages = Convert.ToInt32(txbRDPageCount.Text);

            ////Take 1 off to match index loops - 10 in txb was 11 loops.
            //noLFPages--;

            //Create UpperLower List
            List<int> upperLowerRD = new List<int>(new int[] { RDCurrentNo, (RDCurrentNo + noRDPages) });
            List<string> values = new List<string>();

            int endPlusOne = RDCurrentNo + noRDPages;
            //create a list of LF Values
            for (int i = RDCurrentNo; i < (endPlusOne); i++)
            {
                string val = i.ToString().PadLeft(6, '0');
                //MessageBox.Show(val);
                values.Add(val);
            }

            ReturnDoc rd = new ReturnDoc(noRDPages, upperLowerRD, values);
            if (printDialogRD.ShowDialog() == DialogResult.OK)
            {
                rd.Show();
            }


            //Update DB with new current number
            SetCurrentNumber(endPlusOne, rdHeaderID);
            SetRecentNumberPages(noRDPages, rdHeaderID);


            //reset changed current number;
            changedCurrentNumberLF = false;

            //refresh current number value
            StartGetCurrentHeaderValues();

            //rd.Close();
        }

        private void txbRDStart_TextChanged(object sender, EventArgs e)
        {
            changedCurrentNumberRD = true;
        }

        private void radToggleSwitch2_ValueChanged(object sender, EventArgs e)
        {
            if (radToggleSwitch2.Value is true)
            {
                txbRDStart.Enabled = true;
            }
            else
            {
                txbRDStart.Enabled = false;
            }
        }

        private void txbRDStart_Leave(object sender, EventArgs e)
        {
            radToggleSwitch2.Value = false;
        }

        private void txbRDStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbRDPageCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        
        // =======



        // Program - Gets all the current values from MySql
    }
}
