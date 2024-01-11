using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class Calisanlar : Form
    {
        private Veritabani veritabani;


        public Calisanlar()
        {
            InitializeComponent();
            veritabani = new Veritabani();

            dataGridViewCalisanlar.Columns.Add("CalisanID", "Çalışan ID");
            dataGridViewCalisanlar.Columns.Add("Adi", "Adı");
            dataGridViewCalisanlar.Columns.Add("Soyadi", "Soyadı");
            dataGridViewCalisanlar.Columns.Add("Pozisyon", "Pozisyon");
            dataGridViewCalisanlar.Columns.Add("Departman", "Departman");
            dataGridViewCalisanlar.Columns.Add("BaslangicTarihi", "Başlangıç Tarihi");
            dataGridViewCalisanlar.Columns.Add("Email", "E-mail");
            dataGridViewCalisanlar.Columns.Add("Telefon", "Telefon");
            dataGridViewCalisanlar.Columns.Add("Adres", "Adres");

            buttonKaydet.Click += buttonKaydet_Click;
            buttonSil.Click += buttonSil_Click;
            buttonYenile.Click += buttonYenile_Click;
            dataGridViewCalisanlar.CellEndEdit += dataGridViewCalisanlar_CellEndEdit;
            CalisanlariGuncelle();
        }

        private void Calisanlar_Load(object sender, EventArgs e)
        {

        }
        private void CalisanlariGuncelle()
        {
            dataGridViewCalisanlar.Rows.Clear();
            var calisanlar = veritabani.CalisanListesi();

            foreach (DataRow row in calisanlar.Rows)
            {
                dataGridViewCalisanlar.Rows.Add(
                    row["CalisanID"],
                    row["Adi"],
                    row["Soyadi"],
                    row["Pozisyon"],
                    row["Departman"],
                    Convert.ToDateTime(row["BaslangicTarihi"]).ToString("yyyy-MM-dd"),
                    row["Email"],
                    row["Telefon"],
                    row["Adres"]
                );
            }
        }

        private void dataGridViewCalisanlar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex < 0) return;
            bool rowsFilled = true;
            DateTime baslangicTarihi = new DateTime();
            for (int i = 0; i < dataGridViewCalisanlar.Columns.Count; i++)
            {
                if (dataGridViewCalisanlar.Rows[satirIndex].Cells[i].Value == null ||
                    dataGridViewCalisanlar.Rows[satirIndex].Cells[i].Value.ToString().Trim() == "")
                {
                    rowsFilled = false;
                    
                    break;
                }
            }

            if (rowsFilled && !DateTime.TryParse(dataGridViewCalisanlar.Rows[satirIndex].Cells["BaslangicTarihi"].Value.ToString(), out baslangicTarihi))
            {
                rowsFilled = false;
                MessageBox.Show("Başlangıç tarihi 'yyyy-MM-dd' formatında olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (rowsFilled)
            {
                string calisanID = dataGridViewCalisanlar.Rows[satirIndex].Cells["CalisanID"].Value.ToString();
                string adi = dataGridViewCalisanlar.Rows[satirIndex].Cells["Adi"].Value.ToString();
                string soyadi = dataGridViewCalisanlar.Rows[satirIndex].Cells["Soyadi"].Value.ToString();
                string pozisyon = dataGridViewCalisanlar.Rows[satirIndex].Cells["Pozisyon"].Value.ToString();
                string departman = dataGridViewCalisanlar.Rows[satirIndex].Cells["Departman"].Value.ToString();
                string email = dataGridViewCalisanlar.Rows[satirIndex].Cells["Email"].Value.ToString();
                string telefon = dataGridViewCalisanlar.Rows[satirIndex].Cells["Telefon"].Value.ToString();
                string adres = dataGridViewCalisanlar.Rows[satirIndex].Cells["Adres"].Value.ToString();

                bool calisanVarMi = veritabani.CalisanVarMi(calisanID);
                if (calisanVarMi)
                {
                    veritabani.CalisanGuncelle(calisanID, adi, soyadi, pozisyon, departman, baslangicTarihi, email, telefon, adres);
                }
                else
                {
                    veritabani.CalisanEkle(calisanID, adi, soyadi, pozisyon, departman, baslangicTarihi, email, telefon, adres);
                }
            }
        }


        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            CalisanlariGuncelle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewCalisanlar.CurrentRow != null)
            {
                string calisanID = dataGridViewCalisanlar.CurrentRow.Cells["CalisanID"].Value.ToString();
                veritabani.CalisanSil(calisanID);
                CalisanlariGuncelle();
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            CalisanlariGuncelle();
        }
    }
}

