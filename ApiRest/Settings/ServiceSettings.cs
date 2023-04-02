namespace ApiRest.Settings;

public class ServiceSettings
{
    public Database Database { get; set; } = null!;
}

public class Database
{
    public string DbConnectionString { get; set; } = null!;
}