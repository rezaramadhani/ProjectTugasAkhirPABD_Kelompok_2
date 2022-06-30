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

namespace FinalProjek
{
    public partial class InputTransaksi : Form
    {
        public InputTransaksi()
        {
            InitializeComponent();
        }
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-LHK17QQH;Initial Catalog=Final_Projek;User ID=sa;Password=Dhani030117");

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Transaksi] (Id_Transaksi,Id_Pembeli,Kode_Barang,Qty,Total_Bayar,Alamat_Pembeli, NoHp_Pembeli) values ('" + textBox1.Text + "' ,'" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "' ,'" + textBox5.Text + "' ,'" + textBox6.Text + "','"+ textBox7.Text +"' )";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Berhasil");
            display_data();
        }
        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Transaksi]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Transaksi] set Id_Transaksi ='" + this.textBox1.Text + "', Id_Pembeli ='" + this.textBox2.Text + "', Kode_Barang ='" + this.textBox3.Text + "', Qty ='" + this.textBox4.Text + "', Total_Bayar ='" + this.textBox5.Text + "',Alamat_Pembeli ='" + this.textBox6.Text + "', NoHp_Pembeli ='" + this.textBox7.Text + "' where Id_Transaksi ='" + this.textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            display_data();
            MessageBox.Show("Update Berhasil");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Transaksi] where Id_Transaksi = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            MessageBox.Show("Data berhasil dihapus");
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Transaksi] where Id_Transaksi = '" + textBox8.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
            textBox8.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuUtama mutama = new MenuUtama();
            mutama.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
