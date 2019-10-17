using Agent.Helpers;
using Agent.Service;
using System;
using System.Threading.Tasks;

namespace Agent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ClientApi();

            var service = new SchedulingService(client);

            try
            {
                await service.PostLogin();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                Console.ReadLine();
            }

        }
    }
}
