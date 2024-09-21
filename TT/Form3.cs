using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TT
{
    public partial class Form3 : Form
    {
        private string connectionString = "Server=MERT;Database=personeltakip;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde tüm kişileri listele
            LoadAllPersons();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void LoadAllPersons()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FirstName, LastName, TCNumber, PhoneNumber FROM Person";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listBox1.Items.Clear(); // ListBox'ı temizle

                    while (reader.Read())
                    {
                        // ListBox'a ad, soyad, TC numarası ve telefon numarasını ekle
                        string displayText = $"{reader["FirstName"]} {reader["LastName"]} - TC: {reader["TCNumber"]} - Numara: {reader["PhoneNumber"]}";
                        listBox1.Items.Add(displayText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void Ara_Click(object sender, EventArgs e)
        {
            string tcNo = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(tcNo))
            {
                LoadAllPersons();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FirstName, LastName, TCNumber, PhoneNumber, Photo FROM Person WHERE TCNumber = @TCNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TCNumber", tcNo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listBox1.Items.Clear(); // Mevcut listeyi temizle

                    if (reader.Read())
                    {
                        // Kişiyi ListBox'a ekle
                        string displayText = $"{reader["FirstName"]} {reader["LastName"]} - TC: {reader["TCNumber"]} - Numara: {reader["PhoneNumber"]}";
                        listBox1.Items.Add(displayText);

                        // Resmi PictureBox'a yükle
                       if (reader["Photo"] != DBNull.Value)
{
    byte[] photoBytes = (byte[])reader["Photo"];
    using (MemoryStream ms = new MemoryStream(photoBytes))
    {
        pictureBox1.Image = Image.FromStream(ms);
    }
    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Resmi sığdırma ayarı
}
else
{
    pictureBox1.Image = null; // Resim yoksa PictureBox'ı temizle
}
                    }
                    else
                    {
                        MessageBox.Show("Bu TC numarasına ait bir kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
    }
}
