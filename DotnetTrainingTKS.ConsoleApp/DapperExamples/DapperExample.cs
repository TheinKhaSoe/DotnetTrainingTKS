using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotnetTrainingTKS.ConsoleApp.Models;

namespace DotnetTrainingTKS.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "THEINKHASOE\\MSSQL2019",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sa@123"
        };
        public void Read()
        {
            string query = "select * from tbl_Blog";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                
            }

            Console.ReadKey();
        }
        public void Edit(int id)
        {
            string query = @"select * from tbl_Blog WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("No Data is found");
                return;
            }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

          

            Console.ReadKey();
        }
        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Added successfully" : "Failed systematically and successfully";
            Console.Write(message);
            

        }
        public void Update(int id, string title, string author, string content)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            string query = "UPDATE [dbo].[tbl_Blog] SET [BlogTitle] = @BlogTitle,[BlogAuthor] = @BlogAuthor ,[BlogContent] = @BlogContent WHERE BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            int result=db.Execute(query, blog);
            string message = result > 0 ? "Updated Successfully" : "Failed Systematically and Successfully";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            using IDbConnection db= new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            string query = "DELETE FROM [dbo].[tbl_BLog] WHERE BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id
            };
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Deleted Successfully" : "Failed Systemcatically and Successfully";
            Console.WriteLine(message);

        }
    }
}
