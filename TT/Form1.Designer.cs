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
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).BeginInit();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(12, 12);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(90, 27);
            txtInput.TabIndex = 0;
            // 
            // btnGenerateQRCode
            // 
            btnGenerateQRCode.Location = new Point(108, 11);
            btnGenerateQRCode.Name = "btnGenerateQRCode";
            btnGenerateQRCode.Size = new Size(154, 29);
            btnGenerateQRCode.TabIndex = 1;
            btnGenerateQRCode.Text = "Generate QR Code";
            btnGenerateQRCode.UseVisualStyleBackColor = true;
            btnGenerateQRCode.Click += button1_Click;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.Location = new Point(12, 45);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(250, 250);
            pictureBoxQRCode.TabIndex = 2;
            pictureBoxQRCode.TabStop = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 301);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(250, 52);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 356);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.Location = new Point(12, 379);
            button3.Name = "button3";
            button3.Size = new Size(250, 52);
            button3.TabIndex = 5;
            button3.Text = "Scan";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBoxVideo
            // 
            pictureBoxVideo.Location = new Point(276, 45);
            pictureBoxVideo.Name = "pictureBoxVideo";
            pictureBoxVideo.Size = new Size(250, 250);
            pictureBoxVideo.TabIndex = 6;
            pictureBoxVideo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 472);
            Controls.Add(pictureBoxVideo);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(pictureBoxQRCode);
            Controls.Add(btnGenerateQRCode);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).EndInit();
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
    }
}
