// See https://aka.ms/new-console-template for more information
/*using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
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

Console.ReadKey();*/

/*using DotnetTrainingTKS.ConsoleApp.AdoDotNetExamples;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Create("The Property", "Dean Winchester", "How to rich in short time?");
//adoDotNetExample.Update(11, "The Reaper", "Franklin", "4HorseMan");
adoDotNetExample.Delete(11);*/

/*using DotnetTrainingTKS.ConsoleApp.DapperExamples;
DapperExample dapperExample=new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(10);
//dapperExample.Create("Indiana Jones", "George Lucas", "The Beginning");
//dapperExample.Update(12, "Indiana Jonse", "George Lucas", "The Lost Island");
dapperExample.Delete(12);*/

//using DotnetTrainingTKS.ConsoleApp.EFCoreExamples;
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(10);
//eFCoreExample.Create("The Batman","BillFinger", "A Rainy Day");
//eFCoreExample.Update(13, "The Batman", "Bill Finger", "The Beginning");
//eFCoreExample.Create("The Batman", "BillFinger", "A Rainy Day");
//eFCoreExample.Delete(14);
using DotnetTrainingTKS.ConsoleApp.HttpClientExamples;
Console.WriteLine("Waiting For Api");
Console.ReadKey();
HttpClientExaple httpclient = new HttpClientExaple();
await httpclient.Run();
Console.ReadKey();