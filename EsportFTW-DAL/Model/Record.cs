namespace EsportFTW_DAL.Model;

public class Record
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public decimal PricePool { get; set; }
    public Tournament Tournament { get; set; }

// Additional properties and methods specific to Record
}