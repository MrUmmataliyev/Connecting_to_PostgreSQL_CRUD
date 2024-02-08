using Npgsql;

class Program
{
    static void Main()
    {
        string connectionString = "Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=7257320;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        Program.Create(connection);
        Program.Read(connection);
        Program.Update(connection);
        Program.Delete(connection);
    }
    static void Create(NpgsqlConnection connection)
    {
        connection.Open();
        Console.Write("Enter user_name: ");
        string name = Console.ReadLine();
        Console.Write("Enter user_surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter age: ");
        int age =  int.Parse(Console.ReadLine());

        string query = $"insert into users (user_name, user_surname, age) values ('{name}','{surname}',{age});";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();

        Console.WriteLine($"Successfully created");

        connection.Close();
    }


    static void Read(NpgsqlConnection connection)
    {
        connection.Open();
        string query = "select * from users";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var result = cmd.ExecuteReader();
        while (result.Read())
        {
            Console.WriteLine($"{result[0]}|{result[1]}|{result[2]}|{result[3]}");
        }
        connection.Close();
    }



    static void Update(NpgsqlConnection connection)
    {
        connection.Open();
        Console.Write("Which id do you want to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter new user_name: ");
        string name = Console.ReadLine();
        Console.Write("Enter new user_surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter new age: ");
        int age = int.Parse(Console.ReadLine());

        string query = $"UPDATE users SET user_name = '{name}', user_surname = '{surname}', age = '{age}' WHERE user_id = {id};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();

        Console.WriteLine($"Successfully updated");

        connection.Close();
    }

    static void Delete(NpgsqlConnection connection)
    {
        connection.Open();
        Console.Write("Which id do you want to delete: ");
        int id = int.Parse(Console.ReadLine());



        string query = $"DELETE from users where id = {id};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();

        Console.WriteLine($"Successfully deleted");

        connection.Close();
    }

}