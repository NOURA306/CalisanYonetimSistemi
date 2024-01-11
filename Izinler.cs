using System;
using System.Data;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class Izinler : Form
    {
        private Veritabani veritabani;

        public Izinler()
        {
            InitializeComponent();
            veritabani = new Veritabani();

            dataGridViewIzinler.Columns.Add("IzinID", "İzin ID");
            dataGridViewIzinler.Columns.Add("CalisanID", "Çalışan ID");
            dataGridViewIzinler.Columns.Add("IzinTuru", "İzin Türü");
            dataGridViewIzinler.Columns.Add("BaslangicTarihi", "Başlangıç Tarihi");
            dataGridViewIzinler.Columns.Add("BitisTarihi", "Bitiş Tarihi");

            buttonKaydet.Click += buttonKaydet_Click;
            buttonSil.Click += buttonSil_Click;
            buttonYenile.Click += buttonYenile_Click;
            dataGridViewIzinler.CellEndEdit += dataGridViewIzinler_CellEndEdit;
            IzinleriGuncelle();
        }

        private void IzinleriGuncelle()
        {
            dataGridViewIzinler.Rows.Clear();
            var izinler = veritabani.IzinListesi();

            foreach (DataRow row in izinler.Rows)
            {
                dataGridViewIzinler.Rows.Add(
                    row["IzinID"],
                    row["CalisanID"],
                    row["IzinTuru"],
                    Convert.ToDateTime(row["BaslangicTarihi"]).ToString("yyyy-MM-dd"),
                    Convert.ToDateTime(row["BitisTarihi"]).ToString("yyyy-MM-dd")
                );
            }
        }

        private void dataGridViewIzinler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex < 0) return;

            bool rowsFilled = true;
            DateTime baslangicTarihi = new DateTime(), bitisTarihi = new DateTime();

            for (int i = 0; i < dataGridViewIzinler.Columns.Count; i++)
            {
                if (dataGridViewIzinler.Rows[satirIndex].Cells[i].Value == null ||
                    dataGridViewIzinler.Rows[satirIndex].Cells[i].Value.ToString().Trim() == "")
                {
                    rowsFilled = false;
                    
                    break;
                }
            }

            if (rowsFilled &&
                (!DateTime.TryParse(dataGridViewIzinler.Rows[satirIndex].Cells["BaslangicTarihi"].Value.ToString(), out baslangicTarihi) ||
                 !DateTime.TryParse(dataGridViewIzinler.Rows[satirIndex].Cells["BitisTarihi"].Value.ToString(), out bitisTarihi)))
            {
                rowsFilled = false;
                MessageBox.Show("Tarihler 'yyyy-MM-dd' formatında olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (rowsFilled)
            {
                string izinID = dataGridViewIzinler.Rows[satirIndex].Cells["IzinID"].Value.ToString();
                string calisanID = dataGridViewIzinler.Rows[satirIndex].Cells["CalisanID"].Value.ToString();
                string izinTuru = dataGridViewIzinler.Rows[satirIndex].Cells["IzinTuru"].Value.ToString();

                bool izinVarMi = veritabani.IzinVarMi(izinID);
                if (izinVarMi)
                {
                    veritabani.IzinGuncelle(izinID, calisanID, izinTuru, baslangicTarihi, bitisTarihi);
                }
                else
                {
                    veritabani.IzinEkle(izinID, calisanID, izinTuru, baslangicTarihi, bitisTarihi);
                }
            }
        }


        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            IzinleriGuncelle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewIzinler.CurrentRow != null)
            {
                string izinID = dataGridViewIzinler.CurrentRow.Cells["IzinID"].Value.ToString();
                veritabani.IzinSil(izinID);
                IzinleriGuncelle();
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            IzinleriGuncelle();
        }
    }
}
