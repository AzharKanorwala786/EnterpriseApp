using System.Data.Entity;

namespace Data
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {

    }
}