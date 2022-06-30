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
    public partial class InputPembeli : Form
    {
        public InputPembeli()
        {
            InitializeComponent();
        }
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-LHK17QQH;Initial Catalog=Final_Projek;User ID=sa;Password=Dhani030117");

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Pembeli] (Id_Pembeli,Nama_Pembeli,NoHp_Pembeli, Alamat_Pembeli) values ('" + textBox1.Text + "' ,'" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "' )";
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
            cmd.CommandText = "select * from [Pembeli]";
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
            cmd.CommandText = "update [Pembeli] set Id_Pembeli ='" + this.textBox1.Text + "', Nama_Pembeli ='" + this.textBox2.Text + "', NoHp_Pembeli ='" + this.textBox3.Text + "', Alamat_Pembeli ='" + this.textBox4.Text +  "' where Id_Pembeli ='" + this.textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Update Berhasil");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Pembeli] where Id_Pembeli = '" + textBox1.Text + "'";
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
            cmd.CommandText = "select * from [Pembeli] where Id_Pembeli = '" + textBox5.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
            textBox5.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuUtama mutama = new MenuUtama();
            mutama.Show();
            this.Hide();
        }

        private void InputPembeli_Load(object sender, EventArgs e)
        {

        }
    }
}
