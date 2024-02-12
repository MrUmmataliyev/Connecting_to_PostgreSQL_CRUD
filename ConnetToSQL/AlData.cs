using Npgsql;


namespace ConnetToSQL
{
    public class AlData
    {



        static void CreateTable(NpgsqlConnection connection)
        {


            connection.Open();

            Console.WriteLine("Enter table name");
            string tableName = Console.ReadLine();

            string query = $"CREATE TABLE {tableName}( id SERIAL PRIMARY KEY,name varchar(50),surname varchar(50));";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Created");
            connection.Close();

        }
        static void CreateIndex(NpgsqlConnection connection)
        {


            connection.Open();

            Console.WriteLine("Enter table name");
            string tableName = Console.ReadLine();
            Console.WriteLine("Enter table name");
            string columnName = Console.ReadLine();
            string query = $"CREATE INDEX index_{tableName} on {tableName}({columnName});";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Created");
            connection.Close();

        }

        static void CreateDataBase(NpgsqlConnection connection)
        {

             
            connection.Open();

            Console.WriteLine("Enter Database name");
            string baseName = Console.ReadLine();

            string query = $"CREATE DATABASE {baseName};";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Created");
            connection.Close();
            string connectionString = $"Host=localhost;Port=5432;Database={baseName};User Id=postgres;Password=7257320;";

            using NpgsqlConnection connection2 = new NpgsqlConnection(connectionString);
            for (int i = 1; i <= 3; i++) 
            {
                Console.WriteLine("table"+i);
              AlData.CreateTable(connection2);
            
            }


        }
        static void Join(NpgsqlConnection connection)
        {
            Console.Write("Enter new user_name: ");
            string table1 = Console.ReadLine();
            Console.Write("Enter new user_surname: ");
            string table2 = Console.ReadLine();


            connection.Open();
            string query = $"select * from {table1} as t1 inner join {table2} as t2 on t1.id = t2.id";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine($"{result[0]}|{result[1]}|{result[2]}|{result[3]}");
            }
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
        static void ReadById(NpgsqlConnection connection)
        {
            connection.Open();
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());
            string query = $"select * from users where user_id = {id}";
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

        static void Insert(string connectionString)
        {

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();

            string query = $"insert into users(user_name,user_Surname) values('{name}','{surname}');";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Inserted");

        }
        static void InsertMany(string connectionString)
        {

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Count of datas: ");
            int co = int.Parse(Console.ReadLine());
            string query = $"insert into users(user_name,user_surname) values";
            while (co > 0)
            {

                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter surname");
                string surname = Console.ReadLine();

                co--;
                query += $"({name},{surname}),";

            }
            query.Remove(query.Length - 1);
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Inserted");

        }
        static void UpdateByName(string connectionString)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();


            Console.WriteLine("Enter Old name");
            string oldName = Console.ReadLine();
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname");
            string surName = Console.ReadLine();

            string query = $"Update users set user_name = '{name}',user_surname='{surName}' where user_name = '{oldName}";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            var res = cmd.ExecuteNonQuery();

            Console.WriteLine("Updated");
            conn.Close();

        }
        static void UpdateTable(string connectionString)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Enter old table name");
            string Tablename = Console.ReadLine();

            Console.WriteLine("Enter new table name");
            string newTableName = Console.ReadLine();
            string query = $"alter table {Tablename} rename to {newTableName}";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated");
            connection.Close();

        }
        static void UpdateColumn(string connectionString)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Enter table name");
            string tableName = Console.ReadLine();
            Console.WriteLine("Enter old column name");
            string oldName = Console.ReadLine();
            Console.WriteLine("Enter new column name");
            string newName = Console.ReadLine();
            string query = $"alter table {tableName} rename column {oldName} to {newName}";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated");
            connection.Close();


        }
        static void GetLike(string connectionString)
        {

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Enter table name");
            string Tablename = Console.ReadLine();
            Console.WriteLine("Enter  Like");
            string like = Console.ReadLine();
            string qre = $"   query = $\"select * from users where user_name like '{like}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(qre, connection);
            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine($"{result[0]}|{result[1]}|{result[2]}|{result[3]}");
            }


            connection.Close();
        }
        static void AddColumn(string connectionString)
        {

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Enter table name");
            string tableName = Console.ReadLine();
            Console.WriteLine("Enter column name");
            string column = Console.ReadLine();
            string query = $"alter table {tableName} add column {column}";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

    }


}


