using Agent.Helpers;
using Agent.Service;
using System.Threading.Tasks;

namespace Agent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ClientApi();

            var service = new SchedulingService(client);

            await service.PostLogin();
        }
    }
}
