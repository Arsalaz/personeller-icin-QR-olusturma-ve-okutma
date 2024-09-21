namespace TT
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            pictureBox1 = new PictureBox();
            Resimseç = new Button();
            Kayİt = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 23);
            label1.TabIndex = 0;
            label1.Text = "AD :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 1;
            label2.Text = "Soyad :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(12, 121);
            label3.Name = "label3";
            label3.Size = new Size(88, 23);
            label3.TabIndex = 2;
            label3.Text = "TC Kimlik :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(12, 177);
            label4.Name = "label4";
            label4.Size = new Size(151, 23);
            label4.TabIndex = 3;
            label4.Text = "Telefon Numarası :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 91);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 147);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 203);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(151, 27);
            textBox4.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(169, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 320);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Resimseç
            // 
            Resimseç.Font = new Font("Segoe UI", 11F);
            Resimseç.Location = new Point(12, 236);
            Resimseç.Name = "Resimseç";
            Resimseç.Size = new Size(151, 119);
            Resimseç.TabIndex = 9;
            Resimseç.Text = "Resim Seç";
            Resimseç.UseVisualStyleBackColor = true;
            Resimseç.Click += Resimseç_Click;
            // 
            // Kayİt
            // 
            Kayİt.Font = new Font("Segoe UI", 11F);
            Kayİt.Location = new Point(12, 361);
            Kayİt.Name = "Kayİt";
            Kayİt.Size = new Size(397, 66);
            Kayİt.TabIndex = 10;
            Kayİt.Text = "Kişiyi Kaydet";
            Kayİt.UseVisualStyleBackColor = true;
            Kayİt.Click += Kayit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(169, 9);
            label5.Name = "label5";
            label5.Size = new Size(64, 23);
            label5.TabIndex = 11;
            label5.Text = "Resim :";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 447);
            Controls.Add(label5);
            Controls.Add(Kayİt);
            Controls.Add(Resimseç);
            Controls.Add(pictureBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kayıt";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private PictureBox pictureBox1;
        private Button Resimseç;
        private Button Kayİt;
        private Label label5;
    }
}