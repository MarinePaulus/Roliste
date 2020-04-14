using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord
{
    class ConfigHandler
    {
        private Config conf;
        private string confPath, line;

        struct Config
        {
            public string token;
        }

        public ConfigHandler()
        {
            conf = new Config()
            {
                token = token;
            };
        }

        public async Task PopulateConfig()
        {
            confPath = Path.Combine(Directory.GetCurrentDirectory(), "config.json").Replace(@"\", @"\\");
            Console.WriteLine(confPath);

            if (!File.Exists(confPath))
            {
                using (var f = File.Create(confPath))
                {
                    DirectoryInfo dInfo = new DirectoryInfo(confPath);
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();
                    dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                    dInfo.SetAccessControl(dSecurity);
                }
                using (StreamWriter sw = File.AppendText(confPath))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(conf));
                }
                Console.WriteLine("WARNING! New Config initialized! Need to fill in values before running commands!");
                throw new Exception("NO CONFIG AVAILABLE! Go to executable path and fill out newly created file!");
            }
            
            using (StreamReader reader = new StreamReader(confPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    conf = JsonConvert.DeserializeObject<Config>(line);
                }
            }

            await Task.CompletedTask;
        }

        public string GetToken()
        {
            return conf.token;
        }
    }
}
