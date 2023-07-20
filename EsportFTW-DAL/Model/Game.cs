namespace EsportFTW_DAL.Model;

public class Game
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Platform { get; set; }
    public decimal PricePool { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
}