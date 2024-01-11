using System;
using System.Data;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class GorevlerForm : Form
    {
        private Veritabani veritabani;

        public GorevlerForm()
        {
            InitializeComponent();
            veritabani = new Veritabani();
            dataGridViewGorevler.Columns.Add("GorevID", "Görev ID");
            dataGridViewGorevler.Columns.Add("Aciklama", "Açıklama");
            dataGridViewGorevler.Columns.Add("AtananCalisanID", "Atanan Çalışan ID");
            dataGridViewGorevler.Columns.Add("BaslangicTarihi", "Başlangıç Tarihi");
            dataGridViewGorevler.Columns.Add("BitisTarihi", "Bitiş Tarihi");
            dataGridViewGorevler.Columns.Add("Durum", "Durum");
            buttonKaydet.Click += buttonKaydet_Click;
            buttonSil.Click += buttonSil_Click;
            buttonYenile.Click += buttonYenile_Click;
            dataGridViewGorevler.CellEndEdit += dataGridViewGorevler_CellEndEdit;
            GorevleriGuncelle();
        }

        private void GorevleriGuncelle()
        {
            dataGridViewGorevler.Rows.Clear();
            var gorevler = veritabani.GorevListesi();
            foreach (DataRow row in gorevler.Rows)
            {
                dataGridViewGorevler.Rows.Add(
                    row["GorevID"],
                    row["Aciklama"],
                    row["AtananCalisanID"],
                    Convert.ToDateTime(row["BaslangicTarihi"]).ToString("yyyy-MM-dd"),
                    Convert.ToDateTime(row["BitisTarihi"]).ToString("yyyy-MM-dd"),
                    row["Durum"]
                );
            }
        }

        private void dataGridViewGorevler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex < 0) return;

            bool rowsFilled = true;
            DateTime baslangicTarihi = new DateTime(), bitisTarihi = new DateTime();

            // Veri tamamlanma kontrolü
            for (int i = 0; i < dataGridViewGorevler.Columns.Count; i++)
            {
                if (dataGridViewGorevler.Rows[satirIndex].Cells[i].Value == null ||
                    dataGridViewGorevler.Rows[satirIndex].Cells[i].Value.ToString().Trim() == "")
                {
                    rowsFilled = false;
                    
                    break;
                }
            }

            // Tarih formatı kontrolü
            if (rowsFilled &&
                (!DateTime.TryParse(dataGridViewGorevler.Rows[satirIndex].Cells["BaslangicTarihi"].Value.ToString(), out baslangicTarihi) ||
                 !DateTime.TryParse(dataGridViewGorevler.Rows[satirIndex].Cells["BitisTarihi"].Value.ToString(), out bitisTarihi)))
            {
                rowsFilled = false;
                MessageBox.Show("Tarihler 'yyyy-MM-dd' formatında olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Veritabanı işlemi
            if (rowsFilled)
            {
                string gorevID = dataGridViewGorevler.Rows[satirIndex].Cells["GorevID"].Value.ToString();
                string aciklama = dataGridViewGorevler.Rows[satirIndex].Cells["Aciklama"].Value.ToString();
                string atananCalisanID = dataGridViewGorevler.Rows[satirIndex].Cells["AtananCalisanID"].Value.ToString();
                string durum = dataGridViewGorevler.Rows[satirIndex].Cells["Durum"].Value.ToString();

                bool gorevVarMi = veritabani.GorevVarMi(gorevID);
                if (gorevVarMi)
                {
                    veritabani.GorevGuncelle(gorevID, aciklama, atananCalisanID, baslangicTarihi, bitisTarihi, durum);
                }
                else
                {
                    veritabani.GorevEkle(gorevID, aciklama, atananCalisanID, baslangicTarihi, bitisTarihi, durum);
                }
            }
        }


        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            GorevleriGuncelle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewGorevler.CurrentRow != null)
            {
                string gorevID = dataGridViewGorevler.CurrentRow.Cells["GorevID"].Value.ToString();
                veritabani.GorevSil(gorevID);
                GorevleriGuncelle();
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            GorevleriGuncelle();
        }
    }
}
