﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        // Event saat form pertama kali dimuat
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Fungsi untuk mengosongkan semua input pada TextBox
        private void ClearForm()
        {

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTambah(object sender, EventArgs e)
        {

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

        private void LoadData(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
