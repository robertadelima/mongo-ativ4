using System;
using backend.Infra.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Ativ4Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().testConnection();
        }

        public void testConnection(){
            var repo = new BlogRepository();
            var blogs = repo.getBlogs();
            System.Console.WriteLine(string.Join(",", blogs.Select(p => p.description)));

           
        }
    }
}
