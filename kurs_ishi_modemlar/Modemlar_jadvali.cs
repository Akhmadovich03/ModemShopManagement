using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kurs_ishi_modemlar
{
    public partial class Modemlar_jadvali : Form
    {
        string path = Program.path;
        string query = "";

        int id = 0;
        bool isCellClick = false;

        SqlConnection conn;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable datatable = new DataTable();

        public Modemlar_jadvali()
        {
            InitializeComponent();
        }

        private void Modemlar_jadvali_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void View()
        {
            conn = new SqlConnection(path);
            query = "SELECT * FROM Modemlar";

            adapter = new SqlDataAdapter(query, conn);
            datatable.Clear();
            adapter.Fill(datatable);
            natija_m.DataSource = datatable;
        }

        public bool FieldIsEmpty()
        {
            return nomi_m.Text.Trim() == "" ||
                   firmasi_m.Text.Trim() == "" ||
                   max_tez_m.Text.Trim() == "" ||
                   shox_soni_m.Text.Trim() == "" ||
                   narxi_m.Text.Trim() == "";
        }

        public void ClearFields()
        {
            nomi_m.Text = "";
            firmasi_m.Text = "";
            max_tez_m.Text = "";
            shox_soni_m.Text = "";
            narxi_m.Text = "";
        }

        private void orqaga_m_Click(object sender, EventArgs e)
        {
            Jadvallar jadvallar = new Jadvallar();
            jadvallar.Show();
            Hide();
        }

        private void Modemlar_jadvali_Load(object sender, EventArgs e)
        {
            View();

            SqlConnection conn1 = new SqlConnection(path);
            SqlCommand sqlCommand1 = new SqlCommand("select Firma_nomi from Firmalar", conn1);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = sqlCommand1;
            DataTable datatable1 = new DataTable();
            adapter1.Fill(datatable1);
            firmasi_m.DataSource = datatable1;
            firmasi_m.DisplayMember = "Firma_nomi";

        }

        private void qoshish_m_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldIsEmpty())
                {
                    MessageBox.Show("Avval satrlarni to'ldiring ! ", "Kiriting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn = new SqlConnection(path);

                query = "INSERT INTO Modemlar VALUES(@nomi, @firmasi, @max_tezligi, @shox_soni, @narxi)";

                sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("@nomi", nomi_m.Text);
                sqlCommand.Parameters.AddWithValue("@firmasi", firmasi_m.Text);
                sqlCommand.Parameters.AddWithValue("@max_tezligi", max_tez_m.Text);
                sqlCommand.Parameters.AddWithValue("@shox_soni", shox_soni_m.Text);
                sqlCommand.Parameters.AddWithValue("@narxi", narxi_m.Text);

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

        private void ochirish_m_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_m.CurrentRow;

                    DialogResult result = MessageBox.Show("Qaroringiz qat'iymi ? \n Tanlangan qator o'chirib yuboriladi",
                               "O'chirilsinmi ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        conn = new SqlConnection(path);

                        query = "DELETE FROM Modemlar WHERE id_modem = @id";

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

        private void yangilash_m_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_m.CurrentRow;

                    conn = new SqlConnection(path);

                    query = "UPDATE Modemlar SET Nomi = @nomi, Firmasi = @firma, Max_tezligi = @max_tezligi, Shoxlari_soni = @shox_soni, Narxi = @narx WHERE id_modem = @id";

                    sqlCommand = new SqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@nomi", nomi_m.Text);
                    sqlCommand.Parameters.AddWithValue("@firma", firmasi_m.Text);
                    sqlCommand.Parameters.AddWithValue("@max_tezligi", max_tez_m.Text);
                    sqlCommand.Parameters.AddWithValue("@shox_soni", shox_soni_m.Text);
                    sqlCommand.Parameters.AddWithValue("@narx", narxi_m.Text);

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

        private void natija_m_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isCellClick = true;

            DataGridViewRow selectedRow = natija_m.CurrentRow;

            if (natija_m.CurrentRow.Index == natija_m.Rows.Count - 1)
            {
                ClearFields();
            }
            else
            {
                id = Convert.ToInt32(selectedRow.Cells[0].Value);
                nomi_m.Text = selectedRow.Cells[1].Value.ToString();
                firmasi_m.Text = selectedRow.Cells[2].Value.ToString();
                max_tez_m.Text = selectedRow.Cells[3].Value.ToString();
                shox_soni_m.Text = selectedRow.Cells[4].Value.ToString();
                narxi_m.Text = selectedRow.Cells[5].Value.ToString();
            }

            isCellClick = false;
        }

        private void nomi_m_TextChanged(object sender, EventArgs e)
        {
            if (!isCellClick)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(path))
                    {
                        query = "SELECT * FROM Modemlar WHERE 1=1";
                        List<SqlParameter> parameters = new List<SqlParameter>();

                        if (!string.IsNullOrWhiteSpace(nomi_m.Text))
                        {
                            query += " AND Nomi LIKE @nomi";
                            parameters.Add(new SqlParameter("@nomi", nomi_m.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(firmasi_m.Text))
                        {
                            query += " AND Firmasi LIKE @firma";
                            parameters.Add(new SqlParameter("@firma", firmasi_m.Text));
                        }

                        if (!string.IsNullOrWhiteSpace(max_tez_m.Text))
                        {
                            query += " AND Max_tezligi LIKE @max_tezligi";
                            parameters.Add(new SqlParameter("@max_tezligi", max_tez_m.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(shox_soni_m.Text))
                        {
                            query += " AND Shoxlari_soni LIKE @shox_soni";
                            parameters.Add(new SqlParameter("@shox_soni", shox_soni_m.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(narxi_m.Text))
                        {
                            query += " AND Narxi LIKE @narx";
                            parameters.Add(new SqlParameter("@narx", narxi_m.Text + "%"));
                        }

                        using (SqlCommand sqlCommand = new SqlCommand(query, conn))
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());

                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable datatable = new DataTable();
                                adapter.Fill(datatable);
                                natija_m.DataSource = datatable;
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

        private void firmasi_m_TextChanged(object sender, EventArgs e)
        {
            nomi_m_TextChanged(sender, e);
        }

        private void max_tez_m_TextChanged(object sender, EventArgs e)
        {
            nomi_m_TextChanged(sender, e);
        }

        private void shox_soni_m_TextChanged(object sender, EventArgs e)
        {
            nomi_m_TextChanged(sender, e);
        }

        private void narxi_m_TextChanged(object sender, EventArgs e)
        {
            nomi_m_TextChanged(sender, e);
        }

        private void tozalash_m_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
