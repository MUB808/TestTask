﻿namespace ProductManagementAPI.Models
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int? Expiration { get; set; } 
    }
}
