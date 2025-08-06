namespace btrade.domain.Model;

public record BrgType(string BrgId, string BrgCode, string BrgName, 
    string KategoriName,  string SatBesar, string SatKecil, string Konversi,
    decimal HrgSat, int Stok): IBrgKey;


public interface IBrgKey
{
    string BrgId { get; }
}
