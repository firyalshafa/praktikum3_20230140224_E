﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktikum3
{
    public partial class Form1 : Form
    {
        // Ganti "SERVER" sesuai dengan SQL Server Anda
        private string connectionString = "Data Source=LAPTOP-SOF8NSPF\\FIRYAL;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        // Event saat form pertama kali dimuat
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Fungsi untuk mengosongkan semua input pada TextBox
        private void ClearForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtEmail.Clear();
            txtTelepon.Clear();
            txtAlamat.Clear();

            // Fokus kembali ke NIM agar user siap memasukkan data baru
            txtNim.Focus();
        }

        private void LoadData(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nim AS [Nim], Nama, Email, Telepon, Alamat FROM Mahasiswa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMahasiswa.AutoGenerateColumns = true;
                    dgvMahasiswa.DataSource = dt;
                    ClearForm(); // Auto Clear setelah LoadData
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnTambah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

            }

        }

        private void btnHapus(object sender, EventArgs e)
        {

        }

        private void btnUbah(object sender, EventArgs e)
        {

        }

        private void btnRefresh(object sender, EventArgs e)
        {

        }

        private void dgvMahasiswa(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
