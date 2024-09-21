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

            // PictureBox'�n SizeMode �zelli�ini ayarla
            pictureBoxVideo.SizeMode = PictureBoxSizeMode.StretchImage; // Kameradan gelen g�r�nt� PictureBox'a s��d�r�lacak
        }

        // Kameray� ba�latma i�lemi
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new VideoCapture(0); // 0, varsay�lan kameray� temsil eder.
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kamera ba�lat�lamad�: " + ex.Message);
            }
        }

        // Her kare al�nd���nda �a�r�lan fonksiyon
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame, 0);

                // Kameradan al�nan g�r�nt�y� PictureBox'a yans�tma
                pictureBoxVideo.Image = frame.ToImage<Bgr, byte>().ToBitmap(); // Bu g�r�nt� PictureBox'a s��d�r�lacak

                // QR kodu tarama
                var bitmap = frame.ToImage<Bgr, byte>().ToBitmap();
                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    // QR kod ba�ar�yla okundu, sonucu Label1'e yazd�r
                    Invoke(new MethodInvoker(delegate ()
                    {
                        string ownerName = GetOwnerNameFromDatabase(result.Text);
                        if (!string.IsNullOrEmpty(ownerName))
                        {
                            label1.Text = $"Ki�i Ad�: {ownerName}";
                        }
                        else
                        {
                            label1.Text = "Ki�i bulunamad�.";
                        }

                        // Kameray� durdur
                        _capture.Stop();
                    }));
                }
            }
        }

        // Form kapan�rken kameray� durdurma i�lemi
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null && _capture.IsOpened)
            {
                _capture.Stop();
                _capture.Dispose();
            }
        }

        // QR kod olu�turma ve veritaban�ndan ki�iye �zel kod alma i�lemi
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox1'den TCNumber'� al
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("L�tfen TC numaras�n� girin.");
                return;
            }

            string tcNumber = txtInput.Text;

            string uniqueCode = GetUniqueCodeFromDatabase(tcNumber);
            if (uniqueCode == null)
            {
                MessageBox.Show("Ki�i bulunamad� veya UniqueCode bulunamad�.");
                return;
            }

            // QR kod olu�turucu
            QRCodeWriter qrCodeWriter = new QRCodeWriter();
            var qrCodeData = qrCodeWriter.encode(uniqueCode, BarcodeFormat.QR_CODE, 250, 250);

            // QR kodu Bitmap olarak olu�tur
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new EncodingOptions
            {
                Width = 250,
                Height = 250
            };

            Bitmap qrCodeBitmap = barcodeWriter.Write(qrCodeData);

            // QR kodunu PictureBox'ta g�ster
            pictureBoxQRCode.Image = qrCodeBitmap;
        }

        // Veritaban�ndan UniqueCode almak i�in kullan�lan metod
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
                    MessageBox.Show("Veritaban� hatas�: " + ex.Message);
                }
            }
            return uniqueCode;
        }

        // Veritaban�ndan QR kod sahibi ki�iyi almak i�in kullan�lan metod
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
                    MessageBox.Show("Veritaban� hatas�: " + ex.Message);
                }
            }
            return ownerName;
        }

        // QR kodu kaydetme i�lemi
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxQRCode.Image != null)
            {
                // SaveFileDialog olu�tur
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png",
                    Title = "QR Kodunu Kaydet"
                };

                // Kullan�c� bir dosya ad� se�tiyse
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // QR kodunu se�ilen konuma kaydet
                    pictureBoxQRCode.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("QR kodu ba�ar�yla kaydedildi.");
                }
            }
            else
            {
                MessageBox.Show("�nce bir QR kodu olu�turun.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kay�tToolStripMenuItem_Click(object sender, EventArgs e)
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
