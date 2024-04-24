using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs_ishi_modemlar
{
    public partial class Firmalar_jadvali : Form
    {
        string path = Program.path;
        string query = "";

        int id = 0;
        bool isCellClick = false;

        SqlConnection conn;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable datatable = new DataTable();
       
        public Firmalar_jadvali()
        {
            InitializeComponent();
        }

        private void orqaga_f_Click(object sender, EventArgs e)
        {
            Jadvallar jadvallar = new Jadvallar();
            jadvallar.Show();
            Hide();
        }

        private void Firmalar_jadvali_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void View()
        {
            conn = new SqlConnection(path);
            query = "SELECT * FROM Firmalar";

            adapter = new SqlDataAdapter(query, conn);
            datatable.Clear();
            adapter.Fill(datatable);
            natija_f.DataSource = datatable;
        }

        public bool FieldIsEmpty()
        {
            return nomi_f.Text.Trim() == "" ||
                   davlati_f.Text.Trim() == "" ||
                   raqami_f.Text.Trim() == "";
        }

        public void ClearFields()
        {
            nomi_f.Text = "";
            davlati_f.Text = "";
            raqami_f.Text = "";
        }

        private void qoshish_f_Click(object sender, EventArgs e)
        {
            try
            {
                if(FieldIsEmpty())
                {
                    MessageBox.Show("Avval satrlarni to'ldiring ! ", "Kiriting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn = new SqlConnection(path);

                query = "INSERT INTO Firmalar VALUES(@nomi, @davlati, @raqami)";
                
                sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("@nomi", nomi_f.Text);
                sqlCommand.Parameters.AddWithValue("@davlati", davlati_f.Text);
                sqlCommand.Parameters.AddWithValue("@raqami", raqami_f.Text);

                conn.Open();
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Ma'lumot qo'shildi", "Kiritildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            View();
            ClearFields();
        }


        private void ochirish_f_Click(object sender, EventArgs e)
        {
            if(!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_f.CurrentRow;

                    DialogResult result = MessageBox.Show("Qaroringiz qat'iymi ? \n Tanlangan qator o'chirib yuboriladi",
                               "O'chirilsinmi ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        conn = new SqlConnection(path);

                        query = "DELETE FROM Firmalar WHERE id_firma = @id";

                        sqlCommand = new SqlCommand(query, conn);
                        sqlCommand.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Ma'lumot muvaffaqqiyatli o'chirildi","O'chirildi",MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Iltimos barcha maydonlarni to'ldiring", "O'chirish",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            View();
            ClearFields();
        }


        private void yangilash_f_Click(object sender, EventArgs e)
        {
            if (!FieldIsEmpty())
            {
                try
                {
                    DataGridViewRow selectedRow = natija_f.CurrentRow;

                    conn = new SqlConnection(path);

                    query = "UPDATE Firmalar SET Firma_nomi = @nomi, Davlati = @davlati, Firma_raqami = @raqami WHERE id_firma = @id";
                    
                    sqlCommand = new SqlCommand(query, conn);
                    
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@nomi", nomi_f.Text);
                    sqlCommand.Parameters.AddWithValue("@davlati", davlati_f.Text);
                    sqlCommand.Parameters.AddWithValue("@raqami", raqami_f.Text);

                    conn.Open();
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Ma'lumot muvaffaqqiyatli yangilandi! ", "Yangilash",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();
                }
                catch(Exception ex)
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

            View();
            ClearFields();
        }

        private void nomi_f_TextChanged(object sender, EventArgs e)
        {
            if (!isCellClick)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(path))
                    {
                        query = "SELECT * FROM Firmalar WHERE 1=1";
                        List<SqlParameter> parameters = new List<SqlParameter>();

                        if (!string.IsNullOrWhiteSpace(nomi_f.Text))
                        {
                            query += " AND Firma_nomi LIKE @nomi";
                            parameters.Add(new SqlParameter("@nomi", "%" + nomi_f.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(davlati_f.Text))
                        {
                            query += " AND Davlati LIKE @davlati";
                            parameters.Add(new SqlParameter("@davlati", "%" + davlati_f.Text + "%"));
                        }

                        if (!string.IsNullOrWhiteSpace(raqami_f.Text))
                        {
                            query += " AND Firma_raqami LIKE @raqami";
                            parameters.Add(new SqlParameter("@raqami", "%" + raqami_f.Text + "%"));
                        }

                        using (SqlCommand sqlCommand = new SqlCommand(query, conn))
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());

                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable datatable = new DataTable();
                                adapter.Fill(datatable);
                                natija_f.DataSource = datatable;
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

        private void davlati_f_TextChanged(object sender, EventArgs e)
        {
            nomi_f_TextChanged(sender, e);
        }
        
        private void raqami_f_TextChanged(object sender, EventArgs e)
        {
            nomi_f_TextChanged(sender, e);
        }
        
        private void natija_f_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isCellClick = true;

            DataGridViewRow selectedRow = natija_f.CurrentRow;

            if (natija_f.CurrentRow.Index == natija_f.Rows.Count - 1)
            {
                ClearFields();
            }
            else
            {
                id = Convert.ToInt32(selectedRow.Cells[0].Value);
                nomi_f.Text = selectedRow.Cells[1].Value.ToString();
                davlati_f.Text = selectedRow.Cells[2].Value.ToString();
                raqami_f.Text = selectedRow.Cells[3].Value.ToString();
            }

            isCellClick = false;
        }

        private void Firmalar_jadvali_Load(object sender, EventArgs e)
        {
            View();
        }

        private void tozalash_f_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
