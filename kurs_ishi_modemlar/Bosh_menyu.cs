using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs_ishi_modemlar
{
    public partial class Bosh_menyu : Form
    {
        public Bosh_menyu()
        {
            InitializeComponent();
        }

        private void jadvallar_btn_Click(object sender, EventArgs e)
        {
            Jadvallar jadvallar = new Jadvallar();
            jadvallar.Show();
            Hide();
        }

        private void Bosh_menyu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
