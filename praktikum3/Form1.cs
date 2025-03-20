using System;
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
                try
                {
                    if (txtNim.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtTelepon.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nim", txtNim.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm(); // Auto Clear setelah tambah data
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void btnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtNIM.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    conn.Open();
                    string query = "UPDATE Mahasiswa SET Nama = @Nama, Email = @Email, Telepon = @Telepon, Alamat = @Alamat WHERE NIM = @NIM";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                }
                cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());        // Parameter untuk NIM
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());      // Parameter untuk Nama
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());    // Parameter untuk Email
                cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());// Parameter untuk Telepon
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());  // Parameter untuk Alamat

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();  // Memuat ulang data agar perubahan terlihat di DataGridView
                    ClearForm(); // Mengosongkan input setelah update data
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan atau gagal diperbarui!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

             catch (Exception ex)
        {
                // Menampilkan pesan error jika terjadi kesalahan saat update data
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHapus(object sender, EventArgs e)
        {
            if (dgvMahasiswa.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string nim = dgvMahasiswa.SelectedRows[0].Cells["Nim"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM Mahasiswa WHERE Nim = @Nim";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Nim", nim);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                    ClearForm(); // Auto Clear setelah hapus data
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnRefresh(object sender, EventArgs e)
        {
            LoadData();
            // Debugging: Cek jumlah kolom dan baris
            MessageBox.Show($"Jumlah Kolom: {dgvMahasiswa.ColumnCount}\nJumlah Baris: {dgvMahasiswa.RowCount}",
                "Debugging DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

        private void dgvMahasiswa(object sender, DataGridViewCellEventArgs e)
        {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvMahasiswa.Rows[e.RowIndex];

            // Coba gunakan indeks jika "NIM" tidak ditemukan
            txtNim.Text = row.Cells[0].Value.ToString();
            txtNama.Text = row.Cells[1].Value?.ToString();
            txtEmail.Text = row.Cells[2].Value?.ToString();
            txtTelepon.Text = row.Cells[3].Value?.ToString();
            txtAlamat.Text = row.Cells[4].Value?.ToString();

        }

    }

    }
}
