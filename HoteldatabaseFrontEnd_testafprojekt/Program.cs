using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HoteldatabaseFrontEnd_testafprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyNewGuest = new Guest()
            {
                Name = "Benjamin",
                Address = "her"
            }; 
            //
            //POST
            Console.WriteLine("Tester for post");
            Console.WriteLine();

            const string serverUrl = "http://hotelws.azurewebsites.net";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PostAsJsonAsync<Guest>("api/Values", MyNewGuest).Result;
                                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Du har indsat et nyt event");
                    Console.WriteLine("Post context: " + response.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine("Fejl, Eventet blev ikke oprettet!");
                    Console.WriteLine("Statuscode: " + response.StatusCode);
                }


            }


                catch (Exception e)
            {

                Console.WriteLine("Der er sket en fejl : " + e.Message);
            }
            Console.WriteLine();
            Console.WriteLine();

            }




            Console.ReadLine();
        }
    }
}
