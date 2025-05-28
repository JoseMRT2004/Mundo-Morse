using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DatabaseConfig
{
    public string ConnectionString { get; }

    public DatabaseConfig(IConfiguration configuration)
    {
        var dbSettings = configuration.GetSection("DataBase:Connection");
        ConnectionString = new SqlConnectionStringBuilder
        {
            DataSource = dbSettings["Server"],
            InitialCatalog = dbSettings["Database"],
            IntegratedSecurity = true,
            TrustServerCertificate = true
        }.ConnectionString;
    }
}