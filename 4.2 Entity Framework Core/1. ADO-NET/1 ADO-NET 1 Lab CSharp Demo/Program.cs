using System;
using _1_ADO_NET_1_Lab_CSharp_Demo_MyClasses;
//using Belot.Engine;
using Microsoft.Data.SqlClient;

namespace _1_ADO_NET_1_Lab_CSharp_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var classTest = new Class1(); // we can use Class1.cs in 1 ADO-NET 1 Lab CSharp Demo MyClasses only if we create depedency/referency, cause it is in other library or project //using Belot.Engine;
            //var belotGame = new BelotGame()
            //var connection = new SqlConnection("");//using Microsoft.Data.SqlClient;
            //connection.Open();
            ////var query = new SqlCommand("SELECT COUNT(*) FROM Employees");
            //connection.Close();
            //select * from sys.databases - it gives info for all databases we have.

            //I. Connecting

            //I.1 Connecting with user name and password
            string connectionString = "Server=.;User Id =Nik;Password=123456;Database=SoftUni";
            //1. Server we want to connect. 
            //On my computer can be: 
            //Server=. -- if we work with SQL EXPRESS, then Server=.\\SQLEXPRESS
            //Server=localhost
            //Server=127.0.0.1
            //Server=DESKTOP-C52TEPF
            //On other computer:
            // IP: 192.168.100.5
            // Domain: nikidb.us-west.db.azure.microsoft.com
            //2. User Id - identify ourselves
            //User Id =Nik
            //3. Password - give the password
            //Password=123456

            //I.2 Connecting with Windows Authentification -- we don't have a user, but directly connect
            string connectionString2 = "Server=.;Integrated Security=true;Database=SoftUni";

            var connection = new SqlConnection(connectionString2); //this an instance of the object only
            connection.Open(); //This is the way to open the connection, using the method Open().

            connection.Close();//We should close the connection after we have done everthing we needed.

            //IT IS BETTER to write Using()
            using (var connection3 = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection3.Open();
            }

            //II. Commands 
            //II.1 ExecuteScalar();
            using (var connection4 = new SqlConnection(
                 "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection4.Open();
                string query = "SELECT COUNT(*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(query, connection4);
                var result = sqlCommand.ExecuteScalar();// Returns an object - the data in the first column of the first row of the result set 
                //int result = (int)sqlCommand.ExecuteScalar(); //if we want int -> should convert it to int
                Console.WriteLine(result);//271
            }

            //II.2 sqlCommand.ExecuteNonQuery();
            using (var connection5 = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection5.Open();
                string query = "UPDATE Employees SET Salary = Salary + 0.12 WHERE FirstName LIKE 'N%'";
                SqlCommand sqlCommand = new SqlCommand(query, connection5);
                var rowsAffected = sqlCommand.ExecuteNonQuery(); //Used for non-query SQL commands, e.g. INSERT, UPDATE, DELETE, CREATE. Returns the number of affected rows (int)
                Console.WriteLine(rowsAffected);//4
            }

            //II.3 sqlCommand.ExecuteReader();
            using (var connection6 = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection6.Open();
                string query = "SELECT d.Name, COUNT(*) as CountEmployees " +
                                "FROM Employees AS e " +
                                "JOIN Departments AS d ON e.DepartmentId = d.DepartmentId " +
                                "GROUP BY d.Name";
                SqlCommand sqlCommand = new SqlCommand(query, connection6);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()) //Returns a SqlDataReader - all data from the query 
                    while (sqlDataReader.Read() == true)
                    {
                        string nameStr = (string)sqlDataReader["Name"];//we should define it, as the reader returns object
                        int count = (int)sqlDataReader["CountEmployees"];//we should define it, as the reader returns object
                        int? count2 = sqlDataReader["CountEmployees"] as int?;//we should define it, as the reader returns object -- when we add ? to the type - it can be NULL too.
                        Console.WriteLine(sqlDataReader["Name"] + " => " + sqlDataReader["CountEmployees"]);
                    }
                //Document Control => 5
                //Engineering => 6
                //Executive => 2
                //Facilities and Maintenance => 7
                //Finance => 10
                //Human Resources => 6
                //Information Services => 10
                //Marketing => 8
                //Production => 179
                //Production Control => 6
                //Purchasing => 12
                //Quality Assurance => 7
                //Research and Development => 7
                //Shipping and Receiving => 6
            }

            //III. SQL Injection
            Console.Write("Please enter username: ");
            var username = Console.ReadLine();
            Console.Write("Please enter password: ");
            var password = Console.ReadLine();

            using (var connection7 = new SqlConnection(
                "Server=.;Integrated Security=true;Database=Design"))
            {
                connection7.Open();
                var query = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";//if nstead of standart username {username}, user writes: ' OR 1=1--  result will always be Access granted! Welcome!, cause it breaks our code. Or we use valud user name UnderSinduxrein + '-- (which will ignore the password). THIS is SQL injection!!!
                SqlCommand sqlCommand = new SqlCommand(query, connection7);//The most important here is that we have info which should come from the user with a variable (@"")
                int usersCount = (int)sqlCommand.ExecuteScalar();
                if(usersCount > 0)
                {
                    Console.WriteLine("Access granted! Welcome!");
                }
                else
                {
                    Console.WriteLine("Access denied.");
                }
            }

            //IV. Preventing SQL Injection
            //We should always use parameters as below.
            //Entity Framework clean this automatically, but here should do as below!

            Console.Write("Please enter username: ");
            var username1 = Console.ReadLine();
            Console.Write("Please enter password: ");
            var password1 = Console.ReadLine();

            using (var connection7 = new SqlConnection(
                "Server=.;Integrated Security=true;Database=Design"))
            {
                connection7.Open();
                var query = $"SELECT COUNT(*) FROM Users WHERE Username = '@username' AND Password = '@password'";
                SqlCommand sqlCommand = new SqlCommand(query, connection7);//The most important here is that we have info which should come from the user with a variable (@"")
                sqlCommand.Parameters.Add(new SqlParameter("@username", username1));//this one cleans all symbols from the console entered info which can break the code: '@--,... and others
                //sqlCommand.Parameters.AddWithValue(new SqlParameter("@username", username1)); - we can use this too
                sqlCommand.Parameters.Add(new SqlParameter("@password", password1));//this one cleans all symbols from the console entered info which can break the code: '@--,... and others
                //sqlCommand.Parameters.AddWithValue(new SqlParameter("@password", password1)); - we can use this too

                int usersCount = (int)sqlCommand.ExecuteScalar();
                if (usersCount > 0)
                {
                    Console.WriteLine("Access granted! Welcome!");
                }
                else
                {
                    Console.WriteLine("Access denied.");
                }
            }
        }
    }
}
