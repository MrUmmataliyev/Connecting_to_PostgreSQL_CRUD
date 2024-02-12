using Npgsql;

class Program
{
    static void Main()
    {
        string connectionString = "Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=7257320;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        //Program.Create(connection);
        //Program.Read(connection);
        //Program.Update(connection);
        //Program.Delete(connection);
    }
   

}