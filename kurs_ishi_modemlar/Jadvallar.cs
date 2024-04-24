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
    public partial class Jadvallar : Form
    {
        public Jadvallar()
        {
            InitializeComponent();
        }

        private void Jadvallar_Load(object sender, EventArgs e)
        {

        }

        private void firmalar_btn_Click(object sender, EventArgs e)
        {
            Firmalar_jadvali firmalar_jadvali = new Firmalar_jadvali();
            firmalar_jadvali.Show();
            Hide();
        }

        private void modemlar_btn_Click(object sender, EventArgs e)
        {
            Modemlar_jadvali modemlar_jadvali = new Modemlar_jadvali();
            modemlar_jadvali.Show();
            Hide();
        }

        private void orqaga_btn_Click(object sender, EventArgs e)
        {
            Bosh_menyu bosh_menyu = new Bosh_menyu();
            bosh_menyu.Show();
            Hide();
        }

        private void switchlar_btn_Click(object sender, EventArgs e)
        {
            Switchlar_jadvali switchlar_jadvali = new Switchlar_jadvali();
            switchlar_jadvali.Show();
            Hide();
        }

        private void routerlar_btn_Click(object sender, EventArgs e)
        {
            Routerlar_jadvali routerlar_jadvali = new Routerlar_jadvali();
            routerlar_jadvali.Show();
            Hide();
        }

        private void Jadvallar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
