namespace ImageEdgeDetection
{
    partial class MainForm
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.BandWFilterButton = new System.Windows.Forms.Button();
            this.RainbowFilterButton = new System.Windows.Forms.Button();
            this.listBoxXFilter = new System.Windows.Forms.ComboBox();
            this.listBoxYFilter = new System.Windows.Forms.ComboBox();
            this.EdgeDetectionButton = new System.Windows.Forms.Button();
            this.labelErrors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Silver;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(12, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(600, 600);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 13;
            this.picPreview.TabStop = false;
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenOriginal.Location = new System.Drawing.Point(152, 23);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(288, 44);
            this.btnOpenOriginal.TabIndex = 15;
            this.btnOpenOriginal.Text = "Load Image";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(136, 20);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(318, 49);
            this.btnSaveNewImage.TabIndex = 16;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click);
            // 
            // BandWFilterButton
            // 
            this.BandWFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BandWFilterButton.Location = new System.Drawing.Point(34, 75);
            this.BandWFilterButton.Name = "BandWFilterButton";
            this.BandWFilterButton.Size = new System.Drawing.Size(231, 46);
            this.BandWFilterButton.TabIndex = 21;
            this.BandWFilterButton.Text = "BlackAndWhiteFilter";
            this.BandWFilterButton.UseVisualStyleBackColor = true;
            this.BandWFilterButton.Click += new System.EventHandler(this.BandWFilterButton_Click);
            // 
            // RainbowFilterButton
            // 
            this.RainbowFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RainbowFilterButton.Location = new System.Drawing.Point(315, 75);
            this.RainbowFilterButton.Name = "RainbowFilterButton";
            this.RainbowFilterButton.Size = new System.Drawing.Size(240, 46);
            this.RainbowFilterButton.TabIndex = 22;
            this.RainbowFilterButton.Text = "Rainbow";
            this.RainbowFilterButton.UseVisualStyleBackColor = true;
            this.RainbowFilterButton.Click += new System.EventHandler(this.RainbowFilterButton_Click);
            // 
            // listBoxXFilter
            // 
            this.listBoxXFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBoxXFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxXFilter.FormattingEnabled = true;
            this.listBoxXFilter.Items.AddRange(new object[] {
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.listBoxXFilter.Location = new System.Drawing.Point(175, 43);
            this.listBoxXFilter.Name = "listBoxXFilter";
            this.listBoxXFilter.Size = new System.Drawing.Size(288, 37);
            this.listBoxXFilter.TabIndex = 23;
            // 
            // listBoxYFilter
            // 
            this.listBoxYFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBoxYFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxYFilter.FormattingEnabled = true;
            this.listBoxYFilter.Items.AddRange(new object[] {
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.listBoxYFilter.Location = new System.Drawing.Point(175, 118);
            this.listBoxYFilter.Name = "listBoxYFilter";
            this.listBoxYFilter.Size = new System.Drawing.Size(288, 37);
            this.listBoxYFilter.TabIndex = 24;
            // 
            // EdgeDetectionButton
            // 
            this.EdgeDetectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdgeDetectionButton.Location = new System.Drawing.Point(175, 175);
            this.EdgeDetectionButton.Name = "EdgeDetectionButton";
            this.EdgeDetectionButton.Size = new System.Drawing.Size(143, 40);
            this.EdgeDetectionButton.TabIndex = 25;
            this.EdgeDetectionButton.Text = "Apply";
            this.EdgeDetectionButton.UseVisualStyleBackColor = true;
            this.EdgeDetectionButton.Click += new System.EventHandler(this.EdgeDetectionButton_Click);
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.Location = new System.Drawing.Point(430, 218);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(0, 17);
            this.labelErrors.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "xFilter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "yFilter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenOriginal);
            this.groupBox1.Location = new System.Drawing.Point(631, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 106);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Load Image";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BandWFilterButton);
            this.groupBox2.Controls.Add(this.RainbowFilterButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(631, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 155);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Apply Filter";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxXFilter);
            this.groupBox3.Controls.Add(this.listBoxYFilter);
            this.groupBox3.Controls.Add(this.EdgeDetectionButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.labelErrors);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(631, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(572, 250);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Apply Edge Detection";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveNewImage);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(640, 541);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(563, 75);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. Save Image";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1215, 628);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picPreview);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Edge Detection";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.Button BandWFilterButton;
        private System.Windows.Forms.Button RainbowFilterButton;
        private System.Windows.Forms.ComboBox listBoxXFilter;
        private System.Windows.Forms.ComboBox listBoxYFilter;
        private System.Windows.Forms.Button EdgeDetectionButton;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

