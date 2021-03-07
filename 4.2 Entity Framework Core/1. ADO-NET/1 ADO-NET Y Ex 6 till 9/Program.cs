using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _1_ADO_NET_Y_Ex_6_till_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task6 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                int vilianID = int.Parse(Console.ReadLine());

                string vilianName = Task6GetVilianName(connection, vilianID);
                int CountMinions = Task6GetCountMinions(connection, vilianID);
                Task6DeleteMinions(connection, vilianID);
                Task6DeleteVilion(connection, vilianID);
                Console.WriteLine($"{vilianName} was deleted.");
                Console.WriteLine($"{CountMinions} minions were released.");
            }

            //Task7 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var query = @"SELECT Name FROM Minions";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                List<string> allMinions = new List<string>();
                while (reader.Read())//It should be minions in the table
                {
                    string currentMinionName = (string)reader["Name"];
                    allMinions.Add(currentMinionName);
                }

                int n = allMinions.Count;
                for (int i = 0; i <= n / 2 - 1; i++)
                {
                    Console.WriteLine(allMinions[i]);
                    Console.WriteLine(allMinions[n - i - 1]);
                }

                if (n % 2 == 1)
                {
                    Console.WriteLine(allMinions[n / 2]);
                }
            }

            //Task8 - Mine
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                List<int> minionsForChange = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

                for (int i = 0; i < minionsForChange.Count; i++)
                {
                    int Id = minionsForChange[i];
                    var query = @"UPDATE Minions
                         SET Age = Age + 1, [Name] = CONCAT(UPPER(LEFT([Name],1)),RIGHT([Name], LEN([Name])-1))
                        WHERE Id = @Id";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();

                    var selectMinions = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                    var command2 = new SqlCommand(selectMinions, connection);
                    command2.Parameters.AddWithValue("@Id", Id);
                    using var reader = command2.ExecuteReader();
                    reader.Read();
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }

            //Task9 
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();
                int Id = int.Parse(Console.ReadLine());

                var query = @"EXEC usp_GetOlder @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();

                var selectMinions = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                using var commandSelect = new SqlCommand(selectMinions, connection);
                commandSelect.Parameters.AddWithValue("@Id", Id);
                using var reader = commandSelect.ExecuteReader();
                reader.Read();
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }
        private static string Task6GetVilianName(SqlConnection connection, int vilianID)
        {
            var query = @"SELECT Name FROM Villains WHERE Id = @villainId";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", vilianID);
            string vilianName = (string)command.ExecuteScalar();
            if (vilianName == null)
            {
                Console.WriteLine("No such villain was found.");
                Environment.Exit(0);
            }

            return vilianName;
        }
        private static int Task6GetCountMinions(SqlConnection connection, int vilianID)
        {
            var query = @"SELECT COUNT(mv.MinionId) AS CountMinions
	                                FROM Villains AS v
	                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
	                                WHERE Id = @villainId";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", vilianID);
            int CountMinions = (int)command.ExecuteScalar();
            return CountMinions;
        }
        private static void Task6DeleteMinions(SqlConnection connection, int vilianID)
        {
            var query = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", vilianID);
            var result = command.ExecuteNonQuery();
        }
        private static void Task6DeleteVilion(SqlConnection connection, int vilianID)
        {
            var query = @"DELETE FROM Villains WHERE Id = @villainId";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", vilianID);
            var result = command.ExecuteNonQuery();
        }
    }
}
