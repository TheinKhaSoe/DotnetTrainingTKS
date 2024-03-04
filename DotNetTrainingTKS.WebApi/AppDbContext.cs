using DotNetTrainingTKS.WebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DotNetTrainingTKS.WebApi
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "THEINKHASOE\\MSSQL2019",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
