using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTrainingTKS.ConsoleApp.HttpClientExamples
{
    public class HttpClientExaple
    {
        public async Task Run()
        {
            await Read();
        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7138/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr=await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
    }
}
