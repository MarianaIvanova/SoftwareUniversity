using System;
using Microsoft.Data.SqlClient;

namespace _1_ADO_NET_Y_Ex_1_Initial_Setup
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Task1
            //Create database
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=master"))
            {
                connection.Open();

                string createDatabase = "CREATE DATABASE MinionsDB";
                using (var command = new SqlCommand(createDatabase, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            //Create tables
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var createTables = GetCreateTablesStatement();
                foreach (var query in createTables)
                {
                    ExecuteNonQuery(connection, query);
                }
            }

            //insertData in tables
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var insertData = GetInsertDataStatement();
                foreach (var query in insertData)
                {
                    ExecuteNonQuery(connection, query);
                }
            }
        }
        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static string[] GetInsertDataStatement()
        {
            var result = new string[]
            {
                "INSERT Countries (Name) VALUES ('Bulgaria'),('France'),('Spain'),('Greece'),('UK')",
                "INSERT Towns (Name, CountryCode) VALUES ('Sofia',1),('Varna',1),('Madrid',3), ('Atina',4),('London',5)",
                "INSERT Minions (Name, Age, TownId) VALUES ('Gosho',18,1),('Pesho',25,2),('Ani',17,3), ('Stoyan',12,4), ('George',20,5) ",
                "INSERT EvilnessFactors (Name) VALUES ('super good'),('good'),('bad'),('evil'),('super evil')",
                "INSERT Villains (Name, EvilnessFactorId) VALUES ('Gru',1),('Tra',2),('Man',3),('Sto',4),('Eo',5)",
                "INSERT MinionsVillains (MinionId, VillainId) VALUES (1,1),(2,2),(3,3),(4,4),(5,5)"
            };

            return result;
        }
        private static string[] GetCreateTablesStatement()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50),CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50),	Age INT,TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillain PRIMARY KEY(MinionId,VillainId) )"
            };

            return result;
        }
    }
}
