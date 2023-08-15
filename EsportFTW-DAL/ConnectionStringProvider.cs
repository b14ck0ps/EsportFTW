namespace EsportFTW_DAL;

public record ConnectionStringProvider
{
    public static string GetConnectionString() => @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=49161))(CONNECT_DATA=(SID=xe)));User ID=ESPORTFTW;Password=ESPORTFTW;";
}