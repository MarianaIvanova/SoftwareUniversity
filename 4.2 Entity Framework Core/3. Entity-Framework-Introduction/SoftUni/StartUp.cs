using System;
using SoftUni.Data;
using SoftUni.Models;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
//This project is made only for apploding the tasks in Judge - one by one. See 3 EntityFrameworkIntroduction Y Ex 1 till 15 for all tasks

//Should insall for every project- but it doesn't work for Judge:
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design
//dotnet ef dbcontext scaffold "Server=.;Integrated Security=true;Database= SoftUni" Microsoft.EntityFrameworkCore.SqlServer -o Models
//This below doesn't work for me, so I need to use NugetPackage for install and uninstall and this above but for the versions below

//For Judge in Tools\NuGet Package Manager\Package Manager Console run one by one this four lines: 3 for installing packages and the last one for connecting with the base:
//Install - Package Microsoft.EntityFrameworkCore.Tools –v 3.1.3
//Install - Package Microsoft.EntityFrameworkCore.SqlServer –v 3.1.3
//Install - Package Microsoft.EntityFrameworkCore.SqlServer.Design
//Scaffold-DbContext -Connection "Server=.;Database=SoftUni;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models
//Uninstall - Package Microsoft.EntityFrameworkCore.Tools - r
//Uninstall - Package Microsoft.EntityFrameworkCore.SqlServer.Design - RemoveDependencies


namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            //Task3: 
            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Task4: 
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Task5: 
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Task6: 
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //Task7: 
            //Console.WriteLine(GetEmployeesInPeriod(context));

            //Task8: 
            //Console.WriteLine(GetAddressesByTown(context));

            //Task9: 
            //Console.WriteLine(GetEmployee147(context));

            //Task10: 
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //Task11: 
            //Console.WriteLine(GetLatestProjects(context));

            //Task12: 
            //Console.WriteLine(IncreaseSalaries(context));

            //Task13: 
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //Task14: 
            //Console.WriteLine(DeleteProjectById(context));

            //Task15: 
            Console.WriteLine(RemoveTown(context));
        }
        //Task3: 
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var allEmpployees = context.Employees.Select(x => new
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                JobTitle = x.JobTitle,
                Salary = x.Salary
            }).OrderBy(a => a.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in allEmpployees)
            {
                sb.Append(employee.FirstName + " ");
                sb.Append(employee.LastName + " ");
                sb.Append(employee.MiddleName + " ");
                sb.Append(employee.JobTitle + " ");
                sb.Append($"{employee.Salary:F2}");
                sb.AppendLine();
            };

            string allData = sb.ToString().Trim();
            return allData;
        }
        //Task4: 
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var allEmpployees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                Salary = x.Salary
            }).Where(x => x.Salary > 50000)
                .OrderBy(a => a.FirstName).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in allEmpployees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            };

            string allData = sb.ToString().Trim();
            return allData;
        }
        //Task5: 
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var allEmpployees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                DepartmentName = x.Department.Name,
                Salary = x.Salary
            }).Where(b => b.DepartmentName == "Research and Development")
                .OrderBy(a => a.Salary).ThenByDescending(a => a.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in allEmpployees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            };

            return sb.ToString().TrimEnd();
        }
        //Task6: 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            //var address = new Address
            //{
            //    AddressText = "Vitoshka 15",
            //    TownId = 4,
            //};
            //context.Addresses.Add(address);
            //context.SaveChanges();

            Employee empployeeNakov = context.Employees.FirstOrDefault(b => b.LastName == "Nakov");
            //empployeeNakov.AddressId = address.AddressId;
            empployeeNakov.Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };
            context.SaveChanges();

            var empployeesAddresses = context.Employees.Select(x => new
            {
                AddressId = x.Address.AddressId,
                AddressText = x.Address.AddressText,
            })
                .OrderByDescending(a => a.AddressId).Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in empployeesAddresses)
            {
                sb.AppendLine($"{employee.AddressText}");
            };

            return sb.ToString().TrimEnd();
        }
        //Task7 : 
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            //Microsoft.EntityFrameworkCore 3.1.3 added and using Microsoft.EntityFrameworkCore too for INCLUDE to work
            var empployees =
            context.Employees
            .Include(x => x.EmployeesProjects)
            .ThenInclude(x => x.Project)
            .Where(x => x.EmployeesProjects.Any(a => a.Project.StartDate.Year >= 2001 
                                                    && a.Project.StartDate.Year < 2004))
            .Select(x => new
            {
                EmployeeFirstName = x.FirstName,
                EmployeeLastName = x.LastName,
                ManagerFirstName = x.Manager.FirstName,
                ManagerLastName = x.Manager.LastName,
                ProjectsCurrentEmployee = x.EmployeesProjects.Select(p => new
                                {
                                    ProjectName = p.Project.Name,
                                    StartDate = p.Project.StartDate,
                                    EndDate = p.Project.EndDate
                                })               
                                    .ToList(),
            })
            .Take(10)
            .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in empployees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.ProjectsCurrentEmployee)
                {
                    //if (project.EndDate == null)
                    //{
                    //    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - not finished");
                    //}
                    //else
                    //{
                    //    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                    //}

                    //Shorter one:
                    var endDate = project.EndDate.HasValue//If EndDate has value 
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) //Then - print this value as string + using System.Globalization;
                        : "not finished";//Else - print "not finished"
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }
                
            return sb.ToString().TrimEnd();
        }
        //Task8: 
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses.Select(a => new
            {
                AddressText = a.AddressText,
                TownName = a.Town.Name,
                countEmployees = a.Employees.Count
            }).OrderByDescending(a => a.countEmployees)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.countEmployees} employees");
            };

            return sb.ToString().TrimEnd();
        }
        //Task9: 
        public static string GetEmployee147(SoftUniContext context)
        {
            ////1. Solution for ordering EmployeesProjects - to name all classes, don't leave them anonymus:
            //var employee147 = context.Employees
            //    .Select(a => new Employee//For OrderBy for Projects we should have not anonymus classes:
            //    {
            //        EmployeeId = a.EmployeeId,
            //        FirstName = a.FirstName,
            //        LastName = a.LastName,
            //        JobTitle = a.JobTitle,
            //        EmployeesProjects = a.EmployeesProjects.Select(b => new EmployeeProject
            //        {
            //            Project = b.Project,
            //        })
            //        .OrderBy(a => a.Project.Name)
            //        .ToList()
            //    })
            //    .FirstOrDefault(c => c.EmployeeId == 147);

            ////2. Solution for ordering EmployeesProjects - to make order by before select for EmployeesProjects
            //var employee147 = context.Employees
            //    .Select(a => new
            //    {
            //        EmployeeId = a.EmployeeId,
            //        FirstName = a.FirstName,
            //        LastName = a.LastName,
            //        JobTitle = a.JobTitle,
            //        EmployeesProjects = a.EmployeesProjects.OrderBy(a => a.Project.Name).Select(b => new
            //        {
            //            Project = b.Project,
            //        })
            //        .ToList()
            //    })
            //    .FirstOrDefault(c => c.EmployeeId == 147);

            ////3. Solution for ordering EmployeesProjects - to make order by after select for EmployeesProjects but don't miss .ToList(), otherwise it will not work.
            //var employee147 = context.Employees
            //    .Select(a => new
            //    {
            //        EmployeeId = a.EmployeeId,
            //        FirstName = a.FirstName,
            //        LastName = a.LastName,
            //        JobTitle = a.JobTitle,
            //        EmployeesProjects = a.EmployeesProjects.Select(b => new
            //        {
            //            Project = b.Project,
            //        })
            //        .OrderBy(a => a.Project.Name)
            //        .ToList()
            //    })
            //    .FirstOrDefault(c => c.EmployeeId == 147);

            //4. Solution for ordering EmployeesProjects - initializing before select
            var employee147 = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .ToList()
                .Select(a => new
                {
                    EmployeeId = a.EmployeeId,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    JobTitle = a.JobTitle,
                    EmployeesProjects = a.EmployeesProjects.Select(b => new
                    {
                        Project = b.Project,
                    })
                    .OrderBy(a => a.Project.Name)
                    .ToList()
                })
                .FirstOrDefault(c => c.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var project in employee147.EmployeesProjects)
            {
                sb.AppendLine($"{project.Project.Name}");
            };

            return sb.ToString().TrimEnd();
        }
        //Task10: 
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments5 = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(a => new
                {
                    DepartmentName = a.Name,
                    ManagerFirstName = a.Manager.FirstName,
                    ManagerLastName = a.Manager.LastName,
                    DepartmentEmployees = a.Employees.Select(b => new
                    {
                        EmployeeFirstName = b.FirstName,
                        EmployeeLastName = b.LastName,
                        EmployeeJobTitle = b.JobTitle,
                    })
                    .OrderBy(x => x.EmployeeFirstName)
                    .ThenBy(x => x.EmployeeLastName)
                    .ToList(),
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments5)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.DepartmentEmployees)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            };

            return sb.ToString().TrimEnd();
        }
        //Task11: 
        public static string GetLatestProjects(SoftUniContext context)
        {
            var last10Projects = context.Projects
                .OrderBy(x => x.StartDate)
                .ToList()
                .TakeLast(10)
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var proj in last10Projects)
            {
                sb.AppendLine($"{proj.Name}");
                sb.AppendLine($"{proj.Description}");
                sb.AppendLine($"{proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            };

            return sb.ToString().TrimEnd();
        }
        //Task12: 
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesDept = context.Employees
                //.Where(x => x.Department.Name == "Engineering"
                //            || x.Department.Name == "Tool Design"
                //            || x.Department.Name == "Marketing"
                //            || x.Department.Name == "Information Services")
                .Where(x => departments.Contains(x.Department.Name))//If we create a new class here with only FirstName, LastName and Salary, it will not affect the DB. Be carefull!
                .ToList();

            foreach (var employee in employeesDept)
            {
                employee.Salary = employee.Salary * 1.12M;
            }

            context.SaveChanges();//TO SAVE in the DB

            employeesDept = employeesDept
                                .OrderBy(x => x.FirstName)
                                .ThenBy(x => x.LastName)
                                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in employeesDept)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:F2})");
            };

            return sb.ToString().TrimEnd();
        }
        //Task13: 
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesWithSa = context.Employees
                //.Where(x => x.FirstName.StartsWith("Sa"))//It works in Judge with this too
                //.Where(x => x.FirstName.StartsWith("Sa", true, CultureInfo.InvariantCulture))//this one is to be caps lock insensitive but for higher versions
                .Where(x => EF.Functions.Like(x.FirstName, "Sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in employeesWithSa)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary:F2})");
            };

            return sb.ToString().TrimEnd();
        }

        //Task14: 
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectWithEmployee = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            if(projectWithEmployee != null)
            {
                foreach (var line in projectWithEmployee)
                {
                    context.EmployeesProjects.Remove(line);
                }
            }

            context.SaveChanges();

            var project = context.Projects
               .FirstOrDefault(x => x.ProjectId == 2);

            context.Projects.Remove(project);
            context.SaveChanges();

            var projects10 = context.Projects.Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var proj in projects10)
            {
                sb.AppendLine($"{proj.Name}");
            };

            return sb.ToString().TrimEnd();
        }
        //Task15: 
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            //Mine - works too in Judge:
            //var addresses = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();
            //var allAddressesIds = addresses.Select(x => x.AddressId).ToList();
            //var employees = context.Employees
            //    .Where(x => x.Address.Town.Name == "Seattle")
            //    .ToList();

            //Ex:
            if (town == null)
            {
                Environment.Exit(0);
            }
            var allAddressesIds = town.Addresses.Select(x => x.AddressId).ToList();
            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && allAddressesIds.Contains(x.AddressId.Value)) //We use .Value here for the null values - for the code to work, but we should avoid null, so we should check that x.AddressId.HasValue!!!
                .ToList();
            if(employees != null)
            {
                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
            }
            context.SaveChanges();

            if(allAddressesIds != null)
            {
                foreach (var addressId in allAddressesIds)
                {
                    var currentAddress = context.Addresses.FirstOrDefault(x => x.AddressId == addressId);
                    context.Addresses.Remove(currentAddress);
                }
            }

            context.Towns.Remove(town); 

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            int count = allAddressesIds.Count;
            sb.AppendLine($"{count} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }
    }
}
