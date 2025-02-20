﻿using Microsoft.Extensions.Configuration;

namespace AutoLend.Data {
    public static class Configuration {
        private static IConfiguration _configuration = null!;

        public static void SetConfiguration( IConfiguration configuration ) {
            _configuration = configuration;
        }
        public static string ConnectionString => _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");

    }
}
