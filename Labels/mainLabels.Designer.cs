﻿namespace Labels
{
    partial class mainLabels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainLabels));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSideContents = new System.Windows.Forms.Panel();
            this.pnlImgViewer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bfbtnPrint = new Bunifu.Framework.UI.BunifuThinButton2();
            this.picHamb = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlSide.SuspendLayout();
            this.pnlSideContents.SuspendLayout();
            this.pnlImgViewer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHamb)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1033, 107);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlSide.Controls.Add(this.pnlSideContents);
            this.pnlSide.Controls.Add(this.picHamb);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 107);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(185, 540);
            this.pnlSide.TabIndex = 1;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(1000, 7);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(26, 26);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(971, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "_";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlSideContents
            // 
            this.pnlSideContents.Controls.Add(this.bfbtnPrint);
            this.pnlSideContents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSideContents.Location = new System.Drawing.Point(0, 47);
            this.pnlSideContents.Name = "pnlSideContents";
            this.pnlSideContents.Size = new System.Drawing.Size(185, 493);
            this.pnlSideContents.TabIndex = 2;
            // 
            // pnlImgViewer
            // 
            this.pnlImgViewer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlImgViewer.Controls.Add(this.panel1);
            this.pnlImgViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlImgViewer.Location = new System.Drawing.Point(185, 157);
            this.pnlImgViewer.Name = "pnlImgViewer";
            this.pnlImgViewer.Size = new System.Drawing.Size(848, 490);
            this.pnlImgViewer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(42, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 447);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(690, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "LARGE FORMAT  REPLACEMENT SHEET";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label2_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label2_MouseUp);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 5;
            this.bunifuFlatButton1.ButtonText = "EDIT";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::Labels.Properties.Resources.cog100;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 60D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(946, 114);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(80, 36);
            this.bunifuFlatButton1.TabIndex = 3;
            this.bunifuFlatButton1.Text = "EDIT";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bfbtnPrint
            // 
            this.bfbtnPrint.ActiveBorderThickness = 1;
            this.bfbtnPrint.ActiveCornerRadius = 20;
            this.bfbtnPrint.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bfbtnPrint.ActiveForecolor = System.Drawing.Color.White;
            this.bfbtnPrint.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bfbtnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bfbtnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bfbtnPrint.BackgroundImage")));
            this.bfbtnPrint.ButtonText = "Print";
            this.bfbtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bfbtnPrint.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bfbtnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bfbtnPrint.IdleBorderThickness = 1;
            this.bfbtnPrint.IdleCornerRadius = 20;
            this.bfbtnPrint.IdleFillColor = System.Drawing.Color.White;
            this.bfbtnPrint.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(163)))));
            this.bfbtnPrint.IdleLineColor = System.Drawing.Color.SeaShell;
            this.bfbtnPrint.Location = new System.Drawing.Point(6, 445);
            this.bfbtnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bfbtnPrint.Name = "bfbtnPrint";
            this.bfbtnPrint.Size = new System.Drawing.Size(173, 43);
            this.bfbtnPrint.TabIndex = 0;
            this.bfbtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picHamb
            // 
            this.picHamb.BackgroundImage = global::Labels.Properties.Resources.icons8_menu_filled_500;
            this.picHamb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picHamb.Location = new System.Drawing.Point(147, 8);
            this.picHamb.Name = "picHamb";
            this.picHamb.Size = new System.Drawing.Size(30, 30);
            this.picHamb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHamb.TabIndex = 1;
            this.picHamb.TabStop = false;
            this.picHamb.Click += new System.EventHandler(this.picHamb_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1033, 647);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.pnlImgViewer);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainLabels";
            this.Text = "mainLabels";
            this.Load += new System.EventHandler(this.mainLabels_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainLabels_MouseDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSide.ResumeLayout(false);
            this.pnlSideContents.ResumeLayout(false);
            this.pnlImgViewer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHamb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private Bunifu.Framework.UI.BunifuThinButton2 bfbtnPrint;
        private System.Windows.Forms.PictureBox picHamb;
        private System.Windows.Forms.Panel pnlSideContents;
        private System.Windows.Forms.Panel pnlImgViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.Button button1;
    }
}