// See https://aka.ms/new-console-template for more information
using WebAPIClientCansole;

Console.WriteLine("API CLIENT:");
EmployeeAPIClient.UpdateEmployee(2).Wait();
Console.ReadLine();
