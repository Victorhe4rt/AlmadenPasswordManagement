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
        public string? DATABASE_NAME2 { get; set; }
        public string? EMAIL_SMTP_HOST { get; set; }
        public string? EMAIL_SMTP_TIMEOUT { get; set; }
        public string? EMAIL_SMTP_PORT { get; set; }

        public EnviromentDocker()
        {
            DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
            DATABASE_PORT = Environment.GetEnvironmentVariable("DATABASE_HOST");
            DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
            DATABASE_PASSWORD = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");
            DATABASE_NAME2 = Environment.GetEnvironmentVariable("DATABASE_NAME2");
            EMAIL_SMTP_HOST = Environment.GetEnvironmentVariable("EMAIL_SMTP_HOST");
            EMAIL_SMTP_TIMEOUT = Environment.GetEnvironmentVariable("EMAIL_SMTP_TIMEOUT");
            EMAIL_SMTP_PORT = Environment.GetEnvironmentVariable("EMAIL_SMTP_PORT");
            
        }

        public void showAllEnvariment(){
            StringBuilder envariments = new StringBuilder();
            envariments.AppendLine("All Envariments In Docker:");
            envariments.AppendLine($"DATABASE_HOST: {DATABASE_HOST}");
            envariments.AppendLine($"DATABASE_PASSWORD: {DATABASE_PASSWORD}");
            envariments.AppendLine($"DATABASE_NAME: {DATABASE_NAME}");
            envariments.AppendLine($"DATABASE_NAME2: {DATABASE_NAME2}");
            envariments.AppendLine($"EMAIL_SMTP_CLIENT: {EMAIL_SMTP_HOST}");
            envariments.AppendLine($"EMAIL_SMTP_TIMEOUT: {EMAIL_SMTP_TIMEOUT}");
            envariments.AppendLine($"EMAIL_SMTP_PORT: {EMAIL_SMTP_PORT}");

            System.Console.WriteLine(envariments);
        }
    }
}



 