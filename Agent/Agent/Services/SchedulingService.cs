using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Agent.Helpers;
using Agent.Models;
using Newtonsoft.Json;


namespace Agent.Service
{
    public class SchedulingService
    {
        private readonly ClientApi _client = new ClientApi();

        public SchedulingService(ClientApi client)
        {
            _client = client;
        }

        private async Task Run(int computerId)
        {
            while (true)
            {
                try
                {
                    await Verificar(computerId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro:  " + ex.Message);
                }
            }

        }

        private async Task Verificar(int computerId)
        {
            try
            {
                var itens = await GetComandos(computerId);

                if (itens.Count == 0)
                    return;

                foreach (var item in itens)
                {
                    try
                    {
                        await Task.Run(() => Execute(item));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro:  " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:  " + ex.Message);
            }
        }

        public async Task PostLogin()
        {
            try
            {
                var response = new HttpResponseMessage();
                Console.WriteLine("Acesse http://accessapi.regislimaprojects.site para se registrar e executar os comandos");
                do
                {
                    Console.WriteLine("Faça login:");
                    Console.Write("Username:");
                    string username = Console.ReadLine();
                    Console.Write("Senha:");
                    string password = Console.ReadLine();

                    var user = new User
                    {
                        Login = username,
                        Password = password
                    };
                    var content = JsonConvert.SerializeObject(user);
                    response = await _client.Login("users/login", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Usuário ou senha inválidos");
                    }
                } while (!response.IsSuccessStatusCode);
                int userId = int.Parse(response.Content.ReadAsStringAsync().Result);
                await RegisterComputer(userId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 

        private async Task RegisterComputer(int userId)
        {
            var disk = Execute("WMIC LOGICALDISK GET Name,Size | find /i \"C:\"").Replace(" ", "");
            var totalDisk = (long.Parse(disk.Substring(2)) / 1073741824) + " GB";
            var ram = Execute("wmic MEMORYCHIP get Capacity").Replace(" ", "");
            var totalRam = long.Parse(ram.Substring(8)) / 1073741824 + " GB";
            var computer = new Computer
            {
                Name = Execute("echo %computername%"),
                Ip = "1",
                OS = Execute("ver"),
                DiskSpace = totalDisk,
                MemoryInfo = totalRam,
                Username = Execute("echo %computername%"),
                UserId = userId
            };
            var content = JsonConvert.SerializeObject(computer);
            var response = await _client.Post("computers", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Erro ao cadastrar computador");
                Console.WriteLine(response);
            }
            int computerId = int.Parse(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("Trabalhando...");
            await Run(computerId);
        } 

        private async Task<List<Scheduling>> GetComandos(int computerId)
        {
            var response = await _client.Get("schedulings/" + computerId);

            if (!response.IsSuccessStatusCode)
                return null;

            var data = await response.Content.ReadAsStringAsync();
            if (data == null) return new List<Scheduling>();

            var list = JsonConvert.DeserializeObject<List<Scheduling>>(data);
            return JsonConvert.DeserializeObject<List<Scheduling>>(data);

        }

        private async Task<HttpResponseMessage> Atualizar(Scheduling item)
        {
            var client = new ClientApi();
            var content = JsonConvert.SerializeObject(item);

            return await client.Put($"schedulings/{item.Id}", content);
        }

        private string Execute(string comand)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = "cmd.exe";

                processo.StartInfo.Arguments = string.Format("/c {0}", comand);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                processo.WaitForExit();

                string result = processo.StandardOutput.ReadToEnd();

                return result.Replace("\r", "").Replace("\n", " ").Trim();
            }
        }

        private async Task Execute(Scheduling item)
        {
            if(item.SchedulingDate <= DateTime.Now)
            {
                using (Process processo = new Process())
                {
                    processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                    processo.StartInfo.Arguments = string.Format("/c {0}", item.Comand);

                    processo.StartInfo.RedirectStandardOutput = true;
                    processo.StartInfo.UseShellExecute = false;
                    processo.StartInfo.CreateNoWindow = true;

                    processo.Start();
                    processo.WaitForExit();

                    string result = processo.StandardOutput.ReadToEnd();

                    item.Response = result;
                    item.ExecutionDate = DateTime.Now;
                    await Atualizar(item);
                }
            }
        }
    }
}
