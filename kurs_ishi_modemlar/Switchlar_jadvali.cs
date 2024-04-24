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
    public partial class Switchlar_jadvali : Form
    {
        string path = Program.path;
        string query = "";

        int id = 0;
        bool isCellClick = false;

        SqlConnection conn;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable datatable = new DataTable();

        public Switchlar_jadvali()
        {
            InitializeComponent();
        }
        
        private void Switchlar_jadvali_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void View()
        {
            conn = new SqlConnection(path);
            query = "SELECT * FROM Switchlar";

            adapter = new SqlDataAdapter(query, conn);
            datatable.Clear();
            adapter.Fill(datatable);
            natija_s.DataSource = datatable;
        }

        public bool FieldIsEmpty()
        {
            return nomi_s.Text.Trim() == "" ||
                   firmasi_s.Text.Trim() == "" ||
                   port_soni_s.Text.Trim() == "" ||
                   narxi_s.Text.Trim() == "";
        }

        public void ClearFields()
        {
            nomi_s.Text = "";
            firmasi_s.Text = "";
            port_soni_s.Text = "";
            narxi_s.Text = "";
        }

        private void orqaga_s_Click(object sender, EventArgs e)
        {
            Jadvallar jadvallar = new Jadvallar();
            jadvallar.Show();
            Hide();
        }
        private void Switchlar_jadvali_Load(object sender, EventArgs e)
        {
            View();

            SqlConnection conn1 = new SqlConnection(path);
            SqlCommand sqlCommand1 = new SqlCommand("select Firma_nomi from Firmalar", conn1);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = sqlCommand1;
            DataTable datatable1 = new DataTable();
            adapter1.Fill(datatable1);
            firmasi_s.DataSource = datatable1;
            firmasi_s.DisplayMember = "Firma_nomi";
        }
       
        private void qoshish_s_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldIsEmpty())
                {
                    MessageBox.Show("Avval satrlarni to'ldiring ! ", "Kiriting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn = new SqlConnection(path);

                query = "INSERT INTO Switchlar VALUES(@nomi, @firmasi, @port_soni, @narxi)";

                sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("@nomi", nomi_s.Text);
                sqlCommand.Parameters.AddWithValue("@firmasi", firmasi_s.Text);
                sqlCommand.Parameters.AddWithValue("@port_soni", port_soni_s.Text);
                sqlCommand.Parameters.AddWithValue("@narxi", narxi_s.Text);

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

        private void ochirish_s_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_s.CurrentRow;

                    DialogResult result = MessageBox.Show("Qaroringiz qat'iymi ? \n Tanlangan qator o'chirib yuboriladi",
                               "O'chirilsinmi ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        conn = new SqlConnection(path);

                        query = "DELETE FROM Switchlar WHERE id = @id";

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

        private void yangilash_s_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_s.CurrentRow;

                    conn = new SqlConnection(path);

                    query = "UPDATE Switchlar SET Nomi = @nomi, Firmasi = @firmasi, Portlari_soni = @port_soni, Narxi = @narxi WHERE id = @id";

                    sqlCommand = new SqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@nomi", nomi_s.Text);
                    sqlCommand.Parameters.AddWithValue("@firmasi", firmasi_s.Text);
                    sqlCommand.Parameters.AddWithValue("@port_soni", port_soni_s.Text);
                    sqlCommand.Parameters.AddWithValue("@narxi", narxi_s.Text);

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

        private void natija_s_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isCellClick = true;

            DataGridViewRow selectedRow = natija_s.CurrentRow;

            if (natija_s.CurrentRow.Index == natija_s.Rows.Count - 1)
            {
                ClearFields();
            }
            else
            {
                id = Convert.ToInt32(selectedRow.Cells[0].Value);
                nomi_s.Text = selectedRow.Cells[1].Value.ToString();
                firmasi_s.Text = selectedRow.Cells[2].Value.ToString();
                port_soni_s.Text = selectedRow.Cells[3].Value.ToString();
                narxi_s.Text = selectedRow.Cells[4].Value.ToString();
            }

            isCellClick = false;
        }

        private void nomi_s_TextChanged(object sender, EventArgs e)
        {
            if (!isCellClick)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(path))
                    {
                        query = "SELECT * FROM Switchlar WHERE 1=1";
                        List<SqlParameter> parameters = new List<SqlParameter>();

                        if (!string.IsNullOrWhiteSpace(nomi_s.Text))
                        {
                            query += " AND Nomi LIKE @nomi";
                            parameters.Add(new SqlParameter("@nomi", nomi_s.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(firmasi_s.Text))
                        {
                            query += " AND Firmasi LIKE @firmasi";
                            parameters.Add(new SqlParameter("@firmasi", firmasi_s.Text));
                        }

                        if (!string.IsNullOrWhiteSpace(port_soni_s.Text))
                        {
                            query += " AND Portlari_soni LIKE @port_soni";
                            parameters.Add(new SqlParameter("@port_soni", port_soni_s.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(narxi_s.Text))
                        {
                            query += " AND Narxi LIKE @narxi";
                            parameters.Add(new SqlParameter("@narxi", narxi_s.Text + "%"));
                        }

                        using (SqlCommand sqlCommand = new SqlCommand(query, conn))
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());

                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable datatable = new DataTable();
                                adapter.Fill(datatable);
                                natija_s.DataSource = datatable;
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

        private void firmasi_s_TextChanged(object sender, EventArgs e)
        {
             nomi_s_TextChanged(sender, e);
        }

        private void port_soni_s_TextChanged(object sender, EventArgs e)
        {
             nomi_s_TextChanged(sender, e);
        }

        private void narxi_s_TextChanged(object sender, EventArgs e)
        {
             nomi_s_TextChanged(sender, e);
        }

        private void tozalash_s_Click(object sender, EventArgs e)
        {
             ClearFields();
        }
    }
}
