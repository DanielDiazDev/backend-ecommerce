﻿namespace EcommerceProject.Data.Configurations;

public class DatabaseConfig
{
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool TrustedConnection { get; set; }
        public bool TrustServerCertificate { get; set; }
}