using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WebApiToDo.Models
{
    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDoModel> ToDo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "ToDoDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
