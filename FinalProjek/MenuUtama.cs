using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjek
{
    public partial class MenuUtama : Form
    {
        public MenuUtama()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            InputPembeli iPembeli = new InputPembeli();
            iPembeli.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InputBarang iBarang = new InputBarang();
            iBarang.Show();
            this.Hide();
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            InputTransaksi iTransaksi = new InputTransaksi();
            iTransaksi.Show();
            this.Hide();
        }
    }
}
