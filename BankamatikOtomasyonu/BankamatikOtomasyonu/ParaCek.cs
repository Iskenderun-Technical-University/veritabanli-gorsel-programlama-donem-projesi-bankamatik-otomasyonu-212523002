﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankamatikOtomasyonu
{
    public partial class ParaCek : Form
    {
        public ParaCek()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(" server = LAPTOP-F1R95NSP\\SQLEXPRESS ; initial catalog = BankamatikOtomasyonu; integrated security = sspi ");

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sayi = float.Parse(maskedTextBox1.Text);

            if(sayi> Form1.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye !","Para Çekme İşlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand(" update musteriler set bakiye -= @p1 where ID = @p2 ", con);
                komut.Parameters.AddWithValue("@p1",sayi);
                komut.Parameters.AddWithValue("@p2",Form1.mID);


                con.Open();

                int sonuc = komut.ExecuteNonQuery();

                if (sonuc == 1)
                {
                    MessageBox.Show("Para Çekme Yapıldı.", "Para Çekme İşlemi", MessageBoxButtons.OK);
                    Form1.mBakiye -= sayi;
                    HareketKaydet.kaydet(Form1.mID, (sayi + "TL Para Çekildi "));
                }
                else
                {
                    MessageBox.Show("Para Çekme İşlemi Başarısız!", "Para Çekme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                con.Close();
                maskedTextBox1.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
