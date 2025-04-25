using System;

class Nasabah
{
    private string NomorRekening { get; set; }
    private string NamaPemilik { get; set; }
    private double SaldoRekening { get; set; }

    public Nasabah(string nomorRekening, string nama, double saldoAwal)
    {
        this.NomorRekening = nomorRekening;
        this.NamaPemilik = nama;
        this.SaldoRekening = saldoAwal;
    }

    public void PenarikanDana(double jumlah)
    {
        if (jumlah > this.SaldoRekening)
        {
            Console.WriteLine("Saldo Anda Tidak Mencukupi");
        }
        else
        {
            this.SaldoRekening = this.SaldoRekening - jumlah;
            Console.WriteLine($"Penarikan sebesar Rp{jumlah},00 berhasil. Saldo anda tersisa: Rp{this.SaldoRekening},00");
        }
    }

    public void SetorTunai(double jumlah)
    {
        this.SaldoRekening = this.SaldoRekening + jumlah;
        Console.WriteLine($"Setor tunai sebesar Rp{jumlah},00 berhasil. Saldo anda saat ini: Rp{this.SaldoRekening},00");
    }

    public void TransferAntarRekening( Nasabah Penerima, double jumlah)
    {
        if (jumlah > this.SaldoRekening)
        {
            Console.WriteLine("Saldo Anda Tidak Mencukupi");
        }
        else
        {
            this.SaldoRekening = this.SaldoRekening - jumlah;
            Penerima.SaldoRekening = Penerima.SaldoRekening + jumlah;
            Console.WriteLine($"Transfer sejumlah Rp{jumlah},00 berhasil. Saldo anda tersisa: Rp{this.SaldoRekening},00");
        }
    }

    public void DataRekeningPengguna()
    {
        Console.WriteLine($"Nomor Rekening: {this.NomorRekening}");
        Console.WriteLine($"Nama Pemilik: {this.NamaPemilik}");
        Console.WriteLine($"Saldo Rekening: Rp{this.SaldoRekening},00");
    }
}

class Program
{
    static void Main()
    {
        Nasabah nasabah1 = new Nasabah("242410103010", "Adam Rizqi", 1000000);
        Nasabah nasabah2 = new Nasabah("242410103077", "Darrel Fawwaz", 1000000);

        Console.WriteLine("\nData Rekening Pengguna");
        nasabah1.DataRekeningPengguna();


        Console.WriteLine("\nMenu Penarikan Dana");
        nasabah1.PenarikanDana(100000);

        Console.WriteLine("\nMenu Setor Tunai");
        nasabah1.SetorTunai(500000);

        Console.WriteLine("\nMenu Transfer");
        nasabah1.TransferAntarRekening(nasabah2, 500000);
        Console.WriteLine("\nData Nasabah penerima transfer: ");
        nasabah2.DataRekeningPengguna();
        
        Console.WriteLine("\nData setelah Transaksi:  ");
        nasabah1.DataRekeningPengguna();
    }
}