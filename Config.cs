using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace launcher
{

    class Config
    {
#pragma warning disable 649
        public string XelAddress;
        public string WorkerName;
        public int Location;
        public int Threads;
        public int Extension;
#pragma warning restore 649

        public static Config ConfigData;

        static Config()
        {
            // Set defaults
            ConfigData = new Config();
            ConfigData.WorkerName = "Your wallet address ";
            ConfigData.Location = 0;
            ConfigData.Threads = Environment.ProcessorCount;
            ConfigData.Extension = 0;

            try { ConfigData = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json")); }
            catch { }
        }

        public static void Commit()
        {
            try { File.WriteAllText("config.json", JsonConvert.SerializeObject(ConfigData)); }
            catch { }
        }
    }

}
