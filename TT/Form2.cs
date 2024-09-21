using Emgu.CV.UI;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TT
{
    public partial class Form2 : Form
    {
        // Veritabanı bağlantı cümlesi
        private string connectionString = "Server=MERT;Database=personeltakip;Trusted_Connection=True;TrustServerCertificate=True;";
        private string selectedImagePath; // Seçilen resmin dosya yolu

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Resim seçme işlemi
        private void Resimseç_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Bir resim dosyası seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                // Seçilen resmi PictureBox'a yükle
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Resmin boyutunu PictureBox'a sığacak şekilde ayarlıyoruz.
            }
        }

        // Kayıt butonuna basıldığında bilgileri veritabanına kaydetme işlemi
        private void Kayit_Click(object sender, EventArgs e)
        {
            // TextBox'lardan bilgileri al
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string tcNumber = textBox3.Text;
            string phoneNumber = textBox4.Text;

            // Girişlerin boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(tcNumber) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun ve bir resim seçin.");
                return;
            }

            try
            {
                // Resmi byte dizisine dönüştür
                byte[] imageBytes = File.ReadAllBytes(selectedImagePath);

                // Veritabanı bağlantısını aç ve bilgileri kaydet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Veritabanına kayıt sorgusu
                    string query = @"INSERT INTO Person (FirstName, LastName, TCNumber, PhoneNumber, Photo) 
                                     VALUES (@FirstName, @LastName, @TCNumber, @PhoneNumber, @Photo)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@TCNumber", tcNumber);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Photo", imageBytes); // Resim byte dizisi olarak kaydedilecek

                    connection.Open();
                    command.ExecuteNonQuery(); // Sorguyu çalıştır
                    connection.Close();
                }

                MessageBox.Show("Personel başarıyla kaydedildi.");
                // Formu temizle
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                pictureBox1.Image = null; // Resmi temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
