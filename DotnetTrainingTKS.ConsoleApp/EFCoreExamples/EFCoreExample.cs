using DotnetTrainingTKS.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTrainingTKS.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db=new AppDbContext();
        public void Read()
        {
            
            List<BlogModel> list= _db.Blogs.ToList();
            foreach(BlogModel blog in list)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }
        }
        public void Edit(int id)
        {
            var item = _db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            if (item != null)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine("No Data is found");
                return;
            }
        }
        public void Create(string title, string author, string content)
        {

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Added Successfully" : "Failed Systematially and Successfully";
            Console.WriteLine(message);
            Read();
        }

        public void Update(int id,string title, string author, string content)
        {
            var obj=_db.Blogs.Where(x=>x.BlogId == id).FirstOrDefault();
            if(obj==null)
            {
                Console.WriteLine("No data is found");
                return;
            }
           obj.BlogTitle = title;
           obj.BlogAuthor = author;
           obj.BlogContent = content;
            _db.Blogs.Update(obj);
            int result= _db.SaveChanges();
            var message = result > 0 ? "Updated Successfully" : "Failed Systematically and Successfully";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            var obj=_db.Blogs.Where(x=>x.BlogId==id).FirstOrDefault();
            _db.Blogs.Remove(obj);
            int result = _db.SaveChanges();
            var message = result > 0 ? "Deleted Successfully" : "Failed Systematically and Successfully";
            Console.WriteLine(message);
            Read();
        }
    }
}
