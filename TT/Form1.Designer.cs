namespace TT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            btnGenerateQRCode = new Button();
            pictureBoxQRCode = new PictureBox();
            buttonSave = new Button();
            label1 = new Label();
            button3 = new Button();
            pictureBoxVideo = new PictureBox();
            menuStrip1 = new MenuStrip();
            personelToolStripMenuItem = new ToolStripMenuItem();
            kayıtToolStripMenuItem = new ToolStripMenuItem();
            kontrolToolStripMenuItem = new ToolStripMenuItem();
            düzenleToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(86, 99);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(250, 27);
            txtInput.TabIndex = 0;
            // 
            // btnGenerateQRCode
            // 
            btnGenerateQRCode.Location = new Point(86, 141);
            btnGenerateQRCode.Name = "btnGenerateQRCode";
            btnGenerateQRCode.Size = new Size(250, 29);
            btnGenerateQRCode.TabIndex = 1;
            btnGenerateQRCode.Text = "QR Oluştur";
            btnGenerateQRCode.UseVisualStyleBackColor = true;
            btnGenerateQRCode.Click += button1_Click;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.BackColor = SystemColors.ActiveBorder;
            pictureBoxQRCode.Location = new Point(86, 176);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(250, 250);
            pictureBoxQRCode.TabIndex = 2;
            pictureBoxQRCode.TabStop = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(86, 452);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(250, 52);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "QR Kodu Kaydet";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 429);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(450, 83);
            button3.Name = "button3";
            button3.Size = new Size(800, 52);
            button3.TabIndex = 5;
            button3.Text = "Scan";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBoxVideo
            // 
            pictureBoxVideo.BackColor = SystemColors.ActiveBorder;
            pictureBoxVideo.Location = new Point(450, 141);
            pictureBoxVideo.Name = "pictureBoxVideo";
            pictureBoxVideo.Size = new Size(800, 600);
            pictureBoxVideo.TabIndex = 6;
            pictureBoxVideo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 10F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { personelToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 31);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // personelToolStripMenuItem
            // 
            personelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kayıtToolStripMenuItem, kontrolToolStripMenuItem, düzenleToolStripMenuItem });
            personelToolStripMenuItem.Name = "personelToolStripMenuItem";
            personelToolStripMenuItem.Size = new Size(88, 27);
            personelToolStripMenuItem.Text = "Personel";
            // 
            // kayıtToolStripMenuItem
            // 
            kayıtToolStripMenuItem.Name = "kayıtToolStripMenuItem";
            kayıtToolStripMenuItem.Size = new Size(156, 28);
            kayıtToolStripMenuItem.Text = "Kayıt";
            kayıtToolStripMenuItem.Click += kayıtToolStripMenuItem_Click;
            // 
            // kontrolToolStripMenuItem
            // 
            kontrolToolStripMenuItem.Name = "kontrolToolStripMenuItem";
            kontrolToolStripMenuItem.Size = new Size(156, 28);
            kontrolToolStripMenuItem.Text = "Kontrol";
            // 
            // düzenleToolStripMenuItem
            // 
            düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            düzenleToolStripMenuItem.Size = new Size(156, 28);
            düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 76);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 8;
            label2.Text = "TC Kimlik Numarasını Girin :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 753);
            Controls.Add(label2);
            Controls.Add(pictureBoxVideo);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(pictureBoxQRCode);
            Controls.Add(btnGenerateQRCode);
            Controls.Add(txtInput);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QR Personel Takip";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnGenerateQRCode;
        private PictureBox pictureBoxQRCode;
        private Button buttonSave;
        private Label label1;
        private Button button3;
        private PictureBox pictureBoxVideo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem personelToolStripMenuItem;
        private ToolStripMenuItem kayıtToolStripMenuItem;
        private ToolStripMenuItem kontrolToolStripMenuItem;
        private ToolStripMenuItem düzenleToolStripMenuItem;
        private Label label2;
    }
}
