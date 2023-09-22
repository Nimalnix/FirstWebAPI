using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebAPIClientCansole
{


    internal class EmployeeAPIClient

    {

        static Uri uri = new Uri("http://localhost:5096/");

        public static async Task CallGetAllEmployee()

        {

            using (var client = new HttpClient())

            {

                client.BaseAddress = uri;

                HttpResponseMessage response = await client.GetAsync("GetAllEmployeespp");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)

                {

                    string x = await response.Content.ReadAsStringAsync();

                    await Console.Out.WriteLineAsync(x);

                }

            }
        }
            public static async Task jasonCallGetAllEmployee()

            {

                using (var client = new HttpClient())

                {

                    client.BaseAddress = uri;
                    List<EmpViewModel> employees = new List<EmpViewModel>();
                    client.DefaultRequestHeaders
                        .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HttpGet
                    HttpResponseMessage response = await client.GetAsync("GetAllEmployeespp");


                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)

                    {

                        string json = await response.Content.ReadAsStringAsync();
                        employees = JasonConvert.DeserializeOject<List<EmpViewModel>>(jason);
                        foreach (EmpViewModel emp in employees)
                        {
                            await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName}");

                        }

                    }

                }

            }
        }
    }

