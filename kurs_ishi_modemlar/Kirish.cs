namespace kurs_ishi_modemlar
{
    public partial class Kirish : Form
    {
        public Kirish()
        {
            InitializeComponent();
        }

        private void enter_btn_Click(object sender, EventArgs e)
        {
            Bosh_menyu bosh_menyu = new Bosh_menyu();
            bosh_menyu.Show();
            Hide();
        }

        private void Kirish_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}