namespace Parabola.Server.Data
{
    using System.Data.Entity;

    public class MyDataContext: DbContext
    {
        public MyDataContext(): base("default") { }

        public DbSet<Point> Points { get; set; }
        public DbSet<UserData> UserData { get; set; }
    }
}