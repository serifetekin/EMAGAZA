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
using ADO.NET;

namespace EMAGAZA
{
    public partial class Form1 : Form
    {
        DbClass db = new DbClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = db.TabloGetir("Select * from KATEGORI");

            Genel.ListDoldur(comboBox1, dt, "KATEGORI_ADI", "KATEGORI_REFNO");
            //comboBox1.DataSource = dt; // VERİ KAYNAĞI (data binding)
            //comboBox1.DisplayMember = "KATEGORI_ADI"; // ekranda görünecek olan
            //comboBox1.ValueMember = "KATEGORI_REFNO"; // seçili bir kategorinin refnosu
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            try
            {
                string kategorirefno = comboBox1.SelectedValue.ToString();

                string sql = "SELECT * FROM ALT_KATEGORI WHERE KATEGORI_REFNO=@P1";
                SqlParameter prm1 = new SqlParameter("@P1", Convert.ToInt32(kategorirefno));

                DataTable dt = db.TabloGetir(sql, prm1);

                Genel.ListDoldur(listBox1, dt, "ALT_KATEGORI_ADI", "ALT_KATEGORI_REFNO");
                //listBox1.DataSource = dt; // VERİ KAYNAĞI (data binding)
                //listBox1.DisplayMember = "ALT_KATEGORI_ADI"; // ekranda görünecek olan
                //listBox1.ValueMember = "ALT_KATEGORI_REFNO"; // seçili bir kategorinin refnosu
                //                                         //int kategorirefno =Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]);
            }
            catch (Exception)
            {

            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) // seçili olan index değişti.
        {
            string alt_kategori_refno = listBox1.SelectedValue.ToString();
            string sql = "SELECT * FROM URUN WHERE ALT_KATEGORI_REFNO=@P1";
            SqlParameter prm1 = new SqlParameter("@P1", Convert.ToInt32(alt_kategori_refno));
            DataTable dt = db.TabloGetir(sql, prm1);

            dataGridView1.DataSource = dt;


        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e) // son harfi kontrol eder.
        {
            string sql = "SELECT * FROM URUN WHERE URUN_ADI LIKE '%'+@p1+'%'";
            SqlParameter prm1 = new SqlParameter("@P1", textBox1.Text);
            DataTable dt = db.TabloGetir(sql, prm1);
            dataGridView1.DataSource = dt;
        }
    }
}
