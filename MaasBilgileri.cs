using System;
using System.Data;
using System.Windows.Forms;

namespace CalisanYonetimSistemi
{
    public partial class MaasBilgileri : Form
    {
        private Veritabani veritabani;

        public MaasBilgileri()
        {
            InitializeComponent();
            veritabani = new Veritabani();

                        dataGridViewMaasBilgileri.Columns.Add("KayitID", "Kayıt ID");
            dataGridViewMaasBilgileri.Columns.Add("CalisanID", "Çalışan ID");
            dataGridViewMaasBilgileri.Columns.Add("MaasMiktari", "Maaş Miktarı");
            dataGridViewMaasBilgileri.Columns.Add("OdemeTarihi", "Ödeme Tarihi");
            dataGridViewMaasBilgileri.Columns.Add("Bonus", "Bonus");

            buttonKaydet.Click += buttonKaydet_Click;
            buttonSil.Click += buttonSil_Click;
            buttonYenile.Click += buttonYenile_Click;
            dataGridViewMaasBilgileri.CellEndEdit += dataGridViewMaasBilgileri_CellEndEdit;
            MaasBilgileriniGuncelle();
        }

        private void MaasBilgileriniGuncelle()
        {
            dataGridViewMaasBilgileri.Rows.Clear();
            var maasBilgileri = veritabani.MaasBilgileriListesi();

            foreach (DataRow row in maasBilgileri.Rows)
            {
                dataGridViewMaasBilgileri.Rows.Add(
                    row["KayitID"],
                    row["CalisanID"],
                    row["MaasMiktari"].ToString(),
                    Convert.ToDateTime(row["OdemeTarihi"]).ToString("yyyy-MM-dd"),
                    row["Bonus"].ToString()
                );
            }
        }

        private void dataGridViewMaasBilgileri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int satirIndex = e.RowIndex;
            if (satirIndex < 0) return;
            bool rowsFilled = true;
            DateTime odemeTarihi = new DateTime();

            for (int i = 0; i < dataGridViewMaasBilgileri.Columns.Count; i++)
            {
                if (dataGridViewMaasBilgileri.Rows[satirIndex].Cells[i].Value == null ||
                    dataGridViewMaasBilgileri.Rows[satirIndex].Cells[i].Value.ToString().Trim() == "")
                {
                    rowsFilled = false;
                    break;
                }
            }
            if (rowsFilled && !DateTime.TryParse(dataGridViewMaasBilgileri.Rows[satirIndex].Cells["OdemeTarihi"].Value.ToString(), out odemeTarihi))
            {
                rowsFilled = false;
                MessageBox.Show("Ödeme tarihi 'yyyy-MM-dd' formatında olmalıdır.", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rowsFilled)
            {
                string kayitID = dataGridViewMaasBilgileri.Rows[satirIndex].Cells["KayitID"].Value.ToString();
                string calisanID = dataGridViewMaasBilgileri.Rows[satirIndex].Cells["CalisanID"].Value.ToString();
                decimal maasMiktari = Convert.ToDecimal(dataGridViewMaasBilgileri.Rows[satirIndex].Cells["MaasMiktari"].Value);
                decimal bonus = Convert.ToDecimal(dataGridViewMaasBilgileri.Rows[satirIndex].Cells["Bonus"].Value);

                bool kayitVarMi = veritabani.MaasBilgisiVarMi(kayitID);
                if (kayitVarMi)
                {
                    veritabani.MaasBilgisiGuncelle(kayitID, calisanID, maasMiktari, odemeTarihi, bonus);
                }
                else
                {
                    veritabani.MaasBilgisiEkle(kayitID, calisanID, maasMiktari, odemeTarihi, bonus);
                }
            }
        }



        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            MaasBilgileriniGuncelle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaasBilgileri.CurrentRow != null)
            {
                string kayitID = dataGridViewMaasBilgileri.CurrentRow.Cells["KayitID"].Value.ToString();
                veritabani.MaasBilgisiSil(kayitID);
                MaasBilgileriniGuncelle();
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            MaasBilgileriniGuncelle();
        }
    }
}
