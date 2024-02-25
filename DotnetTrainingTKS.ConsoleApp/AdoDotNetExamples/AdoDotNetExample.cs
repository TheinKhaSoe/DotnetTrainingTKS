using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace DotnetTrainingTKS.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "THEINKHASOE\\MSSQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";

            string query = "select * from tbl_Blog";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }

            Console.ReadKey();
        }
        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "THEINKHASOE\\MSSQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";

            string query = $@"SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent] From [dbo].[Tbl_Blog] Where BlogId = @BlogId";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Data not found");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
            Console.ReadKey();
        }
        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "THEINKHASOE\\MSSQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = $@"INSERT INTO [dbo].[tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";


            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            string message = result > 0 ? "Saved Successfully" : "Failed Systematically and Successfully";
            Console.WriteLine(message);

        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "THEINKHASOE\\MSSQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = "UPDATE [dbo].[tbl_Blog] SET [BlogTitle] = @BlogTitle,[BlogAuthor] = @BlogAuthor ,[BlogContent] = @BlogContent WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            string message = result > 0 ? "Updated Successfully" : "Failed Systematically and Successfully";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "THEINKHASOE\\MSSQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = "DELETE FROM [dbo].[tbl_BLog] WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            string message=result>0?"Deleted Successfully" : "Failed Systemcatically and Successfully";
            Console.WriteLine(message);

        }
    }

}
