using SQLite;

namespace BoilerMate.Interfaces
{
    public interface  IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
