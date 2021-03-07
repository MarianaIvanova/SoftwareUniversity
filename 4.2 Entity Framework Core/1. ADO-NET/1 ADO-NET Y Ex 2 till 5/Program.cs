using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _1_ADO_NET_Y_Ex_2_till_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task2 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                var getVillians = Task2GetVilliansNames();
                SqlCommand sqlCommand = new SqlCommand(getVillians, connection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader["Name"];//reader[0];
                        var count = reader["CountMinions"];//reader[1];
                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
            //Task3 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                int Id = int.Parse(Console.ReadLine());
                Task3Printresults(Id, connection);
            }
            //Task3 - Ex
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                int id = int.Parse(Console.ReadLine());
                string vilianNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
                using var command = new SqlCommand(vilianNameQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                var result = command.ExecuteScalar();

                string minionQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                if (result == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {result}");
                    using (var commandMinions = new SqlCommand(minionQuery, connection))
                    {
                        commandMinions.Parameters.AddWithValue("@Id", id);
                        using (var reader = commandMinions.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                            }
                        }
                    }
                }
            }
            //Task 4 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                string[] dataMinion = Console.ReadLine().Split(" ").ToArray();
                string minionName = dataMinion[1];
                int minionAge = int.Parse(dataMinion[2]);
                string townName = dataMinion[3];
                int townId = 0;

                string[] dataVilian = Console.ReadLine().Split(" ").ToArray();
                string vilianName = dataVilian[1];

                var resultVilianId = Task4VilianId(connection, vilianName);
                var resultMinionId = Task4MinionId(connection, minionName);
                var resultTownId = Task4TownId(connection, townName);

                if (resultTownId == null)
                {
                    Tasks4ExecuteNonQuery(connection, Tasks4InsertTown(townName));
                    //Tasks4InsertTown2(connection, townName);
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
                resultTownId = Task4TownId(connection, townName);
                townId = (int)resultTownId;

                if (resultVilianId == null)
                {
                    Tasks4ExecuteNonQuery(connection, Tasks4InsertVilian(vilianName));
                    Console.WriteLine($"Villain {vilianName} was added to the database.");
                }
                resultVilianId = Task4VilianId(connection, vilianName);

                if (resultMinionId == null)
                {
                    Tasks4ExecuteNonQuery(connection, Tasks4InsertMinion(minionName, minionAge, townId));
                }
                resultMinionId = Task4MinionId(connection, minionName);

                int villainId = (int)resultVilianId;
                int minionId = (int)resultMinionId;
                Tasks4ExecuteNonQuery(connection, Tasks4InsertMinionVilian(villainId, minionId));
                Console.WriteLine($"Successfully added {minionName} to be minion of {vilianName}.");
            }
            //Task5 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                string countryName = Console.ReadLine();

                var upperCaseQuery = @"UPDATE Towns
                                    SET Name = UPPER(Name)
                                    WHERE CountryCode = (SELECT Id FROM Countries WHERE Name = @countryName)";
                using var commandUpper = new SqlCommand(upperCaseQuery, connection);
                commandUpper.Parameters.AddWithValue("@countryName", countryName);
                commandUpper.ExecuteNonQuery();

                var countTownsQuery = @"SELECT COUNT(t.Id) AS CountTowns
	                                FROM Countries AS c
	                                JOIN Towns AS t ON c.Id = t.CountryCode
	                                WHERE c.Name = @countryName";
                using var commandCount = new SqlCommand(countTownsQuery, connection);
                commandCount.Parameters.AddWithValue("@countryName", countryName);
                int countTowns = (int)commandCount.ExecuteScalar();//int? is int + null
                if(countTowns == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Environment.Exit(0);
                }
                Console.WriteLine($"{countTowns} town names were affected.");

                var townsQuery = @"SELECT t.Name 
	                                FROM Countries AS c
	                                JOIN Towns AS t ON c.Id = t.CountryCode
	                                WHERE c.Name = @countryName";
                using var commandTowns = new SqlCommand(townsQuery, connection);
                commandTowns.Parameters.AddWithValue("@countryName", countryName);
                using (var allTownsReader = commandTowns.ExecuteReader())
                {
                    //Second method for solving this down is to add all the towns in a List<string> towns - see - task 7 
                    //and then print them Console.WriteLine($"[{string.Join(", ",towns)}]");
                    var firstRead = allTownsReader.Read();
                    if (firstRead == false)
                    {
                        Console.WriteLine("No town names were affected.");
                        Environment.Exit(0);
                    }

                    Console.Write("[");
                    Console.Write(allTownsReader[0]);
                    while (allTownsReader.Read())
                    {
                        Console.Write($", {allTownsReader[0]}");
                    }
                    Console.Write("]");
                }
            }
        }

        private static string Task2GetVilliansNames()
        {
            var queryTask2 =
                    @"SELECT v.Name, COUNT(mv.MinionId) AS CountMinions
                    FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                    GROUP BY v.Id, v.Name HAVING COUNT(mv.MinionId) > 3";
            return queryTask2;
        }
        private static string Task3GetMinionsAge(int Id)
        {
            string querytask3 =
                "SELECT v.Id, v.Name as VilianName, m.Name as MinionName, m.Age, " +
                    "DENSE_RANK() OVER(PARTITION BY v.Id ORDER BY m.Name)  AS DENSE_RANK_Vilians " +
                    "FROM Villains AS v " +
                    "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                    "LEFT JOIN Minions AS m ON mv.MinionId = m.Id " +
                    "WHERE v.Id = " + Id;
            return querytask3;
        }
        private static void Task3Printresults(int Id, SqlConnection connection)
        {
            var currentVilionMinionsAge = Task3GetMinionsAge(Id);
            SqlCommand command = new SqlCommand(currentVilionMinionsAge, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                var currentRead = reader.Read();//to check if a vilian with this Id doesn't exist
                if (currentRead == false)
                {
                    Console.WriteLine($"No villain with ID {Id} exists in the database.");
                    Environment.Exit(0);
                }

                while (currentRead == true)
                {
                    var vilianId = reader["Id"];
                    var vilianName = reader["VilianName"];
                    if (reader.IsDBNull(3))//If there are no minions for this vilian
                    {
                        Console.WriteLine($"Villain: {vilianName}");
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        var minionName = reader["MinionName"];
                        var minionAge = reader["Age"];
                        var rankMinions = (Int64)reader["DENSE_RANK_Vilians"];

                        if (rankMinions == 1)
                        {
                            Console.WriteLine($"Villain: {vilianName}");
                            Console.WriteLine($"{rankMinions}. {minionName} {minionAge}");
                        }
                        else
                        {
                            Console.WriteLine($"{rankMinions}. {minionName} {minionAge}");
                        }
                    }
                    currentRead = reader.Read();
                }
            }
        }
        private static object Task4VilianId(SqlConnection connection, string vilianName)
        {
            var vilianQuery = @"SELECT Id FROM Villains WHERE Name = @vilianName";
            using var commandVlilan = new SqlCommand(vilianQuery, connection);
            commandVlilan.Parameters.AddWithValue("@vilianName", vilianName);
            return commandVlilan.ExecuteScalar();//We can make it to be int or null like this:
            //return (int?)commandVlilan.ExecuteScalar(); So there will be no need to cast it later after checking for null
        }
        private static object Task4MinionId(SqlConnection connection, string minionName)
        {
            var minionQuery = @"SELECT Id FROM Minions WHERE Name = @minionName";
            using var commandMinion = new SqlCommand(minionQuery, connection);
            commandMinion.Parameters.AddWithValue("@minionName", minionName);
            return commandMinion.ExecuteScalar();//We can make it to be int or null like this:
            //return (int?)commandVlilan.ExecuteScalar(); So there will be no need to cast it later after checking for null
        }
        private static object Task4TownId(SqlConnection connection, string townName)
        {
            var townQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
            using var commandTown = new SqlCommand(townQuery, connection);
            commandTown.Parameters.AddWithValue("@townName", townName);
            return commandTown.ExecuteScalar();//We can make it to be int or null like this:
            //return (int?)commandVlilan.ExecuteScalar(); So there will be no need to cast it later after checking for null
        }
        private static void Tasks4ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                var result = command.ExecuteNonQuery();
            }
        }
        private static string Tasks4InsertTown(string townName)
        {
            string query = @"INSERT INTO Towns (Name, CountryCode) VALUES ('" + townName + "', 1)";
            return query;//ExecuteNonQuery can be done here by using command and parameters - see below - made like this from the teacher
        }
        //private static void Tasks4InsertTown2(SqlConnection connection, string townName)
        //{
        //    string query = @"INSERT INTO Towns (Name, CountryCode) VALUES (@townName, 1)";
        //    var command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@townName", townName);
        //    command.ExecuteNonQuery();
        //}
        private static string Tasks4InsertVilian(string vilianName)
        {
            string query = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES ('" + vilianName + "', 4)";
            return query;
        }
        private static string Tasks4InsertMinion(string minionName, int minionAge, int townId)
        {
            string query = @"INSERT INTO Minions (Name, Age, TownId) VALUES ('" + minionName + "'," + minionAge + "," + townId + ")";
            return query;
        }
        private static string Tasks4InsertMinionVilian(int villainId, int minionId)
        {
            string query = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (" + minionId + "," + villainId + ")";
            return query;
        }
    }
}
