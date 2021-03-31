using System;
using System.Linq;
using AdvancedQuerying_1_Lab_SoftUni.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

//NuGet package1: Microsoft.EntityFrameworkCore.SqlServer
//NuGet package2: Microsoft.EntityFrameworkCore.Design
//Z.EntityFramework.Plus.EFCore for this lecture - I use 5.1.28
//dotnet ef dbcontext scaffold "Server=.;Integrated Security=true;Database= SoftUni" Microsoft.EntityFrameworkCore.SqlServer -o Models 
namespace AdvancedQuerying_1_Lab_SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            //ALL DATA HERE IS IN AdvancedQuerying_1_Lab to follow the lecture, but as in this SoftUni DB is more appropriate for some of the exmples to be done - I test them here:
            //I. Executing Native SQL Queries
            var db = new SoftUniContext();
            //1. Not Select, no return data - only affected lines from create, update, delete..
            //If we have some Stored Procedure with parameters, which avoid SQL injection - we can use (for SoftUni DB is workin, as the procerude is created there)
            var employeeId = 1;//param
            var projectId = 1;//param
            db.Database.ExecuteSqlInterpolated($"EXEC sp_AddEmployeeToProjest {employeeId}, {projectId}");

            //III. Bulk Operations (Batch Delete and Batch Update) - install: Z.EntityFramework.Plus.EFCore
            //We can't delete tables which don't have a primary key
            var db2 = new SoftUniContext();
            db2.EmployeesProjects.Where(x => x.ProjectId < 3).Delete();//Thanks too Z.EntityFramework.Plus.EFCore and using Z.EntityFramework.Plus;
        }
    }
}
