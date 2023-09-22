// See https://aka.ms/new-console-template for more information
using WebAPIClientCansole;

Console.WriteLine("API CLIENT:");
EmployeeAPIClient.CallGetAllEmployee().Wait();
Console.ReadLine();
