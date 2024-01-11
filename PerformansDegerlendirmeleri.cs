using System;
using System.Data;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class PerformansDegerlendirmeleri : Form
    {
        private Veritabani veritabani;

        public PerformansDegerlendirmeleri()
        {
            InitializeComponent();
            veritabani = new Veritabani();

            dataGridViewPerformansDegerlendirmeleri.Columns.Add("DegerlendirmeID", "Değerlendirme ID");
            dataGridViewPerformansDegerlendirmeleri.Columns.Add("CalisanID", "Çalışan ID");
            dataGridViewPerformansDegerlendirmeleri.Columns.Add("DegerlendirmeTarihi", "Değerlendirme Tarihi");
            dataGridViewPerformansDegerlendirmeleri.Columns.Add("Puan", "Puan");
            dataGridViewPerformansDegerlendirmeleri.Columns.Add("Yorumlar", "Yorumlar");

            buttonKaydet.Click += buttonKaydet_Click;
            buttonSil.Click += buttonSil_Click;
            buttonYenile.Click += buttonYenile_Click;
            dataGridViewPerformansDegerlendirmeleri.CellEndEdit += dataGridViewPerformansDegerlendirmeleri_CellEndEdit;
            PerformansDegerlendirmeleriniGuncelle();
        }

        private void PerformansDegerlendirmeleriniGuncelle()
        {
            dataGridViewPerformansDegerlendirmeleri.Rows.Clear();
            var degerlendirmeler = veritabani.PerformansDegerlendirmeleriListesi();

            foreach (DataRow row in degerlendirmeler.Rows)
            {
                dataGridViewPerformansDegerlendirmeleri.Rows.Add(
                    row["DegerlendirmeID"],
                    row["CalisanID"],
                    Convert.ToDateTime(row["DegerlendirmeTarihi"]).ToString("yyyy-MM-dd"),
                    row["Puan"].ToString(),
                    row["Yorumlar"].ToString()
                );
            }
        }

        private void dataGridViewPerformansDegerlendirmeleri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex < 0) return;
            bool rowsFilled = true;
            DateTime degerlendirmeTarihi = new DateTime();
            int puan = 0;

            for (int i = 0; i < dataGridViewPerformansDegerlendirmeleri.Columns.Count; i++)
            {
                if (dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells[i].Value == null ||
                    dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells[i].Value.ToString().Trim() == "")
                {
                    rowsFilled = false;
                    
                    break;
                }
            }

            if (rowsFilled && !DateTime.TryParse(dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells["DegerlendirmeTarihi"].Value.ToString(), out degerlendirmeTarihi))
            {
                rowsFilled = false;
                MessageBox.Show("Degerlendirme tarihi 'yyyy-MM-dd' formatında olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rowsFilled && !int.TryParse(dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells["Puan"].Value.ToString(), out puan))
            {
                rowsFilled = false;
                MessageBox.Show("Puan bir sayı olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rowsFilled)
            {
                string calisanID = dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells["CalisanID"].Value.ToString();
                string degerlendirmeID = dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells["DegerlendirmeID"].Value.ToString();
                string yorumlar = dataGridViewPerformansDegerlendirmeleri.Rows[satirIndex].Cells["Yorumlar"].Value.ToString();

                bool degerlendirmeVarMi = veritabani.DegerlendirmeVarMi(degerlendirmeID);
                if (degerlendirmeVarMi)
                {
                    veritabani.DegerlendirmeGuncelle(degerlendirmeID, calisanID, degerlendirmeTarihi, puan, yorumlar);
                }
                else
                {
                    veritabani.DegerlendirmeEkle(degerlendirmeID, calisanID, degerlendirmeTarihi, puan, yorumlar);
                }
            }
        }



        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            PerformansDegerlendirmeleriniGuncelle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewPerformansDegerlendirmeleri.CurrentRow != null)
            {
                string degerlendirmeID = dataGridViewPerformansDegerlendirmeleri.CurrentRow.Cells["DegerlendirmeID"].Value.ToString();
                veritabani.DegerlendirmeSil(degerlendirmeID);
                PerformansDegerlendirmeleriniGuncelle();
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            PerformansDegerlendirmeleriniGuncelle();
        }
    }
}
