using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Microsoft.Data.SqlClient;

namespace TT
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private VideoCapture _capture;
        private BarcodeReader reader;
        private string connectionString = "Server=MERT;Database=personeltakip;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            reader = new BarcodeReader();

            // PictureBox'ýn SizeMode özelliðini ayarla
            pictureBoxVideo.SizeMode = PictureBoxSizeMode.StretchImage; // Kameradan gelen görüntü PictureBox'a sýðdýrýlacak
        }

        // Kamerayý baþlatma iþlemi
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new VideoCapture(0); // 0, varsayýlan kamerayý temsil eder.
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kamera baþlatýlamadý: " + ex.Message);
            }
        }

        // Her kare alýndýðýnda çaðrýlan fonksiyon
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame, 0);

                // Kameradan alýnan görüntüyü PictureBox'a yansýtma
                pictureBoxVideo.Image = frame.ToImage<Bgr, byte>().ToBitmap(); // Bu görüntü PictureBox'a sýðdýrýlacak

                // QR kodu tarama
                var bitmap = frame.ToImage<Bgr, byte>().ToBitmap();
                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    // QR kod baþarýyla okundu, sonucu Label1'e yazdýr
                    Invoke(new MethodInvoker(delegate ()
                    {
                        string ownerName = GetOwnerNameFromDatabase(result.Text);
                        if (!string.IsNullOrEmpty(ownerName))
                        {
                            label1.Text = $"Kiþi Adý: {ownerName}";
                        }
                        else
                        {
                            label1.Text = "Kiþi bulunamadý.";
                        }

                        // Kamerayý durdur
                        _capture.Stop();
                    }));
                }
            }
        }

        // Form kapanýrken kamerayý durdurma iþlemi
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null && _capture.IsOpened)
            {
                _capture.Stop();
                _capture.Dispose();
            }
        }

        // QR kod oluþturma ve veritabanýndan kiþiye özel kod alma iþlemi
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox1'den TCNumber'ý al
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Lütfen TC numarasýný girin.");
                return;
            }

            string tcNumber = txtInput.Text;

            string uniqueCode = GetUniqueCodeFromDatabase(tcNumber);
            if (uniqueCode == null)
            {
                MessageBox.Show("Kiþi bulunamadý veya UniqueCode bulunamadý.");
                return;
            }

            // QR kod oluþturucu
            QRCodeWriter qrCodeWriter = new QRCodeWriter();
            var qrCodeData = qrCodeWriter.encode(uniqueCode, BarcodeFormat.QR_CODE, 250, 250);

            // QR kodu Bitmap olarak oluþtur
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new EncodingOptions
            {
                Width = 250,
                Height = 250
            };

            Bitmap qrCodeBitmap = barcodeWriter.Write(qrCodeData);

            // QR kodunu PictureBox'ta göster
            pictureBoxQRCode.Image = qrCodeBitmap;
        }

        // Veritabanýndan UniqueCode almak için kullanýlan metod
        private string GetUniqueCodeFromDatabase(string tcNumber)
        {
            string uniqueCode = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UniqueCode FROM Person WHERE TCNumber = @TCNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TCNumber", tcNumber);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        uniqueCode = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabaný hatasý: " + ex.Message);
                }
            }
            return uniqueCode;
        }

        // Veritabanýndan QR kod sahibi kiþiyi almak için kullanýlan metod
        private string GetOwnerNameFromDatabase(string uniqueCode)
        {
            string ownerName = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FirstName, LastName FROM Person WHERE UniqueCode = @UniqueCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UniqueCode", uniqueCode);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ownerName = $"{reader["FirstName"]} {reader["LastName"]}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabaný hatasý: " + ex.Message);
                }
            }
            return ownerName;
        }

        // QR kodu kaydetme iþlemi
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxQRCode.Image != null)
            {
                // SaveFileDialog oluþtur
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png",
                    Title = "QR Kodunu Kaydet"
                };

                // Kullanýcý bir dosya adý seçtiyse
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // QR kodunu seçilen konuma kaydet
                    pictureBoxQRCode.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("QR kodu baþarýyla kaydedildi.");
                }
            }
            else
            {
                MessageBox.Show("Önce bir QR kodu oluþturun.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kayýtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void kontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
