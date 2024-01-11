using System;
using System.Data;
using System.Data.SqlClient;

public class Veritabani
{
    private SqlConnection baglanti;
    private string baglantiString;

    public Veritabani()
    {
        baglantiString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\calisanyonetimsistemi.mdf;Integrated Security=True";
        baglanti = new SqlConnection(baglantiString);
    }

    private void Calistir(SqlCommand komut)
    {
        try
        {
            baglanti.Open();
            komut.ExecuteNonQuery();
        }
        finally
        {
            baglanti.Close();
        }
    }

    private DataTable VeriListele(string sorgu)
    {
        DataTable table = new DataTable();
        try
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            adapter.Fill(table);
        }
        finally
        {
            baglanti.Close();
        }
        return table;
    }

    public void CalisanEkle(string calisanID, string adi, string soyadi, string pozisyon, string departman, DateTime baslangicTarihi, string email, string telefon, string adres)
    {
        SqlCommand komut = new SqlCommand("SP_CalisanEkle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@Adi", adi);
        komut.Parameters.AddWithValue("@Soyadi", soyadi);
        komut.Parameters.AddWithValue("@Pozisyon", pozisyon);
        komut.Parameters.AddWithValue("@Departman", departman);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@Email", email);
        komut.Parameters.AddWithValue("@Telefon", telefon);
        komut.Parameters.AddWithValue("@Adres", adres);
        Calistir(komut);
    }

    public void CalisanGuncelle(string calisanID, string adi, string soyadi, string pozisyon, string departman, DateTime baslangicTarihi, string email, string telefon, string adres)
    {
        SqlCommand komut = new SqlCommand("SP_CalisanGuncelle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@Adi", adi);
        komut.Parameters.AddWithValue("@Soyadi", soyadi);
        komut.Parameters.AddWithValue("@Pozisyon", pozisyon);
        komut.Parameters.AddWithValue("@Departman", departman);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@Email", email);
        komut.Parameters.AddWithValue("@Telefon", telefon);
        komut.Parameters.AddWithValue("@Adres", adres);
        Calistir(komut);
    }

    public void CalisanSil(string calisanID)
    {
        SqlCommand komut = new SqlCommand("SP_CalisanSil", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        Calistir(komut);
    }

    public void GorevEkle(string gorevID, string aciklama, string atananCalisanID, DateTime baslangicTarihi, DateTime bitisTarihi, string durum)
    {
        SqlCommand komut = new SqlCommand("SP_GorevEkle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@GorevID", gorevID);
        komut.Parameters.AddWithValue("@Aciklama", aciklama);
        komut.Parameters.AddWithValue("@AtananCalisanID", atananCalisanID);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
        komut.Parameters.AddWithValue("@Durum", durum);
        Calistir(komut);
    }

    public void GorevGuncelle(string gorevID, string aciklama, string atananCalisanID, DateTime baslangicTarihi, DateTime bitisTarihi, string durum)
    {
        SqlCommand komut = new SqlCommand("SP_GorevGuncelle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@GorevID", gorevID);
        komut.Parameters.AddWithValue("@Aciklama", aciklama);
        komut.Parameters.AddWithValue("@AtananCalisanID", atananCalisanID);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
        komut.Parameters.AddWithValue("@Durum", durum);
        Calistir(komut);
    }

    public void GorevSil(string gorevID)
    {
        SqlCommand komut = new SqlCommand("SP_GorevSil", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@GorevID", gorevID);
        Calistir(komut);
    }
    public void IzinEkle(string izinID, string calisanID, string izinTuru, DateTime baslangicTarihi, DateTime bitisTarihi)
    {
        SqlCommand komut = new SqlCommand("SP_IzinEkle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@IzinID", izinID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@IzinTuru", izinTuru);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
        Calistir(komut);
    }

    public void IzinGuncelle(string izinID, string calisanID, string izinTuru, DateTime baslangicTarihi, DateTime bitisTarihi)
    {
        SqlCommand komut = new SqlCommand("SP_IzinGuncelle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@IzinID", izinID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@IzinTuru", izinTuru);
        komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
        komut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
        Calistir(komut);
    }

    public void IzinSil(string izinID)
    {
        SqlCommand komut = new SqlCommand("SP_IzinSil", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@IzinID", izinID);
        Calistir(komut);
    }

    public void DegerlendirmeEkle(string degerlendirmeID, string calisanID, DateTime degerlendirmeTarihi, int puan, string yorumlar)
    {
        SqlCommand komut = new SqlCommand("SP_DegerlendirmeEkle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@DegerlendirmeID", degerlendirmeID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@DegerlendirmeTarihi", degerlendirmeTarihi);
        komut.Parameters.AddWithValue("@Puan", puan);
        komut.Parameters.AddWithValue("@Yorumlar", yorumlar);
        Calistir(komut);
    }

    public void DegerlendirmeGuncelle(string degerlendirmeID, string calisanID, DateTime degerlendirmeTarihi, int puan, string yorumlar)
    {
        SqlCommand komut = new SqlCommand("SP_DegerlendirmeGuncelle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@DegerlendirmeID", degerlendirmeID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@DegerlendirmeTarihi", degerlendirmeTarihi);
        komut.Parameters.AddWithValue("@Puan", puan);
        komut.Parameters.AddWithValue("@Yorumlar", yorumlar);
        Calistir(komut);
    }

    public void DegerlendirmeSil(string degerlendirmeID)
    {
        SqlCommand komut = new SqlCommand("SP_DegerlendirmeSil", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@DegerlendirmeID", degerlendirmeID);
        Calistir(komut);
    }
    public void MaasBilgisiEkle(string kayitID, string calisanID, decimal maasMiktari, DateTime odemeTarihi, decimal bonus)
    {
        SqlCommand komut = new SqlCommand("SP_MaasBilgisiEkle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@KayitID", kayitID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@MaasMiktari", maasMiktari);
        komut.Parameters.AddWithValue("@OdemeTarihi", odemeTarihi);
        komut.Parameters.AddWithValue("@Bonus", bonus);
        Calistir(komut);
    }

    public void MaasBilgisiGuncelle(string kayitID, string calisanID, decimal maasMiktari, DateTime odemeTarihi, decimal bonus)
    {
        SqlCommand komut = new SqlCommand("SP_MaasBilgisiGuncelle", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@KayitID", kayitID);
        komut.Parameters.AddWithValue("@CalisanID", calisanID);
        komut.Parameters.AddWithValue("@MaasMiktari", maasMiktari);
        komut.Parameters.AddWithValue("@OdemeTarihi", odemeTarihi);
        komut.Parameters.AddWithValue("@Bonus", bonus);
        Calistir(komut);
    }

    public void MaasBilgisiSil(string kayitID)
    {
        SqlCommand komut = new SqlCommand("SP_MaasBilgisiSil", baglanti);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@KayitID", kayitID);
        Calistir(komut);
    }



    public DataTable CalisanListesi()
    {
        return VeriListele("SELECT * FROM Calisanlar");
    }

    public DataTable GorevListesi()
    {
        return VeriListele("SELECT * FROM Gorevler");
    }

    public DataTable IzinListesi()
    {
        return VeriListele("SELECT * FROM Izinler");
    }

    public DataTable PerformansDegerlendirmeleriListesi()
    {
        return VeriListele("SELECT * FROM PerformansDegerlendirmeleri");
    }

    public DataTable MaasBilgileriListesi()
    {
        return VeriListele("SELECT * FROM MaasBilgileri");
    }
    public bool CalisanVarMi(string calisanID)
    {
        DataTable table = VeriListele("SELECT * FROM Calisanlar WHERE CalisanID = '" + calisanID + "'");
        return table.Rows.Count > 0;
    }

    public bool GorevVarMi(string gorevID)
    {
        DataTable table = VeriListele("SELECT * FROM Gorevler WHERE GorevID = '" + gorevID + "'");
        return table.Rows.Count > 0;
    }

    public bool IzinVarMi(string izinID)
    {
        DataTable table = VeriListele("SELECT * FROM Izinler WHERE IzinID = '" + izinID + "'");
        return table.Rows.Count > 0;
    }

    public bool MaasBilgisiVarMi(string kayitID)
    {
        DataTable table = VeriListele("SELECT * FROM MaasBilgileri WHERE KayitID = '" + kayitID + "'");
        return table.Rows.Count > 0;
    }

    public bool DegerlendirmeVarMi(string degerlendirmeID)
    {
        DataTable table = VeriListele("SELECT * FROM PerformansDegerlendirmeleri WHERE DegerlendirmeID = '" + degerlendirmeID + "'");
        return table.Rows.Count > 0;
    }

}
