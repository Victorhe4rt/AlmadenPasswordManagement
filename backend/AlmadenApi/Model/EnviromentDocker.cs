using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmadenApi.Model
{
   public class EnviromentDocker
    {
        public string? DATABASE_HOST { get; set; }
        public string? DATABASE_PORT { get; set; }
        public string? DATABASE_USER { get; set; }
        public string? DATABASE_PASSWORD { get; set; }
        public string? DATABASE_NAME { get; set; }


        public EnviromentDocker()
        {
            DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
            DATABASE_PORT = Environment.GetEnvironmentVariable("DATABASE_HOST");
            DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
            DATABASE_PASSWORD = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");

            
        }

        public void showAllEnvariment(){
            StringBuilder envariments = new StringBuilder();
            envariments.AppendLine("All EnviromentDocker In Docker:");
            envariments.AppendLine($"DATABASE_HOST: {DATABASE_HOST}");
            envariments.AppendLine($"DATABASE_PASSWORD: {DATABASE_PASSWORD}");
            envariments.AppendLine($"DATABASE_NAME: {DATABASE_NAME}");
   

            System.Console.WriteLine(envariments);
        }
    }
}



 