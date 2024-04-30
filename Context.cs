using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace wpf_todo
{
    internal class Context : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=todo;Trusted_Connection=true;");
        }
    }

    public class Task
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }

        public Task() { }
        public Task(string content, bool isDone)
        {
            Content = content;
            IsDone = isDone;
        }
    }
}
