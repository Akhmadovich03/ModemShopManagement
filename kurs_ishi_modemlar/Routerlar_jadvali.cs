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

namespace kurs_ishi_modemlar
{
    public partial class Routerlar_jadvali : Form
    {
        string path = Program.path;
        string query = "";

        int id = 0;
        bool isCellClick = false;

        SqlConnection conn;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable datatable = new DataTable();

        public Routerlar_jadvali()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Jadvallar jadvallar = new Jadvallar();
            jadvallar.Show();
            Hide();
        }

        private void Routerlar_jadvali_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void View()
        {
            conn = new SqlConnection(path);
            query = "SELECT * FROM Routerlar";

            adapter = new SqlDataAdapter(query, conn);
            datatable.Clear();
            adapter.Fill(datatable);
            natija_r.DataSource = datatable;
        }

        public bool FieldIsEmpty()
        {
            return nomi_r.Text.Trim() == "" ||
                   firmasi_r.Text.Trim() == "" ||
                   max_tez_r.Text.Trim() == "" ||
                   shox_soni_r.Text.Trim() == "" ||
                   wi_fi_avlodi_r.Text.Trim() =="" ||
                   chastotasi_r.Text.Trim() == "" ||
                   narxi_r.Text.Trim() == "";
        }

        public void ClearFields()
        {
            nomi_r.Text = "";
            firmasi_r.Text = "";
            max_tez_r.Text = "";
            shox_soni_r.Text = "";
            wi_fi_avlodi_r.Text = "";
            chastotasi_r.Text = "";
            narxi_r.Text = "";
        }

        private void Routerlar_jadvali_Load(object sender, EventArgs e)
        {
            View();

            SqlConnection conn1 = new SqlConnection(path);
            SqlCommand sqlCommand1 = new SqlCommand("select Firma_nomi from Firmalar", conn1);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = sqlCommand1;
            DataTable datatable1 = new DataTable();
            adapter1.Fill(datatable1);
            firmasi_r.DataSource = datatable1;
            firmasi_r.DisplayMember = "Firma_nomi";
        }

        private void qoshish_r_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldIsEmpty())
                {
                    MessageBox.Show("Avval satrlarni to'ldiring ! ", "Kiriting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn = new SqlConnection(path);

                query = "INSERT INTO Routerlar VALUES(@nomi, @firmasi, @max_tezligi, @shox_soni, @wifi_avlodi, @chastotasi, @narxi)";

                sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("@nomi", nomi_r.Text);
                sqlCommand.Parameters.AddWithValue("@firmasi", firmasi_r.Text);
                sqlCommand.Parameters.AddWithValue("@max_tezligi", max_tez_r.Text);
                sqlCommand.Parameters.AddWithValue("@shox_soni", shox_soni_r.Text);
                sqlCommand.Parameters.AddWithValue("@wifi_avlodi", wi_fi_avlodi_r.Text);
                sqlCommand.Parameters.AddWithValue("@chastotasi", chastotasi_r.Text);
                sqlCommand.Parameters.AddWithValue("@narxi", narxi_r.Text);

                conn.Open();
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Ma'lumot qo'shildi", "Kiritildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ClearFields();
            View();
        }

        private void ochirish_r_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_r.CurrentRow;

                    DialogResult result = MessageBox.Show("Qaroringiz qat'iymi ? \n Tanlangan qator o'chirib yuboriladi",
                               "O'chirilsinmi ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        conn = new SqlConnection(path);

                        query = "DELETE FROM Routerlar WHERE id = @id";

                        sqlCommand = new SqlCommand(query, conn);
                        sqlCommand.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Ma'lumot muvaffaqqiyatli o'chirildi", "O'chirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Iltimos barcha maydonlarni to'ldiring", "O'chirish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearFields();
            View();
        }

        private void yangilash_r_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_r.CurrentRow;

                    conn = new SqlConnection(path);

                    query = "UPDATE Routerlar SET Nomi = @nomi, Firmasi = @firmasi, Max_tezligi = @max_tezligi, Shoxlari_soni = @shox_soni, Wi_Fi_avlodi = @wifi_avlodi, Chastotasi = @chastotasi, Narxi = @narxi WHERE id = @id";

                    sqlCommand = new SqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@nomi", nomi_r.Text);
                    sqlCommand.Parameters.AddWithValue("@firmasi", firmasi_r.Text);
                    sqlCommand.Parameters.AddWithValue("@max_tezligi", max_tez_r.Text);
                    sqlCommand.Parameters.AddWithValue("@shox_soni", shox_soni_r.Text);
                    sqlCommand.Parameters.AddWithValue("@wifi_avlodi", wi_fi_avlodi_r.Text);
                    sqlCommand.Parameters.AddWithValue("@chastotasi", chastotasi_r.Text);
                    sqlCommand.Parameters.AddWithValue("@narxi", narxi_r.Text);

                    conn.Open();
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Ma'lumot muvaffaqqiyatli yangilandi! ", "Yangilash",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Iltimos, barcha maydonlarni to'ldiring ! ", "Yangilash",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClearFields();
            View();
        }

        private void natija_r_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isCellClick = true;

            DataGridViewRow selectedRow = natija_r.CurrentRow;

            if (natija_r.CurrentRow.Index == natija_r.Rows.Count - 1)
            {
                ClearFields();
            }
            else
            {
                id = Convert.ToInt32(selectedRow.Cells[0].Value);
                nomi_r.Text = selectedRow.Cells[1].Value.ToString();
                firmasi_r.Text = selectedRow.Cells[2].Value.ToString();
                max_tez_r.Text = selectedRow.Cells[3].Value.ToString();
                shox_soni_r.Text = selectedRow.Cells[4].Value.ToString();
                wi_fi_avlodi_r.Text = selectedRow.Cells[5].Value.ToString();
                chastotasi_r.Text = selectedRow.Cells[6].Value.ToString();
                narxi_r.Text = selectedRow.Cells[7].Value.ToString();
            }

            isCellClick = false;
        }

        private void nomi_r_TextChanged(object sender, EventArgs e)
        {
            if (!isCellClick)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(path))
                    {
                        query = "SELECT * FROM Routerlar WHERE 1=1";
                        List<SqlParameter> parameters = new List<SqlParameter>();

                        if (!string.IsNullOrWhiteSpace(nomi_r.Text))
                        {
                            query += " AND Nomi LIKE @nomi";
                            parameters.Add(new SqlParameter("@nomi", nomi_r.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(firmasi_r.Text))
                        {
                            query += " AND Firmasi LIKE @firma";
                            parameters.Add(new SqlParameter("@firma", firmasi_r.Text));
                        }

                        if (!string.IsNullOrWhiteSpace(max_tez_r.Text))
                        {
                            query += " AND Max_tezligi LIKE @max_tezligi";
                            parameters.Add(new SqlParameter("@max_tezligi", max_tez_r.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(shox_soni_r.Text))
                        {
                            query += " AND Shoxlari_soni LIKE @shox_soni";
                            parameters.Add(new SqlParameter("@shox_soni", shox_soni_r.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(wi_fi_avlodi_r.Text))
                        {
                            query += " AND Wi_Fi_avlodi LIKE @wifi_avlodi";
                            parameters.Add(new SqlParameter("@wifi_avlodi", wi_fi_avlodi_r.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(chastotasi_r.Text))
                        {
                            query += " AND Chastotasi LIKE @chastotasi";
                            parameters.Add(new SqlParameter("@chastotasi", chastotasi_r.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(narxi_r.Text))
                        {
                            query += " AND Narxi LIKE @narx";
                            parameters.Add(new SqlParameter("@narx", narxi_r.Text + "%"));
                        }

                        using (SqlCommand sqlCommand = new SqlCommand(query, conn))
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());

                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable datatable = new DataTable();
                                adapter.Fill(datatable);
                                natija_r.DataSource = datatable;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void firmasi_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void max_tez_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void shox_soni_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void wi_fi_avlodi_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void chastotasi_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void narxi_r_TextChanged(object sender, EventArgs e)
        {
            nomi_r_TextChanged(sender, e);
        }

        private void tozalash_r_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}