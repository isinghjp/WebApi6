namespace WebApi6.Models
{
    public class DbAccess
    {
        private static string connectionString = @"server=DESKTOP-8IRQUCN\SQLEXPRESS; Integrated security = false; user id=sa; password=bytes; Initial Catalog=studentmanagment";
        public static string ConnectionString
        {
            get => connectionString;
        }
    }
}
